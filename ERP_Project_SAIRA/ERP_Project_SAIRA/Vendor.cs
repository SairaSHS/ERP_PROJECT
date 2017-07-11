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
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
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
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup;",mc.conn);
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while(dr1.Read())
            {
                comboBox2.Items.Add(dr1["GrpName"]);
            }
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into Vendor(VID,VName,VCode,VCity,PH1,PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus)" + "Values(@VID,@VName,@VCode,@VCity,@PH1,@PH2,@VAddress,@CPName,@CPPH,@VEmail,@VFax,@VGroup,@VStatus);", mc.conn);
                cmd.Parameters.AddWithValue("@VID", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@VName", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@VCode", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@VCity", this.textBox3.Text);
                cmd.Parameters.AddWithValue("@PH1", this.textBox4.Text);
                cmd.Parameters.AddWithValue("@PH2", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@VAddress", this.textBox6.Text);
                cmd.Parameters.AddWithValue("@CPName", this.textBox7.Text);
                cmd.Parameters.AddWithValue("@CPPH", this.textBox8.Text);
                cmd.Parameters.AddWithValue("@VEmail", this.textBox9.Text);
                cmd.Parameters.AddWithValue("@VFax", this.textBox10.Text);
                cmd.Parameters.AddWithValue("@VGroup", this.comboBox2.Text);
                cmd.Parameters.AddWithValue("@NStatus", this.comboBox3.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Recorde has been inserted");
                mc.conn.Close();
   
            }
           
            catch (System.Exception excep)
            {

                MessageBox.Show(excep.Message);

            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
