using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace CI_Gwap
{
    public partial class LogOutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Perform Log out
            //Update User profile
            userLogOut();
            Response.Redirect("MainPage.aspx");
        }

        protected void userLogOut()
        {
            String username = Session["username"].ToString();

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlUpdateUserStatus = "Update user_details Set onlineStatus='offline' Where username='" + username + "'";
                OleDbCommand commandUpdateString = new OleDbCommand(sqlUpdateUserStatus, con);

                using (commandUpdateString)
                {
                    commandUpdateString.ExecuteNonQuery();
                    //ClientScript.RegisterStartupScript(this.GetType(), "Logged Out", "alert('Successfully Logged out');", true);
                }
            }
            con.Close();
        }
    }
}