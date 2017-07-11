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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id;
            int p = 123;
            id = Convert.ToString(textBox1.Text);
            if (textBox2.Text == p.ToString())
            {

                Login l = new Login();
                this.Hide();
                Menu m = new Menu();
                m.Show();

            }
            else
            {
                MessageBox.Show("incorrect password");

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
