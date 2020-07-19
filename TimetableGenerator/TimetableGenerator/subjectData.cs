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

            string storeID = "INSERT INTO TIMETABLE(T_ID) VALUE(@t_id)";
            SqlCommand cmd_id = new SqlCommand(storeID, con);
            cmd_id.Parameters.AddWithValue("@t_id", userID.Text);
            cmd_id.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            string s1 = "INSERT INTO TIMETABLE(LEC1, LEC2, LEC3, LEC4, LEC5, LEC6, LEC7) VALUES(@l1, @l2, @l3, @l4, @l5, @l6, @l7)";
            SqlCommand ls1 = new SqlCommand(s1, con);
            if (th1.Text=="Lab")
            {
                ls1.Parameters.AddWithValue("@l1", sub1.Text);
                ls1.Parameters.AddWithValue("@l2", sub1.Text);
                ls1.Parameters.AddWithValue("@l3", sub1.Text);
            }
            else if(th1.Text=="lab")
            {
                ls1.Parameters.AddWithValue("@l1", sub1.Text);
                ls1.Parameters.AddWithValue("@l2", sub1.Text);
                ls1.Parameters.AddWithValue("@l3", sub1.Text);
         
            }
            else if(th1.Text=="Theory")
            {
                if(crd1.Text=="1")
                {
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                }
                else if(crd1.Text=="2")
                {
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                }
                else if(crd1.Text=="3")
                {
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                    ls1.Parameters.AddWithValue("@l3", sub1.Text);
                }
                ls1.ExecuteNonQuery();
            }
            con.Close();
            
            //------------------------------------   2   ------------------------------

            con.Open();
            string query2 = "INSERT INTO SUBJECT2(SUBJ2, CHRS2, TEACHER2, SUBTYPE2, S_ID2)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd2.Parameters.AddWithValue("@sub", sub2.Text);
            cmd2.Parameters.AddWithValue("@crdhrs", crd2.Text);
            cmd2.Parameters.AddWithValue("@teacher", t2.Text);
            cmd2.Parameters.AddWithValue("@type", th2.Text);
            cmd2.Parameters.AddWithValue("@usid", userID.Text);
            cmd2.ExecuteNonQuery();
            con.Close();

            //------------------------------------   3   ------------------------------

            con.Open();
            string query3 = "INSERT INTO SUBJECT3(SUBJ3, CHRS3, TEACHER3, SUBTYPE3, S_ID3)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd3 = new SqlCommand(query3, con);

            cmd3.Parameters.AddWithValue("@sub", sub3.Text);
            cmd3.Parameters.AddWithValue("@crdhrs", crd3.Text);
            cmd3.Parameters.AddWithValue("@teacher", t3.Text);
            cmd3.Parameters.AddWithValue("@type", th3.Text);
            cmd3.Parameters.AddWithValue("@usid", userID.Text);
            cmd3.ExecuteNonQuery();
            con.Close();

            //------------------------------------   4   ------------------------------

            con.Open();
            string query4 = "INSERT INTO SUBJECT4(SUBJ4, CHRS4, TEACHER4, SUBTYPE4, S_ID4)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd4 = new SqlCommand(query4, con);

            cmd4.Parameters.AddWithValue("@sub", sub4.Text);
            cmd4.Parameters.AddWithValue("@crdhrs", crd4.Text);
            cmd4.Parameters.AddWithValue("@teacher", t4.Text);
            cmd4.Parameters.AddWithValue("@type", th4.Text);
            cmd4.Parameters.AddWithValue("@usid", userID.Text);
            cmd4.ExecuteNonQuery();
            con.Close();

            //------------------------------------   5   ------------------------------

            con.Open();
            string query5 = "INSERT INTO SUBJECT5(SUBJ5, CHRS5, TEACHER5, SUBTYPE5, S_ID5)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd5 = new SqlCommand(query5, con);

            cmd5.Parameters.AddWithValue("@sub", sub5.Text);
            cmd5.Parameters.AddWithValue("@crdhrs", crd5.Text);
            cmd5.Parameters.AddWithValue("@teacher", t5.Text);
            cmd5.Parameters.AddWithValue("@type", th5.Text);
            cmd5.Parameters.AddWithValue("@usid", userID.Text);
            cmd5.ExecuteNonQuery();
            con.Close();

            //------------------------------------   6   ------------------------------

            con.Open();
            string query6 = "INSERT INTO SUBJECT6(SUBJ6, CHRS6, TEACHER6, SUBTYPE6, S_ID6)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd6 = new SqlCommand(query6, con);

            cmd6.Parameters.AddWithValue("@sub", sub6.Text);
            cmd6.Parameters.AddWithValue("@crdhrs", crd6.Text);
            cmd6.Parameters.AddWithValue("@teacher", t6.Text);
            cmd6.Parameters.AddWithValue("@type", th6.Text);
            cmd6.Parameters.AddWithValue("@usid", userID.Text);
            cmd6.ExecuteNonQuery();
            con.Close();

            //------------------------------------   7   ------------------------------

            con.Open();
            string query7 = "INSERT INTO SUBJECT7(SUBJ7, CHRS7, TEACHER7, SUBTYPE7, S_ID7)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd7 = new SqlCommand(query7, con);

            cmd7.Parameters.AddWithValue("@sub", sub7.Text);
            cmd7.Parameters.AddWithValue("@crdhrs", crd7.Text);
            cmd7.Parameters.AddWithValue("@teacher", t7.Text);
            cmd7.Parameters.AddWithValue("@type", th7.Text);
            cmd7.Parameters.AddWithValue("@usid", userID.Text);
            cmd7.ExecuteNonQuery();
            con.Close();

            //------------------------------------   8  -----------------------------

            con.Open();
            string query8 = "INSERT INTO SUBJECT8(SUBJ8, CHRS8, TEACHER8, SUBTYPE8, S_ID8)" +
                "VALUES(@sub, @crdhrs, @teacher, @type, @usid)";

            SqlCommand cmd8 = new SqlCommand(query8, con);

            cmd8.Parameters.AddWithValue("@sub", sub8.Text);
            cmd8.Parameters.AddWithValue("@crdhrs", crd8.Text);
            cmd8.Parameters.AddWithValue("@teacher", t8.Text);
            cmd8.Parameters.AddWithValue("@type", th8.Text);
            cmd8.Parameters.AddWithValue("@usid", userID.Text);
            cmd8.ExecuteNonQuery();
            con.Close();
                        
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
