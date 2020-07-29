
/* *************************************** LOGIN PAGE ************************************ */

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
            // ------------------ LOGIN BUTTON WILL LET YOU LOGIN THE ACCOUNT USING 
            //                    INFORMATION YOU SIGNED UP WITH --------------------

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");
            
            // Storing data in a string from textbox
            string username = UserID_textBox.Text;
            string password = Password_textBox.Text;
            // Opening the conection
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
                // If the data entered is valid; user will shown a success message and will be 
                // logged in to the system. 
                MessageBox.Show("You are Logged in Successfully");

                // After login, next page of inputData is displayed and the previous one is hidden
                this.Hide();
                inputData ss1 = new inputData();
                ss1.Show();
            }
            else
            {
                // Incase the username and password are not valid, a error message will be displayed.
                MessageBox.Show("Login Credential are incorrect");
            }

            // Connection is closed
            con.Close();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ------------------ IT WILL TAKE YOU BACK ON PREVIOUS PAGE --------------------
            //  At back button, previous page of Form1 is displayed and the current page is hidden
            // Form1 is the first page where user is asked either to login or signup
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }

        private void Show_CheckedChanged(object sender, EventArgs e)
        {
            // It is the check box to show entered password
            if (Show.Checked)
            {
                // If the checkbox is checked, the password is revealed
                Password_textBox.UseSystemPasswordChar = false;
            }
            else
            {
                // If the checkbox is unchecked, the password is not revealed
                Password_textBox.UseSystemPasswordChar = true;
            }
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE THIS BUTTON WILL LET YOU MAKE AN ACCOUNT --------------------
            // Clicking on the signup button, previous page will dissapear and signup page is displayed
            this.Hide();
            signup ss1 = new signup();
            ss1.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }
    }
}
