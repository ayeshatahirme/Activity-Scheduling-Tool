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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string Username = UserName.Text;
            string email = Email.Text;
            string password = Password.Text;
            SqlConnection con = new SqlConnection("Data Source=\\SQLEXPRESS;Initial Catalog=AutoTimeTable;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into UserTable(UserName,Email,Password)values(@username,@email,@password)", con);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            MessageBox.Show("You are Successfully added");
            new login().Show();
            this.Hide();
        }
        }
    }
}
