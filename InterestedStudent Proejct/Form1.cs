using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace InterestedStudent_Proejct
{
    public partial class Form1 : Form
    {
        List<User> Users = new List<User>(); //Creates collection of students
        public Form1()
        {
            List<User> Users = new List<User>();
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Users = MyDAL.LoadData("//Mac/Home/Desktop/CS/teststudentdata.csv");
            comboBox1.DataSource = Users;
            comboBox1.DisplayMember = "UserName";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MyDAL.SaveData("//Mac/Home/Desktop/CS/teststudentdata.csv", Users);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = Users;
        }
        public class MyDAL
        {
            public static List<User> LoadData(string FileName)
            {
                List<User> localList = new List<User>();

                StreamReader sr = new StreamReader("//Mac/Home/Desktop/CS/teststudentdata.csv");
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string localline = sr.ReadLine();
                        /*
                         * 1 Index = Name
                         * 2 Index = Cell Phone #
                         * 3 Index = ID #
                         * 4 Index = Email
                         * 5 Index = Status
                         */
                        string[] inputs = localline.Split(','); //3 strings

                        User localUser = new User();
                        localUser.UserName = inputs[0]; //Name
                        localUser.UserCellNum = int.Parse(inputs[1]); //Cell phone #
                        localUser.UserID = int.Parse(inputs[2]); //ID #
                        localUser.UserEmail = inputs[3]; //Email
                        localUser.UserStatus = inputs[4]; //Status

                        MessageBox.Show(inputs[0]);
                        MessageBox.Show(inputs[1]);
                        MessageBox.Show(inputs[2]);
                        MessageBox.Show(inputs[3]);
                        MessageBox.Show(inputs[4]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                sr.Close();
                return localList;
            }
            public static bool SaveData(string FileLocation, List<User> MyData)
            {
                StreamWriter sw = new StreamWriter("//Mac/Home/Desktop/CS/teststudentdata.csv");
                foreach (User localUser in MyData)
                {
                    sw.WriteLine(localUser.UserName + "," + localUser.UserID);
                }

                sw.Close();
                return true;
            }
        }
        public class User
        {
            public String UserName { get; set; }
            public int UserCellNum { get; set; }
            public int UserID { get; set; }
            public String UserEmail { get; set; }
            public String UserStatus { get; set; }
        }
    }
}
