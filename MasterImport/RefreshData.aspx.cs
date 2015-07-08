using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using Gnt.Data;
using Gnt.Transaction;
using Man.Utils;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Data.DBCommand;
using System.IO;
using System.Threading;
namespace Man.Song
{
    public partial class RefreshData : PageBase
    {
       


        protected void btnMasterGet_Click(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString);
            try
            {
                // formulate a string containing the name of the
                // stored procedure
                string procedureString = "tran_master";
                
                // create a SqlCommand object to hold the SQL statement
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // set the CommandText property of the SqlCommand object to
                // procedureString
                mySqlCommand.CommandText = procedureString;

                // set the CommandType property of the SqlCommand object
                // to CommandType.StoredProcedure
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                mySqlCommand.Parameters.Add(new SqlParameter("@admin", SqlDbType.VarChar, 50));

                mySqlCommand.Parameters[0].Value =  Page.User.Identity.Name;

                // open the database connection using the
                // Open() method of the SqlConnection object
                mySqlConnection.Open();

                // run the stored procedure
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        protected void btnFullGet_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadObj = new Thread(new ThreadStart(FullGet));
                threadObj.Priority = ThreadPriority.Highest;
                threadObj.Start();
                Thread.Sleep(1000);
                threadObj.Start();
            }
            catch (Exception exc)
            {
                ICJSystem.Instance.Log.Error(exc.Message);
            }
        }
        protected void FullGet()
        {
            SqlConnection mySqlConnection = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString);
            try
            {
                // formulate a string containing the name of the
                // stored procedure
                string procedureString = "tran_to_mone_full_tmp";

                // create a SqlCommand object to hold the SQL statement
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // create a SqlCommand object to hold the SQL statement
                mySqlCommand = mySqlConnection.CreateCommand();

                // set the CommandText property of the SqlCommand object to
                // procedureString
                mySqlCommand.CommandText = procedureString;

                // set the CommandType property of the SqlCommand object
                // to CommandType.StoredProcedure
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                mySqlCommand.Parameters.Add(new SqlParameter("@admin", SqlDbType.VarChar, 50));

                mySqlCommand.Parameters[0].Value = Page.User.Identity.Name;

                // open the database connection using the
                // Open() method of the SqlConnection object
                mySqlConnection.Open();

                // run the stored procedure
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        protected void btnUtaGet_Click(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString);
            try
            {
                // formulate a string containing the name of the
                // stored procedure
                string procedureString = "tran_to_mone_uta";

                // create a SqlCommand object to hold the SQL statement
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // create a SqlCommand object to hold the SQL statement
                mySqlCommand = mySqlConnection.CreateCommand();

                // set the CommandText property of the SqlCommand object to
                // procedureString
                mySqlCommand.CommandText = procedureString;

                // set the CommandType property of the SqlCommand object
                // to CommandType.StoredProcedure
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                mySqlCommand.Parameters.Add(new SqlParameter("@admin", SqlDbType.VarChar, 50));

                mySqlCommand.Parameters[0].Value = Page.User.Identity.Name;

                // open the database connection using the
                // Open() method of the SqlConnection object
                mySqlConnection.Open();

                // run the stored procedure
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        protected void btnVideoGet_Click(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString);
            try
            {
                // formulate a string containing the name of the
                // stored procedure
                string procedureString = "tran_to_mone_video";

                // create a SqlCommand object to hold the SQL statement
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // create a SqlCommand object to hold the SQL statement
                mySqlCommand = mySqlConnection.CreateCommand();

                // set the CommandText property of the SqlCommand object to
                // procedureString
                mySqlCommand.CommandText = procedureString;

                // set the CommandType property of the SqlCommand object
                // to CommandType.StoredProcedure
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                mySqlCommand.Parameters.Add(new SqlParameter("@admin", SqlDbType.VarChar, 50));

                mySqlCommand.Parameters[0].Value = Page.User.Identity.Name;

                // open the database connection using the
                // Open() method of the SqlConnection object
                mySqlConnection.Open();

                // run the stored procedure
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

    }   
}
