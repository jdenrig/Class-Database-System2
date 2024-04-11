using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.CodeDom.Compiler;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Login_Window
{
    public partial class Faculty : System.Windows.Forms.Form
    {

        List<String> assignedCourses = new List<String>(); // a local variable that I can pass between lists
        string stuName;
        string userName;
        string lineToWrite;
        int line_to_edit;
        string fName;
        string lName;
        string lineToSplit;
        string time;
        string replacementString;
        int newNumSeats;
        int line_to_replace;
        public Faculty(string user)
        {
            InitializeComponent();
            string FacultyName;
            FacultyName = user;
            List<String> Coursedatabase = new List<String>();
            var Courselist = new Dictionary<int, dynamic>();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            System.Console.WriteLine("Contents of Course database");

            List<String> Userdatabase = new List<String>();
            string[] users = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");

            foreach (string line in lines2)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase.Add(line);
                Console.WriteLine("\n" + line);
            }

            for (int i = 0; i < Coursedatabase.Count; i++)
            {
                string[] Coursestring = Coursedatabase[i].Split(' ');
                string courseName = Coursestring[0];
                string courseTitle = Coursestring[1];
                string instructor = Coursestring[2];
                string courseCredit = Coursestring[3];
                string numSeats = Coursestring[4];
                string numTimeBlock1 = Coursestring[5];
                string numTimeBlock2 = Coursestring[6];
                //string numTimeBlock3 = Coursestring[7];
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Courselist[i] = d1;
                Courselist[i].courses = "User" + i;
                Courselist[i].courses = new { coursename = courseName, coursetitle = courseTitle, instructorname = instructor, courseCreditNum = courseCredit, nSeats = numSeats, nTime1 = numTimeBlock1, nTime2 = numTimeBlock2 };

            }
            foreach (string line in users)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);
            }

            for (int i = 0; i < Courselist.Count; i++)
            {
                if (Courselist[i].courses.instructorname == FacultyName)
                {
                    listBox1.Items.Add(Coursedatabase[i]);
                    assignedCourses.Add(Coursedatabase[i]);
                }

                listBox2.Items.Add(Coursedatabase[i]);

            }

            for (int i = 0; i < Userdatabase.Count; i++)
            {
                string[] Userstring = Userdatabase[i].Split(" ");
                string advisor = "";
                if (Userstring.Length == 6)
                {
                     advisor = Userstring[5];
                }
                if (FacultyName == advisor)
                { 
                    string advisee = Userstring[2] + " " + Userstring[3] + " " + Userstring[4];
                    adviseeList.Items.Add(advisee);
                }
            }

            


        }



        public string user { get; set; }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rosters_listBox3.Items.Clear();
            string curCourse = listBox1.SelectedItem.ToString();

            string courseNum = curCourse.Substring(0, curCourse.IndexOf(' '));
            Rosters_listBox3.Items.Add(courseNum); //Prints out the class number to the roster before displaying the students

            //code fine up to here

            //string[] OGCourseDataBase = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\OrginalCourseHistoryDatabase.txt");
            string[] CourseHisDataBase = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseDatabase.txt");
            List<string> addedCoursesDataBase = new List<string>();

            foreach (string line in CourseHisDataBase)
            {
                string[] splitLines = line.Split(' ');
                if (splitLines.Contains(courseNum))
                {

                    if (splitLines[Array.IndexOf(splitLines, courseNum) + 1] == "F23")
                    {
                        Rosters_listBox3.Items.Add(splitLines[0]);
                    }
                    else
                    {
                        string[] splitLines2 = line.Split(courseNum);
                        if (splitLines2.Contains(courseNum))
                        {

                            if (splitLines[Array.IndexOf(splitLines2, courseNum) + 1] == "F23")
                            { Rosters_listBox3.Items.Add(splitLines[0]); }


                        }
                    }
                }


            }









            //Saying i have an out of index issue
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {




        }

        private void rostersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // this needs to pull up a seperate window to pull up the rosters for the classes you are assigned


        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            ////Need to add the rosters in this box
            //string[] OGCourseDataBase = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\OrginalCourseDatabase.txt");
            //string[] CourseDataBase = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\CourseDatabase.txt");
            //List<string> addedCoursesDataBase;

            //int i = 0; //counter
            //foreach (string line in CourseDataBase)
            //{
            //    string toadd = (line.Split(OGCourseDataBase[i])).ToString();
            //    addedCoursesDataBase.Add(toadd);
            //    i++;
            //}



            //int j = 0; //coutner
            //foreach (string line in assignedCourses)
            //{
            //    List<int> includedIndex;
            //    if (addedCoursesDataBase.Contains(line))
            //    {
            //      includedIndex.Add(j);
            //    }

            //    if (includedIndex.Count() != 0)
            //    {
            //        Rosters_listBox3.Items.Add(line);



            //    }


            //    j++;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void adviseeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            advSched.Items.Clear();
            stuName = adviseeList.SelectedItem.ToString();
            string[] names = stuName.Split(' ');

            string lastName = names[2];

            string[] CourseHisDataBase = System.IO.File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<string> addedCoursesDataBase = new List<string>();

            foreach (string line in CourseHisDataBase)
            {
                string[] splitLines = line.Split(' ');
                if (splitLines[0].Contains(lastName))
                {

                    for (int i = 0; i < splitLines.Length; i++)
                    {

                        if (splitLines[i] == "F23")
                        {
                            string newCourses;
                            newCourses = splitLines[i - 1];
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
                                    fullClassData = Coursedatabase[p];
                                    advSched.Items.Add(fullClassData);
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
                        /* bool isPM = false;

                         float milTime = ((x / 10) % 100) / 2f;
                         int endTime = (int)(x % 10);
                         finalTime = (int)(milTime - 0.5);
                         //string y; 
                         if (endTime == 3)
                         {
                             finalTime = finalTime + 1;

                             if (finalTime > 12)
                             {
                                 finalTime = finalTime - 12;
                                 time2 += " - ";
                                 time2 += finalTime.ToString();

                                 time2 += ":30 P.M.";
                             }
                             else
                             {
                                 time2 += " - ";
                                 time2 += finalTime.ToString();

                                 time2 += ":30 ";
                                 if (isPM == true) { time2 += "P.M."; }
                                 else { time2 += "A.M."; }

                             }


                         }
                         else
                         {
                             finalTime = finalTime + 1;
                             time2 += " - ";

                             time2 += finalTime.ToString();  // here is the issue

                             time2 += ":00";
                             if (isPM == true) { time2 += "P.M."; }
                             else { time2 += "A.M."; }

                         }

                         endTime = (int)(x % 10);
                         //string y; 
                         if (endTime == 3)
                         {
                             finalTime = finalTime + 1;

                             if (finalTime > 12)
                             {
                                 finalTime = finalTime - 12;

                                 time2 += " - ";
                                 time2 += finalTime.ToString();

                                 time2 += ":30 P.M.";
                             }
                             else
                             {
                                 time2 += " - ";
                                 time2 += finalTime.ToString();

                                 time2 += ":30 ";
                                 if (isPM == true) { time2 += "P.M."; }
                                 else { time2 += "A.M."; }

                             }


                         }
                         else
                         {
                             finalTime = finalTime + 1;
                             time2 += " - ";

                             time2 += finalTime.ToString();  // here is the issue

                             time2 += ":00";
                             if (isPM == true) { time2 += "P.M."; }
                             else { time2 += "A.M."; }

                         }

                        */


                    }


                }
                //else
                //{
                //    string[] splitLines2 = line.Split(lastName);
                //    if (splitLines2.Contains(lastName))
                //    {

                //        if (splitLines[Array.IndexOf(splitLines2, lastName) + 1] == "F23")
                //        { advSched.Items.Add(splitLines[0]); }


                //    }
                //}
            }

            }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void advSched_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\SE Repos\F2023 Confrimation Database.txt");
            string[] lines2 = File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            List<String> Confirmationdatabase = new List<String>();
            
            string[] nameSplit = stuName.Split(" ");
            fName = nameSplit[0];
            lName = nameSplit[2];
            foreach (string line in lines2)
            {
                Userdatabase.Add(line);
            }
            foreach (string line in lines)
            {
                Confirmationdatabase.Add(line);
            }
            for (int i = 0; i < Userdatabase.Count ; i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string firstname = Userstring[2];
                string lastname = Userstring[4];

                if (firstname == fName && lastname == lName)
                {
                    userName = username;
                }
      
      
            }
            for (int i = 0; i < Confirmationdatabase.Count - 1; i++)
            {
                string[] Confirmationstring = Confirmationdatabase[i].Split(' ');
                string user2 = Confirmationstring[0];
                string confirmVal = Confirmationstring[1];
                if (user2 == userName)
                {
                    line_to_edit = i;
                    lineToWrite = userName;
                    lineToWrite += " 1";
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
            ConfirmationPage ConfirmationForm = new ConfirmationPage(fName, lName);
            ConfirmationForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\SE Repos\F2023 Confrimation Database.txt");
            string[] lines2 = File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");
            string[] lines3 = File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            string[] lines4 = File.ReadAllLines(@"C:\SE Repos\CourseHistoryDatabase.txt");
            List<String> Userdatabase = new List<String>();
            List<String> Confirmationdatabase = new List<String>();
            List<String> OriginalCourseHistorydatabase = new List<String>();
            List<String> CourseHistorydatabase = new List<String>();
            string[] nameSplit = stuName.Split(" ");
            fName = nameSplit[0];
            lName = nameSplit[2];
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
            for (int i = 0; i < Userdatabase.Count - 1; i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string firstname = Userstring[2];
                string lastname = Userstring[4];

                if (firstname == fName && lastname == lName)
                {
                    userName = username;
                }


            }
            for (int i = 0; i < Confirmationdatabase.Count - 1; i++)
            {
                string[] Confirmationstring = Confirmationdatabase[i].Split(' ');
                string user2 = Confirmationstring[0];
                
                if (user2 == userName)
                {
                    line_to_edit = i;
                    lineToWrite = userName;
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
              
                if (user2 == userName)
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
                if (user == Historylist[b].usrs.usrname)
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

                    string[] lines6 = File.ReadAllLines(@"C:\Users\turtl\Desktop\CourseHistoryDatabase.txt");

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
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\turtl\Desktop\CourseHistoryDatabase.txt"))
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


            denyForm denyForm = new denyForm(fName, lName);
            denyForm.Show();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
