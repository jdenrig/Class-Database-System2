using Form;
using Login_GUI;
using static System.Windows.Forms.LinkLabel;

namespace Login_Window
{
    public partial class Login_Window : System.Windows.Forms.Form
    {
        public static string username1;
        public static string password2;
        Boolean invalid = false;
        Boolean invalid2 = true;
        public Login_Window()
        {
            InitializeComponent();

        }



        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {



        }


        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void cbx_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            txb_passWord.UseSystemPasswordChar = false;
        }



        private void btn_login_Click_1(object sender, EventArgs e)
        {
            //shows form one need to make if else statment that brings up errors and moves onto class list.
            //var Form1 = new Form1();
            //Form1.Show();
            string[] lines = System.IO.File.ReadAllLines(@"C:\SE Repos\UserDatabase.txt");


            List<String> Userdatabase = new List<String>();
            var Userlist = new Dictionary<int, dynamic>();
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
            username1 = txb_userName.Text;
            password2 = txb_passWord.Text;
            for (int i = 0; i < Userlist.Count; i++)
            {
                if (username1 == Userlist[i].usrs.usrname && password2 == Userlist[i].usrs.pswd && Userlist[i].usrs.s == "admin")
                {

                    invalid2 = false;
                    Admin adminForm = new Admin();
                    //AddDrop addForm = new AddDrop(username1);
                    //addForm.Show();
                    adminForm.Show();

                }
                if (username1 == Userlist[i].usrs.usrname && password2 == Userlist[i].usrs.pswd && Userlist[i].usrs.s == "faculty")
                {
                    //AddDrop addForm = new AddDrop(username1);
                    //addForm.Show();
                    invalid2 = false;
                    Faculty facultyForm = new Faculty(username1);
                    facultyForm.Show();

                }
                else if (username1 == Userlist[i].usrs.usrname && password2 == Userlist[i].usrs.pswd && Userlist[i].usrs.s != "admin" && Userlist[i].usrs.s != "faculty")
                {
                    invalid2 = false;
                    AddDrop addForm = new AddDrop(username1);
                    addForm.Show();
                }

                if (username1 != Userlist[i].usrs.usrname | password2 != Userlist[i].usrs.pswd)
                {
                    invalid = true;
                }
            }
            if (invalid == true && invalid2 != false)
            {
                formWin error = new formWin();
                error.Show();
            }

        }

        private void txb_userName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_passWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbx_showPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            //txb_passWord_TextChanged.useSystemPassChar = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void lbl_softwareName_Click(object sender, EventArgs e)
        {

        }

        private void lnk_forgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lbl_password_Click(object sender, EventArgs e)
        {

        }
    }
}