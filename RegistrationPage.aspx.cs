using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Globalization;

namespace CI_Gwap
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            string v_username = txtboxUsername.Text;
            string v_emailaddress = txtemailAddress.Text;
            string v_password = txtboxPassword.Text;
            string v_country = txtCountry.Text;
            int userId=0;

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();
            OleDbConnection con3 = new OleDbConnection();
            OleDbConnection con4 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;
            con3.ConnectionString = dbProvider + dbSource;
            con4.ConnectionString = dbProvider + dbSource;

            //Insert into user_details
            using (con)
            {
                con.Open();
                String sqlInsertString = "Insert Into user_details ([username], [emailAddress], [password], [onlineStatus]) values('" + v_username + "','" + v_emailaddress + "','" + v_password + "', 'offline')";
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con);
                commandString.ExecuteNonQuery();
            }
            con.Close();

            //Retrieve userId
            using (con2)
            {
                //Answered question and insert into database
                con2.Open();
                String sqlInsertString = "Select * From user_details Where emailAddress='" + v_emailaddress +"'";
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con2);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    userId = int.Parse(dr["ID"].ToString());
                }
            }
            con2.Close();

            //Insert into status_details
            using (con3)
            {
                con3.Open();
                String sqlInsertString = "Insert Into profile_details (userId, userExperiencePoint, userStatusExperiencePoint, countryOfOrigin) values('" + userId + "', 0, 0,'" + v_country + "')";
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con3);
                commandString.ExecuteNonQuery();
            }
            con3.Close();

            //Insert into leaderboard_details
            DateTime todayDate = DateTime.Now;
            int weekNumber = GetWeekNumber(todayDate);

            using (con4)
            {
                con4.Open();
                String sqlInsertString = "Insert Into leaderboard_details ([userName], [allTimeScore], [weeklyScore], [weekNumber]) values('" + v_username + "', 0, 0, " + weekNumber + ")";
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con4);
                commandString.ExecuteNonQuery();
            }
            con4.Close();

            Response.Redirect("MainPage.aspx?Complete=registered");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        public static int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }
    }
}