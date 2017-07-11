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
    public partial class Cust : Form
    {
        public Cust()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into Customer(CID,Cname,CAddress,City,PH1,PH2,ContectPerson,CPPH,CEmail,CreditLimit,Cstatus,CGroup)" + "Values(@CID,@Cname,CAddress,@City,PH1,PH2,ContectPerson,CPPH,CEmail,CreditLimit,Cstatus,CGroup);", mc.conn);
                
                cmd.Parameters.AddWithValue("@CID", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@Cname", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@CAddress",this.textBox2.Text);
                cmd.Parameters.AddWithValue("@City", this.comboBox2.Text);
                cmd.Parameters.AddWithValue("@PH1", this.textBox3.Text);
                cmd.Parameters.AddWithValue("@PH2", this.textBox4.Text);
                cmd.Parameters.AddWithValue("@ContectPerson", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@CPPH", this.textBox6.Text);
                cmd.Parameters.AddWithValue("@CEmail", this.textBox7.Text);
                cmd.Parameters.AddWithValue("@CreditLimit", this.textBox8.Text);
                cmd.Parameters.AddWithValue("@Cstatus", this.comboBox3.Text);
                cmd.Parameters.AddWithValue("@CGroup", this.comboBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted");
                mc.conn.Close();
            }
            catch (System.Exception excep)
            {

            MessageBox.Show(excep.Message);

           } 

        }

        private void Cust_Load(object sender, EventArgs e)
        {
            this.comboBox2.Items.Add("Karachi");
            this.comboBox2.Items.Add("Lahore");
            this.comboBox2.Items.Add("Faisalabad");
            this.comboBox2.Items.Add("Rawalpindi");
            this.comboBox2.Items.Add("Hyderabad	");
            this.comboBox2.Items.Add("Larkana");
            this.comboBox3.Items.Add("Active");
            this.comboBox3.Items.Add("Not_Active");

            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand CMD = new OleDbCommand("select CID from Customer", mc.conn);
            OleDbDataReader dr = CMD.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]);
            }
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while(dr1.Read())
            {
                comboBox4.Items.Add(dr1["GrpName"]);
            }
            mc.conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

       
           
    }
}
