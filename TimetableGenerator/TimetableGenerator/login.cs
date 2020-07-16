using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableGenerator
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void loginbut_Click(object sender, EventArgs e)
        {
            string username = User_textBox.Text;
            string password = Password_textBox.Text;
            SqlConnection con = new SqlConnection("Data Source=\\SQLEXPRESS;Initial Catalog=AutoTimeTable;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from UserTable where UserName=@username and User_password=@password ", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("You are Login Successfully");
                new inputData().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Credential are wrong");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }
        private void SignUp_Click(object sender, EventArgs e)
        {
            new signup().Show();
            this.Hide();
        }
    }
}
