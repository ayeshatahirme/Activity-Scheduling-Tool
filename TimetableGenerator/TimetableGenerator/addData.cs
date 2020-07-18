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
    public partial class addData : Form
    {
        public addData()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            subjectData ss1 = new subjectData();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            inputData ss1 = new inputData();
            ss1.Show();
        }
        void clearData()
        {

            userID.Text = "";
            code.Text = "";
            sem.Text = "";
            roomno.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection("Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");
            con.Open();

            string query = "INSERT INTO COURSE(ID, COUESECODE, SEMESTER, ROOM)" +
                "VALUES(@id, @c_code, @sem, @room_no)";

            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@id", userID.Text);
            cmd.Parameters.AddWithValue("@c_code", code.Text);
            cmd.Parameters.AddWithValue("@sem", sem.Text);
            cmd.Parameters.AddWithValue("@room_no", roomno.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Stored!");
            
                //  clearData();
                con.Close();
            */
            this.Hide();
            generator ss = new generator();
            ss.Show();
        }
    }
}

