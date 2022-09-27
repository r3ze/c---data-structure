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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
           
        }



        private void panel8_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void panel9_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void panel10_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void panel10_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
    
        }

        private void panel11_MouseHover(object sender, EventArgs e)
        {
           
            panel11.BackColor = Color.DimGray;
        }

        private void panel11_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
            panel11.BackColor = Color.DodgerBlue;

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            this.panel13.Controls.Clear();
            salesReport s = new salesReport();
            s.Show();
            this.panel13.Controls.Add(s);
            panel8.BackColor = Color.DimGray;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.DodgerBlue;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lbluser.Text = Login.name;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();   
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
          
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void panel9_Click(object sender, EventArgs e)
        {
            panel13.Controls.Clear();
            Accounts a = new Accounts();
            a.Show();
            panel13.Controls.Add(a);
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.DimGray;
            panel10.BackColor = Color.DodgerBlue;
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            panel13.Controls.Clear();
            products p = new products();
            p.Show();
            panel13.Controls.Add(p);
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.DimGray;
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
         
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.WhiteSmoke;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.WhiteSmoke;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.WhiteSmoke;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.WhiteSmoke;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.WhiteSmoke;
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.WhiteSmoke;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.WhiteSmoke;
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            panel11.BackColor = Color.DimGray;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel11.BackColor = Color.DodgerBlue;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.panel13.Controls.Clear();
            salesReport s = new salesReport();
            s.Show();
            this.panel13.Controls.Add(s);
            panel8.BackColor = Color.DimGray;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.DodgerBlue;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel13.Controls.Clear();
            Accounts a = new Accounts();
            a.Show();
            panel13.Controls.Add(a);
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.DimGray;
            panel10.BackColor = Color.DodgerBlue;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel13.Controls.Clear();
            products p = new products();
            p.Show();
            panel13.Controls.Add(p);
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.DimGray;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.panel13.Controls.Clear();
            salesReport s = new salesReport();
            s.Show();
            this.panel13.Controls.Add(s);
            panel8.BackColor = Color.DimGray;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.DodgerBlue;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panel13.Controls.Clear();
            Accounts a = new Accounts();
            a.Show();
            panel13.Controls.Add(a);
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.DimGray;
            panel10.BackColor = Color.DodgerBlue;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            panel13.Controls.Clear();
            products p = new products();
            p.Show();
            panel13.Controls.Add(p);
            panel8.BackColor = Color.DodgerBlue;
            panel9.BackColor = Color.DodgerBlue;
            panel10.BackColor = Color.DimGray;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

       
    }
}
