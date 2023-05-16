using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter Both UserName and PassWord");
            }
            else if(UnameTb.Text == "Admin" && PasswordTb.Text == "Password")
            {
                Event obj = new Event();
                obj.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong UserName or Password");
                UnameTb.Text = "";
                PasswordTb.Text = " ";

            }
        }
    }
}
