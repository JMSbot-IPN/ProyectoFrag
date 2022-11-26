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
            string testString = "select * from Sales.SalesOrderHeader";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(testString, con);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Salida");
            con.Close();
            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Salida";


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}