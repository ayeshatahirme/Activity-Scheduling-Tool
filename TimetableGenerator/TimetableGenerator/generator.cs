
/* *************************************** PAGE THAT SHOWS GENERATED TIMETABLE ************************************ */

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
    public partial class generator : Form
    {
        SqlConnection connectionString = new SqlConnection (@"Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");

        public generator()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE SHOW/CREATE TIMETABLE BUTTON WILL LET YOU 
            //                                GENERATE OR SEE YOUR TIMETABLE         --------------------

            // ------------------------ course details ----------------------------

            // This query will select all data from table COURSE where its ID is
            // what is written in userID textbox.
            string labelData = "SELECT * FROM COURSE WHERE ID =" + int.Parse(userID.Text);
            SqlCommand labCmd = new SqlCommand(labelData, connectionString);
            
            // Connection is opened
            connectionString.Open();
            
            using (SqlDataReader dr = labCmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    // Respective data of courseID is written in labels
                    label4.Text = dr["COUESECODE"].ToString();
                    label6.Text = dr["SEMESTER"].ToString();
                    label8.Text = dr["ROOM"].ToString();
                }
            }
            
            // ---------------------------- DISPLAYING THE GENERATED TIMETABLE ------------------------

            // Using this query all the lectures of timetable are fetched from database where userID 
            // is what the user entered; and is shown in gridview
            string q = "SELECT LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7 FROM TIMETABLE WHERE T_ID = " + int.Parse(userID.Text);
            SqlDataAdapter sqlDa_timetable = new SqlDataAdapter(q, connectionString);
            DataTable dbtltimetable = new DataTable();
            sqlDa_timetable.Fill(dbtltimetable);
            dataGridView1.DataSource = dbtltimetable;

            // Connection is closed
            connectionString.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE ALL DONE BUTTON MEANS YOU HAVE DONE YOUR WORK --------------------
            // previous page hides when new page is requested
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE BACK BUTTON WILL TAKE YOU YOU TO PREVIOUS PAGE --------------------
            // previous page hides when new page is requested

            this.Hide();
            inputData ss1 = new inputData();
            ss1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void generator_Load(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void logout_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE LOGOUT BUTTON WILL TAKE  YOU BACK ON LOGIN PAGE --------------------
            // previous page hides when new page is requested

            this.Hide();
            login ss1 = new login();
            ss1.Show();
        }
    }
}
