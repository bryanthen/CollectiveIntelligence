using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Globalization;

namespace CI_Gwap.LeaderboardPages
{
    public partial class LeaderboardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAllTimeTable();
            loadWeeklyTable();

            if (Request.QueryString["UserCheck"] == "true")
            {
                //User directed after play page finish
                int userRetrieveRanking = loadUserAllTimeTable();
                userRankinglbl.Text = "Your Current All Time Ranking:" + userRetrieveRanking.ToString();
            }
            else
            {
                //Nothing happen
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

        //count parameter will be getting 10 from loadAllTimeTable() method
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

        public int loadUserAllTimeTable()
        {
            int currentUser = Int32.Parse(Session["userID"].ToString());
            int userRanking = 0;
            string userName = "";

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con1 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con1.ConnectionString = dbProvider + dbSource;

            //Retrieve User's username
            using (con)
            {
                con.Open();
                String sqlSearchString = "Select * From user_details Where ID=" + currentUser;
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    userName = dr["username"].ToString();
                }
            }
            con.Close();

            //Reconstruct entire all time leaderboard without top N value
            using (con1)
            {
                con1.Open();
                String sqlSearchString = "Select L.userName as Player_Name, L.allTimeScore as All_Time_Score From leaderboard_details L Order By L.allTimeScore DESC";
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con1);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlSearchString, con1);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                hiddenUserGridView.DataSource = dt;
                hiddenUserGridView.DataBind();
            }
            con1.Close();

            //Retrieve user's all time ranking
            for (int i = 0; i < hiddenUserGridView.Rows.Count; i++)
            {
                if (userName == hiddenUserGridView.Rows[i].Cells[1].Text)
                {
                    //userRanking = int.Parse(hiddenUserGridView.Rows[i].Cells[0].Text);
                    userRanking = i+1;
                }
            }

            return userRanking;
        }
    }
}