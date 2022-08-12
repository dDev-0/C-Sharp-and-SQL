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
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }
        string connectionPath = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\\Visual Studio 2015\\Projects\\f\\f\\bin\\Debug\\База данных для Форм.accdb";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (productName.Text.Trim() == "")
                {
                    productName.Focus();
                    throw new Exception("Поле товар не должно быть пустым. Введите значение для поиска.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
            using (OleDbConnection connection = new OleDbConnection(connectionPath))
            {
                string query = "SELECT Предприятие, Товар, Объем, Цена FROM Ассортимент WHERE Товар = '" + productName.Text + "' AND Объем = " + Convert.ToInt32(numericUpDown1.Value) + " AND Цена <= " + Convert.ToInt32(numericUpDown2.Value) + "";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connectionPath);
                DataSet newData = new DataSet();
                adapter.Fill(newData);
                dataGridView1.DataSource = newData.Tables[0].DefaultView;
            }
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionPath))
            {
                OleDbCommand command = new OleDbCommand("SELECT Наименование FROM Товар", connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                AutoCompleteStringCollection sourceForCompanies = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    sourceForCompanies.Add(reader.GetString(0));
                }
                productName.AutoCompleteCustomSource = sourceForCompanies;
            }
        }
    }
}
