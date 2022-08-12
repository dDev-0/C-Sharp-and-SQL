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
namespace f
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        string connectionPath = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\\Visual Studio 2015\\Projects\\f\\f\\bin\\Debug\\База данных для Форм.accdb";

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) {
                try
                {
                    if(CompanyTextBox.Text.Trim() == "")
                    {
                        CompanyTextBox.Focus();
                        throw new Exception("Введите название компании");
                    }
                    if (ProductTextBox.Text.Trim() == "")
                    {
                        ProductTextBox.Focus();
                        throw new Exception("Введите название товара");
                    }
                    int a;
                    if(!Int32.TryParse(CapacityTextBox.Text, out a))
                    {
                        CapacityTextBox.Focus();
                        throw new Exception("Введенное значение объема не является числом");
                    }
                    if (!Int32.TryParse(PriceTextBox.Text, out a))
                    {
                        PriceTextBox.Focus();
                        throw new Exception("Введенное значение цены не является числом");
                    }

                    if (!ComprasionWithValuesFromDataBase("SELECT Наименование FROM Предприятия", CompanyTextBox.Text))
                    {
                        CompanyTextBox.Focus();
                        throw new Exception("В базе данных нет такого значения названия компании. Если вы хотите добавить новую компанию в таблицу Ассортимент, то сначала добавьте новую компанию в таблицу Предприятия.");
                    }
                    if (!ComprasionWithValuesFromDataBase("SELECT Наименование FROM Товар", ProductTextBox.Text))
                    {
                        ProductTextBox.Focus();
                        throw new Exception("В базе данных нет такого значения названия продукта. Если вы хотите добавить новый продукт в таблицу Ассортимент, то сначала добавьте новый продукт в таблицу Товар.");
                    }
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка");
                    e.Cancel = true;
                }
            }
        }
        // Создание коллекций всех возможных значений для компонентов TextBox.
        private void Form3_Load(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionPath))
            {
                OleDbCommand command = new OleDbCommand("SELECT Наименование FROM Предприятия", connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                AutoCompleteStringCollection sourceForCompanies = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    sourceForCompanies.Add(reader.GetString(0));
                }
                CompanyTextBox.AutoCompleteCustomSource = sourceForCompanies;

                AutoCompleteStringCollection sourceForProducts = new AutoCompleteStringCollection();
                command = new OleDbCommand("SELECT Наименование FROM Товар", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sourceForProducts.Add(reader.GetString(0));
                }
                ProductTextBox.AutoCompleteCustomSource = sourceForProducts;
            }
        }

        bool ComprasionWithValuesFromDataBase(string SQLcommand, string value)
        {
            using(OleDbConnection connection = new OleDbConnection(connectionPath))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(SQLcommand, connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (value == reader.GetString(0))
                        return true;
                }
            }
            return false;
        }
    }
}
