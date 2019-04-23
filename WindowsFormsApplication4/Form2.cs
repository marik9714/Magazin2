using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication4.SqlServerTypes.Helpers.WindowsFormsApplication4.Helpers;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        private object dataGridView8;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Query;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    Query = @"SELECT Книги.Товар_ID, Книги.Наименование, Книги.Количество, Книги.Цена, Отделы.Отдел FROM Отделы 
INNER JOIN Книги ON Отделы.Отдел_ID = Книги.Отдел_ID; ";
                    break;
                case 1:
                    Query = "Select * from Авторы";
                    break;
                case 2:
                    Query = "Select * from Издания";
                    break;

                case 3:
                    Query = "Select * from Сотрудники";
                    break;
                case 4:
                    Query = "Select * from Склад";
                    break;
              
                case 5:
                    Query = "Select * from Заказы";
                    break;
                case 6:
                    Query = "Select * from Издательства";
                    break;
                case 7:
                    Query = "Select * from Классификатор";
                    break;
                case 8:
                    Query = "Select * from ФИО_Авторов";
                    break;
                case 9:
                    Query = "Select * from Продажа";
                    break;

                default:
                    Query = "";
                    break;

            }

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
            sotrDA.Fill(ds, "Магазин");
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 1:
                    dataGridView2.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 2:
                    dataGridView3.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 3:
                    dataGridView5.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 4:
                    dataGridView6.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 5:
                    dataGridView7.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 6:
                    dataGridView9.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 7:
                    dataGridView4.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 8:
                    dataGridView10.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
                case 9:
                    dataGridView11.DataSource = ds.Tables["Магазин"].DefaultView;
                    break;
            }
            connect.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "магазин2DataSet.Продажи". При необходимости она может быть перемещена или удалена.
            //this.продажиTableAdapter.Fill(this.магазин2DataSet.Продажи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "магазин2DataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            //this.сотрудникиTableAdapter.Fill(this.магазин2DataSet.Сотрудники);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "магазин2DataSet.Поступления". При необходимости она может быть перемещена или удалена.
            //this.поступленияTableAdapter.Fill(this.магазин2DataSet.Поступления);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "магазин2DataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            //this.клиентыTableAdapter.Fill(this.магазин2DataSet.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "магазин2DataSet.Отделы". При необходимости она может быть перемещена или удалена.
            //this.поставщикиTableAdapter.Fill(this.магазин2DataSet.Отделы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "магазин2DataSet.Отделы". При необходимости она может быть перемещена или удалена.
            //this.отделыTableAdapter.Fill(this.магазин2DataSet.Отделы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "магазин2DataSet.Книги". При необходимости она может быть перемещена или удалена.
            //this.товарыTableAdapter.Fill(this.магазин2DataSet.Книги);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            var connect = SqlConnectionHelper.GetSqlConnection();
            string Query;
            Query = "SELECT TOP 1 * FROM Книги ORDER BY Книги.Цена DESC;";
            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
            form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            string Query;
            Query = "SELECT Книги.Наименование, Книги.Цена, Отделы.Отдел_ID FROM Отдел_ID INNER JOIN Книги ON Отделы.Отдел_ID = Книги.Отдел_ID ORDER BY Отделы.Отдел_ID DESC;";

            var connect = SqlConnectionHelper.GetSqlConnection();
            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
            form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            string Query;

            Query = "SELECT Книги.Наименование, Поступления.[Количество], Поступления.Цена, Отделы.Отдел_ID, Поступления.Дата FROM Отделы INNER JOIN(Книги INNER JOIN Поступления ON Книги.Товар_ID = Поступления.Товар_ID) ON Отдел_ID.Отдел_ID = Книги.Отдел_IDы_ID WHERE (((Поступления.Дата)Between Date() And Date() - 60));";
            var connect = SqlConnectionHelper.GetSqlConnection();
            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
            form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            string Query;

            Query = "SELECT Книги.Наименование, Продажи.Количество, Книги.Цена, [Продажи].[Количество]*[Книги].[Цена] AS Итого FROM Книги INNER JOIN Продажи ON Книги.Товар_ID = Продажи.Товар;";
            var connect = SqlConnectionHelper.GetSqlConnection();
            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
            form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            string Query, con;

            Query = "SELECT [Сотрудники].[ФИО] + ' ' +[Сотрудники].[Таб_номер_сотрудника] AS Сотрудник, Продажи.[Номер_продажи], Продажи.[Дата_продажи], Книги.Наименование, Продажи.Количество, Книги.Цена, [Продажи].[Количество]*[Книги].[Цена] AS Сумма, [Клиенты].[ФИО]+' '+[Клиенты].[Имя]+' '+[Клиенты].[Отчество] AS Клиент FROM Книги INNER JOIN (Сотрудники INNER JOIN (Клиенты INNER JOIN Продажи ON Клиенты.Код = Продажи.Клиент_ID) ON Сотрудники.Таб_номер_сотрудника = Продажи.Таб_номер_сотрудника) ON Книги.Товар_ID = Продажи.Товар ORDER BY[Сотрудники].[ФИО]+' '+[Сотрудники].[Таб_номер_сотрудника] DESC;";
            var connect = SqlConnectionHelper.GetSqlConnection();
            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
            form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Введите номер продажи");
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
                string Query, con;

                Query = "SELECT Продажи.[Номер_продажи], Отдел_ID.Отдел_ID, Отделы.Адрес, Отделы.Телефон FROM(Отделы INNER JOIN Книги ON Отделы.Отдел_ID = Книги.Отдел_IDы_ID) INNER JOIN Продажи ON Книги.Товар_ID = Продажи.Товар WHERE Продажи.[Номер_продажи] = " + textBox2.Text + ";";
                var connect = SqlConnectionHelper.GetSqlConnection();
                try
                {
                    connect.Open();
                    MessageBox.Show("Соединение прошло успешно");
                }
                catch { MessageBox.Show("Ошибка соединения"); }
                DataSet ds = new DataSet();
                ds.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
                form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
                connect.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Введите номер продажи");
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
                string Query, con;
                con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Магазин2.mdb;Persist Security Info=False;";
                Query = "SELECT Продажи.[Номер_продажи], Клиенты.Фамилия, Клиенты.Имя, Клиенты.Отчество, Клиенты.Отдел_ID, Клиенты.Телефон FROM Клиенты INNER JOIN Продажи ON Клиенты.Код = Продажи.Клиент_ID WHERE Продажи.[Номер_продажи] =" + textBox1.Text + ";";
                var connect = SqlConnectionHelper.GetSqlConnection();
                try
                {
                    connect.Open();
                    MessageBox.Show("Соединение прошло успешно");
                }
                catch { MessageBox.Show("Ошибка соединения"); }
                DataSet ds = new DataSet();
                ds.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
                form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
                connect.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                    return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    textBox2.Focus();
                return;
            }
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                    return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    textBox1.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            findgoods();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Введите цену");
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
                string Query, con;
                con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Магазин2.mdb;Persist Security Info=False;";
                Query = "SELECT Книги.Товар_ID, Книги.Наименование, Книги.Количество, Книги.[Цена], Отделы.Отдел_ID, Отделы.Отдел FROM Отделы INNER JOIN (Отделы INNER JOIN Книги ON Отделы.Отдел_ID = Книги.Отдел_ID) ON Отдел_ID.Отдел_ID = Книги.Отдел_ID_ID WHERE Книги.[Цена] =" + textBox4.Text + ";";
                var connect = SqlConnectionHelper.GetSqlConnection();
                try
                {
                    connect.Open();
                    MessageBox.Show("Соединение прошло успешно");
                }
                catch { MessageBox.Show("Ошибка соединения"); }
                DataSet ds = new DataSet();
                ds.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
                form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
                connect.Close();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            findprovider();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                    return;
            }
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Space)
                    return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    findgoods();
                return;
            }
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                    return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    textBox4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                    return;
            }
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Space)
                    return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    findprovider();
                return;
            }
            e.Handled = true;
        }

        private void findprovider()
        {
            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Введите поставщика");
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
                string Query, con;
                con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Магазин2.mdb;Persist Security Info=False;";
                Query = "SELECT Книги.Товар_ID, Книги.Наименование, Книги.Количество, Книги.Цена, Отделы.Отдел_ID, Отделы.Отдел FROM Отделы INNER JOIN(Отделы INNER JOIN Книги ON Отделы.Отделы_ID = Книги.Отделы_ID) ON Отделы.Отдел_ID = Книги.Отдел_ID WHERE Отделы.Отдел_ID = '" + textBox5.Text + "';";
                var connect = SqlConnectionHelper.GetSqlConnection();
                try
                {
                    connect.Open();
                    MessageBox.Show("Соединение прошло успешно");
                }
                catch { MessageBox.Show("Ошибка соединения"); }
                DataSet ds = new DataSet();
                ds.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query, "Отделы товара", ds, connect);
                form3.dataGridView1.DataSource = ds.Tables["Отделы товара"].DefaultView;
                connect.Close();
            }
        }
        private void findgoods()
        {
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Введите название товара");
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
                string Query, con;
                con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Магазин2.mdb;Persist Security Info=False;";
                Query = "SELECT Книги.Товар_ID, Книги.Наименование, Книги.Количество, Книги.Цена, Отделы.Отдел_ID, Отделы.Отдел FROM Отделы INNER JOIN(Отделы INNER JOIN Книги ON Отделы.Отделы_ID = Книги.Отделы_ID) ON Отделы.Отдел_ID = Книги.Отдел_ID WHERE Книги.Наименование = '" + textBox3.Text + "';";
                var connect = SqlConnectionHelper.GetSqlConnection();
                try
                {
                    connect.Open();
                    MessageBox.Show("Соединение прошло успешно");
                }
                catch { MessageBox.Show("Ошибка соединения"); }
                DataSet ds = new DataSet();
                ds.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query, "Поиск товара", ds, connect);

                form3.dataGridView1.DataSource = ds.Tables["Поиск товара"].DefaultView;
                connect.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            string Query, con;
            con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Магазин2.mdb;Persist Security Info=False;";
            Query = "SELECT TOP 10 Продажи.Код, Книги.Наименование, Продажи.Количество, Книги.Цена, [Продажи].[Количество]*[Книги].[Цена] AS Сумма, [Клиенты].[Фамилия]+' '+[Клиенты].[Имя]+' '+[Клиенты].[Отчество] AS Клиент, [Сотрудники].[ФИО] AS Сотрудник, Продажи.[Номер_продажи], Продажи.[Дата_продажи] FROM Книги INNER JOIN (Сотрудники INNER JOIN(Клиенты INNER JOIN Продажи ON Клиенты.Код = Продажи.Клиент_ID) ON Сотрудники.Таб_номер_сотрудника = Продажи.Таб_номер_сотрудника) ON Книги.Товар_ID = Продажи.Товар ORDER BY Продажи.Количество DESC;";
            var connect = SqlConnectionHelper.GetSqlConnection();
            try
            {
                connect.Open();
                MessageBox.Show("Соединение прошло успешно");
            }
            catch { MessageBox.Show("Ошибка соединения"); }
            DataSet ds = new DataSet();
            ds.Clear();
            SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
            form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Введите номер продажи");
            }
            else
            {
                Form10 form10 = new Form10();
                form10.Show();
                string Query, Query1, con;
                con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Магазин2.mdb;Persist Security Info=False;";
                Query = "SELECT Книги.Наименование, Продажи.Количество, Книги.Цена, [Продажи].[Количество]*[Книги].[Цена] AS Сумма FROM Книги INNER JOIN Продажи ON Книги.Товар_ID = Продажи.Товар WHERE Продажи.[Номер_продажи] =" + textBox6.Text + ";";
                var connect = SqlConnectionHelper.GetSqlConnection();
                try
                {
                    connect.Open();
                    MessageBox.Show("Соединение прошло успешно");
                }
                catch { MessageBox.Show("Ошибка соединения"); }
                DataSet ds = new DataSet();
                ds.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query, "Товарный чек", ds, connect);
                form10.dataGridView1.DataSource = ds.Tables["Товарный чек"].DefaultView;
                connect.Close();
                Query1 = "SELECT[Сотрудники].[ФИО] + ' '  FROM Сотрудники INNER JOIN Продажи ON Сотрудники.Таб_номер_сотрудника = Продажи.Таб_номер_сотрудника WHERE Продажи.[Номер_продажи] =" + textBox6.Text + ";";
                OleDbDataAdapter dan1 = new OleDbDataAdapter(Query1, con);
                connect.Open();
                DataSet ds1 = new DataSet();
                ds1.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query1, "Товарный чек", ds1, connect);
                form10.label5.Text = ds1.Tables["Товарный чек"].Rows[0][0].ToString();
                form10.label11.Text = ds1.Tables["Товарный чек"].Rows[0][1].ToString();
                form10.label3.Text = ds1.Tables["Товарный чек"].Rows[0][2].ToString();
                connect.Close();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                    return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    textBox6.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Неправильный интервал даты");
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
                string Query, con;
                string formateddate1 = "#" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Year.ToString() + "#";
                string formateddate2 = "#" + dateTimePicker2.Value.Day.ToString() + "/" + dateTimePicker2.Value.Month.ToString() + "/" + dateTimePicker2.Value.Year.ToString() + "#";
                con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Магазин2.mdb;Persist Security Info=False;";
                Query = "SELECT Продажи.Код, Книги.Наименование, Продажи.Количество, Книги.Цена, [Продажи].[Количество]*[Книги].[Цена] AS Сумма, [Клиенты].[Фамилия]+' '+[Клиенты].[Имя]+' '+[Клиенты].[Отчество] AS Клиент, [Сотрудники].[ФИО]+' '+[Сотрудники].[Таб_номер_сотрудника]+ AS Сотрудник, Продажи.[Номер_продажи], Продажи.[Дата_продажи] FROM Книги INNER JOIN (Сотрудники INNER JOIN(Клиенты INNER JOIN Продажи ON Клиенты.Код = Продажи.Клиент_ID) ON Сотрудники.Таб_номер_сотрудника = Продажи.Таб_номер_сотрудника) ON Книги.Товар_ID = Продажи.Товар WHERE Продажи.[Дата_продажи] Between " + formateddate1 + " And " + formateddate2 + ";";
                var connect = SqlConnectionHelper.GetSqlConnection();
                try
                {
                    connect.Open();
                    MessageBox.Show("Соединение прошло успешно");
                }
                catch { MessageBox.Show("Ошибка соединения"); }
                DataSet ds = new DataSet();
                ds.Clear();
                SqlConnectionHelper.ExecuteButtonHandle(Query, "Запрос", ds, connect);
                form3.dataGridView1.DataSource = ds.Tables["Запрос"].DefaultView;
                connect.Close();
            }
        }
    }
}

