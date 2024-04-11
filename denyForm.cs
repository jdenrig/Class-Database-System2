using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Window
{
    public partial class denyForm : System.Windows.Forms.Form
    {
        public denyForm(string firstName,string lastName)
        {
            InitializeComponent();
            label1.Text = "Course Selection has been denied for " + firstName + " " + lastName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
