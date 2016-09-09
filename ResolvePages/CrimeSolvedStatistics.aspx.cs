using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace CI_Gwap.ResolvePages
{
    public partial class CrimeSolvedStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        public void loadTable()
        {
            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;

            using (con)
            {
                con.Open();
                String sqlSearchString = "Select Q.questionId, Q.questionString as Question, C.crimeId as Crime_Id, C.crimeType as Crime_Type, C.crimeCountry as Crime_Country, C.crimeUploadDate as Upload_Date, C.caseStatus as Case_Status From question Q, crime_details C Where Q.crimeId=C.crimeId";
                OleDbCommand commandString = new OleDbCommand(sqlSearchString, con);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlSearchString, con);
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            con.Close();
        }

        protected void YourGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string questionId = GridView1.SelectedRow.Cells[1].Text;
            
            Accordion1.RequireOpenedPane = false;
            Accordion1.SelectedIndex = -1;

            AccordionPane2.Visible = true;
            getAnswer(questionId);
        }

        public void getAnswer(string questionId)
        {
            //Declaration
            int answerListID = 0;
            int questionImageID = 0;
            int selectionOneCount = 0;
            int selectionTwoCount = 0;
            int selectionThreeCount = 0;
            int selectionFourCount = 0;

            //Database Connection Declarations
            OleDbConnection conn = new OleDbConnection();
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();
            OleDbConnection con3 = new OleDbConnection();
            OleDbConnection con4 = new OleDbConnection();
            OleDbConnection con5 = new OleDbConnection();
            OleDbConnection con6 = new OleDbConnection();
            OleDbConnection con7 = new OleDbConnection();
            OleDbConnection con8 = new OleDbConnection();
            OleDbConnection con9 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            conn.ConnectionString = dbProvider + dbSource;
            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;
            con3.ConnectionString = dbProvider + dbSource;
            con4.ConnectionString = dbProvider + dbSource;
            con5.ConnectionString = dbProvider + dbSource;
            con6.ConnectionString = dbProvider + dbSource;
            con7.ConnectionString = dbProvider + dbSource;
            con8.ConnectionString = dbProvider + dbSource;
            con9.ConnectionString = dbProvider + dbSource;

            //Get AnswerListID
            using (conn)
            {
                conn.Open();
                String sqlSearchAnswerListId = "Select * from question where questionId=" + questionId;
                OleDbCommand commandString = new OleDbCommand(sqlSearchAnswerListId, conn);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    answerListID = int.Parse(dr["answerListId"].ToString());
                    questionImageID = int.Parse(dr["questionImageId"].ToString());
                }
            }

            //Calculation of Option One on specified question
            using (con)
            {
                con.Open();
                String sqlUserAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND userAnswer=1";
                OleDbCommand commandUserAnswerString = new OleDbCommand(sqlUserAnswerString, con);
                selectionOneCount += int.Parse(commandUserAnswerString.ExecuteScalar().ToString());
            }
            con.Close();

            using (con2)
            {
                con2.Open();
                String sqlPartnerAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND partnerAnswer=1";
                OleDbCommand commandPartnerAnswerString = new OleDbCommand(sqlPartnerAnswerString, con2);
                selectionOneCount += int.Parse(commandPartnerAnswerString.ExecuteScalar().ToString());
            }
            con2.Close();

            //Calculation of Option Two on specified question
            using (con3)
            {
                con3.Open();
                String sqlUserAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND userAnswer=2";
                OleDbCommand commandUserAnswerString = new OleDbCommand(sqlUserAnswerString, con3);
                selectionTwoCount += int.Parse(commandUserAnswerString.ExecuteScalar().ToString());
            }
            con3.Close();

            using (con4)
            {
                con4.Open();
                String sqlPartnerAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND partnerAnswer=2";
                OleDbCommand commandPartnerAnswerString = new OleDbCommand(sqlPartnerAnswerString, con4);
                selectionTwoCount += int.Parse(commandPartnerAnswerString.ExecuteScalar().ToString());
            }
            con4.Close();

            //Calculation of Option Three on specified question
            using (con5)
            {
                con5.Open();
                String sqlUserAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND userAnswer=3";
                OleDbCommand commandUserAnswerString = new OleDbCommand(sqlUserAnswerString, con5);
                selectionThreeCount += int.Parse(commandUserAnswerString.ExecuteScalar().ToString());
            }
            con5.Close();

            using (con6)
            {
                con6.Open();
                String sqlPartnerAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND partnerAnswer=3";
                OleDbCommand commandPartnerAnswerString = new OleDbCommand(sqlPartnerAnswerString, con6);
                selectionThreeCount += int.Parse(commandPartnerAnswerString.ExecuteScalar().ToString());
            }
            con6.Close();

            //Calculation of Option Four on specified question
            using (con7)
            {
                con7.Open();
                String sqlUserAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND userAnswer=4";
                OleDbCommand commandUserAnswerString = new OleDbCommand(sqlUserAnswerString, con7);
                selectionFourCount += int.Parse(commandUserAnswerString.ExecuteScalar().ToString());
            }
            con7.Close();

            using (con8)
            {
                con8.Open();
                String sqlPartnerAnswerString = "Select count(*) From reply_details Where questionId=" + questionId + " AND partnerAnswer=4";
                OleDbCommand commandPartnerAnswerString = new OleDbCommand(sqlPartnerAnswerString, con8);
                selectionFourCount += int.Parse(commandPartnerAnswerString.ExecuteScalar().ToString());
            }
            con8.Close();

            using (con9)
            {
                con9.Open();
                String sqlQuestionImageString = "Select * From image_details Where imageId=" + questionImageID;
                OleDbCommand commandQuestionImage = new OleDbCommand(sqlQuestionImageString, con9);
                OleDbDataReader dr = commandQuestionImage.ExecuteReader();

                while (dr.Read())
                {
                    questionImage.ImageUrl = dr["imagePath"].ToString();
                }
            }
            con9.Close();

            retrieveImage(answerListID, selectionOneCount, selectionTwoCount, selectionThreeCount, selectionFourCount);
        }

        public void retrieveImage(int answerListId, int totalOneCount, int totalTwoCount, int totalThreeCount, int totalFourCount)
        {
            //Declaration
            int imageOptionOne = 0;
            int imageOptionTwo = 0;
            int imageOptionThree = 0;
            int imageOptionFour = 0;
            string optionOneImagePath = "";
            string optionTwoImagePath = "";
            string optionThreeImagePath = "";
            string optionFourImagePath = "";

            //Database Connection Declarations
            OleDbConnection con = new OleDbConnection();
            OleDbConnection con2 = new OleDbConnection();
            OleDbConnection con3 = new OleDbConnection();
            OleDbConnection con4 = new OleDbConnection();
            OleDbConnection con5 = new OleDbConnection();

            String dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
            String dbSource = "Data Source=C:\\Users\\4\\Visual Studio Project\\CI_Gwap\\CI_Gwap\\App_Data\\GwapDatabase.mdb";

            con.ConnectionString = dbProvider + dbSource;
            con2.ConnectionString = dbProvider + dbSource;
            con3.ConnectionString = dbProvider + dbSource;
            con4.ConnectionString = dbProvider + dbSource;
            con5.ConnectionString = dbProvider + dbSource;

            //Retrieve image ID
            using (con)
            {
                con.Open();
                String sqlAnswerListString = "Select * From answer_list_details Where answerListId=" + answerListId;
                OleDbCommand commandString = new OleDbCommand(sqlAnswerListString, con);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    imageOptionOne = int.Parse(dr["optionOne"].ToString());
                    imageOptionTwo = int.Parse(dr["optionTwo"].ToString());
                    imageOptionThree = int.Parse(dr["optionThree"].ToString());
                    imageOptionFour = int.Parse(dr["optionFour"].ToString());
                }
            }
            con.Close();

            //Retrieve option one image path
            using (con2)
            {
                con2.Open();
                String sqlSelectString = "Select * From image_details Where imageId=" + imageOptionOne;
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con2);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    optionOneImagePath = dr["imagePath"].ToString();
                }
            }
            con2.Close();

            //Retrieve option two image path
            using (con3)
            {
                con3.Open();
                String sqlSelectString = "Select * From image_details Where imageId=" + imageOptionTwo;
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con3);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    optionTwoImagePath = dr["imagePath"].ToString();
                }
            }
            con3.Close();

            //Retrieve option three image path
            using (con4)
            {
                con4.Open();
                String sqlSelectString = "Select * From image_details Where imageId=" + imageOptionThree;
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con4);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    optionThreeImagePath = dr["imagePath"].ToString();
                }
            }
            con4.Close();

            //Retrieve option four image path
            using (con5)
            {
                con5.Open();
                String sqlSelectString = "Select * From image_details Where imageId=" + imageOptionFour;
                OleDbCommand commandString = new OleDbCommand(sqlSelectString, con5);
                OleDbDataReader dr = commandString.ExecuteReader();

                while (dr.Read())
                {
                    optionFourImagePath = dr["imagePath"].ToString();
                }
            }
            con5.Close();

            //Calculation
            int totalCount = totalOneCount + totalTwoCount + totalThreeCount + totalFourCount;

            if (totalCount == 0)
            {
                imagestatDiv.Visible = false;
                notificationlbl.Text = "Unfortunately, No Responses made yet.";
            }
            else
            {
                imagestatDiv.Visible = true;
                int[] arrayKey = { totalOneCount, totalTwoCount, totalThreeCount, totalFourCount };
                string[] arrayValue = { optionOneImagePath, optionTwoImagePath, optionThreeImagePath, optionFourImagePath };
                Array.Sort(arrayKey, arrayValue);

                //Place Statistics
                int arrayCountForStat = 0;
                foreach (int key in arrayKey)
                {
                    decimal calculation;

                    if (arrayCountForStat == 0)
                    {
                        calculation = (Convert.ToDecimal(key) / Convert.ToDecimal(totalCount)) * 100;
                        image4span.Style[HtmlTextWriterStyle.Width] = calculation.ToString() + "%";
                        image4lbl.Text = key.ToString();
                        arrayCountForStat++;
                    }
                    else if (arrayCountForStat == 1)
                    {
                        calculation = (Convert.ToDecimal(key) / Convert.ToDecimal(totalCount)) * 100;
                        image3span.Style[HtmlTextWriterStyle.Width] = calculation.ToString() + "%";
                        image3lbl.Text = key.ToString();
                        arrayCountForStat++;
                    }
                    else if (arrayCountForStat == 2)
                    {
                        calculation = (Convert.ToDecimal(key) / Convert.ToDecimal(totalCount)) * 100;
                        image2span.Style[HtmlTextWriterStyle.Width] = calculation.ToString() + "%";
                        image2lbl.Text = key.ToString();
                        arrayCountForStat++;
                    }
                    else
                    {
                        calculation = (Convert.ToDecimal(key) / Convert.ToDecimal(totalCount)) * 100;
                        image1span.Style[HtmlTextWriterStyle.Width] = calculation.ToString() + "%";
                        image1lbl.Text = key.ToString();
                    }
                }

                //Place Image
                int arrayCountForImage = 0;
                foreach (string value in arrayValue)
                {
                    if (arrayCountForImage == 0)
                    {
                        Image4.ImageUrl = value;
                        arrayCountForImage++;
                    }
                    else if (arrayCountForImage == 1)
                    {
                        Image3.ImageUrl = value;
                        arrayCountForImage++;
                    }
                    else if (arrayCountForImage == 2)
                    {
                        Image2.ImageUrl = value;
                        arrayCountForImage++;
                    }
                    else
                    {
                        Image1.ImageUrl = value;
                    }
                }
            }
        }
    }
}