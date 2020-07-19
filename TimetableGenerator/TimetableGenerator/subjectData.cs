using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace TimetableGenerator
{
    public partial class subjectData : Form
    {

        public subjectData()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");
            con.Open();
            string query1 = "INSERT INTO SUBJECT1(SUBJ1, CHRS1, TEACHER1, SUBTYPE1, S_ID1)" +
                "VALUES(@sub, @chrs, @teacher, @type, @usid)";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            
            cmd1.Parameters.AddWithValue("@sub", sub1.Text);
            cmd1.Parameters.AddWithValue("@chrs", crd1.Text);
            cmd1.Parameters.AddWithValue("@teacher", t1.Text);
            cmd1.Parameters.AddWithValue("@type", th1.Text);
            cmd1.Parameters.AddWithValue("@usid", userID.Text);
            cmd1.ExecuteNonQuery();

            // --------------- Storing primary key value ---------------

            string storeID1 = "INSERT INTO TIMETABLE(T_ID) VALUE(@t_id)";
            SqlCommand cmd_id1 = new SqlCommand(storeID1, con);
            cmd_id1.Parameters.AddWithValue("@t_id", userID.Text);
            cmd_id1.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            string s1 = "INSERT INTO TIMETABLE(LEC1, LEC2, LEC3, LEC4, TBREAK LEC5, LEC6, LEC7) VALUES(@l1, @l2, @l3, @l4, @tbreak, @l5, @l6, @l7)";
            SqlCommand ls1 = new SqlCommand(s1, con);
            string var = "BREAK";
            string nill = "-";

            // ls1.Parameters.AddWithValue("@tbreak", var);

            if (th1.Text == "Lab" || th1.Text == "lab" || th1.Text == "l")
            {
                ls1.Parameters.AddWithValue("@l1", sub1.Text);
                ls1.Parameters.AddWithValue("@l2", sub1.Text);
                ls1.Parameters.AddWithValue("@l3", sub1.Text);
                ls1.Parameters.AddWithValue("@l4", nill);
            }
            else if(th1.Text=="Theory" || th1.Text == "theory" || th1.Text == "th")
            {
                if(crd1.Text=="1")
                {
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", nill);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if(crd1.Text=="2")
                {
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if(crd1.Text=="3")
                {
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                    ls1.Parameters.AddWithValue("@l3", sub1.Text);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
        //        ls1.ExecuteNonQuery();
            }
            //   con.Close();

            //------------------------------------   2   ------------------------------

            
            // con.Open();
            string query2 = "INSERT INTO SUBJECT2(SUBJ2, CHRS2, TEACHER2, SUBTYPE2, S_ID2)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd2.Parameters.AddWithValue("@sub", sub2.Text);
            cmd2.Parameters.AddWithValue("@crdhrs", crd2.Text);
            cmd2.Parameters.AddWithValue("@teacher", t2.Text);
            cmd2.Parameters.AddWithValue("@type", th2.Text);
            cmd2.Parameters.AddWithValue("@usid", userID.Text);
            cmd2.ExecuteNonQuery();
            // con.Close();

            // --------------------- TIMETABLE ------------------------

            if (th2.Text == "Lab" || th2.Text == "lab" || th2.Text == "l")
            {
                //ls1.Parameters.AddWithValue("@l4", nill);
                ls1.Parameters.AddWithValue("@tbreak", var);
                ls1.Parameters.AddWithValue("@l5", sub2.Text);
                ls1.Parameters.AddWithValue("@l6", sub2.Text);
                ls1.Parameters.AddWithValue("@l7", sub2.Text);
            }
            else if (th2.Text == "Theory" || th2.Text == "theory" || th2.Text == "th")
            {
                if (crd1.Text == "1")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub2.Text);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd1.Text == "2")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub2.Text);
                    ls1.Parameters.AddWithValue("@l6", sub2.Text);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd1.Text == "3")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub2.Text);
                    ls1.Parameters.AddWithValue("@l6", sub2.Text);
                    ls1.Parameters.AddWithValue("@l7", sub2.Text);
                }
                ls1.ExecuteNonQuery();
            }

            //------------------------------------   3   ------------------------------

            // con.Open();
            string query3 = "INSERT INTO SUBJECT3(SUBJ3, CHRS3, TEACHER3, SUBTYPE3, S_ID3)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd3 = new SqlCommand(query3, con);

            cmd3.Parameters.AddWithValue("@sub", sub3.Text);
            cmd3.Parameters.AddWithValue("@crdhrs", crd3.Text);
            cmd3.Parameters.AddWithValue("@teacher", t3.Text);
            cmd3.Parameters.AddWithValue("@type", th3.Text);
            cmd3.Parameters.AddWithValue("@usid", userID.Text);
            cmd3.ExecuteNonQuery();
            //  con.Close();

            // --------------- Storing primary key value ---------------

            string storeID2 = "INSERT INTO TIMETABLE(T_ID) VALUE(@t_id)";
            SqlCommand cmd_id2 = new SqlCommand(storeID2, con);
            cmd_id2.Parameters.AddWithValue("@t_id", userID.Text);
            cmd_id2.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            
            if (th3.Text == "Lab" || th3.Text == "lab" || th3.Text == "l")
            {
                ls1.Parameters.AddWithValue("@l1", sub3.Text);
                ls1.Parameters.AddWithValue("@l2", sub3.Text);
                ls1.Parameters.AddWithValue("@l3", sub3.Text);
                ls1.Parameters.AddWithValue("@l4", nill);
            }
            else if (th3.Text == "Theory" || th3.Text == "theory" || th3.Text == "th")
            {
                if (crd3.Text == "1")
                {
                    ls1.Parameters.AddWithValue("@l1", sub3.Text);
                    ls1.Parameters.AddWithValue("@l2", nill);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if (crd3.Text == "2")
                {
                    ls1.Parameters.AddWithValue("@l1", sub3.Text);
                    ls1.Parameters.AddWithValue("@l2", sub3.Text);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if (crd3.Text == "3")
                {
                    ls1.Parameters.AddWithValue("@l1", sub3.Text);
                    ls1.Parameters.AddWithValue("@l2", sub3.Text);
                    ls1.Parameters.AddWithValue("@l3", sub3.Text);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
            }

            //------------------------------------   4   ------------------------------

            //      con.Open();
            string query4 = "INSERT INTO SUBJECT4(SUBJ4, CHRS4, TEACHER4, SUBTYPE4, S_ID4)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd4 = new SqlCommand(query4, con);

            cmd4.Parameters.AddWithValue("@sub", sub4.Text);
            cmd4.Parameters.AddWithValue("@crdhrs", crd4.Text);
            cmd4.Parameters.AddWithValue("@teacher", t4.Text);
            cmd4.Parameters.AddWithValue("@type", th4.Text);
            cmd4.Parameters.AddWithValue("@usid", userID.Text);
            cmd4.ExecuteNonQuery();
            //            con.Close();


            // --------------------- TIMETABLE ------------------------

            if (th4.Text == "Lab" || th4.Text == "lab" || th4.Text == "l")
            {
                //ls1.Parameters.AddWithValue("@l4", nill);
                ls1.Parameters.AddWithValue("@tbreak", var);
                ls1.Parameters.AddWithValue("@l5", sub4.Text);
                ls1.Parameters.AddWithValue("@l6", sub4.Text);
                ls1.Parameters.AddWithValue("@l7", sub4.Text);
            }
            else if (th4.Text == "Theory" || th4.Text == "theory" || th4.Text == "th")
            {
                if (crd4.Text == "1")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub4.Text);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd1.Text == "2")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub4.Text);
                    ls1.Parameters.AddWithValue("@l6", sub4.Text);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd1.Text == "3")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub4.Text);
                    ls1.Parameters.AddWithValue("@l6", sub4.Text);
                    ls1.Parameters.AddWithValue("@l7", sub4.Text);
                }
                ls1.ExecuteNonQuery();
            }

            //------------------------------------   5   ------------------------------

            //  con.Open();
            string query5 = "INSERT INTO SUBJECT5(SUBJ5, CHRS5, TEACHER5, SUBTYPE5, S_ID5)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd5 = new SqlCommand(query5, con);

            cmd5.Parameters.AddWithValue("@sub", sub5.Text);
            cmd5.Parameters.AddWithValue("@crdhrs", crd5.Text);
            cmd5.Parameters.AddWithValue("@teacher", t5.Text);
            cmd5.Parameters.AddWithValue("@type", th5.Text);
            cmd5.Parameters.AddWithValue("@usid", userID.Text);
            cmd5.ExecuteNonQuery();
            //         con.Close();


            // --------------- Storing primary key value ---------------

            string storeID3 = "INSERT INTO TIMETABLE(T_ID) VALUE(@t_id)";
            SqlCommand cmd_id3 = new SqlCommand(storeID3, con);
            cmd_id3.Parameters.AddWithValue("@t_id", userID.Text);
            cmd_id3.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------


            if (th5.Text == "Lab" || th5.Text == "lab" || th5.Text == "l")
            {
                ls1.Parameters.AddWithValue("@l1", sub5.Text);
                ls1.Parameters.AddWithValue("@l2", sub5.Text);
                ls1.Parameters.AddWithValue("@l3", sub5.Text);
                ls1.Parameters.AddWithValue("@l4", nill);
            }
            else if (th5.Text == "Theory" || th5.Text == "theory" || th5.Text == "th")
            {
                if (crd5.Text == "1")
                {
                    ls1.Parameters.AddWithValue("@l1", sub5.Text);
                    ls1.Parameters.AddWithValue("@l2", nill);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if (crd5.Text == "2")
                {
                    ls1.Parameters.AddWithValue("@l1", sub5.Text);
                    ls1.Parameters.AddWithValue("@l2", sub5.Text);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if (crd5.Text == "3")
                {
                    ls1.Parameters.AddWithValue("@l1", sub5.Text);
                    ls1.Parameters.AddWithValue("@l2", sub5.Text);
                    ls1.Parameters.AddWithValue("@l3", sub5.Text);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
            }


            //------------------------------------   6   ------------------------------

            //      con.Open();
            string query6 = "INSERT INTO SUBJECT6(SUBJ6, CHRS6, TEACHER6, SUBTYPE6, S_ID6)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd6 = new SqlCommand(query6, con);

            cmd6.Parameters.AddWithValue("@sub", sub6.Text);
            cmd6.Parameters.AddWithValue("@crdhrs", crd6.Text);
            cmd6.Parameters.AddWithValue("@teacher", t6.Text);
            cmd6.Parameters.AddWithValue("@type", th6.Text);
            cmd6.Parameters.AddWithValue("@usid", userID.Text);
            cmd6.ExecuteNonQuery();
            //       con.Close();


            // --------------------- TIMETABLE ------------------------

            if (th6.Text == "Lab" || th6.Text == "lab" || th6.Text == "l")
            {
                //ls1.Parameters.AddWithValue("@l4", nill);
                ls1.Parameters.AddWithValue("@tbreak", var);
                ls1.Parameters.AddWithValue("@l5", sub6.Text);
                ls1.Parameters.AddWithValue("@l6", sub6.Text);
                ls1.Parameters.AddWithValue("@l7", sub6.Text);
            }
            else if (th6.Text == "Theory" || th6.Text == "theory" || th6.Text == "th")
            {
                if (crd6.Text == "1")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub6.Text);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd6.Text == "2")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub6.Text);
                    ls1.Parameters.AddWithValue("@l6", sub6.Text);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd6.Text == "3")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub6.Text);
                    ls1.Parameters.AddWithValue("@l6", sub6.Text);
                    ls1.Parameters.AddWithValue("@l7", sub6.Text);
                }
                ls1.ExecuteNonQuery();
            }


            //------------------------------------   7   ------------------------------

            //        con.Open();
            string query7 = "INSERT INTO SUBJECT7(SUBJ7, CHRS7, TEACHER7, SUBTYPE7, S_ID7)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd7 = new SqlCommand(query7, con);

            cmd7.Parameters.AddWithValue("@sub", sub7.Text);
            cmd7.Parameters.AddWithValue("@crdhrs", crd7.Text);
            cmd7.Parameters.AddWithValue("@teacher", t7.Text);
            cmd7.Parameters.AddWithValue("@type", th7.Text);
            cmd7.Parameters.AddWithValue("@usid", userID.Text);
            cmd7.ExecuteNonQuery();
            //      con.Close();

            // --------------- Storing primary key value ---------------

            string storeID4 = "INSERT INTO TIMETABLE(T_ID) VALUE(@t_id)";
            SqlCommand cmd_id4 = new SqlCommand(storeID2, con);
            cmd_id4.Parameters.AddWithValue("@t_id", userID.Text);
            cmd_id4.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------


            if (th7.Text == "Lab" || th7.Text == "lab" || th7.Text == "l")
            {
                ls1.Parameters.AddWithValue("@l1", sub7.Text);
                ls1.Parameters.AddWithValue("@l2", sub7.Text);
                ls1.Parameters.AddWithValue("@l3", sub7.Text);
                ls1.Parameters.AddWithValue("@l4", nill);
            }
            else if (th7.Text == "Theory" || th7.Text == "theory" || th7.Text == "th")
            {
                if (crd7.Text == "1")
                {
                    ls1.Parameters.AddWithValue("@l1", sub7.Text);
                    ls1.Parameters.AddWithValue("@l2", nill);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if (crd7.Text == "2")
                {
                    ls1.Parameters.AddWithValue("@l1", sub7.Text);
                    ls1.Parameters.AddWithValue("@l2", sub7.Text);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if (crd7.Text == "3")
                {
                    ls1.Parameters.AddWithValue("@l1", sub7.Text);
                    ls1.Parameters.AddWithValue("@l2", sub7.Text);
                    ls1.Parameters.AddWithValue("@l3", sub7.Text);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
            }


            //------------------------------------   8  -----------------------------

            //    con.Open();
            string query8 = "INSERT INTO SUBJECT8(SUBJ8, CHRS8, TEACHER8, SUBTYPE8, S_ID8)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd8 = new SqlCommand(query8, con);

            cmd8.Parameters.AddWithValue("@sub", sub8.Text);
            cmd8.Parameters.AddWithValue("@crdhrs", crd8.Text);
            cmd8.Parameters.AddWithValue("@teacher", t8.Text);
            cmd8.Parameters.AddWithValue("@type", th8.Text);
            cmd8.Parameters.AddWithValue("@usid", userID.Text);
            cmd8.ExecuteNonQuery();
            //         con.Close();

            // --------------------- TIMETABLE ------------------------

            if (th8.Text == "Lab" || th8.Text == "lab" || th8.Text == "l")
            {
                //ls1.Parameters.AddWithValue("@l4", nill);
                ls1.Parameters.AddWithValue("@tbreak", var);
                ls1.Parameters.AddWithValue("@l5", sub8.Text);
                ls1.Parameters.AddWithValue("@l6", sub8.Text);
                ls1.Parameters.AddWithValue("@l7", sub8.Text);
            }
            else if (th8.Text == "Theory" || th8.Text == "theory" || th8.Text == "th")
            {
                if (crd8.Text == "1")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub8.Text);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd8.Text == "2")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub8.Text);
                    ls1.Parameters.AddWithValue("@l6", sub8.Text);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd8.Text == "3")
                {
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub8.Text);
                    ls1.Parameters.AddWithValue("@l6", sub8.Text);
                    ls1.Parameters.AddWithValue("@l7", sub8.Text);
                }
                ls1.ExecuteNonQuery();
            }



            this.Hide();
            addData ss1 = new addData();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sub2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sub3_TextChanged(object sender, EventArgs e)
        {

        }

        private void th1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
