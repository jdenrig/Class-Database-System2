using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Login_Window
{
    public partial class courseDeletionForm : System.Windows.Forms.Form
    {
        public courseDeletionForm(string courseName)
        {
            InitializeComponent();
            string course = "The course ";
            course += courseName;
            course += " has been removed.";
            label1.Text = course;   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
