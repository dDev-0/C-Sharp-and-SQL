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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionPath = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\\Visual Studio 2015\\Projects\\f\\f\\bin\\Debug\\База данных для Форм.accdb";
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                try
                {
                    if(NameTextBox.Text.Trim() == "")
                    {
                        NameTextBox.Focus();
                        throw new Exception("Введите название компании");
                    }
                    if (TypeTextBox.Text.Trim() == "")
                    {
                        TypeTextBox.Focus();
                        throw new Exception("Введите организационно-правовую форму компании");
                    }
                    if (LocationTextBox.Text.Trim() == "")
                    {
                        LocationTextBox.Focus();
                        throw new Exception("Введите адрес компании");
                    }
                    if (ComprasionWithValuesFromDataBase("SELECT Наименование FROM Предприятия", NameTextBox.Text))
                    {
                        NameTextBox.Focus();
                        throw new Exception("В базе данных уже существует предприятие с наименованием, которое ввели вы. Пожалуйста, введите новое наименование.");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
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
