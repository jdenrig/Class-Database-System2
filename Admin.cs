using Form;
using Microsoft.VisualBasic.ApplicationServices;
using Overload_Warning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Warning_Form;
using static Login_Window.AddUserForm;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Login_Window
{
    public partial class Admin : System.Windows.Forms.Form
    {
        string time;
        string curCourse;
        string tempUser;
        int line_to_edit;
        int itemToRemove;
        string lineToWrite;
        string numCoursesTaken;
        int line_to_replace;
        string replacementString;
        string curStudent;
        
        //Global variables
        List<String> currentSchedNames = new List<String>(); //this is a internal list of what classes the student is enrolled into
        List<String> currentSchedTimes = new List<String>(); // and the time those classes occur
        float creditTot = 0; // This allows us to know the credit total in this form.
        string selectedClass;
     
        public string user { get; set; }
        public string course { get; set; }

        public Admin()
        {

            InitializeComponent();

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
            for (int i = 0; i < Coursedatabase.Count; i++)
            {
                listBox2.Items.Add(Coursedatabase[i]);
                checkedListBox1.Items.Add(Coursedatabase[i]);
            }
            for (int i = 0; i < CourseConfirmationdatabase.Count(); i++)
            {
                string[] confrimationSplit = CourseConfirmationdatabase[i].Split(" ");
                if (confrimationSplit.Count() > 1)
                {
                    string user = confrimationSplit[0];
                    string status = confrimationSplit[1];
                    if (status == "0")
                    {
                        listBox7.Items.Add(user);
                    }
                }

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
                string status = "";
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string password = Userstring[1];
                string firstname = Userstring[2];
                string middlename = Userstring[3];
                string lastname = Userstring[4];
                if (Userstring.Length == 6)
                {
                     status = Userstring[5];
                }
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
                if ((Userlist[i].usrs.s == "admin"))
                { listBox1.Items.Add(Userlist[i].usrs.usrname + " " + Userlist[i].usrs.s); }
                else if (Userlist[i].usrs.s == "faculty")
                { listBox3.Items.Add(Userlist[i].usrs.usrname); }//+ " " + Userlist[i].usrs.s); }
                else { listBox4.Items.Add(Userlist[i].usrs.usrname); listBox8.Items.Add(Userlist[i].usrs.usrname);

                }

            }

            //List<String> Coursedatabase = new List<String>();
            //string[] lines2 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            this.user = user;


            //System.Console.WriteLine("Contents of Course database");
            //foreach (string line in lines2)
            //{
            //    // Use a tab to indent each line of the file.
            //    Coursedatabase.Add(line);
            //    Console.WriteLine("\n" + line);
            //}
            //for (int i = 0; i < Coursedatabase.Count; i++)
            //{
            //    checkedListBox1.Items.Add(Coursedatabase[i]);
            //}

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempUser = listBox1.SelectedItem.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            // *************** SHOULD ADD THE PROFS NAME TO THE ROSTER TOO *********************

            listBox6.Items.Clear();
            string curCourse = listBox2.SelectedItem.ToString();
            course = curCourse;
            string courseNum = curCourse.Substring(0, curCourse.IndexOf(' '));
            //string courseName = curCourse.Substring(curCourse.IndexOf(courseNum), curCourse.IndexOf(' '));
            //string profName = "Instructor: " + curCourse.Substring(curCourse.IndexOf(courseName), curCourse.IndexOf(' '));
            listBox6.Items.Add(courseNum); //Prints out the class number to the roster before displaying the students
            //listBox6.Items.Add(profName);

            //string[] OGCourseDataBase = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\OrginalCourseHistoryDatabase.txt");
            string[] CourseHisDataBase = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<string> addedCoursesDataBase = new List<string>();

            foreach (string line in CourseHisDataBase)
            {
                string[] splitLines = line.Split(' ');
                if (splitLines.Contains(courseNum))
                {

                    if (splitLines[Array.IndexOf(splitLines, courseNum) + 1] == "F23")
                    {
                        listBox6.Items.Add(splitLines[0]);
                    }
                    else
                    {
                        string[] splitLines2 = line.Split(courseNum);
                        if (splitLines2.Contains(courseNum))
                        {

                            if (splitLines[Array.IndexOf(splitLines2, courseNum) + 1] == "F23")
                            { listBox6.Items.Add(splitLines[0]); }


                        }
                    }
                }


            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Refresh Button that can be used after deleting a user
            Admin refreshedForm = new Admin();
            refreshedForm.Show();
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Steal Advisee code from faculty menu


        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ask Naomi to do this bit
            tempUser = listBox3.SelectedItem.ToString();
            listBox5.Items.Clear();
            List<String> Userdatabase = new List<String>();
            string[] users = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\UserDatabase.txt");

            foreach (string line in users)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
            }

            for (int i = 0; i < Userdatabase.Count; i++)
            {
                string[] Userstring = Userdatabase[i].Split(" ");
                string advisor = Userstring[5];
                if (tempUser == advisor)
                {
                    string advisee = Userstring[2] + " " + Userstring[3] + " " + Userstring[4];
                    listBox5.Items.Add(advisee);
                }
            }
            //itemToRemove = listBox4.SelectedIndex;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempUser = listBox4.SelectedItem.ToString();
            //itemToRemove = listBox4.SelectedIndex;
            //listBox4.Items.RemoveAt(itemToRemove);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            string[] lines3 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<String> CourseHistoryDatabase = new List<String>();
            var Userlist = new Dictionary<int, dynamic>();

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);

            }
            foreach (string line in lines3)
            {
                // Use a tab to indent each line of the file.
                CourseHistoryDatabase.Add(line);
                Console.WriteLine("\n" + line);

            }

            for (int i = 0; i < Userdatabase.Count(); i++)
            {
                string status = "";
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string password = Userstring[1];
                string firstname = Userstring[2];
                string middlename = Userstring[3];
                string lastname = Userstring[4];
                if (Userstring.Length == 6) { 
                     status = Userstring[5];
            }
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Userlist[i] = d1;
                Userlist[i].usrs = "User" + i;
                Console.WriteLine(Userlist[i].usrs);

                Userlist[i].usrs = new { usrname = username, pswd = password, fname = firstname, mname = middlename, lname = lastname, s = status };
                if (Userlist[i].usrs.usrname == tempUser)
                {
                    line_to_edit = i;
                }

                //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
            }

            using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\UserDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= lines.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        //writer.WriteLine(""); //skips over the rewrite to delete selected users.
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine]);
                    }
                }
            }
            for (int i = 0; i < CourseHistoryDatabase.Count(); i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username1 = Userstring[0];
                if (username1 == tempUser)
                {
                    line_to_edit = i;
                }

                //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
            }
            using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseHistoryDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= lines3.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        //writer.WriteLine(""); //skips over the rewrite to delete selected users.
                    }
                    else
                    {
                        writer.WriteLine(lines3[currentLine]);
                    }
                }
            }
            listBox4.Items.Clear();
            listBox3.Items.Clear();
            listBox1.Items.Clear();
            Userdatabase.Clear();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            foreach (string line in lines2)
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
                if ((Userlist[i].usrs.s == "admin"))
                { listBox1.Items.Add(Userlist[i].usrs.usrname); }
                else if (Userlist[i].usrs.s == "faculty")
                { listBox3.Items.Add(Userlist[i].usrs.usrname); }//+ " " + Userlist[i].usrs.s); }
                else { listBox4.Items.Add(Userlist[i].usrs.usrname); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUserForm newUserForm = new AddUserForm();
            newUserForm.Show();
            this.Close();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            Faculty facultyForm = new Faculty("dumFac");
            facultyForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDrop addForm = new AddDrop("dumStu");
            addForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string CourseToEdit = listBox2.GetItemText(listBox2.SelectedItem);
            List<String> Coursedatabase = new List<String>();
            string[] courses = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            foreach (string course in courses)
            {
                if (course != CourseToEdit)
                { Coursedatabase.Add(course); }

            }

            System.IO.File.WriteAllText(@"C:\SE Repos\CourseDatabase.txt", string.Empty);

            foreach (string course in Coursedatabase)
                using (StreamWriter sw = File.AppendText(@"C:\SE Repos\CourseDatabase.txt")) //appending the line to the course data base
                {
                    sw.WriteLine(course);

                }

            listBox2.Items.Clear();
            var Courselist = new Dictionary<int, dynamic>();
            List<String> Coursedatabase2 = new List<String>();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            //System.Console.WriteLine("Contents of Course database");

            foreach (string line in lines2)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase2.Add(line);
                Console.WriteLine("\n" + line);
            }

            for (int i = 0; i < Coursedatabase2.Count; i++)
            {
                listBox2.Items.Add(Coursedatabase2[i]);
            }

            //List<String> Coursedatabase = new List<String>();
            //string[] courses = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            //foreach (string line in courses)
            //{
            //    // Use a tab to indent each line of the file.
            //    Coursedatabase.Add(line);
            //    //Console.WriteLine("\n" + line);
            //}
            //for (int i = 0; i < Coursedatabase.Count(); i++)
            //{
            //    if (curCourse == Coursedatabase[i])
            //    {
            //        line_to_edit = i;
            //        string[] tempSplit = Coursedatabase[i].Split(" ");
            //        string courseName = tempSplit[0];
            //        courseDeletionForm deleteForm = new courseDeletionForm(courseName);
            //        deleteForm.Show();
            //    }
            //}
            //using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseDatabase.txt"))
            //{
            //    for (int currentLine = 0; currentLine <= courses.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
            //    {
            //        if (currentLine == line_to_edit)
            //        {
            //            //writer.WriteLine(""); //skips over the rewrite to delete selected users.
            //        }
            //        else
            //        {
            //            writer.WriteLine(courses[currentLine]);
            //        }
            //    }
            //}

            //listBox2.Items.Clear();
            //var Courselist = new Dictionary<int, dynamic>();
            //List<String> Coursedatabase2 = new List<String>();
            //string[] lines2 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            ////System.Console.WriteLine("Contents of Course database");

            //foreach (string line in lines2)
            //{
            //    // Use a tab to indent each line of the file.
            //    Coursedatabase2.Add(line);
            //    Console.WriteLine("\n" + line);
            //}

            //for (int i = 0; i < Coursedatabase2.Count; i++)
            //{
            //    listBox2.Items.Add(Coursedatabase2[i]);
            //}
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            curStudent = listBox7.SelectedItem.ToString();
            string[] lines = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            string[] lines3 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<String> CourseHistoryDatabase = new List<String>();
            var Userlist = new Dictionary<int, dynamic>();
            int numCoursesThatNeedApproval = 0;

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);

            }
            foreach (string line in lines3)
            {
                // Use a tab to indent each line of the file.
                CourseHistoryDatabase.Add(line);
                Console.WriteLine("\n" + line);

            }
            for (int i = 0; i < CourseHistoryDatabase.Count(); i++)
            {
                string[] courseHistoryString = CourseHistoryDatabase[i].Split(" ");
                string username = courseHistoryString[0];
                string numCourses = courseHistoryString[1];
                if (curStudent == username)
                {
                    numCoursesTaken = numCourses;
                    textBox2.Clear();
                    textBox2.Text = numCoursesTaken;
                }

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
                if (curStudent == username)
                {
                    textBox1.Clear();
                    textBox1.Text = status;

                    string[] CourseHisDataBase = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
                    List<string> addedCoursesDataBase = new List<string>();

                    foreach (string line in CourseHisDataBase)
                    {
                        string[] splitLines = line.Split(' ');
                        if (splitLines[0].Contains(username))
                        {

                            for (int j = 0; j < splitLines.Length; j++)
                            {

                                if (splitLines[j] == "F23")
                                {
                                    string newCourses;
                                    newCourses = splitLines[j - 1];
                                    //newCourses += " ";
                                    //newCourses += splitLines[i];
                                    //newCourses += " ";
                                    //newCourses += splitLines[i + 1];
                                    //newCourses += " ";
                                    //newCourses += splitLines[i + 2];
                                    //newCourses += " ";
                                    //advSched.Items.Add(newCourses);
                                    string fullClassData;
                                    //string selectedItem = advSched.SelectedItem.ToString();
                                    string[] lines10 = File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
                                    List<String> Coursedatabase = new List<String>();
                                    foreach (string line5 in lines10)
                                    {
                                        Coursedatabase.Add(line5);
                                    }
                                    for (int p = 0; p < Coursedatabase.Count; p++)
                                    {
                                        string[] classSplit = Coursedatabase[p].Split(" ");
                                        string className = classSplit[0];
                                        if (className == newCourses)
                                        {
                                            numCoursesThatNeedApproval += 1;
                                            fullClassData = Coursedatabase[p];
                                            //advSched.Items.Add(fullClassData);
                                            string[] splitClassData = fullClassData.Split(" ");
                                            string days = splitClassData[6];
                                            int index = dataGridView1.Rows.Add(); //creates new row
                                            dataGridView1.Rows[index].Cells[0].Value = splitClassData[0]; //enters values into their specified collumns
                                            dataGridView1.Rows[index].Cells[1].Value = splitClassData[1];
                                            dataGridView1.Rows[index].Cells[2].Value = splitClassData[2];
                                            dataGridView1.Rows[index].Cells[3].Value = splitClassData[3];
                                            dataGridView1.Rows[index].Cells[4].Value = splitClassData[4];
                                            dataGridView1.Rows[index].Cells[5].Value = splitClassData[5];
                                            dataGridView1.Rows[index].Cells[6].Value = dayTranslation(days);
                                            dataGridView1.Rows[index].Cells[7].Value = timeStartTranslation(days);
                                            dataGridView1.Rows[index].Cells[8].Value = timeEndTranslation(days, time);

                                            //only happens if there are two time blocks
                                            if (splitClassData.Count() == 8)
                                            {
                                                index = dataGridView1.Rows.Add();
                                                dataGridView1.Rows[index].Cells[6].Value = dayTranslation(days);
                                                dataGridView1.Rows[index].Cells[7].Value = timeStartTranslation(days);
                                                dataGridView1.Rows[index].Cells[8].Value = timeEndTranslation(days, time);
                                                string extraTimeBlock = splitClassData[7];

                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            textBox3.Clear();
            textBox3.Text = numCoursesThatNeedApproval.ToString();

        }
        string dayTranslation(string timeReadIn)
        {
            int x = int.Parse(timeReadIn);

            if (x / 1000 == 21)
            {
                return "MWF";
            }
            else if (x / 1000 == 8)
            {
                return "R";
            }
            else if (x / 1000 == 15) { return "MTWR"; }
            else if (x / 1000 == 12) { return "WR"; }
            else if (x / 1000 == 1) { return "M"; }
            else if (x / 1000 == 2) { return "T"; }
            else if (x / 1000 == 4) { return "W"; }

            else
            {
                return "F";
            }

        }

        //This is a dumb way to do this. Maybe coming back and fixing this may be good
        string timeStartTranslation(string timeReadIn)
        {
            int x = int.Parse(timeReadIn);
            float finalTime = 0;
            bool not12 = true;
            bool isPM = false;
            int y;
            float milTime = ((x / 10) % 100) / 2f;

            //These next conditional Statements are finding out the start time of the course
            if ((milTime / 12) <= 1) //AM
            {
                if (milTime % 0.5 == 1) // If we have a 30 minute start time
                {
                    finalTime = (int)(milTime - 0.5);
                    time = finalTime.ToString();
                    time = time + ":30 A.M.";

                }
                else
                {
                    time = milTime.ToString();
                    time = time + ":00 A.M.";
                }



            }
            // NEED TO MAKE AN IF ELSE IF THERE IS AN EXACT 12

            else //PM
            {
                finalTime = (int)(milTime - 12); // Subtracting 12 hours from military time because it is in the PM // IT IS NOT SUBTRACTING BY 12 WTF

                if (finalTime % 0.5 == 1) // If we have a 30 minute start time
                {
                    finalTime = (int)(milTime - 0.5);

                    time = finalTime.ToString();
                    time = time + ":30 P.M.";

                }
                else
                {
                    time = finalTime.ToString();
                    time = time + ":00 P.M.";
                }

                isPM = true;

            }
            string[] tempVal1 = time.Split(":");
            string firstNum1 = tempVal1[0];
            y = int.Parse(firstNum1);
            tempVal1[0] += ":";
            tempVal1[0] += tempVal1[1];


            string[] tempVal = time.Split(":");
            string firstNum = tempVal[0];
            y = int.Parse(firstNum);
            if (y == 0)
            {
                tempVal[0] = "";
                tempVal[0] += 12;
                tempVal[0] += ":";
                tempVal[0] += tempVal[1];
                not12 = false;
            }
            if (not12 == true)
            {
                return tempVal1[0];
            }
            else
            {
                return tempVal[0];
            }
        }

        // this block of conditional statements is going to add the end time of the course to the time string
        //This code isn't working for some reason
        string timeEndTranslation(string timeReadIn, string timeval)
        {

            int x = int.Parse(timeReadIn);
            float finalTime;
            string[] time = timeval.Split(':');
            string firstNum = time[0];
            string SecNum = time[1];
            bool isPM = false;
            finalTime = (x % 10);
            double timeComp = float.Parse(time[0]);
            if (time[1] == "30")
            {
                timeComp += .5;
            }
            if (timeComp == 0)
            {
                timeComp += 12;
            }

            for (int i = 0; i < finalTime; i++)
            {
                timeComp += .5;
            }
            if (timeComp > 12)
            {
                timeComp -= 12;
                isPM = true;
            }
            if (timeComp % 1 != 0)
            {
                timeComp -= .5;
                time[0] = timeComp.ToString();
                time[0] += ":30";
            }
            else
            {
                time[0] = timeComp.ToString();
                time[0] += ":00";
            }
            if (isPM == true)
            {
                time[0] += " P.M.";
            }
            else
            {
                time[0] += " A.M.";
            }
            return time[0];
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string curStu = (string)listBox7.SelectedItem;

            string[] lines = File.ReadAllLines(@"C:\SE Repos\F2023 Confrimation Database.txt");
            string[] lines2 = File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            List<String> Confirmationdatabase = new List<String>();

            System.IO.File.WriteAllText(@"C:\SE Repos\F2023 Confrimation Database.txt", string.Empty);

            foreach (string line in lines) //line 244
            {
                // Use a tab to indent each line of the file.
                string[] userSplit = line.Split(' ');
                if (userSplit[0] == curStu)
                {
                    String fixline = line.Replace(userSplit[1], "1");
                    using (StreamWriter sw = File.AppendText(@"C:\SE Repos\F2023 Confrimation Database.txt"))
                    {
                        sw.Write(fixline);
                        sw.Write('\n');
                    }
                }

                else
                {
                    using (StreamWriter sw = File.AppendText(@"C:\SE Repos\F2023 Confrimation Database.txt"))
                    {
                        sw.Write(line);
                        sw.Write('\n');
                    }
                }

                //using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\F2023 Confrimation Database.txt")) {
                //    for (int i = 0; i < Confirmationdatabase.Count - 1; i++)
                //    {
                //        string[] Confirmationstring = Confirmationdatabase[i].Split(' ');
                //        string user2 = Confirmationstring[0];
                //        string confirmVal = Confirmationstring[1];
                //        if (user2 == curStudent)
                //        {
                //            lineToWrite = curStudent;
                //            lineToWrite += " 1";
                //            writer.WriteLine(lineToWrite);
                //        }
                //        else
                //            writer.WriteLine(user2 + " " + confirmVal);
                //    }

                //}
                //using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\F2023 Confrimation Database.txt"))
                //{
                //    for (int currentLine = 0; currentLine <= lines.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                //    {
                //        if (currentLine == line_to_edit)
                //        {
                //            writer.WriteLine(lineToWrite);
                //        }
                //        else
                //        {
                //            writer.WriteLine(lines[currentLine]);
                //        }
                //    }
                //}

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\SE Repos\F2023 Confrimation Database.txt");
            string[] lines2 = File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            string[] lines3 = File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            string[] lines4 = File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<String> Userdatabase = new List<String>();
            List<String> Confirmationdatabase = new List<String>();
            List<String> OriginalCourseHistorydatabase = new List<String>();
            List<String> CourseHistorydatabase = new List<String>();

            int newSeatNum;
            string[] lines5 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            List<String> Courselist = new List<String>();
            var CourseDic = new Dictionary<int, dynamic>();


            foreach (string line in lines5)
            {
                // Use a tab to indent each line of the file.
                Courselist.Add(line);
                //Console.WriteLine("\n" + line);

            }
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--) //loops through our dataTable and finds any rows with a checked index, if the index is checked that whole row gets removed.
            {
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[i];

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value) == true)
                {
                    line_to_replace = i;
                }
            }
            for (int p = 0; p < Courselist.Count; p++)
            {
                string[] classString = Courselist[p].Split(" ");
                string classNum = classString[0];
                string classNam = classString[1];
                string faculty = classString[2];
                string creditTot = classString[3];
                string numSeats = classString[4];
                string numTimeBlocks = classString[5];
                string timeBlock1 = classString[6];
                if (numTimeBlocks == "2")
                {
                    string timeBlock2 = classString[7];
                }

                if (classNum == (string)dataGridView1.Rows[line_to_replace].Cells[0].Value)

                {
                    line_to_edit = p;
                    newSeatNum = int.Parse(numSeats);
                    newSeatNum += 1;
                    replacementString = classNum;
                    replacementString += " ";
                    replacementString += classNam;
                    replacementString += " ";
                    replacementString += faculty;
                    replacementString += " ";
                    replacementString += creditTot;
                    replacementString += " ";
                    replacementString += newSeatNum.ToString();
                    replacementString += " ";
                    replacementString += numTimeBlocks;
                    replacementString += " ";
                    replacementString += timeBlock1;
                    if (numTimeBlocks == "2")
                    {
                        replacementString += " ";
                        replacementString += classString[7];
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= lines5.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        writer.WriteLine(replacementString);
                    }
                    else
                    {
                        writer.WriteLine(lines5[currentLine]);
                    }
                }
            }
            foreach (string line in lines3)
            {
                OriginalCourseHistorydatabase.Add(line);
            }
            foreach (string line in lines4)
            {
                CourseHistorydatabase.Add(line);
            }
            foreach (string line in lines2)
            {
                Userdatabase.Add(line);
            }
            foreach (string line in lines)
            {
                Confirmationdatabase.Add(line);
            }

            for (int i = 0; i < Confirmationdatabase.Count - 1; i++)
            {
                string[] Confirmationstring = Confirmationdatabase[i].Split(' ');
                string user2 = Confirmationstring[0];

                if (user2 == curStudent)
                {
                    line_to_edit = i;
                    lineToWrite = curStudent;
                    lineToWrite += " 0";
                }

            }
            using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\F2023 Confrimation Database.txt"))
            {
                for (int currentLine = 0; currentLine <= lines.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine]);
                    }
                }
            }

            for (int i = 0; i < OriginalCourseHistorydatabase.Count - 1; i++)
            {
                string[] OriginalCourseHistorystring = OriginalCourseHistorydatabase[i].Split(' ');
                string user2 = OriginalCourseHistorystring[0];

                if (user2 == curStudent)
                {
                    line_to_edit = i;

                    lineToWrite = OriginalCourseHistorydatabase[i];
                }
            }




            List<String> CourseHistory = new List<String>();
            var Historylist = new Dictionary<int, dynamic>();
            foreach (string line in lines4)
            {
                // Use a tab to indent each line of the file.
                CourseHistory.Add(line);
                Console.WriteLine("\n" + line);

            }
            for (int l = 0; l < CourseHistory.Count - 1; l++)
            {
                string[] Historystring = CourseHistory[l].Split(' '); //reading in the coursehistory
                string username = Historystring[0];
                string numCourses2 = Historystring[1];
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Historylist[l] = d1;
                Historylist[l].usrs = "User" + l;
                Historylist[l].usrs = new { usrname = username, courseNum = numCourses2 };
            }
            for (int b = 0; b < Historylist.Count; b++)
            {
                if (curStudent == Historylist[b].usrs.usrname)
                {
                    line_to_edit = b;
                }
            }
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--) //loops through our dataTable and finds any rows with a checked index, if the index is checked that whole row gets removed.
            {
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[i];

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value) == true)
                {
                    string replacementLine;
                    replacementLine = (string)dataGridView1.Rows[i].Cells[0].Value;
                    replacementLine += " ";
                    replacementLine += "F23";
                    replacementLine += " ";
                    replacementLine += (string)dataGridView1.Rows[i].Cells[3].Value;
                    replacementLine += " ";
                    replacementLine += "N";

                    string[] lines6 = File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");

                    string oldLine = lines6[line_to_edit];
                    string[] splitText = oldLine.Split(replacementLine);
                    string newText = splitText[0];
                    if (splitText.Count() >= 1)
                    {
                        newText += splitText[1];
                    }

                    string[] newText2 = newText.Split(" ");
                    int numClasses = int.Parse(newText2[1]);
                    numClasses -= 1;
                    string newText3 = newText2[0];
                    newText3 += " ";
                    newText3 += numClasses.ToString();
                    newText3 += " ";
                    for (int g = 2; g < newText2.Count(); g++)
                    {
                        newText3 += newText2[g];
                        newText3 += " ";
                    }
                    string lineToWrite = newText3;


                    // Write the new file over the old file.
                    using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseHistoryDatabase.txt"))
                    {
                        for (int currentLine = 0; currentLine <= lines6.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                        {
                            if (currentLine == line_to_edit)
                            {
                                writer.WriteLine(lineToWrite);
                            }
                            else
                            {
                                writer.WriteLine(lines6[currentLine]);
                            }
                        }
                    }
                    dataGridView1.Rows.RemoveAt(i);

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Course_Edits_Window edit = new Course_Edits_Window(course);
            edit.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String selectStu = listBox4.GetItemText(listBox4.SelectedItem);
            Change_Advisor changeAdvis = new Change_Advisor(selectStu);
            changeAdvis.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Drop_btn_Click(object sender, EventArgs e)
        {
            string[] lines3 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<String> CourseHistory = new List<String>();
            var Historylist = new Dictionary<int, dynamic>();
            int newSeatNum;
            string[] lines4 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            List<String> Courselist = new List<String>();
            var CourseDic = new Dictionary<int, dynamic>();

            foreach (string line in lines3)
            {
                // Use a tab to indent each line of the file.
                CourseHistory.Add(line);
                //Console.WriteLine("\n" + line);

            }
            foreach (string line in lines4)
            {
                // Use a tab to indent each line of the file.
                Courselist.Add(line);
                //Console.WriteLine("\n" + line);

            }
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--) //loops through our dataTable and finds any rows with a checked index, if the index is checked that whole row gets removed.
            {
                DataGridViewRow dataGridViewRow = dataGridView2.Rows[i];

                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[9].Value) == true)
                {
                    line_to_replace = i;
                }
            }
            for (int p = 0; p < Courselist.Count; p++)
            {
                string[] classString = Courselist[p].Split(" ");
                string classNum = classString[0];
                string classNam = classString[1];
                string faculty = classString[2];
                string creditTot = classString[3];
                string numSeats = classString[4];
                string numTimeBlocks = classString[5];
                string timeBlock1 = classString[6];
                if (classString.Length == 8)
                {
                    string timeBlock2 = classString[7];

                }

                if (classNum == (string)dataGridView2.Rows[line_to_replace].Cells[0].Value)

                {
                    line_to_edit = p;
                    newSeatNum = int.Parse(numSeats);
                    newSeatNum += 1;
                    replacementString = classNum;
                    replacementString += " ";
                    replacementString += classNam;
                    replacementString += " ";
                    replacementString += faculty;
                    replacementString += " ";
                    replacementString += creditTot;
                    replacementString += " ";
                    replacementString += newSeatNum.ToString();
                    replacementString += " ";
                    replacementString += numTimeBlocks;
                    replacementString += " ";
                    replacementString += timeBlock1;
                    if (numTimeBlocks == "2")
                    {
                        replacementString += " ";
                        replacementString += classString[7];
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= lines4.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        writer.WriteLine(replacementString);
                    }
                    else
                    {
                        writer.WriteLine(lines4[currentLine]);
                    }
                }
            }

            for (int l = 0; l < CourseHistory.Count; l++)
            {
                string[] Historystring = CourseHistory[l].Split(' '); //reading in the coursehistory
                string username = Historystring[0];
                string numCourses2 = Historystring[1];
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Historylist[l] = d1;
                Historylist[l].usrs = "User" + l;
                Historylist[l].usrs = new { usrname = username, courseNum = numCourses2 };
            }

            for (int b = 0; b < Historylist.Count; b++)
            {
                if ((string)listBox8.SelectedItem == Historylist[b].usrs.usrname)
                {
                    line_to_edit = b;
                }
            }
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--) //loops through our dataTable and finds any rows with a checked index, if the index is checked that whole row gets removed.
            {
                DataGridViewRow dataGridViewRow = dataGridView2.Rows[i];

                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[9].Value) == true)
                {
                    string replacementLine;
                    replacementLine = (string)dataGridView2.Rows[i].Cells[0].Value;
                    replacementLine += " ";
                    replacementLine += "F23";
                    replacementLine += " ";
                    replacementLine += (string)dataGridView2.Rows[i].Cells[3].Value;
                    replacementLine += " ";
                    replacementLine += "N";

                    string[] lines5 = File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");

                    string oldLine = lines5[line_to_edit];
                    string[] splitText = oldLine.Split(replacementLine);
                    string newText = splitText[0];
                    if (splitText.Count() >= 1)
                    {
                        newText += splitText[1];
                    }

                    string[] newText2 = newText.Split(" ");
                    int numClasses = int.Parse(newText2[1]);
                    numClasses -= 1;
                    string newText3 = newText2[0];
                    newText3 += " ";
                    newText3 += numClasses.ToString();
                    newText3 += " ";
                    for (int g = 2; g < newText2.Count(); g++)
                    {
                        newText3 += newText2[g];
                        newText3 += " ";
                    }
                    string lineToWrite = newText3;


                    // Write the new file over the old file.
                    using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseHistoryDatabase.txt"))
                    {
                        for (int currentLine = 0; currentLine <= lines5.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                        {
                            if (currentLine == line_to_edit)
                            {
                                writer.WriteLine(lineToWrite);
                            }
                            else
                            {
                                writer.WriteLine(lines5[currentLine]);
                            }
                        }
                    }
                    dataGridView2.Rows.RemoveAt(i);

                }






            }




        }

        private void lbl_submit_Click(object sender, EventArgs e)
        {
            List<string> courses = new List<string>(); // this is used to keep track of what courses have been selected in the select menu
            bool nameCheck = false; // this name check that we will use later to make sure we aren't adding any of the same courses twice
            bool timeCheck = false; // this is a time check that we will use later to make sure we aren't adding any courses to the schedule that have time conflicts
            bool credCheck = false;
            string[] lines6 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            string[] lines4 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<String> courseList = new List<String>();
            foreach (string item in checkedListBox1.CheckedItems) // for each course that was checked...
            {

                courses.Add(item); // we will add the string to the course list
                selectedClass = item.ToString();


            }
            string[] classSplit = selectedClass.Split(" ");
            string numSeats1 = classSplit[4];
            int numberSeats = int.Parse(numSeats1);
            numberSeats -= 1;
            string newString1 = classSplit[0];
            newString1 += " ";
            newString1 += classSplit[1];
            newString1 += " ";
            newString1 += classSplit[2];
            newString1 += " ";
            newString1 += classSplit[3];
            newString1 += " ";
            newString1 += numberSeats.ToString();
            newString1 += " ";
            newString1 += classSplit[5];
            newString1 += " ";
            newString1 += classSplit[6];
            newString1 += " ";
            if (classSplit[5] == "2")
            {
                newString1 += classSplit[7];
                //newString1 += " ";
            }


            foreach (string line in lines6)
            {
                courseList.Add(line);
            }

            for (int p = 0; p < courseList.Count(); p++)
            {
                if (selectedClass == courseList[p])
                {
                    line_to_edit = p;
                }
            }
            // this is setting the template for the new rows I am going to make later

            using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= lines6.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        writer.WriteLine(newString1);
                    }
                    else
                    {
                        writer.WriteLine(lines6[currentLine]);
                    }
                }
            }

            for (int i = 0; i < courses.Count; i++) // we are now going to look through the course list

            {
                //Splitting everything up in the course descriptions
                string[] courseInfo = courses[i].Split(' ');


                string courseNumber = courseInfo[0]; // course number
                string courseName = courseInfo[1]; // course name
                //we need to add these to the global variables if they aren't already on there

                //course history check
                List<String> historyData = new List<String>();
                var history = new Dictionary<String, List<String>>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
                System.Console.WriteLine("Contents of Course History:");
                foreach (string line in lines)
                {
                    historyData.Add(line);
                    //Debug.WriteLine("\n" + line);
                }
                for (int k = 0; k < historyData.Count; k++)
                {
                    dynamic[] classInfo = historyData[k].Split(' ');
                    string username = classInfo[0];
                    history.Add(username, new List<String>());
                    int numCourses4 = int.Parse(classInfo[1]);
                    // iterate through numClasses, add courses to list, add to dictionary
                    int spot = 2;
                    for (int j = 0; j < numCourses4; j++)
                    {
                        history[username].Add(classInfo[spot]);
                        spot += 3;

                    }
                }

                if (history[(string)listBox8.SelectedItem].Contains(courseNumber))
                {
                    warningForm error = new warningForm();
                    error.ShowDialog();
                }

                if (currentSchedNames.Count == 0) // if there is nothing in our global list then we can just add the class straight away and pass the check
                {
                    currentSchedNames.Add(courseName);
                    nameCheck = true;
                }


                else
                {
                    foreach (string item in currentSchedNames) // checking the global variable that has access to all of the courses the student has just enrolled in
                    {
                        if (item == courseNumber) // if the course is already been added
                        {
                            nameCheck = false; //it fails the name check 
                            warningForm error = new warningForm(); // show error window WILL REPLACE WITH ACTUAL GUI EVENTUALLY
                            error.ShowDialog(); //Show error
                            break; // break from the loop so we don't do anything crazy
                        }
                        else // if the item and course name aren't the same
                        {
                            nameCheck = true; // it is passing the namecheck as of now

                        }

                    }

                    if (nameCheck) { currentSchedNames.Add(courseName); } // if it did pass the name check we are going to add it to are global list
                }



                string instructor = courseInfo[2]; // instructor info
                string credit = courseInfo[3]; // credit info

                creditTot = (float)(creditTot + float.Parse(credit));

                if (creditTot >= 5) // CHECK LATER THIS IS SCREWED UP
                {
                    credCheck = false;

                }
                else
                {
                    credCheck = true;
                }

                if (credCheck == false)
                {
                    OverloadForm overloaderror = new OverloadForm();
                    overloaderror.ShowDialog();
                    break;
                }

                string numSeats = (Convert.ToInt32(courseInfo[4]) - 1).ToString(); // number of seats info

                //function to iterate the course num seats



                //Need to translate these into actual times
                string timeBlocks = courseInfo[5]; // how many time blocks this course has
                string days = courseInfo[6]; // this is the time code that later has to be translated accordingly 

                if (nameCheck == true) // here we are doing a time check only if it passes the first name check (we don't want two error windows popping up if you try to enroll in the exact same class)
                {
                    if (currentSchedTimes.Count == 0) // if there is nothing in the global list we can just add it and pass the check
                    {
                        currentSchedTimes.Add(days);
                        timeCheck = true;
                    }

                    else
                    {
                        foreach (string item in currentSchedTimes) // for each item in the list
                        {
                            if (item == days) // if it is the EXACT same as the course number I NEED TO FIGURE OUT HOW TO DO CONFLICTING TIMES BETTER 
                            {

                                timeCheck = false; // fails the check
                                OverloadForm overloaderror = new OverloadForm();
                                overloaderror.ShowDialog(); //shows the error dialog THAT NEEDS TO BE ADDED 
                                break; // Breaks out of this loop no need to keep checking


                            }
                            else
                            {
                                timeCheck = true;

                            }
                        }
                        if (timeCheck == true) { currentSchedTimes.Add(days); } // only adds if we yield a passed check



                    }
                }

                if (nameCheck && timeCheck && credCheck)
                {  //Making my new row


                    //Adding the things in the desired places
                    int index = dataGridView2.Rows.Add(); //creates new row
                    dataGridView2.Rows[index].Cells[0].Value = courseNumber; //enters values into their specified collumns
                    dataGridView2.Rows[index].Cells[1].Value = courseName;
                    dataGridView2.Rows[index].Cells[2].Value = instructor;
                    dataGridView2.Rows[index].Cells[3].Value = credit;
                    dataGridView2.Rows[index].Cells[4].Value = numSeats;
                    dataGridView2.Rows[index].Cells[5].Value = timeBlocks;
                    dataGridView2.Rows[index].Cells[6].Value = dayTranslation(days);
                    dataGridView2.Rows[index].Cells[7].Value = timeStartTranslation(days);
                    dataGridView2.Rows[index].Cells[8].Value = timeEndTranslation(days, time);

                    //only happens if there are two time blocks
                    if (courseInfo.Count() == 8)
                    {
                        index = dataGridView2.Rows.Add();
                        dataGridView2.Rows[index].Cells[6].Value = dayTranslation(days);
                        dataGridView2.Rows[index].Cells[7].Value = timeStartTranslation(days);
                        dataGridView2.Rows[index].Cells[8].Value = timeEndTranslation(days, time);
                        string extraTimeBlock = courseInfo[7];

                    }
                    string[] lines3 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
                    List<String> CourseHistory = new List<String>();
                    var Historylist = new Dictionary<int, dynamic>();
                    foreach (string line in lines3)
                    {
                        // Use a tab to indent each line of the file.
                        CourseHistory.Add(line);
                        Console.WriteLine("\n" + line);

                    }
                    string newString;
                    string[] className = new string[10];
                    string[] semester = new string[10];
                    string[] creditNum = new string[10];
                    string[] Grade = new string[10];

                    int lineIncriment;
                    for (int l = 0; l < CourseHistory.Count; l++)
                    {
                        string[] Historystring = CourseHistory[l].Split(' '); //reading in the coursehistory
                        string username = Historystring[0];
                        string numCourses2 = Historystring[1];
                        int increment = 2;
                        if ((string)listBox8.SelectedItem == username)
                        {
                            for (int o = 0; o < int.Parse(numCourses2); o++)//checks num of classes and adds different course vals based upon num of courses
                            {
                                className[o] = Historystring[increment];
                                increment++;
                                semester[o] = Historystring[increment];
                                increment++;
                                creditNum[o] = Historystring[increment];
                                increment++;
                                Grade[o] = Historystring[increment];
                                increment++;
                            }
                        }
                        dynamic d1 = new System.Dynamic.ExpandoObject();
                        Historylist[l] = d1;
                        Historylist[l].usrs = "User" + l;
                        Console.WriteLine(Historylist[l].usrs);

                        Historylist[l].usrs = new { usrname = username, courseNum = numCourses2 }; //saves some vals

                        //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
                    }

                    for (int b = 0; b < Historylist.Count; b++)
                    {
                        if ((string)listBox8.SelectedItem == Historylist[b].usrs.usrname)
                        {
                            int line_to_edit = b;
                            int increment2 = 0;

                            string tempNum = Historylist[b].usrs.courseNum; //gets old values that were already in the text file and adds those entries into the string.
                            int tempVal = int.Parse(tempNum);
                            tempVal += 1; //increments by 1 to allow for a new class to be inputted
                            newString = Historylist[b].usrs.usrname;
                            newString += " ";
                            newString += tempVal.ToString();
                            newString += " ";
                            for (int g = 0; g < tempVal - 1; g++)
                            {
                                newString += className[increment2];
                                newString += " ";
                                newString += semester[increment2];
                                newString += " ";
                                newString += creditNum[increment2];
                                newString += " ";
                                newString += Grade[increment2];
                                newString += " ";
                                increment2++;
                            }
                            newString += courseNumber; //adds in the string for any new classes that were added through our database.
                            newString += " ";
                            newString += "F23";
                            newString += " ";
                            newString += credit;
                            newString += " ";
                            newString += "N";

                            string[] lines5 = File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
                            string lineToWrite = newString;
                            // Write the new file over the old file.
                            using (StreamWriter writer = new StreamWriter(@"C:\SE Repos\CourseHistoryDatabase.txt"))
                            {
                                for (int currentLine = 0; currentLine <= lines5.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                                {
                                    if (currentLine == line_to_edit)
                                    {
                                        writer.WriteLine(lineToWrite);
                                    }
                                    else
                                    {
                                        writer.WriteLine(lines5[currentLine]);
                                    }
                                }
                            }
                            //File.AppendAllText(@"C:\Users\turtl\Desktop\CourseHistoryDatabase.txt",
                            //newString + Environment.NewLine);




                        }

                    }


                    // resetting my bool statements to false to then re iterate through more courses
                    timeCheck = false;
                    nameCheck = false;
                    credCheck = false;




                }



            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CourseHistory coursehistroyForm = new CourseHistory((string)listBox8.SelectedItem);
            coursehistroyForm.Show();
        }
    }
}

            
        

