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

namespace Meeting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            login.FormClosed += WriteSamir;
        }

        private void WriteSamir(object sender, FormClosedEventArgs e)
        {
            lblLoginName.Visible = true;
            btnLogin.Visible = false;
            btnOut.Visible = true;
            lblLoginName.Text = ortaq.name.ToString();
            lblSeat1.Text = ortaq.name.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source = HP-TL15UPD\SQLEXPRESS;Initial Catalog = MeetingProject; Integrated Security = True";

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select Workers_name, Workers_surname from Workers";

            connection.Open();

            var dr = command.ExecuteReader();

            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    comboBox1.Items.Add(dr["Workers_name"].ToString() + " " + dr["Workers_surname"].ToString());
                }
            }

            connection.Close();

        }

      
    }
}
