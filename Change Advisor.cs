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
    public partial class Change_Advisor : System.Windows.Forms.Form
    {
        public string user { get; set; }
        public Change_Advisor(string incominguser)
        {
            InitializeComponent();
            user = incominguser;
            List<String> Coursedatabase = new List<String>();
            List<String> CourseConfirmationdatabase = new List<String>();
            var Courselist = new Dictionary<int, dynamic>();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            System.Console.WriteLine("Contents of Course database");
            string[] courseConfirmationLines = System.IO.File.ReadAllLines(@"C:\SE Repos\F2023 Confrimation Database.txt");
            foreach (string line in lines2)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase.Add(line);
                Console.WriteLine("\n" + line);
            }
            foreach (string line in courseConfirmationLines)
            {
                // Use a tab to indent each line of the file.

                CourseConfirmationdatabase.Add(line);
                Console.WriteLine("\n" + line);
            }
            
       

            string[] lines = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            var Userlist = new Dictionary<int, dynamic>();

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);

            }

            for (int i = 0; i < Userdatabase.Count(); i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string password = Userstring[1];
                string firstname = Userstring[2];
                string middlename = Userstring[3];
                string lastname = Userstring[4];
                string status = Userstring[5];
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Userlist[i] = d1;
                Userlist[i].usrs = "User" + i;
                Console.WriteLine(Userlist[i].usrs);

                Userlist[i].usrs = new { usrname = username, pswd = password, fname = firstname, mname = middlename, lname = lastname, s = status };

                //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
            }

            // This is loading in the users into the correct places
            for (int i = 0; i < Userdatabase.Count(); i++)
            {
                
                 if (Userlist[i].usrs.s == "faculty")
                { listBox1.Items.Add(Userlist[i].usrs.usrname); }//+ " " + Userlist[i].usrs.s); }
                

            }


        }

       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

    






        }

        private void button1_Click(object sender, EventArgs e)
        {
            String newAdv = listBox1.GetItemText(listBox1.SelectedItem);

            string[] lines = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            var Userlist = new Dictionary<int, dynamic>();


            System.IO.File.WriteAllText(@"C:\SE Repos\UserDatabase.txt", string.Empty);

            foreach (string line in lines) //line 244
            {
                // Use a tab to indent each line of the file.
                string[] userSplit = line.Split(' ');
                if (userSplit[0] == user)
                {
                    String fixline = line.Replace(userSplit[5], newAdv);
                    using (StreamWriter sw = File.AppendText(@"C:\SE Repos\UserDatabase.txt"))
                    {
                        sw.Write(fixline);
                        sw.Write('\n');
                    }
                }

                else {
                    using (StreamWriter sw = File.AppendText(@"C:\SE Repos\UserDatabase.txt"))
                    {
                        sw.Write(line);
                        sw.Write('\n');
                    }
                }


                
                Console.WriteLine("\n" + line);

            }

            this.Close();


        }

        private void Change_Advisor_Load(object sender, EventArgs e)
        {

        }
    }
}
