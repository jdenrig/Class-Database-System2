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
    public partial class CourseHistory : System.Windows.Forms.Form
    {
        public CourseHistory(string user)
        {
            InitializeComponent();
            string numClasses;
            string user1 = user;
            string[] className = new string[100];
            string[] semester = new string[100];
            string[] creditNum = new string[100];
            string[] Grade = new string[100];
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
                string[] classInfo = historyData[k].Split(' ');
                string username = classInfo[0];
                numClasses = classInfo[1];
                history.Add(username, new List<String>());
                int numCourses = int.Parse(classInfo[1]);
                // iterate through numClasses, add courses to list, add to dictionary
                int increment = 2;
                if (user == classInfo[0])
                {
                    for (int i = 0; i < int.Parse(numClasses); i++)
                    {
                        className[i] = classInfo[increment];
                        increment++;
                        semester[i] = classInfo[increment];
                        increment++;
                        creditNum[i] = classInfo[increment];
                        increment++;
                        Grade[i] = classInfo[increment];
                        increment++;
                    }
                    for (int b = 0; b < int.Parse(numClasses); b++)
                    {
                        string tempClass;
                        tempClass = className[b];
                        tempClass += " ";
                        tempClass += semester[b];
                        tempClass += " ";
                        tempClass += creditNum[b];
                        tempClass += " ";
                        tempClass += Grade[b];
                        checkedListBox1.Items.Add(tempClass);
                    }
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
