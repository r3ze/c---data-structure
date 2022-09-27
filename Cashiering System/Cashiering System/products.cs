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
    public partial class products : UserControl
    {
        public static DataGridView dgv;
        public static ComboBox cbx;
        int selectedCategory = 0;
        public products()
        {
           
            InitializeComponent();
            dgv = dataGridView1;
            cbx = cbxCat;

        }
      
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=products;Convert Zero Datetime=true";
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

        private void cbxCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = GetConnection();
            if (cbxCat.Text == "Classic Milktea")
            {
                String sql = "SELECT pname, price, dateadded FROM classicmilktea";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 1;
  
            }
            else if(cbxCat.Text=="Frappe")
            {
                String sql = "SELECT pname, price, dateadded FROM frappe";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 2;
     
            }
            else if(cbxCat.Text=="Fruit Tea")
            {
                String sql = "SELECT pname, price, dateadded FROM fruittea";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 3;
              
            }
            else if (cbxCat.Text == "Fruit Tea Yakult")
            {
                String sql = "SELECT pname, price, dateadded FROM fruitteayakult";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 4;
            
            }
            else if (cbxCat.Text == "Fruit Tea Yogurt")
            {
                String sql = "SELECT pname, price, dateadded FROM fruitteayogurt";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 5;
             
            }
            else if (cbxCat.Text == "Milk Based")
            {
                String sql = "SELECT pname, price, dateadded FROM milkbased";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 6;
               
            }
            else if (cbxCat.Text == "Rock Salt and Cheese")
            {
                String sql = "SELECT  pname, price, dateadded FROM rsc";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 7;
           
            }
            else if (cbxCat.Text == "Special Fruit Shakes")
            {
                String sql = "SELECT  pname, price, dateadded FROM specialfruitshakes";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 8;
           
            }
            else if (cbxCat.Text == "Special Milktea")
            {
                String sql = "SELECT pname, price, dateadded FROM specialmilktea";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                selectedCategory = 9;
             
            }
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_product add = new Add_product();
            add.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            edit_product p = new edit_product();
            p.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to disable this product?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

            
            MySqlConnection con = GetConnection();
            int i = dataGridView1.CurrentCell.RowIndex;
        
                String SQL = "INSERT INTO disabled_products VALUES(NULL, @category, @pname, @price, @datedisabled)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = cbxCat.Text;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@price", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@datedisabled", MySqlDbType.Date).Value = DateTime.Now;

            try
                {
                   
                    CMD.ExecuteNonQuery();
                 

                }
                catch (Exception)
                {


                }

            if (cbxCat.Text == "Classic Milktea")
            {

                String sql = "DELETE FROM classicmilktea WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if(cbxCat.Text=="Frappe")
            {
                String sql = "DELETE FROM frappe WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if (cbxCat.Text == "Fruit Tea")
            {
                String sql = "DELETE FROM fruittea WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if (cbxCat.Text == "Fruit Tea Yakult")
            {
                String sql = "DELETE FROM fruitteayakult WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if (cbxCat.Text == "Fruit Tea Yogurt")
            {
                String sql = "DELETE FROM fruitteayogurt WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if (cbxCat.Text == "Milk Based")
            {
                String sql = "DELETE FROM milkbased WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product  successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if (cbxCat.Text == "Rock Salt and Cheese")
            {
                String sql = "DELETE FROM rsc WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if (cbxCat.Text == "Special Fruit Shakes")
            {
                String sql = "DELETE FROM specialfruitshakes WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            else if (cbxCat.Text == "Special Milktea")
            {
                String sql = "DELETE FROM specialmilktea WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView2.DataSource = TBL;



                con.Close();
            }
            }

        }

        private void products_Load(object sender, EventArgs e)
        {
            MySqlConnection con = GetConnection();
            String Sql = "SELECT category, pname, price, dateadded FROM disabled_products";
            MySqlCommand Cmd = new MySqlCommand(Sql, con);
            MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
            DataTable TBL = new DataTable();
            ADP.Fill(TBL);
            dataGridView2.DataSource = TBL;
            cbxCat.Text = "Classic Milktea";
            textBox1.Text = "Search product name";    

            con.Close();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to enable this product?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

          
                MySqlConnection con = GetConnection();
            int i = dataGridView2.CurrentCell.RowIndex;
            if(dataGridView2.Rows[i].Cells[0].Value.ToString()=="Classic Milktea")
            {
                String SQL = "INSERT INTO classicmilktea VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to enable product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM classicmilktea";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
           else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Frappe")
            {
                String SQL = "INSERT INTO frappe VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                   

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM frappe";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
            else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Fruit Tea")
            {
                String SQL = "INSERT INTO fruittea VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                   

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM fruittea";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
           else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Fruit Tea Yakult")
            {
                String SQL = "INSERT INTO fruitteayakult VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to enable product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM fruitteayakult";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
           else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Fruit Tea Yogurt")
            {
                String SQL = "INSERT INTO fruitteayogurt VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
              

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM fruitteayogurt";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
            else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Milk Based")
            {
                String SQL = "INSERT INTO milkbased VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                   

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM milkbased";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
            else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Rock Salt and Cheese")
            {
                String SQL = "INSERT INTO rsc VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                  

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM rsc";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
            else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Special Fruit Shakes")
            {
                String SQL = "INSERT INTO specialfruitshakes VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                 

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product  successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM specialfruitshakes";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
           else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Special Milktea")
            {
                String SQL = "INSERT INTO specialmilktea VALUES(NULL, @category, @pname, @price, @date)";
                MySqlCommand CMD = new MySqlCommand(SQL, con);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.Add("@category", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                CMD.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                CMD.Parameters.Add("@price", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                CMD.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                try
                {
                    CMD.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                   

                }

                String sql = "DELETE FROM disabled_products WHERE pname = @pname";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[1].Value;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.RemoveAt(i);
                }
                catch (Exception)
                {


                }
                String Sql = "SELECT pname, price, dateadded FROM specialmilktea";
                MySqlCommand Cmd = new MySqlCommand(Sql, con);
                MySqlDataAdapter ADP = new MySqlDataAdapter(Cmd);
                DataTable TBL = new DataTable();
                ADP.Fill(TBL);
                dataGridView1.DataSource = TBL;


                con.Close();
            }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (selectedCategory != 0)
            {
                if(selectedCategory==1)
                {
                    String sql = "SELECT pname, price,dateadded FROM classicmilktea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==2)
                {
                    String sql = "SELECT pname, price,dateadded FROM frappe WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 3)
                {
                    String sql = "SELECT pname, price, dateadded FROM fruittea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                    
                }
                else if (selectedCategory == 4)
                {
                    String sql = "SELECT pname, price, dateadded FROM fruitteayakult WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 5)
                {
                    String sql = "SELECT pname, price, dateadded FROM fruitteayogurt WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 6)
                {
                    String sql = "SELECT pname, price, dateadded FROM milkbased WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 7)
                {
                    String sql = "SELECT pname, price, dateadded FROM rsc WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 8)
                {
                    String sql = "SELECT pname, price, dateadded FROM specialfruitshakes WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 9)
                {
                    String sql = "SELECT pname, price, dateadded FROM specialmilktea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
            }
          
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text=="Search product name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search product name";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "Search product name")
            {
                String sql = "SELECT category, pname, price, dateadded FROM disabled_products WHERE pname LIKE '" + textBox2.Text + "%'";
                MySqlConnection conn = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView2.DataSource = tbl;
                conn.Close();
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text=="Search product name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                textBox2.Text = "Search product name";
                textBox2.ForeColor = Color.DimGray; 
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(selectedCategory!=0)
            {
                if (selectedCategory == 1 && textBox1.Text != "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM classicmilktea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==2&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM frappe WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==3&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM fruittea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==4&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM fruitteayakult WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==5&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM fruitteayogurt WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==6&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM milkbased WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==7&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM rsc WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==8&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM specialfruitshakes WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==9&&textBox1.Text!= "Search product name")
                {
                    String sql = "SELECT pname, price, dateadded FROM specialmilktea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
            }
        }
    }
}