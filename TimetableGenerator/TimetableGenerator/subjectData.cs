
/* *************************************** PAGE TO ADD SUBJECT DATA FOR TIMETABLE ************************************ */

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
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THIS BUTTON WILL LET YOU LEAVE THE PAGE --------------------

            // Creating a connection with database
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");

            // Opening the connection
            con.Open();

            // ------------------------------- 1 -----------------------------
            // This query will store subject1 data in SUBJECT1 table in database

            string query1 = "INSERT INTO SUBJECT1(SUBJ1, CHRS1, SUBTYPE1, S_ID1)" +
                "VALUES(@sub, @chrs, @type, @usid)";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            
            cmd1.Parameters.AddWithValue("@sub", sub1.Text);
            cmd1.Parameters.AddWithValue("@chrs", crd1.Text);
            cmd1.Parameters.AddWithValue("@type", th1.Text);
            cmd1.Parameters.AddWithValue("@usid", userID.Text);
            cmd1.ExecuteNonQuery();


            // --------------------- Lecture slots generation for input subjects ------------------------

            // Inserting the lecture in database table of TIMETABLE in sequence of after applying conditions
            string s1 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id, @l1, @l2, @l3, @l4, @tbreak, @l5, @l6, @l7)";
            SqlCommand ls1 = new SqlCommand(s1, con);

            // Creating variables for break and free slots
            string var = "BREAK";
            string nill = "-";

            // If it is lab entered in subject 1 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th1.Text == "Lab" || th1.Text == "lab" || th1.Text == "l")
            {
                ls1.Parameters.AddWithValue("@t_id", userID.Text);
                ls1.Parameters.AddWithValue("@l1", sub1.Text);
                ls1.Parameters.AddWithValue("@l2", sub1.Text);
                ls1.Parameters.AddWithValue("@l3", sub1.Text);
            }
            else if(th1.Text=="Theory" || th1.Text == "theory" || th1.Text == "th")
            {
                // If it is theory entered in subject 1 textbox, then it is adjusted according to its contact 
                // hours mentioned 
                if (crd1.Text=="1")
                {
                    // If the contact hour of subject is 1, then it is assigned the first lecture slot on first
                    // day of the week
                    ls1.Parameters.AddWithValue("@t_id", userID.Text);
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", nill);
                    ls1.Parameters.AddWithValue("@l3", nill);
                }
                else if(crd1.Text=="2")
                {
                    // If the contact hour of subject is 2, then it is assigned the two consective lecture slots
                    // on first day of the week
                    ls1.Parameters.AddWithValue("@t_id", userID.Text);
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                    ls1.Parameters.AddWithValue("@l3", nill);
                }
                else if(crd1.Text=="3")
                {
                    // If the contact hour of subject is 3, then it is assigned the three consective lecture
                    // slots on first day of the week
                    ls1.Parameters.AddWithValue("@t_id", userID.Text);
                    ls1.Parameters.AddWithValue("@l1", sub1.Text);
                    ls1.Parameters.AddWithValue("@l2", sub1.Text);
                    ls1.Parameters.AddWithValue("@l3", sub1.Text);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls1.Parameters.AddWithValue("@t_id", userID.Text);
                ls1.Parameters.AddWithValue("@l1", nill);
                ls1.Parameters.AddWithValue("@l2", nill);
                ls1.Parameters.AddWithValue("@l3", nill);
            }

            //------------------------------------   2   ------------------------------
            // This query will store subject2 data in SUBJECT2 table in database

            string query2 = "INSERT INTO SUBJECT2(SUBJ2, CHRS2, SUBTYPE2, S_ID2)" +
                "VALUES(@sub, @crdhrs, @type, @usid)";

            SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd2.Parameters.AddWithValue("@sub", sub2.Text);
            cmd2.Parameters.AddWithValue("@crdhrs", crd2.Text);
            cmd2.Parameters.AddWithValue("@type", th2.Text);
            cmd2.Parameters.AddWithValue("@usid", userID.Text);
            cmd2.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            // If it is lab entered in subject 2 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th2.Text == "Lab" || th2.Text == "lab" || th2.Text == "l")
            {
                ls1.Parameters.AddWithValue("@l4", nill);
                ls1.Parameters.AddWithValue("@tbreak", var);
                ls1.Parameters.AddWithValue("@l5", sub2.Text);
                ls1.Parameters.AddWithValue("@l6", sub2.Text);
                ls1.Parameters.AddWithValue("@l7", sub2.Text);
            }
            else if((th2.Text == "Theory" || th2.Text == "theory" || th2.Text == "th") && (th1.Text == "Theory" || th1.Text == "theory" || th1.Text == "th") && (crd1.Text=="1" || crd1.Text == "2" || crd1.Text == "3"))
            {
                // If it is theory entered in subject 2 textbox, then it is adjusted according to its contact 
                // hours mentioned
                if (crd2.Text == "1")
                {
                    // If the contact hour of subject is 1, then it is assigned the 4th lecture slot on first day 
                    // of the week
                    ls1.Parameters.AddWithValue("@l4", sub2.Text);
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", nill);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd2.Text == "2")
                {
                    // If the contact hour of subject is 2, then it is assigned the two consective lecture slots;
                    // 4th and 5th slot on first day of the week
                    ls1.Parameters.AddWithValue("@l4", sub2.Text);
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub2.Text);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd2.Text == "3")
                {
                    // If the contact hour of subject is 3, then it is assigned the three consective lecture slots;
                    // 4th, 5th and 6th slot on first day of the week
                    ls1.Parameters.AddWithValue("@l4", sub2.Text);
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub2.Text);
                    ls1.Parameters.AddWithValue("@l6", sub2.Text);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
            }
            else if ((th2.Text == "Theory" || th2.Text == "theory" || th2.Text == "th") && (th1.Text == "Lab" || th1.Text == "lab" || th1.Text == "l"))
            {
                // If subject 1 is a lab and subject 2 is theory then lectures are arranges in following manner
                if (crd2.Text == "1")
                {
                    // If the contact hour of subject is 1, then it is assigned the one lecture slot;
                    // 4th slot on first day of the week
                    ls1.Parameters.AddWithValue("@l4", sub2.Text);
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", nill);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd2.Text == "2")
                {
                    // If the contact hour of subject is 2, then it is assigned the two consective lecture slots;
                    // 4th and 5th slot on first day of the week
                    ls1.Parameters.AddWithValue("@l4", sub2.Text);
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub2.Text);
                    ls1.Parameters.AddWithValue("@l6", nill);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
                else if (crd2.Text == "3")
                {
                    // If the contact hour of subject is 3, then it is assigned the three consective lecture slots;
                    // 4th, 5th and 6th slot on first day of the week
                    ls1.Parameters.AddWithValue("@l4", sub2.Text);
                    ls1.Parameters.AddWithValue("@tbreak", var);
                    ls1.Parameters.AddWithValue("@l5", sub2.Text);
                    ls1.Parameters.AddWithValue("@l6", sub2.Text);
                    ls1.Parameters.AddWithValue("@l7", nill);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls1.Parameters.AddWithValue("@l4", nill);
                ls1.Parameters.AddWithValue("@tbreak", var);
                ls1.Parameters.AddWithValue("@l5", nill);
                ls1.Parameters.AddWithValue("@l6", nill);
                ls1.Parameters.AddWithValue("@l7", nill);
            }
            ls1.ExecuteNonQuery();

            //------------------------------------   3   ------------------------------
            // This query will store subject3 data in SUBJECT3 table in database

            string query3 = "INSERT INTO SUBJECT3(SUBJ3, CHRS3, SUBTYPE3, S_ID3)" +
                "VALUES(@sub, @crdhrs, @type, @usid)";

            SqlCommand cmd3 = new SqlCommand(query3, con);

            cmd3.Parameters.AddWithValue("@sub", sub3.Text);
            cmd3.Parameters.AddWithValue("@crdhrs", crd3.Text);
            cmd3.Parameters.AddWithValue("@type", th3.Text);
            cmd3.Parameters.AddWithValue("@usid", userID.Text);
            cmd3.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            // Inserting the lecture in database table of TIMETABLE in sequence of after applying conditions

            string s2 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id_2, @l1_2, @l2_2, @l3_2, @l4_2, @tbreak_2, @l5_2, @l6_2, @l7_2)";
            SqlCommand ls2 = new SqlCommand(s2, con);

            // If it is lab entered in subject 3 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th3.Text == "Lab" || th3.Text == "lab" || th3.Text == "l")
            {
                ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                ls2.Parameters.AddWithValue("@l2_2", sub3.Text);
                ls2.Parameters.AddWithValue("@l3_2", sub3.Text);
            }
            else if (th3.Text == "Theory" || th3.Text == "theory" || th3.Text == "th")
            {
                // If it is theory entered in subject 3 textbox, then it is adjusted according to its contact 
                // hours mentioned
                if (crd3.Text == "1")
                {
                    ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                    ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l2_2", nill);
                    ls2.Parameters.AddWithValue("@l3_2", nill);
                }
                else if (crd3.Text == "2")
                {
                    ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                    ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l2_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l3_2", nill);
                }
                else if (crd3.Text == "3")
                {
                    ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                    ls2.Parameters.AddWithValue("@l1_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l2_2", sub3.Text);
                    ls2.Parameters.AddWithValue("@l3_2", sub3.Text);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls2.Parameters.AddWithValue("@t_id_2", userID.Text);
                ls2.Parameters.AddWithValue("@l1_2", nill);
                ls2.Parameters.AddWithValue("@l2_2", nill);
                ls2.Parameters.AddWithValue("@l3_2", nill);
            }

            //------------------------------------   4   ------------------------------
            // This query will store subject4 data in SUBJECT4 table in database

            string query4 = "INSERT INTO SUBJECT4(SUBJ4, CHRS4, SUBTYPE4, S_ID4)" +
                "VALUES(@sub, @crdhrs, @type, @usid)";

            SqlCommand cmd4 = new SqlCommand(query4, con);

            cmd4.Parameters.AddWithValue("@sub", sub4.Text);
            cmd4.Parameters.AddWithValue("@crdhrs", crd4.Text);
            cmd4.Parameters.AddWithValue("@type", th4.Text);
            cmd4.Parameters.AddWithValue("@usid", userID.Text);
            cmd4.ExecuteNonQuery();


            // --------------------- TIMETABLE ------------------------

            // If it is lab entered in subject 4 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th4.Text == "Lab" || th4.Text == "lab" || th4.Text == "l")
            {
                ls2.Parameters.AddWithValue("@l4_2", nill);
                ls2.Parameters.AddWithValue("@tbreak_2", var);
                ls2.Parameters.AddWithValue("@l5_2", sub2.Text);
                ls2.Parameters.AddWithValue("@l6_2", sub2.Text);
                ls2.Parameters.AddWithValue("@l7_2", sub2.Text);
            }
            else if ((th4.Text == "Theory" || th4.Text == "theory" || th4.Text == "th") && (th3.Text == "Theory" || th3.Text == "theory" || th3.Text == "th") && (crd3.Text == "1" || crd3.Text == "2" || crd3.Text == "3"))
            {
                // If it is theory entered in subject 4 textbox, then it is adjusted according to its contact 
                // hours mentioned
                if (crd4.Text == "1")
                {
                    ls2.Parameters.AddWithValue("@l4_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", nill);
                    ls2.Parameters.AddWithValue("@l6_2", nill);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
                else if (crd4.Text == "2")
                {
                    ls2.Parameters.AddWithValue("@l4_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l6_2", nill);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
                else if (crd4.Text == "3")
                {
                    ls2.Parameters.AddWithValue("@l4_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l6_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
            }
            else if ((th4.Text == "Theory" || th4.Text == "theory" || th4.Text == "th") && (th3.Text == "Lab" || th3.Text == "lab" || th3.Text == "l"))
            {
                if (crd4.Text == "1")
                {
                    ls2.Parameters.AddWithValue("@l4_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", nill);
                    ls2.Parameters.AddWithValue("@l6_2", nill);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
                else if (crd4.Text == "2")
                {
                    ls2.Parameters.AddWithValue("@l4_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l6_2", nill);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
                else if (crd4.Text == "3")
                {
                    ls2.Parameters.AddWithValue("@l4_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@tbreak_2", var);
                    ls2.Parameters.AddWithValue("@l5_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l6_2", sub4.Text);
                    ls2.Parameters.AddWithValue("@l7_2", nill);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls2.Parameters.AddWithValue("@l4_2", nill);
                ls2.Parameters.AddWithValue("@tbreak_2", var);
                ls2.Parameters.AddWithValue("@l5_2", nill);
                ls2.Parameters.AddWithValue("@l6_2", nill);
                ls2.Parameters.AddWithValue("@l7_2", nill);
            }
            ls2.ExecuteNonQuery();

            //------------------------------------   5   ------------------------------
            // This query will store subject5 data in SUBJECT5 table in database

            string query5 = "INSERT INTO SUBJECT5(SUBJ5, CHRS5, SUBTYPE5, S_ID5)" +
                "VALUES(@sub, @crdhrs, @type, @usid)";

            SqlCommand cmd5 = new SqlCommand(query5, con);

            cmd5.Parameters.AddWithValue("@sub", sub5.Text);
            cmd5.Parameters.AddWithValue("@crdhrs", crd5.Text);
            cmd5.Parameters.AddWithValue("@type", th5.Text);
            cmd5.Parameters.AddWithValue("@usid", userID.Text);
            cmd5.ExecuteNonQuery();


            // --------------------- TIMETABLE ------------------------

            // Inserting the lecture in database table of TIMETABLE in sequence of after applying conditions

            string s3 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id_3, @l1_3, @l2_3, @l3_3, @l4_3, @tbreak_3, @l5_3, @l6_3, @l7_3)";
            SqlCommand ls3 = new SqlCommand(s3, con);

            // If it is lab entered in subject 5 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th5.Text == "Lab" || th5.Text == "lab" || th5.Text == "l")
            {
                ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                ls3.Parameters.AddWithValue("@l2_3", sub5.Text);
                ls3.Parameters.AddWithValue("@l3_3", sub5.Text);
            }
            else if (th5.Text == "Theory" || th5.Text == "theory" || th5.Text == "th")
            {
                // If it is theory entered in subject 5 textbox, then it is adjusted according to its contact 
                // hours mentioned
                if (crd5.Text == "1")
                {
                    ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                    ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l2_3", nill);
                    ls3.Parameters.AddWithValue("@l3_3", nill);
                }
                else if (crd5.Text == "2")
                {
                    ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                    ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l2_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l3_3", nill);
                }
                else if (crd5.Text == "3")
                {
                    ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                    ls3.Parameters.AddWithValue("@l1_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l2_3", sub5.Text);
                    ls3.Parameters.AddWithValue("@l3_3", sub5.Text);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls3.Parameters.AddWithValue("@t_id_3", userID.Text);
                ls3.Parameters.AddWithValue("@l1_3", nill);
                ls3.Parameters.AddWithValue("@l2_3", nill);
                ls3.Parameters.AddWithValue("@l3_3", nill);
            }

            //------------------------------------   6   ------------------------------
            // This query will store subject6 data in SUBJECT6 table in database

            string query6 = "INSERT INTO SUBJECT6(SUBJ6, CHRS6, SUBTYPE6, S_ID6)" +
                "VALUES(@sub, @crdhrs, @type, @usid)";

            SqlCommand cmd6 = new SqlCommand(query6, con);

            cmd6.Parameters.AddWithValue("@sub", sub6.Text);
            cmd6.Parameters.AddWithValue("@crdhrs", crd6.Text);
            cmd6.Parameters.AddWithValue("@type", th6.Text);
            cmd6.Parameters.AddWithValue("@usid", userID.Text);
            cmd6.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            // If it is lab entered in subject 6 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th6.Text == "Lab" || th6.Text == "lab" || th6.Text == "l")
            {
                ls3.Parameters.AddWithValue("@l4_3", nill);
                ls3.Parameters.AddWithValue("@tbreak_3", var);
                ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                ls3.Parameters.AddWithValue("@l6_3", sub6.Text);
                ls3.Parameters.AddWithValue("@l7_3", sub6.Text);
            }
            else if ((th6.Text == "Theory" || th6.Text == "theory" || th6.Text == "th") && (th5.Text == "Theory" || th5.Text == "theory" || th5.Text == "th") && (crd5.Text == "1" || crd5.Text == "2" || crd5.Text == "3"))
            {
                // If it is theory entered in subject 6 textbox, then it is adjusted according to its contact 
                // hours mentioned
                if (crd6.Text == "1")
                {
                    ls3.Parameters.AddWithValue("@l4_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", nill);
                    ls3.Parameters.AddWithValue("@l6_3", nill);
                    ls3.Parameters.AddWithValue("@l7_3", nill);
                }
                else if (crd6.Text == "2")
                {
                    ls3.Parameters.AddWithValue("@l4_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l6_3", nill);
                    ls3.Parameters.AddWithValue("@l7_3", nill);
                }
                else if (crd6.Text == "3")
                {
                    ls3.Parameters.AddWithValue("@l4_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l6_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l7_3", nill);
                }
            }
            else if ((th6.Text == "Theory" || th6.Text == "theory" || th6.Text == "th") && (th5.Text == "Lab" || th5.Text == "lab" || th5.Text == "l"))
            {
                if (crd6.Text == "1")
                {
                    ls3.Parameters.AddWithValue("@l4_2", sub6.Text);
                    ls3.Parameters.AddWithValue("@tbreak_2", var);
                    ls3.Parameters.AddWithValue("@l5_2", nill);
                    ls3.Parameters.AddWithValue("@l6_2", nill);
                    ls3.Parameters.AddWithValue("@l7_2", nill);
                }
                else if (crd6.Text == "2")
                {
                    ls3.Parameters.AddWithValue("@l4_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l6_3", nill);
                    ls3.Parameters.AddWithValue("@l7_3", nill);
                }
                else if (crd6.Text == "3")
                {
                    ls3.Parameters.AddWithValue("@l4_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@tbreak_3", var);
                    ls3.Parameters.AddWithValue("@l5_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l6_3", sub6.Text);
                    ls3.Parameters.AddWithValue("@l7_3", nill);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls3.Parameters.AddWithValue("@l4_3", nill);
                ls3.Parameters.AddWithValue("@tbreak_3", var);
                ls3.Parameters.AddWithValue("@l5_3", nill);
                ls3.Parameters.AddWithValue("@l6_3", nill);
                ls3.Parameters.AddWithValue("@l7_3", nill);
            }
            ls3.ExecuteNonQuery();

            //------------------------------------   7   ------------------------------
            // This query will store subject7 data in SUBJECT7 table in database

            string query7 = "INSERT INTO SUBJECT7(SUBJ7, CHRS7, SUBTYPE7, S_ID7)" +
                "VALUES(@sub, @crdhrs, @type, @usid)";

            SqlCommand cmd7 = new SqlCommand(query7, con);

            cmd7.Parameters.AddWithValue("@sub", sub7.Text);
            cmd7.Parameters.AddWithValue("@crdhrs", crd7.Text);
            cmd7.Parameters.AddWithValue("@type", th7.Text);
            cmd7.Parameters.AddWithValue("@usid", userID.Text);
            cmd7.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            // Inserting the lecture in database table of TIMETABLE in sequence of after applying conditions

            string s4 = "INSERT INTO TIMETABLE(T_ID, LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7) VALUES(@t_id_4, @l1_4, @l2_4, @l3_4, @l4_4, @tbreak_4, @l5_4, @l6_4, @l7_4)";
            SqlCommand ls4 = new SqlCommand(s4, con);

            // If it is lab entered in subject 7 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th7.Text == "Lab" || th7.Text == "lab" || th7.Text == "l")
            {
                ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                ls4.Parameters.AddWithValue("@l2_4", sub7.Text);
                ls4.Parameters.AddWithValue("@l3_4", sub7.Text);
            }
            else if (th7.Text == "Theory" || th7.Text == "theory" || th7.Text == "th")
            {
                // If it is theory entered in subject 7 textbox, then it is adjusted according to its contact 
                // hours mentioned
                if (crd7.Text == "1")
                {
                    ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                    ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l2_4", nill);
                    ls4.Parameters.AddWithValue("@l3_4", nill);
                }
                else if (crd7.Text == "2")
                {
                    ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                    ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l2_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l3_4", nill);
                }
                else if (crd7.Text == "3")
                {
                    ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                    ls4.Parameters.AddWithValue("@l1_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l2_4", sub7.Text);
                    ls4.Parameters.AddWithValue("@l3_4", sub7.Text);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls4.Parameters.AddWithValue("@t_id_4", userID.Text);
                ls4.Parameters.AddWithValue("@l1_4", nill);
                ls4.Parameters.AddWithValue("@l2_4", nill);
                ls4.Parameters.AddWithValue("@l3_4", nill);
            }

            //------------------------------------   8  -----------------------------
            // This query will store subject8 data in SUBJECT8 table in database

            string query8 = "INSERT INTO SUBJECT8(SUBJ8, CHRS8, SUBTYPE8, S_ID8)" +
                "VALUES(@sub, @crdhrs, @type, @usid)";

            SqlCommand cmd8 = new SqlCommand(query8, con);

            cmd8.Parameters.AddWithValue("@sub", sub8.Text);
            cmd8.Parameters.AddWithValue("@crdhrs", crd8.Text);
            cmd8.Parameters.AddWithValue("@type", th8.Text);
            cmd8.Parameters.AddWithValue("@usid", userID.Text);
            cmd8.ExecuteNonQuery();

            // --------------------- TIMETABLE ------------------------

            // If it is lab entered in subject 8 textbox, then it is adjusted such that 3 slots are 
            // assigned to it of 3 hours 
            if (th8.Text == "Lab" || th8.Text == "lab" || th8.Text == "l")
            {
                ls4.Parameters.AddWithValue("@l4_4", nill);
                ls4.Parameters.AddWithValue("@tbreak_4", var);
                ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                ls4.Parameters.AddWithValue("@l6_4", sub8.Text);
                ls4.Parameters.AddWithValue("@l7_4", sub8.Text);
            }
            else if ((th8.Text == "Theory" || th8.Text == "theory" || th8.Text == "th") && (th7.Text == "Theory" || th7.Text == "theory" || th7.Text == "th") && (crd7.Text == "1" || crd7.Text == "2" || crd7.Text == "3"))
            {
                // If it is theory entered in subject 8 textbox, then it is adjusted according to its contact 
                // hours mentioned
                if (crd8.Text == "1")
                {
                    ls4.Parameters.AddWithValue("@l4_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", nill);
                    ls4.Parameters.AddWithValue("@l6_4", nill);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
                else if (crd8.Text == "2")
                {
                    ls4.Parameters.AddWithValue("@l4_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l6_4", nill);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
                else if (crd8.Text == "3")
                {
                    ls4.Parameters.AddWithValue("@l4_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l6_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
            }
            else if ((th8.Text == "Theory" || th8.Text == "theory" || th8.Text == "th") && (th7.Text == "Lab" || th7.Text == "lab" || th7.Text == "l"))
            {
                if (crd8.Text == "1")
                {
                    ls4.Parameters.AddWithValue("@l4_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", nill);
                    ls4.Parameters.AddWithValue("@l6_4", nill);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
                else if (crd8.Text == "2")
                {
                    ls4.Parameters.AddWithValue("@l4_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l6_4", nill);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
                else if (crd8.Text == "3")
                {
                    ls4.Parameters.AddWithValue("@l4_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@tbreak_4", var);
                    ls4.Parameters.AddWithValue("@l5_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l6_4", sub8.Text);
                    ls4.Parameters.AddWithValue("@l7_4", nill);
                }
            }
            else
            {
                // Incase no data is entered, the slots are left nill
                ls4.Parameters.AddWithValue("@l4_4", nill);
                ls4.Parameters.AddWithValue("@tbreak_4", var);
                ls4.Parameters.AddWithValue("@l5_4", nill);
                ls4.Parameters.AddWithValue("@l6_4", nill);
                ls4.Parameters.AddWithValue("@l7_4", nill);
            }
            ls4.ExecuteNonQuery();

            MessageBox.Show("Data stored in database!");
            this.Hide();
            generator ss1 = new generator();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THIS BUTTON WILL MOVE YOU ON THE PREVIOUS PAGE --------------------

            this.Hide();
            addData ss1 = new addData();
            ss1.Show();
        }

        private void sub2_TextChanged(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void sub3_TextChanged(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void th1_TextChanged(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void logout_Click(object sender, EventArgs e)
        {
            // ------------------ LOGOUT FUNCTIONALITY; MOVED TO LOGIN PAGE --------------------

            this.Hide();
            login ss1 = new login();
            ss1.Show();
        }

        private void subjectData_Load(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }
    }
}
