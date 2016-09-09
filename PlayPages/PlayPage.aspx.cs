using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Globalization;

namespace CI_Gwap.PlayPages
{
    public partial class PlayPage : System.Web.UI.Page
    {
        private int user1 = 0;
        private int user2 = 0;
        private int questionId = 0;
        private int questionCounter =0;
        public int v_timerCount = 29000;
        public string v_timeUsed;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "testing2", "alert(' Random Question:" + randomQuestionId + "');", true);
            //Update player's status 
            updatePlayerStatus();

            if (!IsPostBack)
            {
                hid_Ticker.Value = new TimeSpan(0, 0, 0).ToString();
            }

            //Check timer left
            Boolean proceed = checkTimer();
            if (proceed == true)
            {
                questionCounter = int.Parse(Request.QueryString["QuestionCounter"]);
                loadQuestion(questionCounter);

                //Calculate timer
                int timeUsedPreviously = int.Parse(Request.QueryString["TimeUsed"]);
                v_timerCount = v_timerCount - (timeUsedPreviously * 1000);
                hiddenLabel.Text = v_timerCount.ToString();

                //Retrieve Score
                int totalScore = retrieveTotalScore();
                txtboxScore.Text = totalScore.ToString();
            }
            else
            {
                updateInLeaderBoard();
                ClientScript.RegisterStartupScript(this.GetType(), "Completed", "alert(' Timer Stopped. Game Completed ');", true);
                
                //Initiate Bonus Round if user got 10 corrects together
                int totalScore = retrieveTotalScore();
                int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

                //If total score more than 1000 // OR Add timer with 30seconds
                if (totalScore > 1000)
                {
                    questionCounter++;
                    Response.Redirect("~/PlayPages/PlayPage.aspx?SessionId=" + sessionIdFromURL + "&QuestionCounter=" + questionCounter + "&TimeUsed=30");
                }
                else
                {
                    //END of game
                    Response.Redirect("~/LeaderboardPages/LeaderboardPage.aspx?UserCheck=true");
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
                String sqlUpdateString = "Update user_details Set onlineStatus='Playing' Where ID=" + currentUser;
                OleDbCommand commandString = new OleDbCommand(sqlUpdateString, con);
                //OleDbDataReader dr = commandString.ExecuteReader();
                commandString.ExecuteNonQuery();
            }
            con.Close();
        }

        protected void cmdCompleteGameField_Click(object sender, EventArgs e)
        {
            //Complete entire game play
            //ClientScript.RegisterStartupScript(this.GetType(), "Completed", "alert(' Game Completed ');", true);
            
        }

        public Boolean checkTimer()
        {
            Boolean leftTime = false;
            int timeUsedPreviously = int.Parse(Request.QueryString["TimeUsed"]);

            if (timeUsedPreviously > 25)
            {
                leftTime = false;
            }
            else
            {
                leftTime = true;
            }

            return leftTime;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            hid_Ticker.Value = TimeSpan.Parse(hid_Ticker.Value).Add(new TimeSpan(0, 0, 1)).ToString();
            lit_Timer.Text = hid_Ticker.Value.ToString();
        }

        public void loadQuestion(int questionCounter)
        {
            //Declaration
            //String currentUser = Session["userID"].ToString();
            int crimeType = 0;
            int questionImageId = 0;
            int questionAnswerList = 0;

            //Count Database Question Declaration
            int questionCount = databaseQuestionResult();

            //Question's answers declaration
            int optionOneId = 0;
            int optionTwoId = 0;
            int optionThreeId = 0;
            int optionFourId = 0;

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();
            OleDbConnection con3 = new OleDbConnection();
            OleDbConnection con4 = new OleDbConnection();
            OleDbConnection con5 = new OleDbConnection(); //OptionOne
            OleDbConnection con6 = new OleDbConnection(); //OptionTwo
            OleDbConnection con7 = new OleDbConnection(); //OptionThree
            OleDbConnection con8 = new OleDbConnection(); //OptionFour

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;
            con3.ConnectionString = dbProvider + dbSource;
            con4.ConnectionString = dbProvider + dbSource;
            con5.ConnectionString = dbProvider + dbSource; //OptionOne
            con6.ConnectionString = dbProvider + dbSource; //OptionTwo
            con7.ConnectionString = dbProvider + dbSource; //OptionThree
            con8.ConnectionString = dbProvider + dbSource; //OptionFour

            //Read Question from database
            using (con)
            {
                //Random Question
                //Random r = new Random();
                //int randomQuestionId = r.Next(1, questionCount);

                con.Open();
                String sqlSelectString = "Select * From question Where questionId=" + questionCounter;
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    //Retrieve Question from database
                    questionId = int.Parse(dr["questionId"].ToString());
                    questionAnswerList = int.Parse(dr["answerListId"].ToString());
                    questionImageId = int.Parse(dr["questionImageId"].ToString());
                    txtQuestion.Text = dr["questionString"].ToString();
                    crimeType = int.Parse(dr["crimeId"].ToString());

                    //Retrieve Question's Crime Details
                    using (con2)
                    {
                        con2.Open();
                        String sqlCrimeString = "Select * From crime_details Where crimeId=" + crimeType;
                        OleDbCommand commandCrimeString = new OleDbCommand(sqlCrimeString, con2);
                        OleDbDataReader dr2 = commandCrimeString.ExecuteReader();

                        while (dr2.Read())
                        {
                            //Found Crime Details
                            lblCrimeType.Text = dr2["crimeType"].ToString();
                            lblCrimeCountry.Text = dr2["crimeCountry"].ToString();
                        }
                    }
                    con2.Close();

                    //Retrieve Question's Image
                    using (con3)
                    {
                        con3.Open();
                        String sqlImageString = "Select * From image_details Where imageId=" + questionImageId;
                        OleDbCommand commandImageString = new OleDbCommand(sqlImageString, con3);
                        OleDbDataReader dr3 = commandImageString.ExecuteReader();

                        while(dr3.Read()){
                            //Found Image for Question
                            questionImage.ImageUrl = dr3["imagePath"].ToString();
                        }
                    }
                    con3.Close();

                    //Retrieve Question's Answer's Image ID
                    using (con4)
                    {
                        con4.Open();
                        String sqlAnswerString = "Select * From answer_list_details Where answerListId=" + questionAnswerList;
                        OleDbCommand commandAnswerString = new OleDbCommand(sqlAnswerString, con4);
                        OleDbDataReader dr4 = commandAnswerString.ExecuteReader();

                        while (dr4.Read())
                        {
                            //Found AnswerList in database for specified question
                            optionOneId = int.Parse(dr4["optionOne"].ToString());
                            optionTwoId = int.Parse(dr4["optionTwo"].ToString());
                            optionThreeId = int.Parse(dr4["optionThree"].ToString());
                            optionFourId = int.Parse(dr4["optionFour"].ToString());
                        }
                    }
                    con4.Close();

                    //Retrieve Answer Image's File Path //Option One
                    using(con5)
                    {
                        con5.Open();
                        String sqlOptionOneImageString = "Select * From image_details Where imageId=" + optionOneId;
                        OleDbCommand commandOptionOneImageString = new OleDbCommand(sqlOptionOneImageString, con5);
                        OleDbDataReader dr5 = commandOptionOneImageString.ExecuteReader();
                        
                        while (dr5.Read())
                        {
                            imageOptionOne.ImageUrl = dr5["imagePath"].ToString();
                        }
                    }
                    con5.Close();

                    //Retrieve Answer Image's File Path //Option Two
                    using (con6)
                    {
                        con6.Open();
                        String sqlOptionTwoImageString = "Select * From image_details Where imageId=" + optionTwoId;
                        OleDbCommand commandOptionTwoImageString = new OleDbCommand(sqlOptionTwoImageString, con6);
                        OleDbDataReader dr6 = commandOptionTwoImageString.ExecuteReader();

                        while (dr6.Read())
                        {
                            imageOptionTwo.ImageUrl = dr6["imagePath"].ToString();
                        }
                    }
                    con6.Close();

                    //Retrieve Answer Image's File Path //Option Three
                    using (con7)
                    {
                        con7.Open();
                        String sqlOptionThreeImageString = "Select * From image_details Where imageId=" + optionThreeId;
                        OleDbCommand commandOptionThreeImageString = new OleDbCommand(sqlOptionThreeImageString, con7);
                        OleDbDataReader dr7 = commandOptionThreeImageString.ExecuteReader();

                        while (dr7.Read())
                        {
                            imageOptionThree.ImageUrl = dr7["imagePath"].ToString();
                        }
                    }
                    con7.Close();

                    //Retrieve Answer Image's File Path //Option Four
                    using (con8)
                    {
                        con8.Open();
                        String sqlOptionFourImageString = "Select * From image_details Where imageId=" + optionFourId;
                        OleDbCommand commandOptionFourImageString = new OleDbCommand(sqlOptionFourImageString, con8);
                        OleDbDataReader dr8 = commandOptionFourImageString.ExecuteReader();

                        while (dr8.Read())
                        {
                            imageOptionFour.ImageUrl = dr8["imagePath"].ToString();
                        }
                    }
                    con8.Close();
                }
            }
            con.Close();
        }

        protected int databaseQuestionResult()
        {
            int databaseQuestionCount=0;

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            //Read Question from database
            using (con)
            {
                con.Open();
                String sqlUpdateString = "Select * From question";
                OleDbCommand commandString = new OleDbCommand(sqlUpdateString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    //Count the number of question in database
                    databaseQuestionCount++;
                }
            }
            con.Close();

            return databaseQuestionCount;
        }

        public void loadPairedUsers()
        {
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            //Database Declaration
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlCheckString = "Select * From pairUsers_details Where sessionId= "+ sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlCheckString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    //Found Pair
                    user1 = int.Parse(dr["user1"].ToString());
                    user2 = int.Parse(dr["user2"].ToString());
                }
            }
            con.Close();
        }

        protected void imageOptionOne_Click(object sender, ImageClickEventArgs e)
        {
            int currentUser = Int32.Parse(Session["userID"].ToString());
            Boolean answered = checkAnswered(currentUser);
            
            if (answered == false)
            {
                //If answered is false, then insert a new record
                insertAnswer(currentUser, 1);
            }
            else
            {
                //If answer is true, record already exist, partner answered
                partnerInsertAnswer(currentUser,1);
            }

            //wait for both users reply
            Boolean bothAnswered = checkBothAnswered();
            while (bothAnswered == false)
            {
                //Loop until both users answered only load another question
                bothAnswered = checkBothAnswered();
            }

            //Retrieve score
            int score= checkScore();

            //Timer Count
            double tickerTime = TimeSpan.Parse(hid_Ticker.Value).TotalSeconds;
            int timeUsedPreviously = int.Parse(Request.QueryString["TimeUsed"]);
            int totalTimeSpend = Convert.ToInt16(tickerTime) + timeUsedPreviously;
            hiddenLabel.Text = totalTimeSpend.ToString();
            v_timeUsed = hiddenLabel.Text;

            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);
            questionCounter++;
            Response.Redirect("~/PlayPages/PlayPage.aspx?SessionId=" + sessionIdFromURL + "&QuestionCounter=" + questionCounter + "&TimeUsed=" + v_timeUsed);
        }

        protected void imageOptionTwo_Click(object sender, ImageClickEventArgs e)
        {
            int currentUser = Int32.Parse(Session["userID"].ToString());
            Boolean answered = checkAnswered(currentUser);

            if (answered == false)
            {
                //If answered is false, then insert a new record
                insertAnswer(currentUser, 2);
            }
            else
            {
                //If answer is true, record already exist, partner answered
                partnerInsertAnswer(currentUser, 2);
            }

            //wait for both users reply
            Boolean bothAnswered = checkBothAnswered();
            while (bothAnswered == false)
            {
                //Loop until both users answered only load another question
                bothAnswered = checkBothAnswered();
            }

            //Retrieve score
            int score = checkScore();

            //Timer Count
            double tickerTime = TimeSpan.Parse(hid_Ticker.Value).TotalSeconds;
            int timeUsedPreviously = int.Parse(Request.QueryString["TimeUsed"]);
            int totalTimeSpend = Convert.ToInt16(tickerTime) + timeUsedPreviously;
            hiddenLabel.Text = totalTimeSpend.ToString();
            v_timeUsed = hiddenLabel.Text;

            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);
            questionCounter++;
            Response.Redirect("~/PlayPages/PlayPage.aspx?SessionId=" + sessionIdFromURL + "&QuestionCounter=" + questionCounter + "&TimeUsed=" + v_timeUsed);
        }

        protected void imageOptionThree_Click(object sender, ImageClickEventArgs e)
        {
            int currentUser = Int32.Parse(Session["userID"].ToString());
            Boolean answered = checkAnswered(currentUser);

            if (answered == false)
            {
                //If answered is false, then insert a new record
                insertAnswer(currentUser, 3);
            }
            else
            {
                //If answer is true, record already exist, partner answered
                partnerInsertAnswer(currentUser, 3);
            }

            //wait for both users reply
            Boolean bothAnswered = checkBothAnswered();
            while (bothAnswered == false)
            {
                //Loop until both users answered only load another question
                bothAnswered = checkBothAnswered();
            }

            //Retrieve score
            int score = checkScore();

            //Timer Count
            double tickerTime = TimeSpan.Parse(hid_Ticker.Value).TotalSeconds;
            int timeUsedPreviously = int.Parse(Request.QueryString["TimeUsed"]);
            int totalTimeSpend = Convert.ToInt16(tickerTime) + timeUsedPreviously;
            hiddenLabel.Text = totalTimeSpend.ToString();
            v_timeUsed = hiddenLabel.Text;

            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);
            questionCounter++;
            Response.Redirect("~/PlayPages/PlayPage.aspx?SessionId=" + sessionIdFromURL + "&QuestionCounter=" + questionCounter + "&TimeUsed=" + v_timeUsed);
        }

        protected void imageOptionFour_Click(object sender, ImageClickEventArgs e)
        {
            int currentUser = Int32.Parse(Session["userID"].ToString());
            Boolean answered = checkAnswered(currentUser);

            if (answered == false)
            {
                //If answered is false, then insert a new record
                insertAnswer(currentUser, 4);
            }
            else
            {
                //If answer is true, record already exist, partner answered
                partnerInsertAnswer(currentUser, 4);
            }

            //wait for both users reply
            Boolean bothAnswered = checkBothAnswered();
            while (bothAnswered == false)
            {
                //Loop until both users answered only load another question
                bothAnswered = checkBothAnswered();
            }

            //Retrieve score
            int score = checkScore();

            //Timer Count
            double tickerTime = TimeSpan.Parse(hid_Ticker.Value).TotalSeconds;
            int timeUsedPreviously = int.Parse(Request.QueryString["TimeUsed"]);
            int totalTimeSpend = Convert.ToInt16(tickerTime) + timeUsedPreviously;
            hiddenLabel.Text = totalTimeSpend.ToString();
            v_timeUsed = hiddenLabel.Text;

            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);
            questionCounter++;
            Response.Redirect("~/PlayPages/PlayPage.aspx?SessionId=" + sessionIdFromURL + "&QuestionCounter=" + questionCounter + "&TimeUsed=" + v_timeUsed);
        }

        protected Boolean checkAnswered(int currentUser)
        {
            Boolean answered = false;
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            //Database Declaration
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlReplyString = "Select * From reply_details Where questionId= " + questionId + " AND sessionId=" + sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlReplyString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    if (int.Parse(dr["userAnswer"].ToString()) == 0)
                    {
                        //Partner havent make any attempt
                        answered = false;
                    }
                    else
                    {
                        answered = true;
                    }
                }
            }
            con.Close();

            return answered;
        }

        protected void insertAnswer(int pairedUser, int userAnswer)
        {
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            //Database Declaration
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                //Answered question and insert into database
                con.Open();
                String sqlInsertString = "Insert Into reply_details (questionId, pairedUser, userAnswer, sessionId) values('" + questionId + "','" + pairedUser + "','" + userAnswer + "','" + sessionIdFromURL + "')";
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con);
                commandString.ExecuteNonQuery();
            }
            con.Close();
        }

        protected void partnerInsertAnswer(int pairedPartner, int partnerAnswer)
        {
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            //Database Declaration
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                //Answered question and insert into database
                con.Open();
                String sqlPartnerInsertString = "Update reply_details Set pairedPartner=" + pairedPartner + ", partnerAnswer=" + partnerAnswer + " Where questionId=" + questionId + " AND sessionId=" + sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlPartnerInsertString, con);
                commandString.ExecuteNonQuery();
            }
            con.Close();
        }

        protected Boolean checkBothAnswered()
        {
            Boolean bothAnswered = false;
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            //Database Declaration
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlReplyString = "Select * From reply_details Where questionId= " + questionId + " AND sessionId=" + sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlReplyString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    int user1Answer = int.Parse(dr["userAnswer"].ToString());
                    int user2Answer = int.Parse(dr["partnerAnswer"].ToString());
                    if (user1Answer == 0 && user2Answer == 0)
                    {
                        //either one side have not answered
                        bothAnswered = false;
                    }
                    else if(user1Answer != 0 && user2Answer != 0)
                    {
                        //both user answered
                        bothAnswered = true;
                    }
                }
            }
            con.Close();

            return bothAnswered;
        }

        protected int checkScore()
        {
            int retrievedScore = 0;
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            //Database Declaration
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlReplyString = "Select * From reply_details Where questionId= " + questionId + " AND sessionId=" + sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlReplyString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    int user1Answer = int.Parse(dr["userAnswer"].ToString());
                    int user2Answer = int.Parse(dr["partnerAnswer"].ToString());
                    if (user1Answer != user2Answer)
                    {
                        retrievedScore = 0;
                        headerLabel.Text = "Aww, your partner selected another";
                    }
                    else
                    {
                        retrievedScore = 100;
                        headerLabel.Text = "Congrats!";
                    }
                }
            }
            con.Close();

            using(con2){
                con2.Open();
                String sqlUpdateScore = "Update reply_details Set scoreObtained='" + retrievedScore + "' Where questionId=" + questionId + " AND sessionId=" + sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlUpdateScore, con2);
                commandString.ExecuteNonQuery();
            }
            con2.Close();

            return retrievedScore;
        }

        protected int retrieveTotalScore()
        {
            int totalScore = 0;
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            //Database Declaration
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlSelectString = "Select * From reply_details Where sessionId=" + sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    int currentScore = int.Parse(dr["scoreObtained"].ToString());
                    totalScore += currentScore;
                }
            }
            con.Close();

            return totalScore;
        }

        protected void updateInLeaderBoard()
        {
            //Declaration
            int currentUser = Int32.Parse(Session["userID"].ToString());
            string currentUserName = "" ;
            int allTimeScore = 0;
            int currentTotalScore = 0;

            //Database Declaration
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con1 = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();
            OleDbConnection con3= new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con1.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;
            con3.ConnectionString = dbProvider + dbSource;

            //Get username
            //Insert into leaderboard_details
            using (con)
            {
                con.Open();
                String sqlSelectString = "Select * From user_details Where ID=" + currentUser;
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    currentUserName = dr["userName"].ToString();
                }
            }
            con.Close();

            //Check if current obtained score higher than previous high score then replace
            using (con1)
            {
                con1.Open();
                String sqlSelectString = "Select * From leaderboard_details Where userName='" + currentUserName + "'";
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con1);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    allTimeScore = int.Parse(dr["allTimeScore"].ToString());

                    //Retrieve Current Score
                    currentTotalScore = retrieveTotalScore();

                    if (currentTotalScore > allTimeScore)
                    {
                        //Update leaderboard Alltime score
                        using (con2)
                        {
                            con2.Open();
                            String sqlUpdateString = "Update leaderboard_details Set allTimeScore=" + currentTotalScore + " Where userName='" + currentUserName +"'";
                            OleDbCommand commandUpdateString = new OleDbCommand(sqlUpdateString, con2);
                            commandUpdateString.ExecuteNonQuery();
                        }
                        con2.Close();
                    }
                    else
                    {
                        //nothing to update on all time scoreboard
                    }
                }
            }
            con1.Close();

            //Update Weekly Score
            DateTime todayDate = DateTime.Now;
            int weekNumber = GetWeekNumber(todayDate);

            using (con3)
            {
                con3.Open();
                String sqlUpdateString = "Update leaderboard_details Set weeklyScore=" + currentTotalScore + ", weekNumber=" + weekNumber + " Where userName='" + currentUserName +"'";
                OleDbCommand commandUpdateString = new OleDbCommand(sqlUpdateString, con3);
                commandUpdateString.ExecuteNonQuery();
            }
            con3.Close();
        }

        public static int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            //User selected Give Up as there are no match or unidentified image
            int sessionIdFromURL = int.Parse(Request.QueryString["SessionId"]);

            questionCounter++;

            //Search Database if Partner made attemp 
            //Database Declaration
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                //Answered question and insert into database
                con.Open();
                String sqlInsertString = "Select * From reply_details Where questionId=" + questionId + " And SessionId=" + sessionIdFromURL;
                OleDbCommand commandString = new OleDbCommand(sqlInsertString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    int userAnswer = int.Parse(dr["userAnswer"].ToString());
                    int partnerAnswer = int.Parse(dr["partnerAnswer"].ToString());

                    if(userAnswer != 0){
                        //Partner already made an answer
                        //But no score will be given since you gave up
                        //Update to database
                        int pairedPartner = Int32.Parse(Session["userID"].ToString());

                        using (con2)
                        {
                            con2.Open();
                            String sqlGiveUpString = "Update reply_details Set pairedPartner=" + pairedPartner + ", partnerAnswer= -1 Where questionId=" + questionId + " AND sessionId=" + sessionIdFromURL;
                            OleDbCommand commandGiveUpString = new OleDbCommand(sqlGiveUpString, con2);
                            commandGiveUpString.ExecuteNonQuery();
                        }
                        con2.Close();
                    }
                }
            }
            con.Close();

            //Update Scores
            //Retrieve score
            int score = checkScore();

            //Timer Count
            double tickerTime = TimeSpan.Parse(hid_Ticker.Value).TotalSeconds;
            int timeUsedPreviously = int.Parse(Request.QueryString["TimeUsed"]);
            int totalTimeSpend = Convert.ToInt16(tickerTime) + timeUsedPreviously;
            hiddenLabel.Text = totalTimeSpend.ToString();
            v_timeUsed = hiddenLabel.Text;

            Response.Redirect("~/PlayPages/PlayPage.aspx?SessionId=" + sessionIdFromURL + "&QuestionCounter=" + questionCounter + "&TimeUsed=" + v_timeUsed);
        }
    }
}