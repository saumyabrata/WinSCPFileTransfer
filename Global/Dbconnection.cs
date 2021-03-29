using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace WinSCPFileTransfer.Global
{
    public class Dbconnection
    {
        public static void CreateCommand(string queryString)
        {
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
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

        public static DataTable GetDataTable(string queryString)
        {
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, connection))
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds.Tables[0];
                    }

                }
                catch(SqlException ex)
                {
                    MessageBox.Show("Error:- " + ex.Message);
                }
                finally
                {
                   connection.Close();
                }
            }
            return null;
        }
    }
}
