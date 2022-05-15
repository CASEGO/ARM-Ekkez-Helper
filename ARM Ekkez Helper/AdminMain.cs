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
    public partial class AdminMain : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ARM.mdb";
        private OleDbConnection myConnection;
        public AdminMain()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);
            this.реквизитыTableAdapter.Fill(this.aRMDataSet.Реквизиты);
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

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Клиенты WHERE [Код клиента] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = клиентыBindingSource;
            this.клиентыTableAdapter.Fill(this.aRMDataSet.Клиенты);
            textBox1.Clear();
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

        private void button8_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox12.Text);
            string query = "DELETE FROM Объекты WHERE [Код объекта] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView3.DataSource = объектыBindingSource;
            this.объектыTableAdapter.Fill(this.aRMDataSet.Объекты);
            textBox12.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox11.Text);
            string query = "UPDATE Объекты SET [Цена за м²] ='" + textBox2.Text + "' WHERE [Код объекта] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.объектыTableAdapter.Fill(this.aRMDataSet.Объекты);
            textBox2.Clear();
            textBox11.Clear();
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

        private void button11_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox18.Text);
            string query = "SELECT [Код счёта], Банк, [Номер счёта],Тип, Валюта FROM Реквизиты WHERE [Код счёта] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView2.DataSource = dt;
            textBox18.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView2.DataSource = реквизитыBindingSource;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox18.Text);
            string query = "DELETE FROM Реквизиты WHERE [Код счёта] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView2.DataSource = реквизитыBindingSource;
            this.реквизитыTableAdapter.Fill(this.aRMDataSet.Реквизиты);
            textBox18.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string Bank = textBox21.Text;
            string Nomer = textBox20.Text;
            string Type = textBox19.Text;
            string Valuta = textBox17.Text;
            string query = "INSERT INTO Реквизиты ([Банк],[Номер счёта],[Тип],[Валюта]) VALUES('" + Bank + "','" + Nomer + "','" + Type + "','" + Valuta + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.реквизитыTableAdapter.Fill(this.aRMDataSet.Реквизиты);
            textBox21.Clear();
            textBox20.Clear();
            textBox19.Clear();
            textBox17.Clear();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox26.Text);
            string query = "SELECT [Код сотрудника], ФИО, Телефон, Адрес, Должность, Зарплата FROM Сотрудники WHERE [Код сотрудника] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView4.DataSource = dt;
            textBox26.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView4.DataSource = сотрудникиBindingSource;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox26.Text);
            string query = "DELETE FROM Сотрудники WHERE [Код сотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView2.DataSource = реквизитыBindingSource;
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);
            textBox26.Clear();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string Name = textBox29.Text;
            string Phone = textBox28.Text;
            string Home = textBox27.Text;
            string Status = textBox25.Text;
            string Price = textBox15.Text;
            string query = "INSERT INTO Сотрудники ([ФИО],[Телефон],[Адрес],[Должность],[Зарплата]) VALUES('" + Name + "','" + Phone + "','" + Home + "','" + Status + "','"+Price+"')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);
            textBox29.Clear();
            textBox28.Clear();
            textBox27.Clear();
            textBox15.Clear();
            textBox25.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox23.Text);
            string query = "UPDATE Сотрудники SET [Должность] ='" + textBox22.Text + "' WHERE [Код сотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            string query1 = "UPDATE Сотрудники SET [Зарплата] ='" + textBox16.Text + "' WHERE [Код сотрудника] = " + kod;
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            command1.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);
            textBox22.Clear();
            textBox23.Clear();
            textBox16.Clear();
        }
    }
}
