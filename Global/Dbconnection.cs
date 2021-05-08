using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using NLog;

namespace WinSCPFileTransfer.Global
{
    public class Dbconnection
    {
        public static int CreateCommand(string queryString)
        {
            int status = 0;
            SqlTransaction transaction;
            string conn = ConfigurationManager.ConnectionStrings["patchmanagementdb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                Logger infologger = LogManager.GetLogger("InfoLogger");
                infologger.Debug("Database Connection Established");

                transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection,transaction);
                    command.CommandType = CommandType.Text;
                    status = command.ExecuteNonQuery();
                    command.Dispose();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    Logger logger = LogManager.GetLogger("fileLogger");
                    logger.Error(ex, "Error in CreateCommand");
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
                return status;
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
                    //MessageBox.Show("Error:- " + ex.Message);
                    Logger logger = LogManager.GetLogger("fileLogger");
                    logger.Error(ex, "Error in GetDataTable");

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
