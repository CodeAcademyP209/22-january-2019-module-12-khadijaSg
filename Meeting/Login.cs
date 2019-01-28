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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            btnLogin2.Click += btnLogin2_Click;
        }

        private void btnLogin2_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source = HP-TL15UPD\SQLEXPRESS;Initial Catalog = MeetingProject; Integrated Security = True";

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select Workers_name, Workers_password from Workers";

            connection.Open();

            var dr = command.ExecuteReader();

            string loginName = tbxName.Text;
            string loginPassword = tbxPassword.Text;
            
            if(dr.HasRows)
            {
                while(dr.Read())
                {


                    if (String.IsNullOrEmpty(loginName) || String.IsNullOrEmpty(loginPassword))
                    {
                        MessageBox.Show("Please fill the gaps");
                        break;
                    }
                    else if(loginName == dr["Workers_name"].ToString() && loginPassword == dr["Workers_password"].ToString())
                    {
                        MessageBox.Show("You entered successfully " + dr["Workers_name"].ToString());

                        ortaq.name = dr["Workers_name"].ToString();
                        this.Close();

                        break;
                    }
                    else
                    {
                        
                        continue;
                    }


                }
            }
                

        }

       
    }
}
