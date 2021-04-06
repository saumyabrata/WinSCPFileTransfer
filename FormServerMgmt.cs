﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCPFileTransfer.Global;

namespace WinSCPFileTransfer
{
    public partial class FormServerMgmt : Form
    {
        string storecode;
        int categoryid;
        int rowid;
        bool statusOK = false;
        bool connectivitystatus = false;
        bool sshstatus = false;
        bool shastatus = false;


        public FormServerMgmt()
        {
            InitializeComponent();
        }

        private void FormServerMgmt_Load(object sender, EventArgs e)
        {
            textServerName.Focus();
            string sql = "SELECT store_code,region,store_name FROM dbo.Store";
            DataTable dt = Dbconnection.GetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboStore.DataSource = dt;
                comboStore.DisplayMember = "store_code";
                comboStore.ValueMember = "store_code";
            }

            string sqlc = "SELECT category_id,category FROM dbo.category";
            DataTable dtc = Dbconnection.GetDataTable(sqlc);
            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                comboCategory.DataSource = dtc;
                comboCategory.DisplayMember = "category";
                comboCategory.ValueMember = "category_id";
            }
            FetchServerDetails();
        }

        private void FetchServerDetails()
        {
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    SqlCommand sqlCmd = new SqlCommand("sp_targetserver", connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@ActionType", "FetchData");
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        DataTable dtData = new DataTable();
                        da.Fill(dtData);
                        dgvSrv.AutoGenerateColumns = true;
                        dgvSrv.DataSource = dtData;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error:- " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textServerName.Text))
            {
                MessageBox.Show("Enter Server Name !!!");
                textServerName.Select();
            }
            else if (string.IsNullOrWhiteSpace(textIP.Text))
            {
                MessageBox.Show("Enter IP Address !!!");
                textIP.Select();
            }
            else if (string.IsNullOrWhiteSpace(comboStore.Text))
            {
                MessageBox.Show("Select Location !!!");
                comboStore.Select();
            }
            else if (comboCategory.SelectedIndex <= -1)
            {
                MessageBox.Show("Select Category !!!");
                comboCategory.Select();
            }
            else if (string.IsNullOrWhiteSpace(textPassword.Text) && string.IsNullOrWhiteSpace(textUser.Text))
            {
                MessageBox.Show("Username and Password both need to be entered !!!");
                textUser.Select();
            }
            else
            {
                categoryid = Convert.ToInt32(comboCategory.SelectedValue.ToString());
                storecode = comboStore.SelectedValue.ToString();
                string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    try
                    {
                        if (btnSave.Text == "Save")
                        {
                            try
                            {
                                string username = "";
                                string encrypted_string = "";
                                if (!string.IsNullOrWhiteSpace(textPassword.Text) && !string.IsNullOrWhiteSpace(textUser.Text))
                                {
                                    username = textUser.Text.ToString().Trim();
                                    encrypted_string = EncryptionandDecryption.Encrypt(textPassword.Text.Trim(), "Qnx4pr#2021");
                                }
                                connection.Open();
                                SqlCommand sqlCmd = new SqlCommand("sp_targetserver", connection);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.Parameters.AddWithValue("@ActionType", "SaveData");
                                sqlCmd.Parameters.AddWithValue("@servername", textServerName.Text.Trim().ToString());
                                sqlCmd.Parameters.AddWithValue("@ipaddress", textIP.Text.Trim().ToString());
                                sqlCmd.Parameters.AddWithValue("@username", username);
                                sqlCmd.Parameters.AddWithValue("@password", encrypted_string);
                                sqlCmd.Parameters.AddWithValue("@store_code", storecode);
                                sqlCmd.Parameters.AddWithValue("@category_id", categoryid);
                                sqlCmd.Parameters.AddWithValue("@connectivity", connectivitystatus);
                                sqlCmd.Parameters.AddWithValue("@SSH_Status", sshstatus);
                                sqlCmd.Parameters.AddWithValue("@fingerprint_generated", sshstatus);
                                sqlCmd.Parameters.AddWithValue("@created_by", "Admin");
                                sqlCmd.Parameters.AddWithValue("@created_on", DateTime.UtcNow);

                                int numRes = sqlCmd.ExecuteNonQuery();
                                if (numRes > 0)
                                {
                                    MessageBox.Show("Record Saved Successfully !!!");
                                    ClearAllData();
                                }
                                else
                                    MessageBox.Show("Please Try Again !!!");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("Error:- " + ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        else if(btnSave.Text == "Update")
                        {
                            try
                            {
                                string username = "";
                                string encrypted_string = "";
                                if (!string.IsNullOrWhiteSpace(textPassword.Text) && !string.IsNullOrWhiteSpace(textUser.Text))
                                {
                                    username = textUser.Text.ToString().Trim();
                                    encrypted_string = EncryptionandDecryption.Encrypt(textPassword.Text.Trim(), "Qnx4pr#2021");
                                }
                                connection.Open();
                                SqlCommand sqlCmd = new SqlCommand("sp_targetserver", connection);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.Parameters.AddWithValue("@ActionType", "UpdateData");
                                sqlCmd.Parameters.AddWithValue("@servername", textServerName.Text.Trim().ToString());
                                sqlCmd.Parameters.AddWithValue("@ipaddress", textIP.Text.Trim().ToString());
                                sqlCmd.Parameters.AddWithValue("@username", username);
                                sqlCmd.Parameters.AddWithValue("@password", encrypted_string);
                                sqlCmd.Parameters.AddWithValue("@store_code", storecode);
                                sqlCmd.Parameters.AddWithValue("@category_id", categoryid);
                                sqlCmd.Parameters.AddWithValue("@connectivity", connectivitystatus);
                                sqlCmd.Parameters.AddWithValue("@SSH_Status", sshstatus);
                                sqlCmd.Parameters.AddWithValue("@fingerprint_generated", sshstatus);
                                sqlCmd.Parameters.AddWithValue("@modified_by", "Admin");
                                sqlCmd.Parameters.AddWithValue("@modified_on", DateTime.UtcNow);
                                sqlCmd.Parameters.AddWithValue("@rowid", rowid);
                                sqlCmd.ExecuteNonQuery();
                                //int numRes = sqlCmd.ExecuteNonQuery();
                                //if (numRes > 0)
                                //{
                                //    MessageBox.Show("Record Updated Successfully !!!");
                                //    ClearAllData();
                                //}
                                //else
                                //    MessageBox.Show("Please Try Again !!!");


                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("Error:- " + ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:- " + ex.Message);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        private void ClearAllData()
        {
            btnSave.Text = "Save";
            textServerName.Text = "";
            textIP.Text = "";
            textUser.Text = "";
            textPassword.Text = "";
            comboStore.SelectedIndex = -1;
            comboCategory.SelectedIndex = -1;
            FetchServerDetails();
        }
        private void dgvSrv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSave.Text = "Update";
                rowid = Convert.ToInt32(dgvSrv.Rows[e.RowIndex].Cells[0].Value.ToString());
                DataTable dtData = FetchServerRecords(rowid);
                if (dtData.Rows.Count > 0)
                {
                    //rowid = Convert.ToInt32(dtData.Rows[0][0].ToString());
                    textServerName.Text = dtData.Rows[0][1].ToString();
                    textIP.Text = dtData.Rows[0][2].ToString();
                    textUser.Text = dtData.Rows[0][3].ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(dtData.Rows[0][4].ToString()))
                        {
                        string decryptedstring = EncryptionandDecryption.Decrypt(dtData.Rows[0][4].ToString(), "Qnx4pr#2021");
                        textPassword.Text = decryptedstring;
                        }
                    else
                    {
                        textPassword.Text = "";
                    }
                    comboStore.SelectedValue = dtData.Rows[0][5].ToString();
                    storecode = dtData.Rows[0][5].ToString();
                    DataTable storerec = FetchStoreRecords(storecode);
                    if (storerec.Rows.Count > 0)
                    {
                        textRegion.Text = storerec.Rows[0][1].ToString();
                        textStoreName.Text = storerec.Rows[0][2].ToString();
                    }
                    comboCategory.SelectedValue = Convert.ToInt32(dtData.Rows[0][6].ToString());

                }
                else
                {
                    ClearAllData(); // For clear all control and refresh DataGridView data.  
                }
            }
        }

        private DataTable FetchServerRecords(int rowid)
        {
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    SqlCommand sqlCmd = new SqlCommand("sp_targetserver", connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@ActionType", "FetchRecord");
                    sqlCmd.Parameters.AddWithValue("@RowId", rowid);
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        DataTable dtData = new DataTable();
                        da.Fill(dtData);
                        return dtData;
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error:- " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowid != 0)
            {
                string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand sqlCmd = new SqlCommand("sp_targetserver", connection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ActionType", "DeleteData");
                        sqlCmd.Parameters.AddWithValue("@RowId", rowid);
                        int numRes = sqlCmd.ExecuteNonQuery();
                        if (numRes > 0)
                        {
                            MessageBox.Show("Record Deleted Successfully !!!");
                            ClearAllData();
                        }
                        else
                        {
                            MessageBox.Show("Please Try Again !!!");
                        }

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error:- " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select A Record !!!");
            }
        }

        private void comboLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void comboCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            categoryid = Convert.ToInt32(comboCategory.SelectedValue.ToString());
            string category = comboCategory.Text.ToString();

        }

        private void panelServer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            (dgvSrv.DataSource as DataTable).DefaultView.RowFilter =  string.Format("servername LIKE '{0}%' OR servername LIKE '% {0}%'", textBoxFilter.Text);
        }

        private void comboStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            storecode = comboStore.SelectedValue.ToString();
            DataTable storerec = FetchStoreRecords(storecode);
            if (storerec.Rows.Count > 0)
            {
                textRegion.Text = storerec.Rows[0][1].ToString();
                textStoreName.Text = storerec.Rows[0][2].ToString();
            }
        }

        private DataTable FetchStoreRecords(string mstorecode)
        {
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    SqlCommand sqlCmd = new SqlCommand("sp_store", connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@ActionType", "FetchRecord");
                    sqlCmd.Parameters.AddWithValue("@store_code", mstorecode);
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        DataTable storerec = new DataTable();
                        da.Fill(storerec);
                        return storerec;
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error:- " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }
    }
}
