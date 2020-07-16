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

        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss1 = new login();
            ss1.Show();
        }

        private void signupbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup ss1 = new signup();
            ss1.Show();
        }
    }
}
