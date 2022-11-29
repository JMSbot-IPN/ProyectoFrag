using Microsoft.Data.SqlClient;
using System;
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

            string conString = "Data Source = practicaaworks.database.windows.net; Initial Catalog = productionAW; User Id = patron; Password = Holacomoestas_123;";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            var index = comboBox1.SelectedIndex;
            DataTable dt = new DataTable();

            switch (index)
            {
                case 0:
                    if (textBox1.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta A
                        
                        SqlCommand spA = new SqlCommand("sp_consulta_A", con);
                        spA.CommandType = CommandType.StoredProcedure;
                        spA.Parameters.AddWithValue("@cat",textBox1.Text);
                        
                        SqlDataAdapter dataAdapter0 = new SqlDataAdapter(spA);

                        dataAdapter0.Fill(dt);
                        dataGridView1.DataSource = dt;

                    }
                    break;

                case 1:
                    if (textBox1.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta B
                        /*
                        string testString2 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter2 = new SqlDataAdapter(testString2, con);
                        DataSet dataSet2 = new DataSet();
                        dataAdapter2.Fill(dataSet2, "Salida");
                        dataGridView1.DataSource = dataSet2;
                        dataGridView1.DataMember = "Salida";
                        */
                    }
                    break;

                case 2:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta C

                        SqlCommand spC = new SqlCommand("sp_consulta_C", con);
                        spC.CommandType = CommandType.StoredProcedure;
                        spC.Parameters.AddWithValue("@cat", textBox1.Text);
                        spC.Parameters.AddWithValue("@loc", textBox2.Text);

                        SqlDataAdapter dataAdapter2 = new SqlDataAdapter(spC);

                        dataAdapter2.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    break;

                case 3:
                    if (textBox1.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta D

                        SqlCommand spD = new SqlCommand("sp_consulta_D", con);
                        spD.CommandType = CommandType.StoredProcedure;
                        spD.Parameters.AddWithValue("@cat", textBox1.Text);

                        SqlDataAdapter dataAdapter3 = new SqlDataAdapter(spD);

                        dataAdapter3.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    break;

                case 4:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta E

                        SqlCommand spE = new SqlCommand("sp_consulta_E", con);
                        spE.CommandType = CommandType.StoredProcedure;
                        spE.Parameters.AddWithValue("@qty", textBox1.Text);
                        spE.Parameters.AddWithValue("@Order", textBox2.Text);

                        SqlDataAdapter dataAdapter4 = new SqlDataAdapter(spE);

                        dataAdapter4.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    break;

                case 5:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta F

                        SqlCommand spF = new SqlCommand("sp_consulta_F", con);
                        spF.CommandType = CommandType.StoredProcedure;
                        spF.Parameters.AddWithValue("@envio", textBox1.Text);
                        spF.Parameters.AddWithValue("@Order", textBox2.Text);

                        SqlDataAdapter dataAdapter5 = new SqlDataAdapter(spF);

                        dataAdapter5.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    break;

                case 6:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta G
                        string[] aux = textBox2.Text.Split(' ');
                        if (aux.Length != 2)
                        {
                            MessageBox.Show("Por favor escriba un nombre y un apellido");
                        }
                        else
                        {
                            SqlCommand spG = new SqlCommand("sp_consulta_G", con);
                            spG.CommandType = CommandType.StoredProcedure;
                            spG.Parameters.AddWithValue("@fName", aux[0]);
                            spG.Parameters.AddWithValue("@lName", aux[1]);
                            spG.Parameters.AddWithValue("@correo", textBox1.Text);

                            SqlDataAdapter dataAdapter6 = new SqlDataAdapter(spG);

                            dataAdapter6.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }

                    }
                    break;

                case 7:
                    //Consulta H

                    SqlCommand spH = new SqlCommand("sp_consulta_H", con);
                    spH.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dataAdapter7 = new SqlDataAdapter(spH);

                    dataAdapter7.Fill(dt);
                    dataGridView1.DataSource = dt;
                    break;

                case 8:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta I
                        SqlCommand spI = new SqlCommand("sp_consulta_I", con);
                        spI.CommandType = CommandType.StoredProcedure;
                        spI.Parameters.AddWithValue("@fechaEntrada", textBox1.Text);
                        spI.Parameters.AddWithValue("@fechaSalida", textBox2.Text);

                        SqlDataAdapter dataAdapter8 = new SqlDataAdapter(spI);

                        dataAdapter8.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    break;

                case 9:
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor rellene los parametros especificados");
                    }
                    else
                    {
                        //Consulta J
                        /*
                        string testString9 = "select * from Sales.SalesOrderHeader";
                        SqlDataAdapter dataAdapter9 = new SqlDataAdapter(testString9, con);
                        DataSet dataSet9 = new DataSet();
                        dataAdapter9.Fill(dataSet9, "Salida");
                        dataGridView1.DataSource = dataSet9;
                        dataGridView1.DataMember = "Salida";
                        */
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
                    //Consulta A
                    textBox1.PlaceholderText = "Escriba el ID de la categoria deseada";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";    
                break;
                
                case 1:
                    //Consulta B
                    textBox1.PlaceholderText = "Escriba el ID del producto deseado";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";
                break;

                case 2:
                    //Consulta C
                    textBox1.PlaceholderText = "Escriba el ID del producto a actualizar";
                    textBox2.PlaceholderText = "Escriba el ID de la localidad deseada";
                break;
                    
                case 3:
                    //Consulta D
                    textBox1.PlaceholderText = "Escriba el ID del territorio deseado";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";
                break;

                case 4:
                    //Consulta E
                    textBox1.PlaceholderText = "Escriba la nueva cantidad del producto";
                    textBox2.PlaceholderText = "Escriba el ID del producto a actualizar";
                break;

                case 5:
                    //Consulta F
                    textBox1.PlaceholderText = "Escriba el ID del nuevo metodo de envio";
                    textBox2.PlaceholderText = "Escriba el ID de la orden a actualizar";
                break;

                case 6:
                    //Consulta G
                    textBox1.PlaceholderText = "Escriba el nuevo e-mail del cliente";
                    textBox2.PlaceholderText = "Escriba el nombre completo del cliente";
                break;

                case 7:
                    //Consulta H
                    textBox1.PlaceholderText = "No introduzca ningun parametro";
                    textBox2.PlaceholderText = "No introduzca ningun parametro";
                break;

                case 8:
                    //Consulta I
                    textBox1.PlaceholderText = "limite inferior del rango de fecha (AAAA-MM-DD)";
                    textBox2.PlaceholderText = "limite superior del rango de fecha (AAAA-MM-DD)";
                    break;

                case 9:
                    //Consulta J
                    textBox1.PlaceholderText = "limite inferior del rango de fecha (AAAA-MM-DD)";
                    textBox2.PlaceholderText = "limite superior del rango de fecha (AAAA-MM-DD)";
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