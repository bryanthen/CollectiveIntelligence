using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace CI_Gwap.ProfilePages
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        //Profile variable declaration
        private int userExperiencePoint = 0;
        private int userStatusExperiencePoint = 0;
        private string countryOfOrigin = "";

        private int level = 0;
        private int ranking = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadUserLevel();
            loadMeter();
        }

        public void loadUserLevel()
        {
            //Declaration
            String currentUser = Session["userID"].ToString();

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;

            //Search Profile Details
            using (con)
            {
                con.Open();
                String sqlSearchString = "Select * From profile_details Where userId=" + currentUser;
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    //Found in database 
                    userExperiencePoint = int.Parse(dr["userExperiencePoint"].ToString());
                    userStatusExperiencePoint = int.Parse(dr["userStatusExperiencePoint"].ToString());
                    countryOfOrigin = dr["countryOfOrigin"].ToString();
                }
            }
            con.Close();

            //Calculate User Level
            for (int i = 1; i < 999; i++)
            {
                if (userExperiencePoint > (i * 1000))
                {
                    level = level + i;
                }
                else
                {
                    level = 0;
                }
            }

            lblLevel.Text = "Level " + level.ToString();

            //Calculate Status Rank
            if (userStatusExperiencePoint < 1000)
            {
                ranking = 8;
            }
            else if (userStatusExperiencePoint >= 1000 && userStatusExperiencePoint < 2000)
            {
                ranking = 7;
            }
            else if (userStatusExperiencePoint >= 2000 && userStatusExperiencePoint < 3000)
            {
                ranking = 6;
            }
            else if (userStatusExperiencePoint >= 3000 && userStatusExperiencePoint < 4000)
            {
                ranking = 5;
            }
            else if (userStatusExperiencePoint >= 4000 && userStatusExperiencePoint < 8000)
            {
                ranking = 4;
            }
            else if (userStatusExperiencePoint >= 8000 && userStatusExperiencePoint < 16000)
            {
                ranking = 3;
            }
            else if (userStatusExperiencePoint >= 16000 && userStatusExperiencePoint < 32000)
            {
                ranking = 2;
            }else{
                ranking = 1;
            }

            ////Retrieve Status Details
            using (con2)
            {
                con2.Open();
                String sqlSearchString = "Select * From status_details Where ranking=" + ranking + " AND country='" + countryOfOrigin + "'";
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con2);
                OleDbDataReader dr2 = commandString.ExecuteReader();

                while (dr2.Read())
                {
                    //Found in database 
                    lblStatusLevel.Text = "Rank " + ranking.ToString() + ": " + dr2["statusName"].ToString();
                }
            }
            con2.Close();
        }

        public void loadMeter()
        {
            //Load user experience meter
            int meterCount = (userExperiencePoint / 100);
            int meterLength = 0;
            for (int i = 0; i < meterCount; i++)
            {
                meterLength++;
                if (meterLength > 10)
                {
                    meterLength = 1;
                }
            }

            string meterWidthLength = (meterLength * 10).ToString() + "%";
            userExperienceMeter.Style[HtmlTextWriterStyle.Width] = meterWidthLength;

            lblUserExperienceMeter.Text = (meterLength * 10).ToString() + "%";

            //Load user rank experience meter
            int meterStatusCount = (userStatusExperiencePoint / 100);
            int meterStatusLength = 0;
            for (int i = 0; i < meterStatusCount; i++)
            {
                meterStatusLength++;
                if (meterStatusLength > 10)
                {
                    meterStatusLength = 1;
                }
            }

            string meterStatusWidthLength = (meterStatusLength * 10).ToString() + "%";
            userStatusExperienceMeter.Style[HtmlTextWriterStyle.Width] = meterStatusWidthLength;

            lblUserStatusExperienceMeter.Text = (meterStatusLength * 10).ToString() + "%";
        }
    }
}