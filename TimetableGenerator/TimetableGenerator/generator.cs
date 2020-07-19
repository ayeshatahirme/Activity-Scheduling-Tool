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
            string labelData = "SELECT * FROM COURSE WHERE ID =" + int.Parse(userID.Text);
            SqlCommand labCmd = new SqlCommand(labelData, connectionString);
            connectionString.Open();
            DataTable dbtl = new DataTable();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT W_D FROM WEEKDAYS", connectionString);

            sqlDa.Fill(dbtl);
                
            dataGridView1.DataSource = dbtl;
            
            using (SqlDataReader dr = labCmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    label4.Text = dr["COUESECODE"].ToString();
                    label6.Text = dr["SEMESTER"].ToString();
                    label8.Text = dr["ROOM"].ToString();
                }
            }
            /* DataTable dt = new DataTable();

                       dt.Columns.Add("Lecture 1 8:00-9:00 am");
                       dt.Columns.Add("Lecture 2 9:00-10:00 am");
                       dt.Columns.Add("Lecture 3 10:00-11:00 am");
                       dt.Columns.Add("Lecture 4 11:00-12:00 pm");
                       dt.Columns.Add("Break  12:00-1:00 pm");
                       dt.Columns.Add("Lecture 5 1:00-2:00 pm");
                       dt.Columns.Add("Lecture 6 2:00-3:00 pm");
                       dt.Columns.Add("Lecture 7 3:00-4:00 pm");

                       dt.Rows.Add("Monday ");
                       dt.Rows.Add("Tuesday ");
                       dt.Rows.Add("Wednesday ");
                       dt.Rows.Add("Thursday ");
                       dt.Rows.Add("Friday ");
                       dataGridView1.DataSource = dt;
                       */

            /*DataTable dtbl = new DataTable();

           SqlCommand cmd;
           using (SqlConnection sqlCon = new SqlConnection(con))
           {
               sqlCon.Open();
               SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT SUBJ1 FROM SUBJECT1", sqlCon);

               sqlDa.Fill(dtbl);
               
               dataGridView1.DataSource = dtbl;

   */


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
    }
}
