using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace CI_Gwap
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                //Do nothing, waiting user to proceed
            }
            else
            {
                //Allow users to continue without login
                txtboxUsername.Text = "";
                txtboxPassword.Text = "";
                txtboxUsername.Enabled = false;
                txtboxPassword.Enabled = false;
                btnLogin.Visible = false;
                btnLogin.Enabled = false;
                menuButtonP.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Username Declaration
            String usernameLogin = txtboxUsername.Text;
            String userPassword = txtboxPassword.Text;

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;

            DataTable dt = new DataTable();

            //Check user login
            using (con)
            {
                con.Open();
                String sqlString = "Select * From user_details Where username='" + usernameLogin + "' AND password='" + userPassword + "'";
                OleDbCommand commandString = new OleDbCommand(sqlString, con);

                using (OleDbDataReader dr = commandString.ExecuteReader())
                {
                    //Found User
                    while (dr.Read())
                    {
                        //Create Session
                        if (Session["username"] == null)
                        {
                            Session["userID"] = dr["ID"].ToString();
                            Session["username"] = txtboxUsername.Text;

                            //Retrieve session id
                            String sessionId2 = System.Web.HttpContext.Current.Session.SessionID;
                            //ClientScript.RegisterStartupScript(this.GetType(), "testing2", "alert(' Session Created! Name: " + sessionId2 + "');", true);

                            //ClientScript.RegisterStartupScript(this.GetType(), "Log In", "alert('Successfully Log in');", true);
                            //GUI change after Success Login
                            menuButtonP.Visible = true;
                            usernameP.Visible = false;
                            passwordP.Visible = false;
                            txtboxUsername.Visible = false;
                            txtboxPassword.Visible = false;
                            txtboxUsername.Enabled = false;
                            txtboxPassword.Enabled = false;
                            btnLogin.Visible = false;
                        }
                        else
                        {
                            //ClientScript.RegisterStartupScript(this.GetType(), "testing", "alert(' Existing Session Name:" + Session["username"] + "! Please logout previous session');", true);
                        }

                        //Found User, update status
                        using (con2)
                        {
                            con2.Open();
                            String sqlUpdateUserStatus = "Update user_details Set onlineStatus='online' Where username='" + usernameLogin + "'";
                            OleDbCommand commandUpdateString = new OleDbCommand(sqlUpdateUserStatus, con2);

                            using (commandUpdateString)
                            {
                                commandUpdateString.ExecuteNonQuery();
                            }
                        }
                        con2.Close();
                    }
                }
            }
            con.Close();
        }
    }
}