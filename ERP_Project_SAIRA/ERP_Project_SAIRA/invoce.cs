using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP_Project_SAIRA
{
    public partial class invoce : Form
    {
        public invoce()
        {
            InitializeComponent();
        }
        private string index = ""; 
        private void invoce_Load(object sender, EventArgs e)
        {
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select GRNID from GRN where Status='Open';", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox4.Items.Add(dr["GRNID"]);
            }
            OleDbCommand cmd1 = new OleDbCommand("select count(InvoiceNO) from Invoice;", mc.conn);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                int count = Convert.ToInt32(dr[0]);
                count++;
                index = count.ToString();
            }
            mc.conn.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from PO where POID='" + this.comboBox4.Text.Substring(4) + "';", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox17.Text = dr["TotalAmount"].ToString();
                DateTime dDate = Convert.ToDateTime(dr["Ddate"].ToString());
                textBox15.Text = dDate.ToString("d");
                DateTime dCDate = Convert.ToDateTime(dr["DCDate"].ToString());
                textBox16.Text = dCDate.ToString("d");
                textBox18.Text = dr["VID"].ToString();
                textBox14.Text = dr["VName"].ToString();
                textBox13.Text = dr["VDept"].ToString();
                textBox12.Text = dr["VCPPH"].ToString();
                textBox11.Text = dr["VContectPerson"].ToString();
            }

            OleDbCommand cmd1 = new OleDbCommand("select * from POProducts where POID='" + this.comboBox4.Text.Substring(4) + "';", mc.conn);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                OleDbCommand cmd2 = new OleDbCommand("select * from Products where PModel='" + dr1["PModel"].ToString() + "';", mc.conn);
                OleDbDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    this.dataGridView2.Rows.Add(dr1["PModel"].ToString(), dr2["PName"].ToString(), dr1["PQty"].ToString(),dr2["BasePrice"].ToString(), (Convert.ToInt16(dr1["PQty"].ToString()) * Convert.ToInt16(dr2["BasePrice"].ToString())));
                }

                OleDbCommand cmd3 = new OleDbCommand("select * from GRN where GRNID='" + this.comboBox4.Text + "';", mc.conn);
                OleDbDataReader dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    DateTime dDate = Convert.ToDateTime(dr["GRDate"].ToString());
                    textBox1.Text = dDate.ToString("d");
                }
            }

            mc.conn.Close();
            if (this.dataGridView2.Rows.Count >= 1)
            {
                this.dataGridView2.Rows.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into Invoice(InvoiceNO,RDate,GRNID,feedback)values(@InvoiceNO,@RDate,@GRNID,@feedback);", mc.conn);

                cmd.Parameters.AddWithValue("@InvoiceNO", index);
                DateTime thisDay = DateTime.Today;
                cmd.Parameters.AddWithValue("@RDate", thisDay);
                cmd.Parameters.AddWithValue("@GRNID", this.comboBox4.Text);

                OleDbCommand cmd1 = new OleDbCommand("update GRN SET Status = '" + this.comboBox1.Text + "' where GRNID='" + this.comboBox4.Text + "';", mc.conn);
                cmd.ExecuteReader();
                MessageBox.Show("Invoice Generated");
                cmd.ExecuteNonQuery();
                mc.conn.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        
            
        }
    }
}
