using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM_Ekkez_Helper
{
    public partial class Pass : Form
    {
        public Pass()
        {
            InitializeComponent();
        }

       

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "root")  
            {
                AdminMain af = new AdminMain();
                af.Show();
                this.Hide();
            }
            else if (textBox1.Text == "user" && textBox2.Text == "pass")
            {
                UserMain af = new UserMain();
                af.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");

                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
