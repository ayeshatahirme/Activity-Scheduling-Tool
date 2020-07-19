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
            // ------------------------------- 1 ----------------------------
            string query1 = "INSERT INTO SUBJECT1(SUBJ1, CHRS1, TEACHER1, SUBTYPE1, S_ID1)" +
                "VALUES(@sub, @chrs, @teacher, @type, @usid)";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            
            cmd1.Parameters.AddWithValue("@sub", sub1.Text);
            cmd1.Parameters.AddWithValue("@chrs", crd1.Text);
            cmd1.Parameters.AddWithValue("@teacher", t1.Text);
            cmd1.Parameters.AddWithValue("@type", th1.Text);
            cmd1.Parameters.AddWithValue("@usid", userID.Text);
            cmd1.ExecuteNonQuery();

           
            // --------------------- TIMETABLE ------------------------

            string s1 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id, @l1, @l2, @l3, @l4, @tbreak, @l5, @l6, @l7)";
            SqlCommand ls1 = new SqlCommand(s1, con);
            string var = "BREAK";
            string nill = "-";
            
            // ls1.Parameters.AddWithValue("@tbreak", var);

            if (th1.Text == "Lab" || th1.Text == "lab" || th1.Text == "l")
            {
                ls1.Parameters.AddWithValue("@t_id", userID.Text);
                ls1.Parameters.AddWithValue("@l1", sub1.Text);
                ls1.Parameters.AddWithValue("@l2", sub1.Text);
                ls1.Parameters.AddWithValue("@l3", sub1.Text);
                ls1.Parameters.AddWithValue("@l4", nill);
            }
            else if(th1.Text=="Theory" || th1.Text == "theory" || th1.Text == "th")
            {
                if(crd1.Text=="1")
                {
                    ls1.Parameters.AddWithValue("@t_id", userID.Text);
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", nill);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if(crd1.Text=="2")
                {
                    ls1.Parameters.AddWithValue("@t_id", userID.Text);
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                    ls1.Parameters.AddWithValue("@l3", nill);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
                else if(crd1.Text=="3")
                {
                    ls1.Parameters.AddWithValue("@t_id", userID.Text);
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                    ls1.Parameters.AddWithValue("@l3", sub1.Text);
                    ls1.Parameters.AddWithValue("@l4", nill);
                }
        //        ls1.ExecuteNonQuery();
            }
            else
            {
                ls1.Parameters.AddWithValue("@t_id", userID.Text);
                ls1.Parameters.AddWithValue("@l1", nill);
                ls1.Parameters.AddWithValue("@l2", nill);
                ls1.Parameters.AddWithValue("@l3", nill);
                ls1.Parameters.AddWithValue("@l4", nill);
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
            else
            {
                ls1.Parameters.AddWithValue("@tbreak", var);
                ls1.Parameters.AddWithValue("@l5", nill);
                ls1.Parameters.AddWithValue("@l6", nill);
                ls1.Parameters.AddWithValue("@l7", nill);
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
            
            // --------------------- TIMETABLE ------------------------
            string s2 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id_2, @l1_2, @l2_2, @l3_2, @l4_2, @tbreak_2, @l5_2, @l6_2, @l7_2)";
            SqlCommand ls2 = new SqlCommand(s2, con);

            if (th3.Text == "Lab" || th3.Text == "lab" || th3.Text == "l")
            {
                ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                ls2.Parameters.AddWithValue("@l2_2", sub3.Text);
                ls2.Parameters.AddWithValue("@l3_2", sub3.Text);
                ls2.Parameters.AddWithValue("@l4_2", nill);
            }
            else if (th3.Text == "Theory" || th3.Text == "theory" || th3.Text == "th")
            {
                if (crd3.Text == "1")
                {
                    ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                    ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l2_2", nill);
                    ls2.Parameters.AddWithValue("@l3_2", nill);
                    ls2.Parameters.AddWithValue("@l4_2", nill);
                }
                else if (crd3.Text == "2")
                {
                    ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                    ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l2_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l3_2", nill);
                    ls2.Parameters.AddWithValue("@l4_2", nill);
                }
                else if (crd3.Text == "3")
                {
                    ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                    ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l2_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l3_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l4_2", nill);
                }
            }
            else
            {
                ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                ls2.Parameters.AddWithValue("@l1_2", nill);
                ls2.Parameters.AddWithValue("@l2_2", nill);
                ls2.Parameters.AddWithValue("@l3_2", nill);
                ls2.Parameters.AddWithValue("@l4_2", nill);
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


            // --------------------- TIMETABLE ------------------------

            if (th4.Text == "Lab" || th4.Text == "lab" || th4.Text == "l")
            {
                ls2.Parameters.AddWithValue("@tbreak_2", var);
                ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                ls2.Parameters.AddWithValue("@l6_2", sub4.Text);
                ls2.Parameters.AddWithValue("@l7_2", sub4.Text);
            }
            else if (th4.Text == "Theory" || th4.Text == "theory" || th4.Text == "th")
            {
                if (crd4.Text == "1")
                {
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l6_2", nill);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
                else if (crd1.Text == "2")
                {
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l6_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
                else if (crd1.Text == "3")
                {
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l6_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l7_2", sub4.Text);
                }
                ls2.ExecuteNonQuery();
            }
            else
            {
                ls2.Parameters.AddWithValue("@tbreak_2", var);
                ls2.Parameters.AddWithValue("@l5_2", nill);
                ls2.Parameters.AddWithValue("@l6_2", nill);
                ls2.Parameters.AddWithValue("@l7_2", nill);
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



            // --------------------- TIMETABLE ------------------------
            string s3 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id_3, @l1_3, @l2_3, @l3_3, @l4_3, @tbreak_3, @l5_3, @l6_3, @l7_3)";
            SqlCommand ls3 = new SqlCommand(s3, con);

            if (th5.Text == "Lab" || th5.Text == "lab" || th5.Text == "l")
            {
                ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                ls3.Parameters.AddWithValue("@l2_3", sub5.Text);
                ls3.Parameters.AddWithValue("@l3_3", sub5.Text);
                ls3.Parameters.AddWithValue("@l4_3", nill);
            }
            else if (th5.Text == "Theory" || th5.Text == "theory" || th5.Text == "th")
            {
                if (crd5.Text == "1")
                {
                    ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                    ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l2_3", nill);
                    ls3.Parameters.AddWithValue("@l3_3", nill);
                    ls3.Parameters.AddWithValue("@l4_3", nill);
                }
                else if (crd5.Text == "2")
                {
                    ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                    ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l2_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l3_3", nill);
                    ls3.Parameters.AddWithValue("@l4_3", nill);
                }
                else if (crd5.Text == "3")
                {
                    ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                    ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l2_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l3_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l4_3", nill);
                }
            }
            else
            {
                ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                ls3.Parameters.AddWithValue("@l1_3", nill);
                ls3.Parameters.AddWithValue("@l2_3", nill);
                ls3.Parameters.AddWithValue("@l3_3", nill);
                ls3.Parameters.AddWithValue("@l4_3", nill);
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
                ls3.Parameters.AddWithValue("@tbreak_3", var);
                ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                ls3.Parameters.AddWithValue("@l6_3", sub6.Text);
                ls3.Parameters.AddWithValue("@l7_3", sub6.Text);
            }
            else if (th6.Text == "Theory" || th6.Text == "theory" || th6.Text == "th")
            {
                if (crd6.Text == "1")
                {
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l6_3", nill);
                    ls3.Parameters.AddWithValue("@l7_3", nill);
                }
                else if (crd6.Text == "2")
                {
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l6_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l7_3", nill);
                }
                else if (crd6.Text == "3")
                {
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l6_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l7_3", sub6.Text);
                }
                ls3.ExecuteNonQuery();
            }
            else
            {
                ls3.Parameters.AddWithValue("@tbreak_3", var);
                ls3.Parameters.AddWithValue("@l5_3", nill);
                ls3.Parameters.AddWithValue("@l6_3", nill);
                ls3.Parameters.AddWithValue("@l7_3", nill);
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



            // --------------------- TIMETABLE ------------------------
            string s4 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id_4, @l1_4, @l2_4, @l3_4, @l4_4, @tbreak_4, @l5_4, @l6_4, @l7_4)";
            SqlCommand ls4 = new SqlCommand(s4, con);

            if (th7.Text == "Lab" || th7.Text == "lab" || th7.Text == "l")
            {
                ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                ls4.Parameters.AddWithValue("@l2_4", sub7.Text);
                ls4.Parameters.AddWithValue("@l3_4", sub7.Text);
                ls4.Parameters.AddWithValue("@l4_4", nill);
            }
            else if (th7.Text == "Theory" || th7.Text == "theory" || th7.Text == "th")
            {
                if (crd7.Text == "1")
                {
                    ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                    ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l2_4", nill);
                    ls4.Parameters.AddWithValue("@l3_4", nill);
                    ls4.Parameters.AddWithValue("@l4_4", nill);
                }
                else if (crd7.Text == "2")
                {
                    ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                    ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l2_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l3_4", nill);
                    ls4.Parameters.AddWithValue("@l4_4", nill);
                }
                else if (crd7.Text == "3")
                {
                    ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                    ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l2_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l3_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l4_4", nill);
                }
            }
            else
            {
                ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                ls4.Parameters.AddWithValue("@l1_4", nill);
                ls4.Parameters.AddWithValue("@l2_4", nill);
                ls4.Parameters.AddWithValue("@l3_4", nill);
                ls4.Parameters.AddWithValue("@l4_4", nill);
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
                ls4.Parameters.AddWithValue("@tbreak_4", var);
                ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                ls4.Parameters.AddWithValue("@l6_4", sub8.Text);
                ls4.Parameters.AddWithValue("@l7_4", sub8.Text);
            }
            else if (th8.Text == "Theory" || th8.Text == "theory" || th8.Text == "th")
            {
                if (crd8.Text == "1")
                {
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l6_4", nill);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
                else if (crd8.Text == "2")
                {
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l6_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
                else if (crd8.Text == "3")
                {
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l6_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l7_4", sub8.Text);
                }
                ls4.ExecuteNonQuery();
            }
            else
            {
                ls4.Parameters.AddWithValue("@tbreak_4", var);
                ls4.Parameters.AddWithValue("@l5_4", nill);
                ls4.Parameters.AddWithValue("@l6_4", nill);
                ls4.Parameters.AddWithValue("@l7_4", nill);
            }

            MessageBox.Show("Data stored in database!");
            this.Hide();
            generator ss1 = new generator();
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
