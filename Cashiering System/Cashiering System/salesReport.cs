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
using DGVPrinterHelper;
namespace Cashiering_System
{
    public partial class salesReport : UserControl
    {
        public salesReport()
        {
            InitializeComponent();
        }
        public static MySqlConnection GetConnection1()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=cashiering_system; Convert Zero Datetime=true";
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

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            String sql = "Select date, cashier, product, price, quantity, total from sales where date between '" + dtStart.Value.ToString("yyyy-MM-dd") + "'AND'" + dtEnd.Value.ToString("yyyy-MM-dd") +"'";
            MySqlConnection conn = GetConnection1();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total += double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            lbltotalAmount.Text = total.ToString("F2");
            conn.Close();
        
        }

   

       
        int numberPerPage = 0;
        int countedNo = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
 
            printer.Title = "Sales Report";

        

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "Total Sales: "+lbltotalAmount.Text;

            printer.FooterSpacing = 15;
          


            printer.PrintPreviewNoDisplay(dataGridView1);

        }

        private void salesReport_Load(object sender, EventArgs e)
        {
           
          
        }

      

  

        private void btnSales_Click_1(object sender, EventArgs e)
        {
            double total = 0;
            String sql = "Select date, cashier, product, price, quantity, total from sales ";
            MySqlConnection conn = GetConnection1();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total += double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            lbltotalAmount.Text = total.ToString("F2");
            conn.Close();
        }
    }
}
