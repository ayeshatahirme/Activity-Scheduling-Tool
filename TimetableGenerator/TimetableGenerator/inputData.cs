
/* *************************************** PAGE THAT ASKS IF USRE WANTS TO GENERATE A NEW TIMETABLE 
 *                                                    OR SEE THE PREVIOUS ONE .       ************************************ */

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
    public partial class inputData : Form
    {
        public inputData()
        {
            InitializeComponent();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss1 = new Form1();
            ss1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ------------------ IT WILL LET YOU GENERATE A NEW TIMETABLE --------------------

            this.Hide();
            addData ss1 = new addData();
            ss1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ------------------ IT WILL SHOW YOU YOUR GENERATED TIMETABLE --------------------

            this.Hide();
            generator ss1 = new generator();
            ss1.Show();
        }

        private void inputData_Load(object sender, EventArgs e)
        {

        }
    }
}
