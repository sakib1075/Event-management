using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Event : Form
    {
        public Event()
        {
            InitializeComponent();
            ShowEvent();
            GetVenue();
            GetCustomer();
        }
        private void ShowEvent()
        {
            Con.Open();
            string Query = "select * from EventTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EventDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Clear()
        {
            EvNameTb.Text = "";
            CustNameTb.Text = "";
            EvDurationTb.Text = "";
            StatusCb.SelectedIndex = -1;
            VenueNameTb.Text = "";

        }
        SqlConnection Con = new SqlConnection(@"C:\USERS\HP\DOCUMENTS\EVENT MANAGEMENT DB.MDF");
        private void GetCustomer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustId from CustomerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(Rdr);
            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = dt;
            Con.Close();

        }
        private void GetCustomerName()
        {
            Con.Open();
            string Query = "select * from CustomerTbl where CustId=" + CustIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustIdCb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }
        private void GetVenue()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select VId from venueTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("VId", typeof(int));
            dt.Load(Rdr);
            EVIdCb.ValueMember = "VId";
            EVIdCb.DataSource = dt;
            Con.Close();

        }
        private void GetVanueName()
        {
            Con.Open();
            string Query = "select * from VenueTbl where VId=" + EVIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                VenueNameTb.Text = dr["VName"].ToString();
            }
            Con.Close();
        }

            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EvNameTb.Text == "" || VenueNameTb.Text == "" || CustNameTb.Text == "" || EvDurationTb.Text == "" || StatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into EventTbl(EvName,EvDate, VenueId, EVVenue, EvDuration,EcCustId,EvCustName,EvStatus) value(@EN,@ED,@VI, @EV, @EDU,@ECI,@ECN,@ES )", Con);
                    cmd.Parameters.AddWithValue("@EN", EvNameTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EvDate.Value.Date);
                    cmd.Parameters.AddWithValue("@VI", EVIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EV", VenueNameTb.Text);
                    cmd.Parameters.AddWithValue("@EDU", EvDurationTb.Text);
                    cmd.Parameters.AddWithValue("@ECI", CustIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ECN", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@ES", StatusCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event Added");

                    Con.Close();
                    ShowEvent();
                    Clear();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EVId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetVanueName();
        }
        private void CustId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustomerName();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EvNameTb.Text == "" || VenueNameTb.Text == "" || CustNameTb.Text == "" || EvDurationTb.Text == "" || StatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update Insert Set EvName=@EN,EvDate=@ED, VenueId=@VI, EVVenue=@EV, EvDuration=@EDU,EcCustId=@ECI,EvCustName=@ECN,EvStatus=@ES where EvId = @EKey", Con);
                    cmd.Parameters.AddWithValue("@EN", EvNameTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EvDate.Value.Date);
                    cmd.Parameters.AddWithValue("@VI", EVIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EV", VenueNameTb.Text);
                    cmd.Parameters.AddWithValue("@EDU", EvDurationTb.Text);
                    cmd.Parameters.AddWithValue("@ECI", CustIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ECN", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@ES", StatusCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@EKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event Updated");

                    Con.Close();
                    ShowEvent();
                    Clear();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }

        }
        int Key = 0;
        private void EventDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EvNameTb.Text = EventDGV.SelectedRows[0].Cells[1].Value.ToString();
            EvDate.Text = EventDGV.SelectedRows[0].Cells[2].Value.ToString();
            EVIdCb.SelectedText = EventDGV.SelectedRows[0].Cells[3].Value.ToString();
            VenueNameTb.Text = EventDGV.SelectedRows[0].Cells[4].Value.ToString();
            EvDurationTb.Text = EventDGV.SelectedRows[0].Cells[5].Value.ToString();
            CustIdCb.SelectedText = EventDGV.SelectedRows[0].Cells[6].Value.ToString();
            CustNameTb.Text = EventDGV.SelectedRows[0].Cells[7].Value.ToString();
            StatusCb.SelectedItem = EventDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (VenueNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EventDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Event");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from EventTbl Where EVId=@EKey", Con);
                    cmd.Parameters.AddWithValue("@EKey" ,Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event Deleted");

                    Con.Close();
                    ShowEvent();
                    Clear();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
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

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Form obj = new Form();
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

    
   

    }
