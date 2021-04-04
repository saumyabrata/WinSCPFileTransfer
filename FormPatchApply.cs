using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using WinSCPFileTransfer.Global;
using WinSCP;

namespace WinSCPFileTransfer
{
    public partial class FormPatchApply : Form
    {
        string categorylist = "";
        string locationlist = "";
        string poslist = "";
        const string KnownHostsFile = "KnownHosts.xml";
        const int SshPortNumber = 22;
        public FormPatchApply()
        {
            InitializeComponent();
            dgvFiles.Columns[1].Name = "Check";
            dgvFiles.Columns[1].Name = "File Name";
            dgvFiles.Columns[2].Name = "Location";
        }

        private void btnSelectMultiple_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    string[] row1 = new string[] { "true",Path.GetFileName(file), file, file };
                    dgvFiles.Rows.Add(row1);
                }
            }
        }

        private void FormPatchApply_Load(object sender, EventArgs e)
        {
            string sql = "SELECT location_id,location FROM dbo.location";
            DataTable dt = Dbconnection.GetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLocation.DataSource = dt;
                ListLocation.DisplayMember = "location";
                ListLocation.ValueMember = "location_id";
            }

            string sqlc = "SELECT category_id,category FROM dbo.category";
            DataTable dtc = Dbconnection.GetDataTable(sqlc);
            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                ListCategory.DataSource = dtc;
                ListCategory.DisplayMember = "category";
                ListCategory.ValueMember = "category_id";
            }
        }

        private void checkLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLocation.Checked == true)
            {
                for (int i = 0; i < ListLocation.Items.Count; i++)
                {
                    ListLocation.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ListLocation.Items.Count; i++)
                {
                    ListLocation.SetItemChecked(i, false);
                }
            }
        }

        private void checkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCategory.Checked == true)
            {
                for (int i = 0; i < ListCategory.Items.Count; i++)
                {
                    ListCategory.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ListCategory.Items.Count; i++)
                {
                    ListCategory.SetItemChecked(i, false);
                }
            }

        }

        private void BttnPOSList_Click(object sender, EventArgs e)
        {
            locationlist = "";
            categorylist = "";

            foreach (var item in ListLocation.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                locationlist += "location_id = " + row["location_id"] + " or ";
            }
            foreach (var item in ListCategory.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                categorylist += "category_id = " + row["category_id"] + " or ";
            }

            locationlist = locationlist.Remove(locationlist.Length - 4);
            categorylist = categorylist.Remove(categorylist.Length - 4);

            if (!string.IsNullOrWhiteSpace(locationlist) && !string.IsNullOrWhiteSpace(categorylist))
            {
                string sql = "SELECT rowid,ipaddress FROM dbo.target_server where (" + locationlist + ") and (" + categorylist + ")";
                DataTable dt = Dbconnection.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListPOS.DataSource = dt;
                        ListPOS.DisplayMember = "ipaddress";
                        ListPOS.ValueMember = "rowid";
                    }
                }
                else
                {
                    MessageBox.Show("No POS found with selected location and category!!");
                    dt.Clear();
                }

            }
            else
            {
                MessageBox.Show("Select at least one item from location and category!!");
            }

        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            foreach (var item in ListPOS.CheckedItems)
            {
                var listrow = (item as DataRowView).Row;
                foreach (DataGridViewRow row in dgvFiles.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        Main_Process(listrow["ipaddress"].ToString().Trim(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString().Replace(@"\", "/"));
                    }
                }
            }
        }

        public static int Main_Process(string mhostname,string sourcepath,string targetpath)
        {
            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Scp,
                    HostName = mhostname,
                    UserName = "Administrator",
                    Password = "^(A59g-!@=fj^",
                    //SshHostKeyFingerprint = "ssh-ed25519 255 1HdaY6/8lIXSZc1pk5g5cyS6/tf6pC8PgVdtjeHsnZI=",
                    //GiveUpSecurityAndAcceptAnySshHostKey = true
                    };
                sessionOptions.AddRawSettings("FSProtocol", "2");

                // Cache key is hostname:portnumber
                int portNumber =
                    (sessionOptions.PortNumber != 0) ? sessionOptions.PortNumber : SshPortNumber;
                string sessionKey = string.Format("{0}:{1}", sessionOptions.HostName, portNumber);

                // Load known hosts (if any)
                XmlDocument knownHosts = new XmlDocument();
                if (File.Exists(KnownHostsFile))
                {
                    knownHosts.Load(KnownHostsFile);
                }
                else
                {
                    knownHosts.AppendChild(knownHosts.CreateElement("KnownHosts"));
                }

                // Lookup host key for this session 
                XmlNode fingerprintNode =
                    knownHosts.DocumentElement.SelectSingleNode(
                        "KnownHost[@host='" + sessionKey + "']/@fingerprint");

                string fingerprint = null;
                if (fingerprintNode != null)
                {
                    fingerprint = fingerprintNode.Value;
                    Console.WriteLine("Connecting to a known host");
                }
                else
                {
                    // Host is not known yet. Scan its host key and let the user decide.
                    using (Session session = new Session())
                    {
                        fingerprint = session.ScanFingerprint(sessionOptions, "SHA-256");
                    }

                    //Console.Write(
                    //    "Continue connecting to an unknown server and add its host key to a cache?" +
                    //        Environment.NewLine +
                    //    "The server's host key was not found in the cache." + Environment.NewLine +
                    //    "You have no guarantee that the server is the computer you think it is." +
                    //        Environment.NewLine +
                    //    Environment.NewLine +
                    //    "The server's key fingerprint is:" + Environment.NewLine +
                    //    fingerprint + Environment.NewLine +
                    //    Environment.NewLine +
                    //    "If you trust this host, press Y. To abandon the connection, press N. ");

                    //char key;
                    //do
                    //{
                    //    key = char.ToUpperInvariant(Console.ReadKey(true).KeyChar);
                    //    if (key == 'N')
                    //    {
                    //        Console.WriteLine(key);
                    //        return 2;
                    //    }
                    //}
                    //while (key != 'Y');

                    //Console.WriteLine(key);

                    // Cache the host key
                    XmlElement knownHost = knownHosts.CreateElement("KnownHost");
                    knownHosts.DocumentElement.AppendChild(knownHost);
                    knownHost.SetAttribute("host", sessionKey);
                    knownHost.SetAttribute("fingerprint", fingerprint);

                    knownHosts.Save(KnownHostsFile);
                }

                // Now we have the fingerprint
                sessionOptions.SshHostKeyFingerprint = fingerprint;


                using (Session session = new Session())
                    {
                        // Connect
                        session.Open(sessionOptions);

                        // Upload files
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                    transferOptions.ResumeSupport.State = WinSCP.TransferResumeSupportState.On;

                        TransferOperationResult transferResult;
                        transferResult =
                            session.PutFiles(sourcepath, targetpath, false, transferOptions);

                        // Throw on any error
                        transferResult.Check();

                        // Print results
                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                        {
                            MessageBox.Show("Upload of "+ transfer.FileName +" succeeded");
                        }
                    }

                    return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }
        }

        private void checkPOS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPOS.Checked == true)
            {
                for (int i = 0; i < ListPOS.Items.Count; i++)
                {
                    ListPOS.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ListPOS.Items.Count; i++)
                {
                    ListPOS.SetItemChecked(i, false);
                }
            }

        }
    }
}
