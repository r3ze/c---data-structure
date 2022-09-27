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
    public partial class Add_user : Form
    {
        public Add_user()
        {
            InitializeComponent();
         
        }
        public static MySqlConnection GetConnection1()
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
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String sQl = "SELECT * FROM accounts WHERE role=@role AND username = @username AND password = @password ";
            MySqlConnection Con = GetConnection1();
            MySqlCommand Cmd = new MySqlCommand(sQl, Con);


            Cmd.Parameters.AddWithValue("@role", comboBox1.Text);
            Cmd.Parameters.AddWithValue("@username", textBox1.Text);
            Cmd.Parameters.AddWithValue("@password", textBox2.Text);
            int result = Convert.ToInt32(Cmd.ExecuteScalar());
            if (result > 0)
            {

                MessageBox.Show("Account already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                String sql = "INSERT INTO accounts VALUES (NULL, @type, @username, @password)";
                MySqlConnection con = GetConnection1();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox2.Text;
                try
                {

                    if (comboBox1.Text == "" && textBox1.Text == "" && textBox2.Text == "")
                    {
                        MessageBox.Show("Please fill in all fields above first.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.Text != "" && textBox1.Text == "" && textBox2.Text == "")
                    {
                        MessageBox.Show("Please enter username and password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.Text == "" && textBox1.Text != "" && textBox2.Text == "")
                    {
                        MessageBox.Show("Please select user type and enter password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.Text == "" && textBox1.Text == "" && textBox2.Text != "")
                    {
                        MessageBox.Show("Please select user type and enter username.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.Text == "")
                    {
                        MessageBox.Show("Please select user type.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please enter username.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBox2.Text == "")
                    {
                        MessageBox.Show("Please enter password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "")
                    {


                        cmd.ExecuteNonQuery();
                        String SQL = "SELECT username, password, role FROM accounts";
                        MySqlConnection conn = GetConnection1();
                        MySqlCommand CMD = new MySqlCommand(SQL, conn);
                        MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                        DataTable tbl = new DataTable();
                        adp.Fill(tbl);
                        Accounts.dgv.DataSource = tbl;
                        comboBox1.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        MessageBox.Show("Account successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Failed to add account. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                panel3.BackColor = Color.Transparent;
                panel4.BackColor = Color.Transparent;
                panel5.BackColor = Color.Transparent;
                lblPs.Text = "";
            }
            if (textBox2.TextLength <= 3 && textBox2.TextLength > 0)
            {
                lblPs.Text = "Weak Password";

                panel3.BackColor = Color.Red;
                panel4.BackColor = Color.Transparent;
                panel5.BackColor = Color.Transparent;
            }
            else if (textBox2.TextLength <= 5 && textBox2.TextLength > 0)
            {
                lblPs.Text = "Medium Password";

                panel3.BackColor = Color.Yellow;
                panel4.BackColor = Color.Yellow;
                panel5.BackColor = Color.Transparent;
            }
            else if (textBox2.TextLength <= 7 && textBox2.TextLength > 0)
            {
                lblPs.Text = "Strong Password";

                panel3.BackColor = Color.Green;
                panel4.BackColor = Color.Green;
                panel5.BackColor = Color.Green;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBox1.Text="";
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
