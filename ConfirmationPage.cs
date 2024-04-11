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
    public partial class ConfirmationPage : System.Windows.Forms.Form
    {
        public ConfirmationPage(string firstName, string lastName)
        {
            InitializeComponent();
            label1.Text = "Courses have been confirmed for " + firstName + " " + lastName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
