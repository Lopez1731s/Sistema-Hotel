using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel_System
{
    public partial class Checkin_outForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog= proyecto; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Checkin_outForm()
        {
            InitializeComponent();
            //label2.Visible = false;
            //textBox1.Visible = false;
            //comboBox1.Items.Add("DUI o Pasaporte");
            //comboBox1.Items.Add("Buscar Todos");
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT T3.Nombres,T3.Apellidos,T3.Telefono, T1.Numero_Habitacion, T1.TIpo FROM Habitaciones AS T1 INNER JOIN R_Habitacion AS T2 ON T1.ID_Habitacion = T2.ID_Habitacion INNER JOIN Clientes AS T3 ON T3.ID = T2.ID";
            cmd.ExecuteNonQuery();
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                textBox2.Text = (string)read["Nombres"];
                textBox3.Text = (string)read["Apellidos"];
                textBox6.Text = Convert.ToString(read["Telefono"]);
                textBox4.Text = Convert.ToString(read["Numero_Habitacion"]);
                textBox5.Text = (string)read["TIpo"];

            }
            con.Close();
        }*/

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form mainfrom = new MainForm();
            mainfrom.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*if (comboBox1.SelectedItem.ToString()=="")
            {
                MessageBox.Show("Seleccione una opcion valida");
            }

            if (comboBox1.SelectedItem.ToString() == "DUI o Pasaporte")
            {
                
            }*/

            /*label1.Visible = true;
            textBox1.Visible = true;*/
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select T3.Nombres, T1.Numero_Habitacion AS Habitacion, T1.TIpo, T2.Fecha_Ingreso, T2.Fecha_Salida, T2.Estadia from Habitaciones AS T1 INNER JOIN R_Habitacion AS T2 ON T1.ID_Habitacion=T2.ID_Habitacion INNER JOIN Clientes AS T3 ON T3.ID=T2.ID";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select T2.Nombres, T3.Numero_Habitacion, T1.Fecha_Ingreso, T1.Fecha_Salida, T1.Estadia, T1.Total_Pagar from Historial_Habitaciones AS T1 INNER JOIN Clientes AS T2 ON T1.ID= T2.ID INNER JOIN Habitaciones AS T3 ON T1.ID_Habitacion=T3.ID_Habitacion";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
