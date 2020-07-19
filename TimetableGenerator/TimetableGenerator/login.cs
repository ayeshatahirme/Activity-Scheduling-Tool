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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void loginbut_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");
            
            // Storing data in a string from textbox

            string username = UserID_textBox.Text;
            string password = Password_textBox.Text;
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM UserTable WHERE UserID=@username AND Password=@password ", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("You are Login Successfully");
                this.Hide();
                inputData ss1 = new inputData();
                ss1.Show();
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

        private void Show_CheckedChanged(object sender, EventArgs e)
        {
            if (Show.Checked)
            {
                Password_textBox.UseSystemPasswordChar = false;
            }
            else
            {
                Password_textBox.UseSystemPasswordChar = true;
            }
        }
    }
}
