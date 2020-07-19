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
            // ------------------------ course details ----------------------------

            string labelData = "SELECT * FROM COURSE WHERE ID =" + int.Parse(userID.Text);
            SqlCommand labCmd = new SqlCommand(labelData, connectionString);
            connectionString.Open();
            
            using (SqlDataReader dr = labCmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    label4.Text = dr["COUESECODE"].ToString();
                    label6.Text = dr["SEMESTER"].ToString();
                    label8.Text = dr["ROOM"].ToString();
                }
            }
            // ------------------------------ week days ------------------------------
           
            /*string query = "SELECT * FROM WEEKDAYS";
            SqlDataAdapter sqlDa_week = new SqlDataAdapter(query, connectionString);
            DataTable dbtlweek = new DataTable();
            sqlDa_week.Fill(dbtlweek);
            dataGridView1.DataSource = dbtlweek;
            */

            // ---------------------------- timetable ---------------------------------

            string q = "SELECT LEC1, LEC2, LEC3, LEC4, TBREAK, LEC5, LEC6, LEC7 FROM TIMETABLE WHERE T_ID = " + int.Parse(userID.Text);
            SqlDataAdapter sqlDa_timetable = new SqlDataAdapter(q, connectionString);
            DataTable dbtltimetable = new DataTable();
            sqlDa_timetable.Fill(dbtltimetable);
            dataGridView1.DataSource = dbtltimetable;
            connectionString.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addData ss1 = new addData();
            ss1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void generator_Load(object sender, EventArgs e)
        {

        }
    }
}
