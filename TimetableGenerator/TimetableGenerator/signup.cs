
/* *************************************** SIGNUP PAGE ************************************ */

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

        // Making a connection string
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THIS BUTTON WILL TAKE YOU BACK ON PREVIOUS PAGE --------------------
            // Back button will display the Form1 page and signup page will hide
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE SIGNUP BUTTON WILL LET YOU MAKE AN ACCOUNT --------------------

            // Storing data values entered by the user in variables
            string Username = UserID.Text;
            string FirstName = F_Name.Text;
            string LastName = L_Name.Text;
            string email = Email.Text;
            string password = pas.Text;
            string C_password = cpass.Text;

            // Openong the connection
            con.Open();

            // Storing data entered by the user in the database tables
            SqlCommand cmd = new SqlCommand("insert into UserTable(UserID,FirstName,LastName,Email,Password)values(@username,@fname,@lname,@email,@password)", con);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@fname", FirstName);
            cmd.Parameters.AddWithValue("@lname", LastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            if (password == C_password)
            {
                // If both the password and confirm password text matches, the success message is displayed
                warning.ForeColor = Color.Green;
                warning.Text = "Matched";
                cmd.ExecuteNonQuery();
                MessageBox.Show("You are Successfully Registered");

                // After signing in, the inputData page will be displayed where user will make a choice
                /// either to create a time table or see the previously generated timetable using code
                this.Hide();
                inputData ss1 = new inputData();
                ss1.Show();
            }
            else
            {
                // If both the password and confirm password text does not matches, the warrning message 
                // is displayed in red color with message that the password did not match.
                warning.ForeColor = Color.Red;
                warning.Text = "Password did not match! ";
            }

            // Closing the connection
            con.Close();
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Checkbox for password textbox
            if (ShowPassword.Checked)
            {
                // If the checkbox is checked  the password is revealed
                pas.UseSystemPasswordChar = false;
            }
            else
            {
                // If the checkbox is unchecked  the password is hidden
                pas.UseSystemPasswordChar = true;
            }
        }

        private void ShowConfirm_CheckedChanged(object sender, EventArgs e)
        {
            // Checkbox for confirm password textbox
            if (ShowConfirm.Checked)
            {
                // If the checkbox is checked  the password is revealed
                cpass.UseSystemPasswordChar = false;
            }
            else
            {
                // If the checkbox is unchecked  the password is hidden
                cpass.UseSystemPasswordChar = true;
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }
    }
}
