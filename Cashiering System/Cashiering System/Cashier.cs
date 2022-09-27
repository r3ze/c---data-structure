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
    public partial class Cashier : Form
    {
      
        int i = 0;
        double price = 0;
        int selectedCategory = 0;
        public static double totalAmount = 0;
      

        public Cashier()
        {
            InitializeComponent();
        }
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=items";
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
        public static MySqlConnection GetConnection2()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=products";
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
        //show items in datagridview
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special Milk Tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            panel8.BackColor = Color.DodgerBlue;
            selectedCategory = 2;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;
         
            numericUpDown1.Value = 0;
        }
  
        private void Cashier_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbldate.Text = DateTime.Now.ToLongDateString();
            lbltime.Text = DateTime.Now.ToLongTimeString();
            lblPtype.Text = "";
            productName.Text = "";
            lbluser.Text = Login.name;
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
            String sql = "SELECT pname, price FROM classicmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Classic Milk tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 1;
            panel7.BackColor = Color.DodgerBlue;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;
         
            numericUpDown1.Value = 0;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            String sql = "SELECT pname, price FROM frappe";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Frappe";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 3;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialfruitshakes";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special fruit shakes";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 4;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.DodgerBlue;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM rsc";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Rocksalt and Cheese";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 5;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.DodgerBlue;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM milkbased";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Milk based";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 6;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.DodgerBlue;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruittea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 7;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.DodgerBlue;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayakult";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yakult";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 8;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.DodgerBlue;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayogurt";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yogurt";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 9;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.DodgerBlue;

            numericUpDown1.Value = 0;
        }
        
    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
         
            i = Convert.ToInt32(e.RowIndex); //store the value of selected row index in i
            if (e.RowIndex >= 0)
            {
                numericUpDown1.Value = 0;
                productName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                productName.BorderStyle = BorderStyle.FixedSingle;
                double iprice = double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                lblprice.Text = iprice.ToString("F2");
                price = double.Parse(lblprice.Text);
            }
                
          
            
                
        }
 



        //clear 


        private void timer1_Tick(object sender, EventArgs e)
        {

            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            if (productName.Text == "")
            {
                MessageBox.Show("No product selected, please select a product first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numericUpDown1.Value==0)
            {
                MessageBox.Show("Please enter the quantity.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                dataGridView2.Rows.Add(productName.Text, lblprice.Text, numericUpDown1.Value, lblTotalprice.Text);
                totalAmount += double.Parse(lblTotalprice.Text);
                productName.Text = "";
                lblprice.Text = "";
                numericUpDown1.Value = 0;
                lblTotalprice.Text = "";
                lblprice.Text = "0.00";
                lblTotalprice.Text = "0.00";
                numberOfItems++;
                lblTotalAmount.Text = totalAmount.ToString("F2");
                productName.BorderStyle = BorderStyle.None;
                price = 0;
                txtAmountTendered.Text = "";
                
            }
        }

        private void btnAdd_MouseHover_1(object sender, EventArgs e)
        {
            if (productName.Text == "" || numericUpDown1.Value==0)
            {
                btnAdd.Cursor = Cursors.No;
            }
            else
            {
                btnAdd.Cursor = Cursors.Default;
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            productName.Text = "";
            lblprice.Text = "0.00";
            lblTotalprice.Text = "0.00";
            price = 0;
            numericUpDown1.Value = 0;
            productName.BorderStyle = BorderStyle.None;
        }

      

        int numberOfItems = 0;
       
        

      

        private void btnPrint_Click(object sender, EventArgs e)
        {
          
     
            if(txtAmountTendered.Text=="")
            {
                MessageBox.Show("Please enter an amount ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                double ttlAmount = double.Parse(lblTotalAmount.Text);
                double amntTendered = double.Parse(txtAmountTendered.Text);
                if (amntTendered>=ttlAmount)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    String sql = "INSERT INTO sales VALUES (NULL,@date,@cashier, @product, @price, @quantity, @totalprice)";
                    MySqlConnection con = GetConnection1();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("@cashier", MySqlDbType.VarChar).Value = Login.name;
                    cmd.Parameters.Add("@product", MySqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value;
                    cmd.Parameters.Add("@price", MySqlDbType.Double).Value = dataGridView2.Rows[i].Cells[1].Value;
                    cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = dataGridView2.Rows[i].Cells[2].Value;
                    cmd.Parameters.Add("@totalprice", MySqlDbType.Double).Value = dataGridView2.Rows[i].Cells[3].Value;
                       
                    try
                    {
                        cmd.ExecuteNonQuery();
                            lblTotalAmount.Text = "";
                            txtAmountTendered.Text = "";
                            lblChange.Text = "";

                        }
                    catch (Exception ee)
                    {

                        MessageBox.Show("MySQL Connectionsdsd! \n" + ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Insufficient amount tendered", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }


        }
        int numberPerPage = 0;
        int countedNo = 0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var pen = new Pen(Color.Black, width: 2);
  
       


          
                e.Graphics.DrawString("Jeremiah Tea", new Font("MS UI Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(350, 10));
            e.Graphics.DrawString("Receipt", new Font("MS UI Gothic", 15, FontStyle.Regular), Brushes.Black, new Point(400, 50));

            e.Graphics.DrawString(DateTime.Now.ToString(), new Font("MS UI Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(340, 90));

            e.Graphics.DrawString("Product name", new Font("MS UI Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(10, 140));
            e.Graphics.DrawString("Price", new Font("MS UI Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(400, 140));
            e.Graphics.DrawString("Quantity", new Font("MS UI Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(500, 140));
            e.Graphics.DrawString("Total Price", new Font("MS UI Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(680, 140));

            int height = 190;
            for (int i = countedNo; i < dataGridView2.Rows.Count; i++)
            {
                var row = dataGridView2.Rows[i];
                numberPerPage++;
                if (numberPerPage <= 24)
                {
                    countedNo++;
                    if (countedNo <= dataGridView2.Rows.Count)
                    {
                        e.Graphics.DrawString(row.Cells[0].Value.ToString(), new Font("MS UI Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, height));
                        e.Graphics.DrawString(row.Cells[1].Value.ToString(), new Font("MS UI Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(400, height));
                        e.Graphics.DrawString(row.Cells[2].Value.ToString(), new Font("MS UI Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(530, height));
                        e.Graphics.DrawString(row.Cells[3].Value.ToString(), new Font("MS UI Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(680, height));
                     
                        height += 30;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
                else
                {
                    numberPerPage = 0;
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawString("Total amount: " + totalAmount.ToString("F2"), new Font("MS UI Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(570, height + 40));
            e.Graphics.DrawString("Cash: " + txtAmountTendered.Text, new Font("MS UI Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(570, height + 80));
            e.Graphics.DrawString("Change: " + lblChange.Text, new Font("MS UI Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(570, height + 120));
            countedNo = 0;
            numberPerPage = 0;


        }

        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountTendered.Text != "")
            {
                double change = double.Parse(txtAmountTendered.Text) - double.Parse(lblTotalAmount.Text);
                lblChange.Text = change.ToString("F2");
            }
            if(txtAmountTendered.Text=="")
            {
                lblChange.Text = "0.00";
            }
            
        }

      
private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {

            
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            if (MessageBox.Show("Are you sure you want to remove " + dataGridView2.Rows[rowindex].Cells[0].Value.ToString() + " from the list?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                totalAmount -= double.Parse(dataGridView2.Rows[rowindex].Cells[3].Value.ToString());
                lblTotalAmount.Text = totalAmount.ToString("F2");
                dataGridView2.Rows.RemoveAt(rowindex);
              
            }
            }
            else
            {
                MessageBox.Show("Customer's order list is empty","",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
        

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
        

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            

        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value!=0)
            {
                double totalprice = (double)price * (double)numericUpDown1.Value;
                lblTotalprice.Text = totalprice.ToString("F2");
            }
            else
            {
                lblTotalprice.Text = "0.00";
            }
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
   (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM classicmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Classic Milk tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 1;
            panel7.BackColor = Color.DodgerBlue;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;
       
            numericUpDown1.Value = 0;
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special Milk Tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            panel8.BackColor = Color.DodgerBlue;
            selectedCategory = 2;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM frappe";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Frappe";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 3;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialfruitshakes";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special fruit shakes";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 4;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.DodgerBlue;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM rsc";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Rocksalt and Cheese";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 5;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.DodgerBlue;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM milkbased";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Milk based";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 6;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.DodgerBlue;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruittea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 7;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.DodgerBlue;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void panel14_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayakult";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yakult";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 8;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.DodgerBlue;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void panel15_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayogurt";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yogurt";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 9;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.DodgerBlue;

            numericUpDown1.Value = 0;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void panel8_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
       
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void panel9_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel10_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel10_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void panel11_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void panel11_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void panel12_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void panel12_MouseLeave(object sender, EventArgs e)
        {
      
        }

        private void panel13_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel14_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void panel14_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void panel15_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void panel15_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
          
        }

   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (selectedCategory != 0&&textBox1.Text!="Search")
            {
                if (selectedCategory == 1)
                {
                    String sql = "SELECT pname, price FROM classicmilktea WHERE pname LIKE '"+textBox1.Text+"%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if(selectedCategory==2)
                {
                    String sql = "SELECT pname, price FROM specialmilktea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 3)
                {
                    String sql = "SELECT pname, price FROM frappe WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 4)
                {
                    String sql = "SELECT pname, price FROM specialfruitshakes WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 5)
                {
                    String sql = "SELECT pname, price FROM rsc WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 6)
                {
                    String sql = "SELECT pname, price FROM milkbased WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory ==7 )
                {
                    String sql = "SELECT pname, price FROM fruittea WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 8)
                {
                    String sql = "SELECT pname, price FROM fruitteayakult WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    dataGridView1.DataSource = tbl;
                    conn.Close();
                }
                else if (selectedCategory == 9)
                {
                    String sql = "SELECT pname, price FROM fruitteayogurt WHERE pname LIKE '" + textBox1.Text + "%'";
                    MySqlConnection conn = GetConnection2();
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
            if (textBox1.Text == "Search")
            {
                textBox1.Text ="";
                textBox1.ForeColor = Color.Black;
                
            }
         
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void panel18_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void lbl_cmt_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM classicmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Classic Milk tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 1;
            panel7.BackColor = Color.DodgerBlue;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;
        
            numericUpDown1.Value = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM classicmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Classic Milk tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 1;
            panel7.BackColor = Color.DodgerBlue;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;
      
            numericUpDown1.Value = 0;
        }

        private void lblSmt_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special Milk Tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            panel8.BackColor = Color.DodgerBlue;
            selectedCategory = 2;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialmilktea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special Milk Tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            panel8.BackColor = Color.DodgerBlue;
            selectedCategory = 2;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblFrappe_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM frappe";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Frappe";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 3;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;
  
            numericUpDown1.Value = 0;
        }

        private void lblSF_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialfruitshakes";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special fruit shakes";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 4;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.DodgerBlue;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblS_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM specialfruitshakes";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Special fruit shakes";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 4;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.DodgerBlue;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblRS_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM rsc";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Rocksalt and Cheese";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 5;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.DodgerBlue;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblCheese_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM rsc";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Rocksalt and Cheese";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 5;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.DodgerBlue;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblMb_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM milkbased";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Milk based";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 6;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.DodgerBlue;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblFruitt_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruittea";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 7;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.DodgerBlue;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblFt_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayakult";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yakult";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 8;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.DodgerBlue;
            panel15.BackColor = Color.White;
  
            numericUpDown1.Value = 0;
        }

        private void label26_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayakult";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yakult";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 8;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.DodgerBlue;
            panel15.BackColor = Color.White;

            numericUpDown1.Value = 0;
        }

        private void lblFrt_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayogurt";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yogurt";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 9;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.DodgerBlue;

            numericUpDown1.Value = 0;
        }

        private void lblYo_Click(object sender, EventArgs e)
        {
            String sql = "SELECT pname, price FROM fruitteayogurt";
            MySqlConnection conn = GetConnection2();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            conn.Close();
            price = 0;
            lblprice.Text = "0.00";
            lblPtype.Text = "Fruit tea yogurt";
            productName.Text = "";
            productName.BorderStyle = BorderStyle.None;
            dataGridView1.CurrentRow.Selected = false;
            selectedCategory = 9;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel15.BackColor = Color.DodgerBlue;

            numericUpDown1.Value = 0;
          
        }
        int numberOfd = 0;
        private void txtAmountTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if(e.KeyChar=='.'&&txtAmountTendered.TextLength==0)
            {
                e.Handled = true;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void panel19_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void panel18_MouseHover(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DimGray;
        }

        private void panel18_MouseLeave(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DodgerBlue;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DimGray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DodgerBlue;
        }

        private void panel19_MouseHover(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DimGray;
        }

        private void panel19_MouseLeave(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DodgerBlue;
        }


    }
}
