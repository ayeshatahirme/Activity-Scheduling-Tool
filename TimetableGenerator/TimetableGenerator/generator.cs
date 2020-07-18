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
        string connectionString = @"Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True;";

        public generator()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

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

            /*DataTable dtbl = new DataTable();

           SqlCommand cmd;
           using (SqlConnection sqlCon = new SqlConnection(con))
           {
               sqlCon.Open();
               SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT SUBJ1 FROM SUBJECT1", sqlCon);

               sqlDa.Fill(dtbl);

           //    dataGridView1.AutoGenerateColumns = false;
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
    }
}
