using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace CI_Gwap.PlayPages
{
    public partial class MatchPlayer : System.Web.UI.Page
    {
        private int sessionId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMatchingText.Text = "Click Search to Find Challenger";
            loadingImage.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Update Player Status
            updatePlayerStatus();

            //Declaration
            int currentUser = Int32.Parse(Session["userID"].ToString());
            int randomOnlineUser=0;
            Boolean pairedUser;

            //Declaration on checking Searching game users
            int[] onlineUserResult;
            onlineUserResult = pairOnlineUser();

            if (onlineUserResult.Length > 0)
            {
                //Found online users
                lblMatchingText.Text = "Player Found";

                Random r = new Random();
                int maxCount = onlineUserResult.Length;
                randomOnlineUser = onlineUserResult[r.Next(maxCount)];
                //ClientScript.RegisterStartupScript(this.GetType(), "testing", "alert(' Random Number:" + randomOnlineUser + "');", true);

                //Search is current user paired
                pairedUser = searchPaired(currentUser);

                //Pair with another Searching User
                if (pairedUser == true)
                {
                    //User already added into database
                }
                else
                {
                    //Add user into database
                    insertPairUsers(currentUser, randomOnlineUser);
                    lblMatchingText.Text = "Ready and Start!";
                    btnSearch.Visible = false;
                    btnReady.Visible = true;
                }
            }
            else
            {
                //Fail to find online user, wait for the next online user
                pairedUser = searchPaired(currentUser);
                while (pairedUser == false)
                {
                    //Loop to keep search in database //false means still doesn't have a pair
                    pairedUser = searchPaired(currentUser);
                }
            }
        }

        protected void updatePlayerStatus()
        {
            //Declaration
            String currentUser = Session["userID"].ToString();

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            DataTable dt = new DataTable();

            //Check online users
            using (con)
            {
                con.Open();
                String sqlUpdateString = "Update user_details Set onlineStatus='Searching' Where ID=" + currentUser;
                OleDbCommand commandString = new OleDbCommand(sqlUpdateString, con);
                //OleDbDataReader dr = commandString.ExecuteReader();
                commandString.ExecuteNonQuery();
            }
            con.Close();
        }

        public int[] pairOnlineUser()
        {
            //Array Declarations
            String[] onlineUser;
            int[] onlineUsers;

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            DataTable dt = new DataTable();

            //Check online users
            using (con)
            {
                con.Open();
                String sqlString = "Select ID From user_details Where onlineStatus='Searching'";
                OleDbCommand commandString = new OleDbCommand(sqlString, con);

                OleDbDataAdapter adapter = new OleDbDataAdapter(commandString);
                adapter.Fill(dt);

                gridViewOnlineUsers.DataSource = dt;
                gridViewOnlineUsers.DataBind();

                List<string> list = new List<string>();
                for (int i = 0; i < gridViewOnlineUsers.Rows.Count; i++)
                {
                    String value = gridViewOnlineUsers.Rows[i].Cells[0].Text;
                    String userId = Session["userID"].ToString();
                    if (value == userId)
                    {
                        //Do nothing
                        //Remove self from the online users list
                    }
                    else
                    {
                        list.Add(value);
                    }
                }

                //Convert to Integer Array
                onlineUser = list.ToArray();
                onlineUsers = new int[onlineUser.Length];
                for (int i = 0; i < onlineUser.Length; i++)
                {
                    onlineUsers[i] = Convert.ToInt16(onlineUser[i]);
                }
            }
            con.Close();

            return onlineUsers;
        }

        public void insertPairUsers(int currentUser, int randomOnlineUser)
        {
            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            DataTable dt = new DataTable();

            //Insert Into Pair List
            using (con)
            {
                con.Open();
                String sqlInsertString = "Insert Into pairUsers_details (user1, user2) values('" + currentUser + "','" + randomOnlineUser + "')";
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con);
                commandString.ExecuteNonQuery();
            }
            con.Close();
        }

        public Boolean searchPaired(int currentUser)
        {
            //Declaration
            Boolean pairedResult=false;

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            DataTable dt = new DataTable();

            //Insert Into Pair List
            using (con)
            {
                con.Open();
                String sqlInsertString = "Select * from pairUsers_details Where user2='" + currentUser + "'";
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    //Found in database as another user's random number pair
                    pairedResult = true;
                    lblMatchingText.Text = "Ready and Start!";
                    btnSearch.Visible = false;
                    btnReady.Visible = true;
                }
            }
            con.Close();

            return pairedResult;
        }

        protected void btnReady_Click(object sender, EventArgs e)
        {
            //Declaration
            String currentUser = Session["userID"].ToString();

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            DataTable dt = new DataTable();

            //Search Paired User's session Id
            using (con)
            {
                con.Open();
                String sqlSearchString = "Select * From pairUsers_details Where user1='" + currentUser + "' OR user2='" + currentUser +"'";
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                ClientScript.RegisterStartupScript(this.GetType(), "testing2", "alert('" + sqlSearchString + "');", true);

                while (dr.Read())
                {
                    //Found in database 
                    sessionId = int.Parse(dr["sessionId"].ToString());
                }
            }
            con.Close();

            //Redirect User to play page
            Response.Redirect("~/PlayPages/PlayPage.aspx?SessionId=" + sessionId+ "&QuestionCounter=1&TimeUsed=0");
        }
    }
}