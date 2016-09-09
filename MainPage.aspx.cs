using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Globalization;

namespace CI_Gwap
{
    public partial class TestingWebform1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAllTimeTable();
            loadWeeklyTable();

            string userRegistration = Request.QueryString["Complete"];
            if (userRegistration == "registered")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Complete Registration", "alert(' Congratulation, your registration is completed ');", true);
            }
            else
            {
                //nothing happen
            }
        }

        public void loadAllTimeTable()
        {
            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlSearchString = "Select L.userName as Player_Name, L.allTimeScore as All_Time_Score From leaderboard_details L Order By L.allTimeScore DESC";
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlSearchString, con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                DataTable dt2 = SelectTopDataRow(dt, 10);

                alltimeGridView.DataSource = dt2;
                alltimeGridView.DataBind();
            }
            con.Close();
        }

        public void loadWeeklyTable()
        {
            DateTime todayDate = DateTime.Now;
            int weekNumber = GetWeekNumber(todayDate);

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlSearchString = "Select L.username as Player_Name, L.weeklyScore as All_Time_Score From leaderboard_details L Where L.weekNumber=" + weekNumber + " Order By L.allTimeScore DESC";
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlSearchString, con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                DataTable dt2 = SelectTopDataRow(dt, 10);

                if (dt.Rows.Count == 0)
                {
                    lblWeekly.Text = "Sadly, No Players Played Yet this week. Grab your rank!";
                }
                else
                {
                    weeklyGridView.DataSource = dt2;
                    weeklyGridView.DataBind();
                }
            }
            con.Close();
        }

        public DataTable SelectTopDataRow(DataTable dt, int count)
        {
            DataTable dtn = dt.Clone();
            for (int i = 0; i < count; i++)
            {
                if (dt.Rows.Count <= i)
                {
                    //stop
                    break;
                }
                else
                {
                    dtn.ImportRow(dt.Rows[i]);
                }
            }

            return dtn;
        }

        public static int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }
    }
}