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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = UserID.Text;
            string FirstName = F_Name.Text;
            string LastName = L_Name.Text;
            string email = Email.Text;
            string password = pas.Text;
            string C_password = cpass.Text;
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into UserTable(UserID,FirstName,LastName,Email,Password)values(@username,@fname,@lname,@email,@password)", con);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@fname", FirstName);
            cmd.Parameters.AddWithValue("@lname", LastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            if (password == C_password)
            {
                warning.ForeColor = Color.Green;
                warning.Text = "Matched";
                cmd.ExecuteNonQuery();
                MessageBox.Show("You are Successfully Registered");

                this.Hide();
                inputData ss1 = new inputData();
                ss1.Show();
            }
            else
            {
                warning.ForeColor = Color.Red;
                warning.Text = "Password didn't Match ";
             //   cpass.Focus();
            }
            con.Close();
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked)
            {
                pas.UseSystemPasswordChar = false;
            }
            else
            {
                pas.UseSystemPasswordChar = true;
            }
        }

        private void ShowConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowConfirm.Checked)
            {
                cpass.UseSystemPasswordChar = false;
            }
            else
            {
                cpass.UseSystemPasswordChar = true;
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }
    }
}
