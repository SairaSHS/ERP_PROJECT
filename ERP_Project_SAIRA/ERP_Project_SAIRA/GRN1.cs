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
    public partial class GRN1 : Form
    {
        public GRN1()
        {
            InitializeComponent();
        }

        private void GRN1_Load(object sender, EventArgs e)
        {
            myconnection mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("select POID from PO where Status='Open' and Approve='Approved';", mc.conn);
            OleDbDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox4.Items.Add(dr["POID"]);
            }
            mc.conn.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
                {

                    myconnection mc = new myconnection();
                    mc.conn.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from PO where POID='" + this.comboBox4.Text + "';", mc.conn);
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

                    OleDbCommand cmd1 = new OleDbCommand("select * from POProducts where POID='" + this.comboBox4.Text + "';", mc.conn);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        OleDbCommand cmd2 = new OleDbCommand("select * from Products where PModel='" + dr1["PModel"].ToString() + "';", mc.conn);
                        OleDbDataReader dr2 = cmd2.ExecuteReader();

                        while (dr2.Read())
                        {
                            this.dataGridView2.Rows.Add(dr1["PModel"].ToString(), dr2["PName"].ToString(), dr1["PQty"].ToString(),
                                                        dr2["BasePrice"].ToString(), (Convert.ToInt16(dr1["PQty"].ToString()) * Convert.ToInt16(dr2["BasePrice"].ToString())));
                        }

                    }

                    mc.conn.Close();
                    if (this.dataGridView2.Rows.Count >= 1)
                    {
                        this.dataGridView2.Rows.Clear();
                    }
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }


            }

        
    

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                myconnection mc = new myconnection();
                mc.conn.Open();
                OleDbCommand cmd =
                new OleDbCommand("insert into GRN(GRNID,BaseDocument,Status,VName,DCDate,Ddate,GRDate)" +
                "values(@GRNID,@BaseDocument,@Status,@VName,@DCDate,@Ddate,@GRDate);", mc.conn);

                cmd.Parameters.AddWithValue("@GRNID", "GRN_" + this.comboBox4.Text);
                cmd.Parameters.AddWithValue("@BaseDocument", this.comboBox4.Text);
                cmd.Parameters.AddWithValue("@Status", "Open");
                cmd.Parameters.AddWithValue("@VName", this.textBox14.Text);
                cmd.Parameters.AddWithValue("@DCDate", this.textBox15.Text);
                cmd.Parameters.AddWithValue("@Ddate", this.textBox16.Text);
                DateTime thisDay = DateTime.Today;
                cmd.Parameters.AddWithValue("@GRDate", thisDay);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Generated GRN");

                OleDbCommand cmd1 = new OleDbCommand("update PO SET Status = '" + this.comboBox5.Text + "' where POID='" + this.comboBox4.Text + "';", mc.conn);
                cmd1.ExecuteReader();
                MessageBox.Show("Successfully ");


                mc.conn.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }
    }
}

