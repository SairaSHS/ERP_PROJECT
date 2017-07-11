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
    public partial class custermer : Form
    {
        
        public custermer()
        {
            InitializeComponent();
        }

        private void custermer_Load(object sender, EventArgs e)
        {
            //try
            //{
            this.comboBox2.Items.Add("Karachi");
            this.comboBox2.Items.Add("Lahore");
            this.comboBox2.Items.Add("Faisalabad");
            this.comboBox2.Items.Add("Rawalpindi");
            this.comboBox2.Items.Add("Hyderabad	");
            this.comboBox2.Items.Add("Larkana");
            this.comboBox3.Items.Add("Active");
            this.comboBox3.Items.Add("Not-Active");
            //mc.conn.Open();
            //cmd = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //   comboBox4.Items.Add(dr["GrpName"].ToString());
            //}
            //OleDbCommand cmd1 = new OleDbCommand("select count(CID) from Customer", mc.conn);
            //dr = cmd1.ExecuteReader();
            //while (dr.Read())
            //{
            //  int count = Convert.ToInt32(dr[0]);
            //count++;
            //if (count < 10)
            //{
            //   this.comboBox1.Items.Add("0" + count);
            //}
            //else
            //{
            //  this.comboBox1.Items.Add(count.ToString());
            //}
            //this.comboBox1.SelectedIndex = 0;
            //}
            //mc.conn.Close();
            //}
            //catch (System.Exception excep)
            //{

            //MessageBox.Show(excep.Message);

            //} 
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd2 = new OleDbCommand("select CID from Customer", mc.conn);
            OleDbDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]);

            }
            OleDbCommand cmd1 = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while(dr1.Read())
            {
                comboBox4.Items.Add(dr1["GrpName"]);
            }
            mc.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into Customer(CID,Cname,CAddress,City,PH1,PH2,contectperson,CEmail,CPPH,CreditLimit,Cstatus,CGroup)" + "Values(@CID,@Cname,@CAddress,@City,@PH1,@PH2,@contectperson,@CEmail,@CPPH,@CreditLimit,Cstatus,CGroup);", mc.conn);

                cmd.Parameters.AddWithValue("@CID", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@Cname", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@CAddress", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@City", this.comboBox2.Text);
                cmd.Parameters.AddWithValue("@PH1", this.textBox3.Text);
                cmd.Parameters.AddWithValue("@Ph2", this.textBox4.Text);
                cmd.Parameters.AddWithValue("@contectperson", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@CEmail", this.textBox6.Text);
                cmd.Parameters.AddWithValue("@CPPH", this.textBox7.Text);
                cmd.Parameters.AddWithValue("@CreditLimit", this.textBox8.Text);
                cmd.Parameters.AddWithValue("@Cstatus", this.comboBox3.Text);
                cmd.Parameters.AddWithValue("@CGroup", this.comboBox4.Text);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Submitte in table");
                mc.conn.Close();
            }
            catch (System.Exception excep)
            {

                MessageBox.Show(excep.Message);

            }
        }
    }
}
