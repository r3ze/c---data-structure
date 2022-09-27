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
    public partial class edit_product : Form
    {
        public edit_product()
        {
            InitializeComponent();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowindex = products.dgv.CurrentCell.RowIndex;
            if ( textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Please fill in all fields above first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter product name first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter price first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (products.cbx.Text == "Classic Milktea")
                {
                    String sQl = "SELECT * FROM classicmilktea WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        String sql = "UPDATE classicmilktea SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {


                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From classicmilktea ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Classic Milktea";
                            MessageBox.Show("Product successfully edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Frappe")
                {
                    String sQl = "SELECT * FROM frappe WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE frappe SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From frappe ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Frappe";
                            MessageBox.Show("Product successfully edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Fruit Tea")
                {
                    String sQl = "SELECT * FROM fruittea WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE fruittea SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From fruittea ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Fruit Tea";
                            MessageBox.Show("Product successfully edited .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Fruit Tea Yakult")
                {
                    String sQl = "SELECT * FROM fruitteayakult WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE fruitteayakult SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {

                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From fruitteayakult ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Fruit Tea Yakult";
                            MessageBox.Show("Product successfully edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Fruit Tea Yogurt")
                {
                    String sQl = "SELECT * FROM fruitteayogurt WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE fruitteayogurt SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From fruitteayogurt ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Fruit Tea Yogurt";
                            MessageBox.Show("Product successfully edited .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Milk Based")
                {
                    String sQl = "SELECT * FROM milkbased WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE milkbased SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From milkbased ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Milk Based";
                            MessageBox.Show("Product successfully edited .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Rock Salt and Cheese")
                {
                    String sQl = "SELECT * FROM rsc WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE rsc SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From rsc ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Rock Salt and Cheese";
                            MessageBox.Show("Product successfully edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Special Fruit Shakes")
                {
                    String sQl = "SELECT * specialfruitshakes WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE specialfruitshakes SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From specialfruitshakes ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Special Fruit Shakes";
                            MessageBox.Show("Product successfully edited .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
                else if (products.cbx.Text == "Special Milktea")
                {
                    String sQl = "SELECT * FROM specialmilktea WHERE pname=@pname ";
                    MySqlConnection Con = GetConnection();
                    MySqlCommand Cmd = new MySqlCommand(sQl, Con);


                    Cmd.Parameters.AddWithValue("@pname", textBox1.Text);

                    int result = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (result > 0)
                    {

                        MessageBox.Show("Product already exists." + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String sql = "UPDATE specialmilktea SET pname = @pname, price = @price WHERE pname='" + products.dgv.Rows[rowindex].Cells[0].Value + "'";
                        MySqlConnection con = GetConnection();
                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@pname", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = textBox2.Text;

                        try
                        {

                            cmd.ExecuteNonQuery();
                            String SQL = "Select pname, price, dateadded From specialmilktea ";
                            MySqlConnection conn = GetConnection();
                            MySqlCommand CMD = new MySqlCommand(SQL, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(CMD);
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);
                            products.dgv.DataSource = tbl;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            products.cbx.Text = "Special Milktea";
                            MessageBox.Show("Product successfully edited .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Failed to edit product. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && textBox2.TextLength == 0)
            {
                e.Handled = true;
            }
        }
    }
}
