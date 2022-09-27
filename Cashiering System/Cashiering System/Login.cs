using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashiering_System
{
    public partial class Login : Form
    {
        public static string name;
        public Login()
        {
            InitializeComponent();
         
        }
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=cashiering_system";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException e)
            {

                MessageBox.Show("MySQL Connection! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
      
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (cbxRole.Text == "" && txtPassword.Text == "" && txtID.Text == "")
                {
                    MessageBox.Show("Please fill in all fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cbxRole.Text != "" && txtID.Text == "" && txtPassword.Text=="")
                {
                    MessageBox.Show("Please enter your username and password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(cbxRole.Text==""&&txtID.Text!=""&&txtPassword.Text=="")
                {
                    MessageBox.Show("Please select user type and enter your password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(cbxRole.Text==""&&txtID.Text==""&&txtPassword.Text!="")
                {
                    MessageBox.Show("Please select user type and enter your username.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cbxRole.Text=="")
                {
                    MessageBox.Show("Please select user type.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txtID.Text=="")
                {
                    MessageBox.Show("Please enter your username.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txtPassword.Text=="")
                {
                    MessageBox.Show("Please enter your password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                else if (cbxRole.Text == "Cashier" && txtID.Text != "" && txtPassword.Text != "") { 
                String sql = "SELECT * FROM accounts WHERE username=@username AND password=@password ";
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
               
          
                cmd.Parameters.AddWithValue("@username", txtID.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                        MessageBox.Show("Login Successful","",MessageBoxButtons.OK,MessageBoxIcon.Information   );
            
                        name = txtID.Text;
                        this.Hide();
                        Cashier c = new Cashier();
                        c.Show();

                            }
                    else
                    {
                        MessageBox.Show("Wrong username or password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
            }
                else if(cbxRole.Text=="Admin"&&txtID.Text!=""&&txtPassword.Text!="")
                {
                    String sql = "SELECT * FROM accounts WHERE role=@role AND username=@username AND password=@password ";
                    MySqlConnection con = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                   
                    cmd.Parameters.AddWithValue("@role", cbxRole.Text);
                    cmd.Parameters.AddWithValue("@username", txtID.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result > 0)
                    {
                        MessageBox.Show("Login Successful","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        name = txtID.Text;
                        this.Hide();
                        Admin a = new Admin();
                        a.Show();


                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error"+ex.Message);
            }
       
          


        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbxRole.Text = "";
            txtID.Text = "";
            txtPassword.Text = "";
        }

     
    }
}
