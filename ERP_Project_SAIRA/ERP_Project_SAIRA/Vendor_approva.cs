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
    public partial class Vendor_approva : Form
    {
        public Vendor_approva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd = new OleDbCommand("update Vendor SET VStatus='" + this.comboBox3.Text + "'where VID='" + this.comboBox1.Text + "';", mc.conn);
                cmd.ExecuteReader();
                MessageBox.Show("Recorde has been Updated");
                mc.conn.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void Vendor_approva_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox8.ReadOnly = true;
            this.textBox9.ReadOnly = true;
            this.textBox10.ReadOnly = true;
           
            this.comboBox3.Items.Add("Active");
            this.comboBox3.Items.Add("Not_Active");
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand CMD = new OleDbCommand("select (VID) from Vendor;", mc.conn);
            OleDbDataReader dr = CMD.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]);
            }
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup;", mc.conn);
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["GrpName"]);
            }
            mc.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("select * from Vendor where VID='" + this.comboBox1.Text + "';", mc.conn);
            OleDbDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                this.textBox1.Text = dr["VName"].ToString();
                this.textBox2.Text = dr["VCode"].ToString();
                this.textBox3.Text = dr["VCity"].ToString();
                this.textBox4.Text = dr["PH1"].ToString();
                this.textBox5.Text = dr["PH2"].ToString();
                this.textBox6.Text = dr["VAddress"].ToString();
                this.textBox7.Text = dr["CPName"].ToString();
                this.textBox8.Text = dr["CPPH"].ToString();
                this.textBox9.Text = dr["VEmail"].ToString();
                this.textBox10.Text = dr["VFax"].ToString();
                this.comboBox2.Text = dr["VGroup"].ToString();
                this.comboBox2.Items.Add(dr["VGroup"]).ToString();
                this.comboBox2.SelectedIndex = 0;
                this.comboBox3.Text = dr["VStatus"].ToString();
                this.comboBox3.Items.Add(dr["VStatus"]).ToString();
                this.comboBox3.SelectedIndex = 0;
               
                
            }
            mc.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show()
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
