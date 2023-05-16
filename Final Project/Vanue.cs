using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Final_Project
{
    public partial class Vanue : Form
    {
        public Vanue()
        {
            InitializeComponent();
            ShowVenue ();  
        }
        private void ShowVenue()
        {
            Con.Open();
            string Query = "select * from VenueTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            VenueDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Clear()
        {
            VNameTb.Text = "";
            VPhoneTb.Text = "";
            VCapacityTb.Text = "";
            VAddressTb.Text = "";
            VManagerTb.Text = "";
            VPhoneTb.Text = "";
        }
SqlConnection Con = new SqlConnection (@"C:\USERS\HP\DOCUMENTS\EVENT MANAGEMENT DB.MDF");
        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            if (VAddressTb.Text == "" || VNameTb.Text == "" || VPhoneTb.Text == "" || VCapacityTb.Text == "" || VManagerTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into VenueTbl(VName,VCapacity, VAddress, VManager, VPhone) value(@VN,@VC,@VA, @VM, @VP )", Con);
                    cmd.Parameters.AddWithValue("@VN", VNameTb.Text);
                    cmd.Parameters.AddWithValue("@VC", VCapacityTb.Text);
                    cmd.Parameters.AddWithValue("@VA", VAddressTb.Text);
                    cmd.Parameters.AddWithValue("@VM", VManagerTb.Text);
                    cmd.Parameters.AddWithValue("@VP", VPhoneTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue Added");

                    Con.Close();
                    ShowVenue();
                    Clear();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void VenueDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            VNameTb.Text = VenueDGV.SelectedRows[0].Cells[1].Value.ToString();
            VCapacityTb.Text = VenueDGV.SelectedRows[0].Cells[2].Value.ToString();
            VAddressTb.Text = VenueDGV.SelectedRows[0].Cells[3].Value.ToString();
            VManagerTb.Text = VenueDGV.SelectedRows[0].Cells[4].Value.ToString();
            VPhoneTb.Text = VenueDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (VNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(VenueDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }



        

        

        private void EditBtn_Click_1(object sender, EventArgs e)
        {
            if (VAddressTb.Text == "" || VNameTb.Text == "" || VPhoneTb.Text == "" || VCapacityTb.Text == "" || VManagerTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update VenueTbl Set VName=@VN,VCapacity=@VC, VAddress=@VA, VManager=@VM, VPhone=@VP where VId =@VKey", Con);
                    cmd.Parameters.AddWithValue("@VN", VNameTb.Text);
                    cmd.Parameters.AddWithValue("@VC", VCapacityTb.Text);
                    cmd.Parameters.AddWithValue("@VA", VAddressTb.Text);
                    cmd.Parameters.AddWithValue("@VM", VManagerTb.Text);
                    cmd.Parameters.AddWithValue("@VP", VPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@VKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue UpDated");

                    Con.Close();
                    ShowVenue();
                    Clear();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Venue");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from VenueTbl Where VId=@VKey", Con);
                    cmd.Parameters.AddWithValue("@VKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue Deleted");

                    Con.Close();
                    ShowVenue();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Event obj = new Event();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
    
}
