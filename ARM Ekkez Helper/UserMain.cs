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

namespace ARM_Ekkez_Helper
{
    public partial class UserMain : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ARM.mdb";
        private OleDbConnection myConnection;
        public UserMain()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserMain_Load(object sender, EventArgs e)
        {
            this.объектыTableAdapter.Fill(this.aRMDataSet.Объекты);
            this.клиентыTableAdapter.Fill(this.aRMDataSet.Клиенты);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "SELECT [Код клиента], ФИО, Номер,[Статус Оплаты], [Код объекта] FROM Клиенты WHERE [Код клиента] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = клиентыBindingSource;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Name = textBox3.Text;
            string Phone = textBox4.Text;
            string Status = textBox5.Text;
            string KodOB = textBox6.Text;
            string query = "INSERT INTO Клиенты ([ФИО],[Номер],[Статус оплаты],[Код объекта]) VALUES('" + Name + "','" + Phone + "','" + Status + "','" + KodOB + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.клиентыTableAdapter.Fill(this.aRMDataSet.Клиенты);

            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox12.Text);
            string query = "SELECT [Код объекта], Объект, [Количество комнат],[Этаж], [Общая площадь], [Цена за м²],[Общая стоимость] FROM Объекты WHERE [Код объекта] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView3.DataSource = dt;
            textBox12.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView3.DataSource = объектыBindingSource;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string Name = textBox10.Text;
            string Room = textBox9.Text;
            string Etaj = textBox8.Text;
            string Plosh = textBox7.Text;
            string M2 = textBox13.Text;
            string Price = textBox14.Text;
            string query = "INSERT INTO Объекты ([Объект],[Количество комнат],[Этаж],[Общая площадь],[Цена за м²],[Общая Стоимость]) VALUES('" + Name + "','" + Room + "','" + Etaj + "','" + Plosh + "','" + M2 + "','" + Price + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.объектыTableAdapter.Fill(this.aRMDataSet.Объекты);

            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }
    }
}
