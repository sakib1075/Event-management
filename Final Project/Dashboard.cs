using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountEvents ();
            CountCustomers ();
            CountVanues ();
            CountExellent ();
            CountGood ();
            CountOkey ();
            CountBad ();
        }
        SqlConnection Con = new SqlConnection(@"C:\USERS\HP\DOCUMENTS\EVENT MANAGEMENT DB.MDF");


        private void CountEvents()
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Count(*) from EventTbl", Con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            EventLb.Text = dt.Rows[0][0].ToString();
                Con.Close();

        }

        private void CountCustomers()
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Count(*) from CustomerTbl", Con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            CustLb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }

        private void CountVanues()
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Count(*) from VanueTbl", Con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            VanueLb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }


        private void CountExellent()
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Count(*) from FeedBackTbl where overAll = "+4+" ", Con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            ExcellentLb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }

        private void CountGood()
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Count(*) from FeedBackTbl where overAll = " + 3 + " ", Con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            GoodLb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }

        private void CountOkey()
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Count(*) from FeedBackTbl where overAll = " + 2 + " ", Con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            OkeyLb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }


        private void CountBad()
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Count(*) from FeedBackTbl where overAll = " + 1 + " ", Con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            BadLb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }


        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form obj = new Form();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Feed_Back obj = new Feed_Back();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Customer obj = new Customer();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Vanue obj = new Vanue();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }
    }
}
