using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Window
{
    public partial class Course_Edits_Window : System.Windows.Forms.Form
    {
        public Course_Edits_Window(string courseToEdit)
        {
            //need to pass in the course information as a 


            InitializeComponent();
            this.CourseToEdit = courseToEdit;
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
            for (int i = 0; i < Userdatabase.Count() - 1; i++)
            {
       
                if (Userlist[i].usrs.s == "faculty")
                { listBox1.Items.Add(Userlist[i].usrs.usrname); }//+ " " + Userlist[i].usrs.s); }
 

            }


            //adding the days of the week to the days of the week check box list
            days_ChLstBx.Items.Add("Monday");
            days_ChLstBx.Items.Add("Tuesday");
            days_ChLstBx.Items.Add("Wednesday");
            days_ChLstBx.Items.Add("Thursday");
            days_ChLstBx.Items.Add("Friday");



        }
        public string CourseToEdit { set; get; }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Course_Edits_Window_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            //now we have to read in the course to figure out were to change things and then recompile the string

            string[] courseInfo = CourseToEdit.Split(' ');
            string courseNum = courseInfo[0];
            string courseName = courseInfo[1];
            string courseInstruct = courseInfo[2];
            string credits = courseInfo[3];
            string classSeats = courseInfo[4];
            string numBlocks = courseInfo[5];
            string OrginalTime = courseInfo[6];
            int timeAdjusted = int.Parse(courseInfo[6]);
            // may have to add the second block adjustments if I wanted to fill everything all out

            string editedCourse = courseNum + " " + courseName;


            if (listBox1.SelectedIndex >= 0)
            {
                string instructSwitch = (string)listBox1.SelectedItem; //need to find correct syntax
                editedCourse +=  " " + instructSwitch+ " " + credits+ ' ' + classSeats+ " "+  numBlocks;
            }
            else
            {
                editedCourse +=  " " + courseInstruct + " " + credits + ' ' + classSeats+" "+ numBlocks;
            }

            bool timeChanged = false;
            bool dayChanged = false;
            float finalTime = 0;

            if (string.IsNullOrEmpty(textBox1.Text) != true || string.IsNullOrEmpty(textBox2.Text) != true )
            {
                float startTimeHours =Int32.Parse( textBox1.Text.ToString());
                float  startTimeMinutes = Int32.Parse(textBox2.Text.ToString());
                
                // do the encoding for theses

                if (radioButton1.Checked == true)
                {
                    if (startTimeMinutes == 30)
                    { finalTime = (float)((startTimeHours + 0.5) * 20); }
                    else if (startTimeMinutes == 0)
                    { finalTime = (float)(startTimeHours * 20); }
                       
                }
                else if (radioButton2.Checked == true)
                {
                    if (startTimeMinutes == 30)
                    { finalTime = (float)((startTimeHours + 12.5) * 20); }
                    else if (startTimeMinutes == 0)
                    { finalTime = (float)((startTimeHours + 12) * 20); }
                }

                if (radioButton4.Checked == true)
                { finalTime = (float)((finalTime + 1)); }
                else if(radioButton3.Checked == true )
                { finalTime = (float)(finalTime + 3); }

                timeAdjusted = (int)((finalTime + (timeAdjusted / 1000) * 1000));
                //                ddttl
                //# dd = days {ddttl / 1000 = dd}
                //        Mon = 1 Tue = 2 Wed = 4 Thurs = 8 Fri = 16

                //        MWF = (1 + 4 + 16) = 21

                //        if (dd & Thurs)    // returns true if Thursday is part of dd
                //# tt = starting time for class- in military, times 2 {(ddttl/10)%100 = tt}
                //                    1:30 PM = 13.5 x 2 = 27
                //	# l  = length of class in half-hours. {ddttl % 10 = l}
                //		a class that lasts 1 and 1/2 hrs has l = 3
                //Examples:
                //	ddttl = 10162 = Tue Thurs 8:00AM to 9:00AM(or 8:50AM, if you prefer)


                //    Class on MTWR, 11:30AM to 1:00PM becomes:

                //        dd : M+T+W+R  =1+2+4+8 = 15
                //		tt : 11:30AM = 11.5*2 = 23
                //		l  : class is 1.5 hrs long, so half hours = 3
                //		Thus, ddttl = 15233


                // I need to quickly take note of the weeke days before the times.




                //int32.parse(OrginalTime)

                //





                timeChanged = true;
            }

            if (days_ChLstBx.CheckedItems.Count != 0)
            { int dayCount = 0;
                List<string> days = new List<string>();
                foreach (string selectedDays in days_ChLstBx.CheckedItems)
                {
                    days.Add(selectedDays);
                }
                if (days.Contains("Monday"))
                { dayCount++; }
                else if (days.Contains("Tuesday"))
                { dayCount = dayCount + 2; }
                else if (days.Contains("Wednesday"))
                { dayCount = dayCount + 4; }
                else if (days.Contains("Thursday"))
                { dayCount = dayCount + 8; }
                else if (days.Contains("Friday"))
                { dayCount = dayCount + 16; }

                timeAdjusted = timeAdjusted % 1000 + (dayCount * 1000);
                timeAdjusted = timeAdjusted + (int)finalTime;
            


                dayChanged = true;
            }

           editedCourse += " " + timeAdjusted.ToString();

            //deleteLine(CourseToEdit);


            List<String> Coursedatabase = new List<String>();
            string[] courses = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            foreach (string course in courses)
            {
                if (course != CourseToEdit)
                { Coursedatabase.Add(course); }
                
            }
            Coursedatabase.Add(editedCourse);

            System.IO.File.WriteAllText(@"C:\SE Repos\CourseDatabase.txt", string.Empty);

            foreach (string course in Coursedatabase)
            using (StreamWriter sw = File.AppendText(@"C:\SE Repos\CourseDatabase.txt")) //appending the line to the course data base
            {
                sw.WriteLine(course);
                
            }

            this.Close();




        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void deleteLine(string curCourse)
        {
            List<String> Coursedatabase = new List<String>();
            string[] courses = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\CourseDatabase.txt");
            foreach (string line in courses)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase.Add(line);
                //Console.WriteLine("\n" + line);
            }
            for (int i = 0; i < Coursedatabase.Count(); i++)
            {
                if (curCourse == Coursedatabase[i])
                {
                    //line_to_edit = i;
                    string[] tempSplit = Coursedatabase[i].Split(" ");
                    string courseName = tempSplit[0];
                    //courseDeletionForm deleteForm = new courseDeletionForm(courseName);
                    //deleteForm.Show();
                }
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Users\katie\OneDrive\Desktop\Databases SE\CourseDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= courses.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    
                        writer.WriteLine(courses[currentLine]);
                    
                }
            }

            ;
            var Courselist = new Dictionary<int, dynamic>();
            List<String> Coursedatabase2 = new List<String>();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\CourseDatabase.txt");
            //System.Console.WriteLine("Contents of Course database");

            foreach (string line in lines2)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase2.Add(line);
                Console.WriteLine("\n" + line);
            }
        }










    }
}
