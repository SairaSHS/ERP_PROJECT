using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Project_SAIRA
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cust cust = new Cust();
            cust.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Approval ap = new Approval();
            ap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vendor v = new Vendor();
            v.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vendor_approva vp = new Vendor_approva();
            vp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            PO po = new PO();
            po.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GRN1 g = new GRN1();
            g.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            invoce iv = new invoce();
            iv.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
