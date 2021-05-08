using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using WinSCPFileTransfer.Global;
using WinSCP;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;
using NLog;
using System.Net.NetworkInformation;
using System.Text;

namespace WinSCPFileTransfer
{
    public partial class FormPatchApply : Form
    {
        string categorylist = "";
        string storelist = "";
        string poslist = "";
        const string KnownHostsFile = "KnownHosts.xml";
        const int SshPortNumber = 22;
        Logger infologger = LogManager.GetLogger("InfoLogger");
        public FormPatchApply()
        {
            InitializeComponent();

            Shown += new EventHandler(FormPatchApply_Shown);

            // To report progress from the background worker we need to set this property
            backgroundWorker1.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            backgroundWorker1.DoWork += new DoWorkEventHandler(BtnTransfer_Click);
            // This event will be raised when we call ReportProgress
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);


            dgvFiles.Columns[0].Name = "colFilename";
            dgvFiles.Columns[1].Name = "colSource";
            dgvFiles.Columns[2].Name = "colDest";
        }

        void FormPatchApply_Shown(object sender, EventArgs e)
        {
            // Start the background worker
            backgroundWorker1.RunWorkerAsync();
        }

        private void FormPatchApply_Load(object sender, EventArgs e)
        {
            Load_masterdata();
            checkActivate.Visible = false;
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
            storelist = "";
            categorylist = "";

            foreach (var item in ListLocation.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                storelist += "Store_Code = '" + row["Store_Code"] + "' or ";
            }
            foreach (var item in ListCategory.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                categorylist += "category_id = " + row["category_id"] + " or ";
            }

            storelist = storelist.Remove(storelist.Length - 4);
            categorylist = categorylist.Remove(categorylist.Length - 4);

            if (!string.IsNullOrWhiteSpace(storelist) && !string.IsNullOrWhiteSpace(categorylist))
            {
                string sql = "SELECT rowid,[servername]+' ['+[ipaddress]+']' IPAddress FROM dbo.target_server where (" + storelist + ") and (" + categorylist + ")";
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

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
        }
        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int result = 0;
            int qryresult = 0;

            foreach (DataGridViewRow dgrow in dataGridView2.Rows)
            {
                string hostname = dgrow.Cells["Hostname"].Value.ToString().Trim();
                string ipaddress = dgrow.Cells["ipaddress"].Value.ToString().Trim();
                int mrowid = Convert.ToInt32(dgrow.Cells["rowid"].Value.ToString());
                string password = "";

                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgrow.Cells[1];
                if (!(chk.Value == null || (bool)chk.Value == false))
                {
                    dgvlog.Rows.Add(new object[] {"Processing... "+ hostname +" ("+ ipaddress +")" });
                    string tsql = @"SELECT Target_Server.rowid, task_master.task_id, Target_Server.servername, 
                    Target_Server.ipaddress, Target_Server.username, Target_Server.password, task_details.Filename, task_details.sourcepath, 
                    task_details.destinationpath, task_master.patch_version, task_master.is_active
                    FROM task_details 
                    INNER JOIN
                    task_master ON task_details.task_id = task_master.task_id 
                    INNER JOIN
                    Target_Server ON task_master.task_id = Target_Server.map_patch_id
                    WHERE task_master.is_active = 1 AND Target_Server.servername = '" + hostname + "' AND " +
                    "Target_Server.ipaddress = '" + ipaddress + "' AND RIGHT(task_details.Filename,3) != 'sql' AND Target_Server.rowid="+ mrowid;

                    DataTable dt = Dbconnection.GetDataTable(tsql);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string username = row["username"].ToString().Trim();
                            if (!string.IsNullOrWhiteSpace(row["password"].ToString()))
                            {
                                string decryptedstring = EncryptionandDecryption.Decrypt(row["password"].ToString(), "Qnx4pr#2021");
                                password = decryptedstring;
                            }
                            else
                            {
                                MessageBox.Show("Password of " + hostname + " is not saved, quitting..");
                                break;
                            }
                            string source_path = row["sourcepath"].ToString();
                            string dest_path = row["destinationpath"].ToString().Replace(@"\", "/");

                            result = Main_Process(username, password, ipaddress, source_path, dest_path);
                            if (result == 0)
                            {
                                infologger.Info("Patch applied to " + hostname + " successfully.");
                                dgvlog.Rows.Add(new object[] { "Patch applied to " + hostname + " (" + ipaddress + ") successfully." });
                            }
                            else
                            {
                                infologger.Info("Patch FAILED to apply on" + hostname);
                                dgvlog.Rows.Add(new object[] { "Patch FAILED to apply on " + hostname + " (" + ipaddress + ")." });
                            }
                        }
                    }

                    // for SQL Execution
                    string msql = @"SELECT Target_Server.rowid, task_master.task_id, Target_Server.servername, 
                    Target_Server.ipaddress, Target_Server.username, Target_Server.password, task_details.Filename, task_details.sourcepath, 
                    task_details.destinationpath, task_master.patch_version, task_master.is_active
                    FROM task_details 
                    INNER JOIN
                    task_master ON task_details.task_id = task_master.task_id 
                    INNER JOIN
                    Target_Server ON task_master.task_id = Target_Server.map_patch_id
                    WHERE task_master.is_active = 1 AND Target_Server.servername = '" + hostname + "' AND " +
                    "Target_Server.ipaddress = '" + ipaddress + "' AND RIGHT(task_details.Filename,3) = 'sql' AND Target_Server.rowid=" + mrowid;

                    DataTable dtsql = Dbconnection.GetDataTable(msql);
                    if (dtsql.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtsql.Rows)
                        {
                            string source_path = row["sourcepath"].ToString();
                            // Execute SQLFile to target POS
                            qryresult = execute_sql(hostname, hostname, "sa", "123", row["sourcepath"].ToString());
                            dgvlog.Rows.Add(new object[] { "Trying to execute SQL on " + hostname + " (" + ipaddress + ")." });

                            if (qryresult == -1)
                            {
                                infologger.Info("SQL executed successfully to " + hostname);
                                dgvlog.Rows.Add(new object[] { "SQL executed successfully on " + hostname + " (" + ipaddress + ")." });
                            }
                            else
                            {
                                infologger.Info("SQL FAILED to execute on " + hostname);
                                dgvlog.Rows.Add(new object[] { "SQL FAILED to execute on " + hostname + " (" + ipaddress + ")." });
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }

        public static int execute_sql(string msqlsrvr, string mdbname, string msqluser, string msqlpwd, string msqlfile)
        {
            int qryresult = 0;
            string targetconnection = "Server=msqlsrvr;Database=mdbname;User Id=msqluser;Password=msqlpwd;";
            using (SqlConnection conn = new SqlConnection(targetconnection))
            {
                try
                {
                    string data = System.IO.File.ReadAllText(msqlfile);
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = data;
                        qryresult = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Logger logger = LogManager.GetLogger("fileLogger");
                    logger.Error(ex, "Error in Executing SQL to remote server.");

                }
                finally
                {
                    conn.Close();
                }
            }
            return qryresult;
        }

        public static int Main_Process(string musername, string mpassword, string mhostname, string sourcepath, string targetpath)
        {
            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Scp,
                    HostName = mhostname,
                    UserName = musername,
                    Password = mpassword,
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
                        //MessageBox.Show("Upload of " + transfer.FileName + " succeeded");
                    }
                }

                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Logger logger = LogManager.GetLogger("fileLogger");
                logger.Error(e, "Error in Transferring file to "+ mhostname);

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

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    string[] row1 = new string[] { Path.GetFileName(file), file, file };
                    dgvFiles.Rows.Add(row1);
                }
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text=="Save")
            {
                SaveRecords();
            }
            else if (btnSave.Text=="Update")
            {
                UpdateRecords();
            }
        }

        private void SaveRecords()
        {
            foreach (DataGridViewRow datarow in dgvFiles.Rows)
            {
                if (datarow.Cells["colFilename"].Value == null || datarow.Cells["colSource"].Value == null || datarow.Cells["colDest"].Value == null)
                {
                    MessageBox.Show("No Files Selected!");
                    btnSave.Enabled = false;
                    btnSelectFiles.Focus();
                }
            }
            if (string.IsNullOrWhiteSpace(textTask.Text) == true)
            {
                textTask.Select();
            }
            else if (string.IsNullOrWhiteSpace(textTaskDesc.Text) == true)
            {
                textTaskDesc.Select();
            }
            else if (string.IsNullOrWhiteSpace(textPatchVer.Text) == true)
            {
                textPatchVer.Select();
            }
            else if (string.IsNullOrWhiteSpace(comboTarget.Text) == true)
            {
                comboTarget.Select();
            }
            else if (string.IsNullOrWhiteSpace(comboTarget.Text) == true)
            {
                comboTarget.Select();
            }
            else if (dtRelease.Value.Date < DateTime.Now.Date)
            {
                dtRelease.Select();
            }
            else
            {
                //Task list save function
                SqlTransaction transaction;
                string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand cmdzs = new SqlCommand("SELECT MAX(task_id) as new_task_id FROM task_master", connection, transaction);
                        cmdzs.CommandType = CommandType.Text;
                        object obj = cmdzs.ExecuteScalar();
                        int maxno = (obj != null && obj != DBNull.Value) ? Convert.ToInt32(obj) : 0;
                        maxno = maxno + 1;

                        string sql = @"
                    INSERT INTO [dbo].[task_master]
                    ([task_id]
                    ,[patch_name]
                    ,[patch_description]
                    ,[patch_version]
                    ,[target_os]
                    ,[patch_release_date]
                    ,[is_active])
			        VALUES
                    (@task_id
                    , @patch_name
                    , @patch_description
                    , @patch_version
                    , @target_os
                    , @patch_release_date
                    , @is_active)";
                        using (var cmd = new SqlCommand(sql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@task_id", maxno);
                            cmd.Parameters.AddWithValue("@patch_name", textTask.Text);
                            cmd.Parameters.AddWithValue("@patch_description", textTaskDesc.Text);
                            cmd.Parameters.AddWithValue("@patch_version", Convert.ToDecimal(textPatchVer.Text));
                            cmd.Parameters.AddWithValue("@target_os", comboTarget.Text);
                            cmd.Parameters.Add("@patch_release_date", SqlDbType.Date).Value = dtRelease.Value;
                            cmd.Parameters.AddWithValue("@is_active", true);
                            cmd.ExecuteNonQuery();

                            foreach (DataGridViewRow datarow in dgvFiles.Rows)
                            {
                                if (datarow.Cells["colFilename"].Value != null || datarow.Cells["colSource"].Value != null || datarow.Cells["colDest"].Value != null)
                                {
                                    string tsql = @"INSERT INTO dbo.task_details (task_id,filename,sourcepath,destinationpath)
                                VALUES(@task_id,@filename,@sourcepath,@destinationpath)";
                                    using (var cmdtrn = new SqlCommand(tsql, connection, transaction))
                                    {
                                        cmdtrn.Parameters.AddWithValue("@task_id", maxno);
                                        cmdtrn.Parameters.Add("@filename", SqlDbType.VarChar).Value = datarow.Cells["colFilename"].Value;
                                        cmdtrn.Parameters.Add("@sourcepath", SqlDbType.VarChar).Value = datarow.Cells["colSource"].Value;
                                        cmdtrn.Parameters.Add("@destinationpath", SqlDbType.VarChar).Value = datarow.Cells["colDest"].Value;
                                        cmdtrn.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show("Task created successfully!");
                        infologger.Info("Patch "+ textTask.Text + " Created.");
                        cleardata();
                    }
                    catch (SqlException sqlError)
                    {
                        MessageBox.Show(sqlError.Message);
                        Logger logger = LogManager.GetLogger("fileLogger");
                        logger.Error(sqlError, "Error in saving records.");

                        transaction.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void UpdateRecords()
        {
            btnSave.Enabled = true;
            foreach (DataGridViewRow datarow in dgvFiles.Rows)
            {
                if (datarow.Cells["colFilename"].Value == null || datarow.Cells["colSource"].Value == null || datarow.Cells["colDest"].Value == null)
                {
                    MessageBox.Show("No Files Selected!");
                    btnSave.Enabled = false;
                    btnSelectFiles.Focus();
                }
            }
            if (string.IsNullOrWhiteSpace(textTask.Text) == true)
            {
                textTask.Select();
            }
            else if (string.IsNullOrWhiteSpace(textTaskDesc.Text) == true)
            {
                textTaskDesc.Select();
            }
            else if (string.IsNullOrWhiteSpace(textPatchVer.Text) == true)
            {
                textPatchVer.Select();
            }
            else if (string.IsNullOrWhiteSpace(comboTarget.Text) == true)
            {
                comboTarget.Select();
            }
            else if (string.IsNullOrWhiteSpace(comboTarget.Text) == true)
            {
                comboTarget.Select();
            }
            else if (dtRelease.Value.Date < DateTime.Now.Date)
            {
                dtRelease.Select();
            }
            else
            {
                //Task list update function
                SqlTransaction transaction;
                string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand cmdx = new SqlCommand("DELETE FROM task_details WHERE task_id ="+Convert.ToInt32(textID.Text), connection, transaction);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.ExecuteNonQuery();
                        cmdx = new SqlCommand("DELETE FROM task_master WHERE task_id =" + Convert.ToInt32(textID.Text), connection, transaction);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.ExecuteNonQuery();
                        cmdx.Dispose();
                        string sql = @"
                    INSERT INTO [dbo].[task_master]
                    ([task_id]
                    ,[patch_name]
                    ,[patch_description]
                    ,[patch_version]
                    ,[target_os]
                    ,[patch_release_date]
                    ,[is_active])
			        VALUES
                    (@task_id
                    , @patch_name
                    , @patch_description
                    , @patch_version
                    , @target_os
                    , @patch_release_date
                    , @is_active)";
                        using (var cmd = new SqlCommand(sql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@task_id", Convert.ToInt32(textID.Text));
                            cmd.Parameters.AddWithValue("@patch_name", textTask.Text);
                            cmd.Parameters.AddWithValue("@patch_description", textTaskDesc.Text);
                            cmd.Parameters.AddWithValue("@patch_version", Convert.ToDecimal(textPatchVer.Text));
                            cmd.Parameters.AddWithValue("@target_os", comboTarget.Text);
                            cmd.Parameters.Add("@patch_release_date", SqlDbType.Date).Value = dtRelease.Value;
                            if (checkActivate.Checked)
                            {
                                cmd.Parameters.AddWithValue("@is_active", false);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@is_active", true);
                            }
                            cmd.ExecuteNonQuery();

                            foreach (DataGridViewRow datarow in dgvFiles.Rows)
                            {
                                if (datarow.Cells["colFilename"].Value != null || datarow.Cells["colSource"].Value != null || datarow.Cells["colDest"].Value != null)
                                {
                                    string tsql = @"INSERT INTO dbo.task_details (task_id,filename,sourcepath,destinationpath)
                                VALUES(@task_id,@filename,@sourcepath,@destinationpath)";
                                    using (var cmdtrn = new SqlCommand(tsql, connection, transaction))
                                    {
                                        cmdtrn.Parameters.AddWithValue("@task_id", Convert.ToInt32(textID.Text));
                                        cmdtrn.Parameters.Add("@filename", SqlDbType.VarChar).Value = datarow.Cells["colFilename"].Value;
                                        cmdtrn.Parameters.Add("@sourcepath", SqlDbType.VarChar).Value = datarow.Cells["colSource"].Value;
                                        cmdtrn.Parameters.Add("@destinationpath", SqlDbType.VarChar).Value = datarow.Cells["colDest"].Value;
                                        cmdtrn.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show("Task updated successfully!");
                        infologger.Info("Patch " + textTask.Text + " Updated.");

                        cleardata();
                    }
                    catch (SqlException sqlError)
                    {
                        MessageBox.Show(sqlError.Message);
                        Logger logger = LogManager.GetLogger("fileLogger");
                        logger.Error(sqlError, "Error in Updating records.");

                        transaction.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void cleardata()
        {
            checkActivate.Visible = false;
            btnSave.Text = "Save";
            textTask.Text = "";
            textTaskDesc.Text = "";
            textPatchVer.Text = "";
            comboTarget.SelectedIndex = -1;
            //btnSave.Enabled = false;
            Load_masterdata();
            dgvFiles.Rows.Clear();
            dgvFiles.Refresh();
            textTask.Select();
        }
        private void tabTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabTask.SelectedTab == tabTask.TabPages["pageTask"])
            {
                Load_masterdata();
                textTask.Focus();
                btnSave.Enabled = false;
            }
            else if (tabTask.SelectedTab == tabTask.TabPages["pageMap"])
            {
                string sql = "SELECT store_code,store_name FROM dbo.Store";
                DataTable dt = Dbconnection.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListLocation.DataSource = dt;
                    ListLocation.DisplayMember = "Store_Name";
                    ListLocation.ValueMember = "Store_Code";
                }

                string sqlc = "SELECT category_id,category FROM dbo.category";
                DataTable dtc = Dbconnection.GetDataTable(sqlc);
                for (int i = 0; i < dtc.Rows.Count; i++)
                {
                    ListCategory.DataSource = dtc;
                    ListCategory.DisplayMember = "category";
                    ListCategory.ValueMember = "category_id";
                }

                string sqltask = "SELECT task_id,patch_name FROM dbo.task_master where is_active=1";
                DataTable dttask = Dbconnection.GetDataTable(sqltask);
                if (dttask.Rows.Count > 0)
                {
                    for (int i = 0; i < dttask.Rows.Count; i++)
                    {
                        //for mapping tab
                        listallTask.DataSource = dttask;
                        listallTask.DisplayMember = "patch_name";
                        listallTask.ValueMember = "task_id";
                    }
                }
                else
                {
                    MessageBox.Show("No Task created");
                }


            }
            else if (tabTask.SelectedTab == tabTask.TabPages["pagePatch"])
            {
                string sqltask = "SELECT task_id,patch_name FROM dbo.task_master where is_active=1";
                DataTable dttask = Dbconnection.GetDataTable(sqltask);
                if (dttask.Rows.Count > 0)
                {
                    for (int i = 0; i < dttask.Rows.Count; i++)
                    {
                        //for apply patch tab
                        listtargetPatch.DataSource = dttask;
                        listtargetPatch.DisplayMember = "patch_name";
                        listtargetPatch.ValueMember = "task_id";
                    }
                }
                else
                {
                    MessageBox.Show("No Task created");
                }

            }

        }

        private void Load_masterdata()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            BindingSource bs = new BindingSource();

            var table = dt;
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                try
                {
                    SqlCommand cmdzs = new SqlCommand("SELECT task_id,patch_name FROM task_master order by patch_release_date desc", connection);
                    cmdzs.CommandType = CommandType.Text;
                    table.Load(cmdzs.ExecuteReader());
                    bs.DataSource = table;
                    listTask.DataSource = table;
                    listTask.DisplayMember = "patch_name";
                    listTask.ValueMember = "task_id";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + " sql query error.");
                    Logger logger = LogManager.GetLogger("fileLogger");
                    logger.Error(ex, "SQL Query Error");

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFiles.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
                {
                    if (dgvFiles.CurrentCell != null && dgvFiles.CurrentCell.Value != null)
                    {
                        if (MessageBox.Show("Do you want to delete the current row?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.dgvFiles.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger logger = LogManager.GetLogger("fileLogger");
                logger.Error(ex, "Failed to delete row from Grid");

            }
        }

        private void textPatchVer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkActivate_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkActivate.CheckState == CheckState.Checked)
            {
                btnSave.Text = "Update";
                btnSave.Enabled = true;
            }
        }

        private void listTask_Click(object sender, EventArgs e)
        {
            if (listTask.SelectedIndex > -1)
            {
                int selectedValue = (int)listTask.SelectedValue;
                textID.Text = selectedValue.ToString();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                var table = dt;
                string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    try
                    {
                        string sql = @"SELECT [patch_name]
                                      ,[patch_description]
                                      ,[patch_version]
                                      ,[target_OS]
                                      ,[patch_release_date]
                                      ,[task_creation_date]
                                      ,[is_active]
                                  FROM [spencerswupdate].[dbo].[task_master] WHERE task_id = " + selectedValue;

                        SqlCommand cmdzs = new SqlCommand(sql, connection);
                        cmdzs.CommandType = CommandType.Text;
                        table.Load(cmdzs.ExecuteReader());
                        foreach (DataRow row in table.Rows)
                        {
                            textTask.Text = row["patch_name"].ToString();
                            textTaskDesc.Text = row["patch_description"].ToString();
                            textPatchVer.Text = row["patch_version"].ToString();
                            comboTarget.Text = row["target_OS"].ToString();
                            dtRelease.Value = Convert.ToDateTime(row["patch_release_date"].ToString());
                        }
                        table.Clear();
                        // detail table
                        sql = @"SELECT [Filename]
                                  ,[sourcepath]
                                  ,[destinationpath]
                                  FROM [spencerswupdate].[dbo].[task_details] WHERE task_id = " + selectedValue;

                        cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtable = new DataTable();
                        da.Fill(dtable);
                        dgvFiles.Rows.Clear();
                        foreach (DataRow row in dtable.Rows)
                        {
                            dgvFiles.Rows.Add(row["Filename"].ToString(), row["sourcepath"].ToString(), row["destinationpath"].ToString());
                        }

                        btnSave.Text = "Update";
                        checkActivate.Visible = true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message + " sql query error.");
                        Logger logger = LogManager.GetLogger("fileLogger");
                        logger.Error(ex, "sql query error.");

                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void buttnNew_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                try
                {

                    SqlCommand cmdzs = new SqlCommand("SELECT MAX(task_id) as new_task_id FROM task_master", connection);
                    cmdzs.CommandType = CommandType.Text;
                    object obj = cmdzs.ExecuteScalar();
                    int maxno = (obj != null && obj != DBNull.Value) ? Convert.ToInt32(obj) : 0;
                    maxno = maxno + 1;
                    textID.Text = maxno.ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + " sql query error.");
                    Logger logger = LogManager.GetLogger("fileLogger");
                    logger.Error(ex, "sql query error.");

                }
                finally
                {
                    connection.Close();
                }
            }
                btnSave.Text = "Save";
            cleardata();
        }

        private void btnMapSave_Click(object sender, EventArgs e)
        {
            foreach (var item in ListPOS.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                var text = (listallTask.SelectedItem as DataRowView)["task_id"].ToString();
                if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(row["rowid"].ToString()))
                {
                    string updatesql = "UPDATE target_server set map_patch_id= " + Convert.ToInt32(text) + " where rowid = " + row["rowid"];
                    int result = Dbconnection.CreateCommand(updatesql);
                    if (result == 0)
                    {
                        MessageBox.Show("Mapping failed, check log!");
                        Logger infologger = LogManager.GetLogger("InfoLogger");
                        infologger.Info("Mapping failed for task:"+ text + "with Server id: "+row);

                        break;
                    }
                }
            }
        }

        private void listtargetPatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private static bool IsMachineUp(string hostName)
        {
            bool retVal = false;
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;
                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                PingReply reply = pingSender.Send(hostName, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                retVal = false;
                MessageBox.Show(ex.Message);
                Logger logger = LogManager.GetLogger("fileLogger");
                logger.Error(ex, "Error in IsMachineUp with hostname " + hostName);

            }
            return retVal;
        }
        private void checkBoxApplyPatch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxApplyPatch.Checked == true)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                    chk.Value = !(chk.Value == null ? false : false); //because chk.Value is initialy null
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                    chk.Value = !(chk.Value == null ? false : true); //because chk.Value is initialy null
                }
            }

        }

        private void listtargetPatch_Click(object sender, EventArgs e)
        {
            if (sender is ListBox lb)
            {
                var text = (lb.SelectedItem as DataRowView)["task_id"].ToString();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    //string sql = "SELECT rowid,[servername]+' ['+[ipaddress]+']' IPAddress FROM dbo.target_server where map_patch_id="+ Convert.ToInt32(text.ToString());
                    string sql = "SELECT rowid,servername,ipaddress FROM dbo.target_server where map_patch_id=" + Convert.ToInt32(text.ToString());
                    DataTable dt = Dbconnection.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView2.Rows.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            if (IsMachineUp(row["ipaddress"].ToString().Trim()) == true)
                            {
                                infologger.Info("Connectivity check OK with " + row["ipaddress"].ToString());
                                dataGridView2.Rows.Add(new object[] { row["rowid"].ToString().Trim(), false, row["servername"].ToString().Trim(), row["ipaddress"].ToString().Trim(), Properties.Resources.ok });
                            }
                            else
                            {
                                infologger.Info("Connectivity check FAILED with " + row["ipaddress"].ToString());
                                dataGridView2.Rows.Add(new object[] { row["rowid"].ToString().Trim(), false, row["servername"].ToString().Trim(), row["ipaddress"].ToString().Trim(), Properties.Resources.error });
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("No POS found with patch id " + text.ToString() + " !!!");
                        dt.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Select at least one item from location and category!!");
                }

            }
        }
    }
}
