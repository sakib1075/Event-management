using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace Final_Project
{
    public partial class Feed_Back : Form
    {
        public Feed_Back()
        {
            InitializeComponent();
            ShowFeedBack();
            GetEvent();
        }

        private void ShowFeedBack()
        {
            Con.Open();
            string Query = "select * from FeedBackTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Clear()
        {
            EVNameTb.Text = "";
            VenueCb.SelectedIndex = -1;
            PunctualityCb.SelectedIndex = -1;
            HospitalityCb.SelectedIndex = -1;

        }
        SqlConnection Con = new SqlConnection(@"C:\USERS\HP\DOCUMENTS\EVENT MANAGEMENT DB.MDF");
        private void GetEvent()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustId from EventTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EVId", typeof(int));
            dt.Load(Rdr);
            EVIdCb.ValueMember = "EVId";
            EVIdCb.DataSource = dt;
            Con.Close();

        }
        private void GetEventName()
        {
            Con.Open();
            string Query = "select * from EventTbl where CustId=" + EVIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EVNameTb.Text = dr["EVName"].ToString();
            }
            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EVNameTb.Text == "" || VenueCb.SelectedIndex== -1 || HospitalityCb.SelectedIndex == -1 || PunctualityCb.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    int Averall = (HospitalityCb.SelectedIndex + VenueCb.SelectedIndex + PunctualityCb.SelectedIndex+3)/3;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into VenueTbl(EVId,EVName,Punctuality,Hospitality, Venue, OverAll) value(@EI,@P,@H,@EN, @V, @O )", Con);
                    cmd.Parameters.AddWithValue("@EI", EVIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EN", EVNameTb.Text);
                    cmd.Parameters.AddWithValue("@P", PunctualityCb.SelectedIndex+1);
                    cmd.Parameters.AddWithValue("@H", HospitalityCb.SelectedIndex+1);
                    cmd.Parameters.AddWithValue("@V", VenueCb.SelectedIndex+1);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("FeedBack Submited");

                    Con.Close();
                    ShowFeedBack();
                    Clear();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EVIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetEventName();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Clear();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form obj = new Form();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
