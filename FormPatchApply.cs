using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCPFileTransfer.Global;

namespace WinSCPFileTransfer
{
    public partial class FormPatchApply : Form
    {
        string categorylist = "";
        string locationlist = "";
        string poslist = "";

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

        }
    }
}
