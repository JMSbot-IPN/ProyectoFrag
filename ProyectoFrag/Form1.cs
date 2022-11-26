using Microsoft.Data.SqlClient;
using System.Data;


namespace ProyectoFrag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string conString = "Data Source = practicaaworks.database.windows.net; Initial Catalog = salesAW; User Id = patron; Password = Holacomoestas_123;";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            var index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    if (textBox1.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString0 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter0 = new SqlDataAdapter(testString0, con);
                        DataSet dataSet0 = new DataSet();
                        dataAdapter0.Fill(dataSet0, "Salida");
                        dataGridView1.DataSource = dataSet0;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 1:
                    if (textBox1.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString1 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter1 = new SqlDataAdapter(testString1, con);
                        DataSet dataSet1 = new DataSet();
                        dataAdapter1.Fill(dataSet1, "Salida");
                        dataGridView1.DataSource = dataSet1;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 2:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString2 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter2 = new SqlDataAdapter(testString2, con);
                        DataSet dataSet2 = new DataSet();
                        dataAdapter2.Fill(dataSet2, "Salida");
                        dataGridView1.DataSource = dataSet2;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 3:
                    if (textBox1.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString3 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter3 = new SqlDataAdapter(testString3, con);
                        DataSet dataSet3 = new DataSet();
                        dataAdapter3.Fill(dataSet3, "Salida");
                        dataGridView1.DataSource = dataSet3;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 4:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString4 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter4 = new SqlDataAdapter(testString4, con);
                        DataSet dataSet4 = new DataSet();
                        dataAdapter4.Fill(dataSet4, "Salida");
                        dataGridView1.DataSource = dataSet4;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 5:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString5 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter5 = new SqlDataAdapter(testString5, con);
                        DataSet dataSet5 = new DataSet();
                        dataAdapter5.Fill(dataSet5, "Salida");
                        dataGridView1.DataSource = dataSet5;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 6:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString6 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter6 = new SqlDataAdapter(testString6, con);
                        DataSet dataSet6 = new DataSet();
                        dataAdapter6.Fill(dataSet6, "Salida");
                        dataGridView1.DataSource = dataSet6;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 7:
                    string testString7 = "select * from Sales.SalesOrderHeader";
                    SqlDataAdapter dataAdapter7 = new SqlDataAdapter(testString7, con);
                    DataSet dataSet7 = new DataSet();
                    dataAdapter7.Fill(dataSet7, "Salida");
                    dataGridView1.DataSource = dataSet7;
                    dataGridView1.DataMember = "Salida";
                    break;

                case 8:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString8 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter8 = new SqlDataAdapter(testString8, con);
                        DataSet dataSet8 = new DataSet();
                        dataAdapter8.Fill(dataSet8, "Salida");
                        dataGridView1.DataSource = dataSet8;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                case 9:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        string testString9 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter9 = new SqlDataAdapter(testString9, con);
                        DataSet dataSet9 = new DataSet();
                        dataAdapter9.Fill(dataSet9, "Salida");
                        dataGridView1.DataSource = dataSet9;
                        dataGridView1.DataMember = "Salida";
                    }
                    break;

                default:
                break;
            }
            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboBox1.SelectedIndex;
            switch (index){

                case 0:
                    textBox1.PlaceholderText = "Escriba el producto a buscar";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";    
                break;
                
                case 1:
                    textBox1.PlaceholderText = "Escriba el producto a buscar";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";
                break;

                case 2:
                    textBox1.PlaceholderText = "Escriba el producto a buscar";
                    textBox2.PlaceholderText = "Escriba la localidad a buscar";
                break;
                    
                case 3:
                    textBox1.PlaceholderText = "Escriba el nombre del cliente a buscar";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";
                break;

                case 4:
                    textBox1.PlaceholderText = "Escriba la nueva cantidad del producto";
                    textBox2.PlaceholderText = "Escriba el producto a actualizar";
                break;

                case 5:
                    textBox1.PlaceholderText = "Escriba el nuevo metodo de envio";
                    textBox2.PlaceholderText = "Escriba la orden a actualizar";
                break;

                case 6:
                    textBox1.PlaceholderText = "Escriba el nuevo e-mail del cliente";
                    textBox2.PlaceholderText = "Escriba el nombre del cliente a actualizar";
                break;

                case 7:
                    textBox1.PlaceholderText = "No introduzca ningun parametro";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";
                break;

                case 8:
                    textBox1.PlaceholderText = "limite inferior del rango de fecha (AAAA/MM/DD)";
                    textBox2.PlaceholderText = "limite superior del rango de fecha (AAAA/MM/DD)";
                    break;

                case 9:
                    textBox1.PlaceholderText = "limite inferior del rango de fecha (AAAA/MM/DD)";
                    textBox2.PlaceholderText = "limite superior del rango de fecha (AAAA/MM/DD)";
                break;

                default:
                break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}