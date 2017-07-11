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
    public partial class Approval : Form
    {
        public Approval()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("update Customer SET Cstatus='" + this.comboBox3.Text + "'where CID='" + this.comboBox1.Text + "';", mc.conn);
            cmd.ExecuteReader();
            MessageBox.Show("Updated is Successfully");
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*myConnection mc = new myConnection();
            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("select * from Customer where CID='" + this.comboBox4.Text + "';", mc.conn);
            OleDbDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                this.textName.Text = dr["CNAME"].ToString();
                this.textCreditLimit.Text = dr["creditlimit"].ToString();
                this.textPH1.Text = dr["PH1"].ToString();
                this.textPH2.Text = dr["PH2"].ToString();
                this.textAddress.Text = dr["CAddress"].ToString();
                this.textEmail.Text = dr["CEmail"].ToString();
                this.textCPPH.Text = dr["CPPH"].ToString();
                this.textCity.Text = dr["CITY"].ToString();
                this.comboBox5.Text = dr["CGroup"].ToString();
                this.comboBox5.Items.Add(dr["CGroup"]);
                this.comboBox5.SelectedIndex = 0;
                //this.comboBox6.Text = dr["CStatus"].ToString();
                this.comboBox6.SelectedIndex = 0;
                //this.textCity.Text = dr["VCity"].ToString();
                this.textCPName.Text = dr["ContectPerson"].ToString();

            }
            mc.conn.Close();*/
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand Cmd = new OleDbCommand("select * from Customer where CID='" + this.comboBox1.Text + "';", mc.conn);
                OleDbDataReader dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.textBox1.Text = dr["CName"].ToString();
                    this.textBox2.Text = dr["CAddress"].ToString();
                    this.textBox3.Text = dr["PH1"].ToString();
                    this.textBox4.Text = dr["PH2"].ToString();
                    this.textBox5.Text = dr["ContectPerson"].ToString();
                    this.textBox6.Text = dr["CPPH"].ToString();
                    this.textBox7.Text = dr["CEmail"].ToString();
                    this.textBox8.Text = dr["CreditLimit"].ToString();
                    this.comboBox4.Text = dr["CGroup"].ToString();
                    this.comboBox4.Items.Add(dr["CGroup"]);
                    this.comboBox4.SelectedIndex = 0;
                    this.comboBox2.SelectedIndex = 0;
                    //this.comboBox3.SelectedIndex = 0;



                }
                mc.conn.Close();
            }
            catch (System.Exception excep)
            {

                MessageBox.Show(excep.Message);
            }
        }

        private void Approval_Load(object sender, EventArgs e)
        {
            this.comboBox3.Items.Add("Active");
            this.comboBox3.Items.Add("Not_Active");
            this.comboBox2.Items.Add("Karachi");
            this.comboBox2.Items.Add("Lahore");
            this.comboBox2.Items.Add("Faisalabad");
            this.comboBox2.Items.Add("Rawalpindi");
            this.comboBox2.Items.Add("Hyderabad	");
            this.comboBox2.Items.Add("Larkana");

            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("select (CID) from Customer;", mc.conn);
            OleDbDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]);
            }
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                comboBox4.Items.Add(dr1["GrpName"]);
            }
            mc.conn.Close();
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
