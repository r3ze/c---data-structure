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
    public partial class Accounts : UserControl
    {
        public static DataGridView dgv;
        public Accounts()
        {
            InitializeComponent();
            dgv = dataGridView1;
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
        
        private void Accounts_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = GetConnection1();
            String sql = "SELECT username, password, role FROM accounts";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;

            String SQL = "SELECT username, password FROM disabled_accounts";
            MySqlCommand CMD = new MySqlCommand(SQL, conn);
            MySqlDataAdapter ADP = new MySqlDataAdapter(CMD);
            DataTable TBL = new DataTable();
            ADP.Fill(TBL);
            dataGridView2.DataSource = TBL;

            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_user add = new Add_user();
            add.ShowDialog();
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to disbale this account?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                MySqlConnection con = GetConnection1();
            int i = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[i].Cells[2].Value.ToString()=="Cashier") { 
            String SQL = "INSERT INTO disabled_accounts VALUES(NULL, @username, @password)";
            MySqlCommand CMD = new MySqlCommand(SQL, con);
            CMD.CommandType = CommandType.Text;
            CMD.Parameters.Add("@username", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
            CMD.Parameters.Add("@password", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
            try
            {
                CMD.ExecuteNonQuery();
            }
            catch (Exception)
            {

              
            }
         

            String sql = "DELETE FROM accounts WHERE role = @role AND username = @username AND password=@password";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[2].Value;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                    try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account disabled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.RemoveAt(i);
            }
            catch (Exception)
            {

               
            }
            String Sql = "SELECT username, password FROM disabled_accounts";
            MySqlCommand Cmd = new MySqlCommand(Sql, con);
            MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
            DataTable TBL = new DataTable();
            ADP.Fill(TBL);
            dataGridView2.DataSource = TBL;

            }
            else
            {
                MessageBox.Show("You can't disable admin accounts.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to enable this account?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

          
                MySqlConnection con = GetConnection1();
            int i = dataGridView2.CurrentCell.RowIndex;
            String SQL = "INSERT INTO accounts VALUES(NULL, @type, @username, @password)";
            MySqlCommand CMD = new MySqlCommand(SQL,con);
            CMD.CommandType = CommandType.Text;
            CMD.Parameters.Add("@type",MySqlDbType.VarChar).Value = "Cashier";
            CMD.Parameters.Add("@username", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
            CMD.Parameters.Add("@password", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
            try
            {
                CMD.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add account. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            String sql = "DELETE FROM disabled_accounts WHERE username = @username AND password=@password";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
         
                try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account enabled successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.Rows.RemoveAt(i);
            }
            catch (Exception)
            {


            }
            String Sql = "SELECT username, password,role FROM accounts";
            MySqlCommand Cmd = new MySqlCommand(Sql, con);
            MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
            DataTable TBL = new DataTable();
            ADP.Fill(TBL);
            dataGridView1.DataSource = TBL;


            con.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //make password encrypted
            if(e.ColumnIndex==1&&e.Value!=null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
    }
}
