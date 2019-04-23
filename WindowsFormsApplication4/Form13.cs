using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication4.SqlServerTypes.Helpers.WindowsFormsApplication4.Helpers;

namespace WindowsFormsApplication4
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text?.Trim();
            var Query = ($@"select Книги.Наименование, (Заказы.количество_экземпляров*Склад.Цена - Заказы.сумма_предоплаты) as 'Сумма доплаты' from Склад
inner join Заказы
on Заказы.код_книги = Склад.код_книги
inner join Книги
on Книги.Товар_ID = Склад.код_книги
where Склад.код_книги = {text}");

            var connect = SqlConnectionHelper.GetSqlConnection();
            SqlCommand command = new SqlCommand(Query, connect);
            command.CommandTimeout = 30;
            SqlDataAdapter sotrDA = new SqlDataAdapter();
            sotrDA.SelectCommand = command;

            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            sotrDA.Fill(ds, "Запрос");

            dataGridView4.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Query = ($@"select * from Склад 
where Склад.цена > 5000 AND Склад.кол_во_экземпляров > 10");

            var connect = SqlConnectionHelper.GetSqlConnection();
            SqlCommand command = new SqlCommand(Query, connect);
            command.CommandTimeout = 30;
            SqlDataAdapter sotrDA = new SqlDataAdapter();
            sotrDA.SelectCommand = command;

            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            sotrDA.Fill(ds, "Запрос");

            dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = textBox2.Text?.Trim();
            var Query = ($@"select * from Заказы where Заказы.номер_заказа = {text}");

            var connect = SqlConnectionHelper.GetSqlConnection();
            SqlCommand command = new SqlCommand(Query, connect);
            command.CommandTimeout = 30;
            SqlDataAdapter sotrDA = new SqlDataAdapter();
            sotrDA.SelectCommand = command;

            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            sotrDA.Fill(ds, "Запрос");

            dataGridView2.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var text = textBox2.Text?.Trim();
            var Query = ($@"select * from Издательства");

            var connect = SqlConnectionHelper.GetSqlConnection();
            SqlCommand command = new SqlCommand(Query, connect);
            command.CommandTimeout = 30;
            SqlDataAdapter sotrDA = new SqlDataAdapter();
            sotrDA.SelectCommand = command;

            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            sotrDA.Fill(ds, "Запрос");

            dataGridView3.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var text = textBox3.Text?.Trim();
            var Query = ($@"INSERT INTO [dbo].[Издательства]
           ([Наименование])
     VALUES
           ({text})");

            var connect = SqlConnectionHelper.GetSqlConnection();
            SqlCommand command = new SqlCommand(Query, connect);
            command.CommandTimeout = 30;

            connect.Open();
            for (int i = 0; i < 4; i++)
            {
                command.ExecuteNonQuery();
            }
            
            connect.Close();
        }
    }
}
