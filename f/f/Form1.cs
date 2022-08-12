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
    public partial class Form1 : Form
    {
        enum selectedTable
        {
            ПредприятияSelected,
            АссортиментSelected,
            ТоварSelected
        }

        selectedTable Table;

        string connectionPath = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\\Visual Studio 2015\\Projects\\f\\f\\bin\\Debug\\База данных для Форм.accdb";
        public Form1()
        {
            InitializeComponent();
        }

        #region Заполнение данными
        // При загрузке формы у компонентов DGV устанавливаются источники данных
        private void Form1_Load(object sender, EventArgs e)
        {
            FillTablesWithData();
        }

        void FillTablesWithData()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionPath))
            {
                Companies.DataSource = getData("SELECT * FROM Предприятия ORDER BY Код").Tables[0].DefaultView;
                ProductRange.DataSource = getData("SELECT * FROM Ассортимент").Tables[0].DefaultView;
                Product.DataSource = getData("SELECT * FROM Товар").Tables[0].DefaultView;
            }
           
        }
        // Метод для заполнения компонентов DGV данными
        DataSet getData(string command)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(command, connectionPath);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }
        #endregion
        #region Операции над данными


        void Add(object sender, EventArgs e)
        {
            switch(Table)
            {
                case selectedTable.ПредприятияSelected:
                    Form2 form = new Form2();
                    form.Text = "Добавление нового предприятия";
                    if(form.ShowDialog() == DialogResult.OK)
                    {
                        string query = "INSERT INTO Предприятия (Наименование, ОргПравФорм, Адрес) VALUES ('" + form.NameTextBox.Text + "', '" + form.TypeTextBox.Text + "', '" + form.LocationTextBox.Text + "')";
                        DoAQuery(query);
                    }
                break;

                case selectedTable.ТоварSelected:
                    Form4 addNewProduct = new Form4();
                    addNewProduct.Text = "Добавление нового товара";
                    if (addNewProduct.ShowDialog() == DialogResult.OK)
                    {
                        string query = "INSERT INTO Товар (Наименование, Единицы_Измерения) VALUES ('" + addNewProduct.productTextBox.Text + "', '" + addNewProduct.UnitsTextBox.Text + "')";
                        DoAQuery(query);
                    }
                 break;

                case selectedTable.АссортиментSelected:
                    Form3 addNewList = new Form3();
                    addNewList.Text = "Добавление нового списка";
                    if (addNewList.ShowDialog() == DialogResult.OK)
                    {
                        string query = "INSERT INTO Ассортимент (Предприятие, Товар, Объем, Цена) VALUES ('" + addNewList.CompanyTextBox.Text + "', '" + addNewList.ProductTextBox.Text + "', '" + addNewList.CapacityTextBox.Text + "', '" + Convert.ToInt32(addNewList.PriceTextBox.Text) + "')";
                        DoAQuery(query);
                    }
                    break;
            }
        }

        void DoAQuery(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionPath))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
            FillTablesWithData();
        }
        void QueryMethod (object sender, EventArgs e)
        {
            QueryForm form = new QueryForm();
            form.ShowDialog();
        }

        void CompanyDGV_Click(object sender, EventArgs e)
        {
            Table = selectedTable.ПредприятияSelected;
            button1.Enabled = true;
        }
        void ProductDGV_Click(object sender, EventArgs e)
        {
            Table = selectedTable.ТоварSelected;
            button1.Enabled = true;
        }
        void ListDGV_Click(object sender, EventArgs e)
        {
            Table = selectedTable.АссортиментSelected;
            button1.Enabled = true;
        }
        #endregion
    }
}
