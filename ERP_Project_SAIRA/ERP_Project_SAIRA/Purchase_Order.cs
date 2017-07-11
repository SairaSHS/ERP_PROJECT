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
    public partial class Purchase_Order : Form
    {
        public Purchase_Order()
        {
            InitializeComponent();
        }
        public static int counter = 0;
        

       /* private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();

                /* new OleDbCommand("insert into PO(Poid,Ddate,Status,Approve,VDept,VName,Vid,VContectPerson,VCPPH,TotalAmount,GoodRecieved, DCDate)" +
                 "values(@Poid,@Ddate,@Status,@Approve,@VDept,@VName,@Vid,@VContectPerson,@VCPPH,@TotalAmount,@GoodRecieved,@DCDate);", mc.conn);

                 cmd.Parameters.AddWithValue("@Poid", this.textBox9.Text);
                 cmd.Parameters.AddWithValue("@DDate", this.dateTimePicker1.Value.Date);
                 cmd.Parameters.AddWithValue("@Status", "Open");
                 cmd.Parameters.AddWithValue("@Approve", "Not Approved");
                 cmd.Parameters.AddWithValue("@VDept", this.textBox5.Text);
                 cmd.Parameters.AddWithValue("@VName", this.textBox4.Text);
                 cmd.Parameters.AddWithValue("@Vid", this.comboBox3.Text);
                 cmd.Parameters.AddWithValue("@VContectPerson", this.textBox6.Text);
                 cmd.Parameters.AddWithValue("@VCPPH", this.textBox7.Text);
                 cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                 cmd.Parameters.AddWithValue("@GoodRecieved", "No");
                 DateTime thisDay = DateTime.Today;
                 cmd.Parameters.AddWithValue("@DCDate", thisDay);
                OleDbCommand cmd = new OleDbCommand("insert into PO(VID,VName,VDept,VContectPerson,VCPPH,Poid,Ddate,Status,Approve,GoodRecieved, DCDate,TotalAmount)" + "Values(@VID,@VName,@VDept,@VContectPerson,@VCPPH,@Poid,@Ddate,@Status,@Approve,@GoodRecieved,@DCDate,@TotalAmount);", mc.conn);
                cmd.Parameters.AddWithValue("@VID", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@VName", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@VDept", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@VContectPerson", this.textBox3.Text);
                cmd.Parameters.AddWithValue("@VCPPH", this.textBox4.Text);
                cmd.Parameters.AddWithValue("@Poid", this.textBox10.Text);
                cmd.Parameters.AddWithValue("@Ddate", this.dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Status", "Open");
                cmd.Parameters.AddWithValue("@Approve", "Not Approved");
                cmd.Parameters.AddWithValue("@GoodRecieved", "No");
                DateTime thisDay = DateTime.Today;
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order successfilly added.");
                mc.conn.Close();

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        int totalAmount = 0;*/

        private void Purchase_Order_Load(object sender, EventArgs e)
        {
            try
            {
               
                this.comboBox5.Items.Add("Approved");
                this.comboBox5.Items.Add("Not Approved");
                this.comboBox5.SelectedIndex = 0;
                this.textBox1.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.textBox5.ReadOnly = true;
                this.textBox6.ReadOnly = true;
                this.textBox8.Text = this.textBox6.Text;
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from Vendor;", mc.conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["VID"]);

                }
                OleDbCommand cmd1 = new OleDbCommand("select * from Products;", mc.conn);
                OleDbDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    this.comboBox3.Items.Add(dr1["PModel"]);

                }
                OleDbCommand cmd2 = new OleDbCommand("select count(POID) from POProducts;", mc.conn);
                OleDbDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    counter = Convert.ToInt32(dr2[0]);
                    counter++;

                }
                OleDbCommand cmd3 = new OleDbCommand("select POID from PO where Approve='Not Approved';", mc.conn);
                OleDbDataReader dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    this.comboBox4.Items.Add(dr3["POID"]);
                }
                mc.conn.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into POProducts(POID,PModel,PQty)values(@POID,@PModel,@PQty);", mc.conn);
            cmd.Parameters.AddWithValue("@POID", this.textBox10.Text);
            cmd.Parameters.AddWithValue("@PModel", this.comboBox3.Text);
            cmd.Parameters.AddWithValue("@PQty", this.textBox7.Text);
            cmd.ExecuteNonQuery();
            mc.conn.Close();
            totalAmount += Convert.ToInt16(this.textBox8.Text);

            this.textBox9.Text = totalAmount.ToString();
            this.dataGridView1.Rows.Add(this.textBox10.Text, this.textBox5.Text, this.textBox7.Text,this.textBox8.Text, this.dateTimePicker1.Value.Date.ToString("d"));

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd1 = new OleDbCommand("select * from Vendor where VID='" + this.comboBox1.Text + "';", mc.conn);
                OleDbDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    textBox1.Text = dr1["VName"].ToString();
                    textBox2.Text = dr1["VGroup"].ToString();
                    textBox3.Text = dr1["CPName"].ToString();
                    textBox4.Text = dr1["CPPH"].ToString();

                }
                mc.conn.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.textBox8.Text = this.textBox6.Text;
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd1 = new OleDbCommand("select * from Products where PModel='" + this.comboBox3.Text + "';", mc.conn);
                OleDbDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    this.textBox5.Text = dr["PName"].ToString();
                    this.textBox6.Text = dr["BasePrice"].ToString();
                    this.textBox7.Text = "1";
                }
                mc.conn.Close();
                if (textBox5.Text != "")
                {
                    string tempStr = (textBox2.Text.Length > 3) ? textBox2.Text.Substring(0, 3) : textBox2.Text.Substring(0, 2);
                    this.textBox10.Text = tempStr + "_" + counter + "_" + DateTime.Now.Year.ToString();
                }
                else
                {
                    this.textBox10.Text = textBox2.Text + "_" + this.comboBox1.Text + "_" + counter;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox7.Text != "")
                {
                    this.textBox8.Text = (Convert.ToInt64(this.textBox6.Text) * Convert.ToInt64(this.textBox7.Text)).ToString();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            if (this.dataGridView2.Rows.Count >= 1) 
            {
                this.dataGridView2.Rows.Clear();
            }
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("select * from PO where POID='" + this.comboBox4.Text + "';", mc.conn);
            OleDbDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                
                textBox18.Text = dr["VID"].ToString();
                textBox14.Text = dr["VName"].ToString();
                textBox13.Text = dr["VDept"].ToString();
                textBox11.Text = dr["VCPPH"].ToString();
                textBox12.Text = dr["VContectPerson"].ToString();
                textBox17.Text = dr["TotalAmount"].ToString();
                DateTime dDate = Convert.ToDateTime(dr["Ddate"].ToString());
                textBox15.Text = dDate.ToString("d");
                DateTime dCDate = Convert.ToDateTime(dr["DCDate"].ToString());
                textBox16.Text = dCDate.ToString("d");
               

            }

            OleDbCommand cmd2 = new OleDbCommand("select * from POProducts where POID='" + this.comboBox4.Text + "';", mc.conn);
            OleDbDataReader dr1 = cmd2.ExecuteReader();
            while (dr1.Read())
            {
                OleDbCommand cmd3 = new OleDbCommand("select * from Products where PModel='" + dr1["PModel"].ToString() + "';", mc.conn);
                OleDbDataReader dr2 = cmd3.ExecuteReader();

                while (dr2.Read())
                {
                    this.dataGridView2.Rows.Add(dr1["PModel"].ToString(), dr2["PName"].ToString(), dr1["PQty"].ToString(),dr2["BasePrice"].ToString(), ( Convert.ToInt16(dr1["PQty"].ToString()) * Convert.ToInt16(dr2["BasePrice"].ToString()) ) ); 
                }

            }

            mc.conn.Close();
            }
            
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        { 
            try
            {
            myconnection mc=new myconnection();
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into PO(VID,VName,VDept,VContectPerson,VCPPH,Poid,Ddate,Status,Approve,GoodRecieved, DCDate,TotalAmount)" + "Values(@VID,@VName,@VDept,@VContectPerson,@VCPPH,@Poid,@Ddate,@Status,@Approve,@GoodRecieved,@DCDate,@TotalAmount);", mc.conn);
                cmd.Parameters.AddWithValue("@VID", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@VName", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@VDept", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@VContectPerson", this.textBox3.Text);
                cmd.Parameters.AddWithValue("@VCPPH", this.textBox4.Text);
                cmd.Parameters.AddWithValue("@Poid", this.textBox10.Text);
                cmd.Parameters.AddWithValue("@Ddate", this.dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Status", "Open");
                cmd.Parameters.AddWithValue("@Approve", "Not Approved");
                cmd.Parameters.AddWithValue("@GoodRecieved", "No");
                DateTime thisDay = DateTime.Today;
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
               
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Order successfilly added.");
            

                mc.conn.Close();

            }
    
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        int totalAmount = 0;

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        }
    }

