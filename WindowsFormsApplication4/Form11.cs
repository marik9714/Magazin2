using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication4.SqlServerTypes.Helpers.WindowsFormsApplication4.Helpers;

namespace WindowsFormsApplication4
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             var Query = @"SELECT [Наименование]
      ,([Количество] * Цена) as 'Общая стоимость'
  FROM [dbo].[Книги]";

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
            var Query = @"select sum(кол_во_экз) as 'Кол-во проданных экземпляров', Книги.Наименование,  Сотрудники.ФИО from Продажа
inner join Сотрудники 
on Продажа.код_сотрудника = Сотрудники.Таб_номер_сотрудника
inner join Книги
on Книги.Товар_ID = Продажа.код_книги
group by Продажа.код_сотрудника, Книги.Наименование, Сотрудники.ФИО";

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
            var text = textBox1.Text?.Trim();
            var Query = $@"select * from Клиенты where Фамилия like('{text}%');";

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

        private void button4_Click(object sender, EventArgs e)
        {
            var text = textBox2.Text?.Trim();
            var Query = $@"select  Книги.Наименование,Продажа.Дата from Продажа
inner join Книги
on Книги.Товар_ID = Продажа.код_книги and  Продажа.Дата = {text}";

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

        private void button5_Click(object sender, EventArgs e)
        {
            // Текстбокс ввода на твоей панели
            var text = textBox3.Text?.Trim();
            var Query =$@"select Книги.Наименование as 'Книга', Издательства.Наименование as 'Издательство' from Продажа
inner join Книги
on Продажа.код_книги=Книги.Товар_ID AND Продажа.Дата = {text}
inner join Издательства
on Продажа.код_издательства = Издательства.Код_издательства";

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

            dataGridView5.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }
    }
}
