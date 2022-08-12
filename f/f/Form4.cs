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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string connectionPath = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\\Visual Studio 2015\\Projects\\f\\f\\bin\\Debug\\База данных для Форм.accdb";
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    if(productTextBox.Text.Trim() == "")
                    {
                        productTextBox.Focus();
                        throw new Exception("Введите название товара");
                    }
                    if(UnitsTextBox.Text.Trim() == "")
                    {
                        UnitsTextBox.Focus();
                        throw new Exception("Введите единицы измерения товара");
                    }

                    if(ComprasionWithValuesFromDataBase("SELECT Наименование FROM Товар", productTextBox.Text))
                    {
                        productTextBox.Focus();
                        throw new Exception("В базе данных уже существует товар с именем, которое ввели вы. Пожалуйста, измените имя добавляемого товара.");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка");
                    e.Cancel = true;
                }
            }
        }

        bool ComprasionWithValuesFromDataBase(string SQLcommand, string value)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionPath))
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
