using Microsoft.Data.SqlClient;
using ProyectoFrag;
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



            if (comboBox2.SelectedIndex < 0) //Checa si el usuario selecciono algun servidor al que conectarse
            {
                MessageBox.Show("Por favor elija un servidor al que conectarse");
            }
            else
            {
                string[] instance = comboBox2.Text.Split(' '); //Como el nombre es constante lo asilamos para la connectionString
                //Utilizando la biblioteca using SqlClient para la conexion a SQL Server, no se necesita nada mas
                string conString = $"Data Source = {instance[1]}; Initial Catalog = {instance[2]}; User Id = alumno; Password = Estudiante; TrustServerCertificate = true;";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                var index = comboBox1.SelectedIndex;
                DataTable dt = new DataTable();//Tabla de datos que recive las consultas almacenadas

                switch (index)//Checa que consulta almacenada eligio el usuario
                {
                    case 0:
                        if (textBox1.Text.Equals(""))//Checa si se llenaron los campos correctamente
                        {
                            MessageBox.Show("Por favor rellene los parametros especificados");
                        }
                        else
                        {
                            //Consulta A

                            SqlCommand spA = new SqlCommand("sp_consulta_A", con);//Manda a llamar al procedimiento almacenado
                            spA.CommandType = CommandType.StoredProcedure;//Declara el tipo de comando
                            spA.Parameters.AddWithValue("@cat", textBox1.Text);//Llena los parametros solicitados con la informacion introducida

                            SqlDataAdapter dataAdapter0 = new SqlDataAdapter(spA);//Se crea un adaptador para transformar los datos a algo compatible con la dataTable

                            dataAdapter0.Fill(dt);//Rellena la dataTable con los campos recividos desde SQL Server
                            if (dt.Rows.Count < 1)//Checa si la dataTable esta vacia
                            {
                                MessageBox.Show("No se encontraron resultados de la consulta");
                            }
                            else
                            dataGridView1.DataSource = dt;
                            //Se plasma la informacion recivida de SQL Server en la interfaz grafica por medio del elemento de dataGridView

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

                            SqlCommand spB = new SqlCommand("sp_consulta_B", con);
                            spB.CommandType = CommandType.StoredProcedure;
                            spB.Parameters.AddWithValue("@region", textBox1.Text);

                            SqlDataAdapter dataAdapter0 = new SqlDataAdapter(spB);

                            dataAdapter0.Fill(dt);
                            if (dt.Rows.Count < 1)
                            {
                                MessageBox.Show("No se encontraron resultados de la consulta");
                            }
                            else
                            dataGridView1.DataSource = dt;
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
                            if (dt.Rows.Count < 1)
                            {
                                MessageBox.Show("No se encontraron resultados de la consulta");
                            }
                            else
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
                            if (dt.Rows.Count < 1)
                            {
                                MessageBox.Show("No se encontraron resultados de la consulta");
                            }
                            else
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
                            string[] aux = textBox2.Text.Split(' ');
                            SqlCommand spE = new SqlCommand("sp_consulta_E", con);
                            spE.CommandType = CommandType.StoredProcedure;
                            spE.Parameters.AddWithValue("@qty", textBox1.Text);
                            spE.Parameters.AddWithValue("@OrderId", aux[0]);
                            spE.Parameters.AddWithValue("@producto", aux[1]);

                            SqlDataAdapter dataAdapter4 = new SqlDataAdapter(spE);

                            dataAdapter4.Fill(dt);
                            if (dt.Rows.Count < 1)
                            {
                                MessageBox.Show("No se encontraron resultados de la consulta");
                            }
                            else
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
                            if (dt.Rows.Count < 1)
                            {
                                MessageBox.Show("No se encontraron resultados de la consulta");
                            }
                            else
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
                                if (dt.Rows.Count < 1)
                                {
                                    MessageBox.Show("No se encontraron resultados de la consulta");
                                }
                                else
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
                        if (dt.Rows.Count < 1)
                        {
                            MessageBox.Show("No se encontraron resultados de la consulta");
                        }
                        else
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
                            if (dt.Rows.Count < 1)
                            {
                                MessageBox.Show("No se encontraron resultados de la consulta");
                            }
                            else
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

                            //SqlCommand spI = new SqlCommand("sp_consulta_J", con);
                            //spI.CommandType = CommandType.StoredProcedure;
                            //spI.Parameters.AddWithValue("@fechaEntrada", textBox1.Text);
                            //spI.Parameters.AddWithValue("@fechaSalida", textBox2.Text);

                            //SqlDataAdapter dataAdapter8 = new SqlDataAdapter(spI);

                            //dataAdapter8.Fill(dt);
                            //dataGridView1.DataSource = dt;
                        }
                        break;

                    default:
                        break;
                }
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var index = comboBox1.SelectedIndex;
            switch (index)
            {

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}