
/* **************************** A SIMPLE PAGE THAT ASKA USER IF THEY WANT TO LOGIN OR SIGNUP ***************************** */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE LOGIN BUTTON WILL LET YOU ENTER YOUR LOGIN DETAILS 
            //                          TO ACCESS TIMETABLE FUNCTIONALITIES     --------------------
            // this will hide the previous page and will show the next requested page

            this.Hide();
            login ss1 = new login();
            ss1.Show();
        }

        private void signupbutton_Click(object sender, EventArgs e)
        {
            // ------------------ CLICKING THE SIGNUP BUTTON WILL LET YOU MAKE AN ACCOUNT SO THAT 
            //                          YOU CAN ACCESS TIMETABLE FUNCTIONALITIES        --------------------
            // this will hide the previous page and will show the next requested page

            this.Hide();
            signup ss1 = new signup();
            ss1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // NO FUNCTIONALITY IMPLEMENTATION REQUIRED
            // REMOVING THIS MAY AFFECT THE DESIGN PAGE
        }
    }
}
