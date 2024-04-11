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
    public partial class AddUserForm : System.Windows.Forms.Form
    {
        string tempstring;
        public AddUserForm()
        {
            InitializeComponent();
            string[] lines = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);

            }
            for (int i = 0; i < Userdatabase.Count - 1; i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string status = Userstring[5];
                if (status == "faculty")
                {
                    checkedListBox1.Items.Add(username);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string firstName = textBox3.Text;
            string middleName = textBox4.Text;
            string lastName = textBox5.Text;
            string status = checkedListBox1.SelectedItem.ToString();
            tempstring = username;
            tempstring += " ";
            tempstring += password;
            tempstring += " ";
            tempstring += firstName;
            tempstring += " ";
            tempstring += middleName;
            tempstring += " ";
            tempstring += lastName;
            tempstring += " ";
            tempstring += status;
            textBox6.Text = tempstring;
            File.AppendAllText(@"C:\SE Repos\UserDatabase.txt", tempstring + Environment.NewLine);
            File.AppendAllText(@"C:\SE Repos\CourseHistoryDatabase.txt", username + " " + "0" + Environment.NewLine);
            Admin refreshedForm = new Admin();
            refreshedForm.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
