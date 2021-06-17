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
    public partial class Rooms : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog=proyecto; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Rooms()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            id.Visible = false;
            id_h.Visible = false;
            visible.Visible = false;
            comboBox2.Items.Add("Disponible");
            comboBox2.Items.Add("Ocupado");
            comboBox2.Text = "Disponible";
            id2.Visible = false;
            id_habitacion.Visible = false;
            id_r.Visible = false;
            sesion.Text = Form1.variable;
            sesion.Visible = false;
            sesion2.Visible = false;
            dateTimePicker3.MinDate = DateTime.Today;
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            label22.Visible = false;
            button3.Visible = false;
            label28.Visible = false;
            groupBox4.Visible = false;
            cama1.Visible = false;
            cama2.Visible = false; ;
            cama3.Visible = false;
            cama4.Visible = false;
            cama5.Visible = false;
            pc3.Visible = false;
            pc2.Visible = false;
            pc1.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select rango from Usuarios WHERE Nombre_Usuario='" + sesion.Text + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sesion2.Text = Convert.ToString(reader["rango"]);
            }
            con.Close();
            
            if (sesion2.Text == "Empleado")
            {
                groupBox1.Visible = false;
                label7.Visible = false;
                label22.Visible = false;
                label27.Visible = false;
                comboBox2.Visible = false;
                button8.Visible = false;
                dataGridView4.Visible = false;
                groupBox4.Visible = false;
                pc3.Visible = true;
                pc2.Visible = true;
                pc1.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
            }
            cargar();
            cargar2();
            cargar3();
            cargar4();
            cargar5();

            if (sesion2.Text != "Empleado")
            {
                groupBox6.Visible = false;
                pc1.Visible = false;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                radioButton6.Visible = true;
            }

            if (cama1.Text=="")
            {
                pic_cama1.Visible = false;
                button7.Enabled = false;
            }

            if (cama2.Text=="")
            {
                pic_cama2.Visible = false;
                b1.Enabled = false;
            }

            if (cama3.Text=="")
            {
                pic_cama3.Visible = false;
                button9.Enabled = false;
            }
            if (cama4.Text=="")
            {
                pic_cama4.Visible = false;
                button10.Enabled = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form back = new MainForm();
            back.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("1");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("1");
                comboBox1.Items.Add("2");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("1");
                comboBox1.Items.Add("2");
                comboBox1.Items.Add("3");
                comboBox1.Items.Add("4");
                comboBox1.Items.Add("5");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Por favor ingresar todos los campos necesarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Numero_Habitacion from Habitaciones where Numero_Habitacion = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    visible.Text = Convert.ToString(reader["Numero_Habitacion"]);
                }

                if (textBox1.Text == visible.Text)
                {
                    MessageBox.Show("El Numero de Habitacion ya esta registrado", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                if (visible.Text=="")
                {
                    con.Open();
                    if (radioButton1.Checked)
                    {
                        cmd.CommandText = "INSERT INTO Habitaciones(Numero_Habitacion, Disponibilidad, TIpo, Numero_Camas, precio) VALUES(" + textBox1.Text + ", 'Disponible', 'Individual', " + comboBox1.Text + ", " + textBox2.Text + ")";
                        cmd.ExecuteNonQuery();
                    }
                    if (radioButton2.Checked)
                    {
                        cmd.CommandText = "INSERT INTO Habitaciones(Numero_Habitacion, Disponibilidad, TIpo, Numero_Camas, precio) VALUES(" + textBox1.Text + ", 'Disponible', 'Doble', " + comboBox1.Text + ", " + textBox2.Text + ")";
                        cmd.ExecuteNonQuery();
                    }
                    if (radioButton3.Checked)
                    {
                        cmd.CommandText = "INSERT INTO Habitaciones(Numero_Habitacion, Disponibilidad, TIpo, Numero_Camas, precio) VALUES(" + textBox1.Text + ", 'Disponible', 'Suit', " + comboBox1.Text + ", " + textBox2.Text + ")";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Registro agreagado con exito");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox2.SelectedItem.ToString()=="")
            {
                MessageBox.Show("Por Favor, seleccione una opcion.");
            }
            else if (comboBox2.SelectedItem.ToString() == "Disponible")
            {
                textBox3.Visible = true;
                label22.Visible = true;
                button3.Visible = true;
                label28.Visible = true;
                groupBox4.Visible = true;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Numero_Habitacion, Disponibilidad, Tipo, Numero_Camas AS Camas, Precio from Habitaciones WHERE Disponibilidad='Disponible'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            else if (comboBox2.SelectedItem.ToString() == "Ocupado")
            {
                textBox3.Visible = false;
                label22.Visible = false;
                button3.Visible = false;
                label28.Visible = false;
                groupBox4.Visible = false;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Numero_Habitacion, Disponibilidad, Tipo, Numero_Camas AS Camas, Precio from Habitaciones WHERE Disponibilidad='Ocupado'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            con.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = (string)Convert.ToString(dataGridView4.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from clientes WHERE DUI='" + textBox10.Text + "' or Pasaporte='" + textBox10.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox4.Text = (string)reader["Nombres"];
                textBox5.Text = (string)reader["Apellidos"];
                textBox8.Text = (string)reader["Direccion"];
                textBox7.Text = (string)reader["Pais"];
                textBox6.Text = Convert.ToString(reader["Telefono"]);
                id.Text = Convert.ToString(reader["ID"]);
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DateTime dt1 = dateTimePicker2.Value.Date;
            DateTime dt2 = dateTimePicker3.Value.Date;
            cmd.CommandText = "INSERT INTO R_Habitacion(ID_Habitacion,ID,Fecha_Ingreso,Fecha_Salida) VALUES(" + id_h.Text + ", " + id.Text + ", '" + dt1 + "', '" + dt2 + "')";
            cmd.ExecuteNonQuery();

            if (cama1.Text=="1")
            {
                cmd.CommandText = "Update Habitaciones SET Disponibilidad='Ocupado' where Numero_Habitacion = 1";
                cmd.ExecuteNonQuery();
                pic_cama1.Visible = false;
                button7.Enabled = false;
                cama1.Text = "";
            }
            if (textBox3.Text == "0" && cama1.Text == "0")
            {
                cmd.CommandText = "Update Habitaciones SET Disponibilidad='Ocupado' where Numero_Habitacion = " + cama2.Text + "";
                cmd.ExecuteNonQuery();
                pic_cama2.Visible = false;
                b1.Enabled = false;
                cama2.Text = "";
            }
            if (textBox3.Text=="F")
            {
                cmd.CommandText = "Update Habitaciones SET Disponibilidad='Ocupado' where Numero_Habitacion = " + cama3.Text + "";
                cmd.ExecuteNonQuery();
                pic_cama3.Visible = false;
                button9.Enabled = false;
                cama3.Text = "";
                cargar3x();
            }
            if (textBox3.Text == "a")
            {
                cmd.CommandText = "Update Habitaciones SET Disponibilidad='Ocupado' where Numero_Habitacion = " + cama4.Text + "";
                cmd.ExecuteNonQuery();
                pic_cama4.Visible = false;
                button10.Enabled = false;
                cama4.Text = "";
                cargar3x();
            }
            if (textBox3.Text == "c")
            {
                cmd.CommandText = "Update Habitaciones SET Disponibilidad='Ocupado' where Numero_Habitacion = " + cama5.Text + "";
                cmd.ExecuteNonQuery();
                pic_cama5.Visible = false;
                button11.Enabled = false;
                cama5.Text = "";
                cargar3x();
            }
            if (textBox3.Text == textBox14.Text)
            {
                cmd.CommandText = "Update Habitaciones SET Disponibilidad='Ocupado' where Numero_Habitacion = " + textBox3.Text + "";
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Habitacion asignada con exito!");
            con.Close();
            
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            cama1.Text = "ttt";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Habitaciones WHERE Numero_Habitacion='" + textBox3.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox14.Text = Convert.ToString(reader["Numero_Habitacion"]);
                textBox11.Text = (string)reader["Tipo"];
                textBox13.Text = Convert.ToString(reader["Numero_Camas"]);
                textBox9.Text = Convert.ToString(reader["Precio"]);
                id_h.Text = Convert.ToString(reader["ID_Habitacion"]);
            }
            con.Close();
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from clientes WHERE DUI='" + textBox12.Text + "' or Pasaporte='" + textBox12.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox31.Text = (string)reader["Nombres"];
                textBox30.Text = (string)reader["Apellidos"];
                textBox28.Text = (string)reader["Direccion"];
                textBox27.Text = (string)reader["Pais"];
                textBox29.Text = Convert.ToString(reader["Telefono"]);
                id2.Text = Convert.ToString(reader["ID"]);
            }
            con.Close();
            con.Open();
            cmd.CommandText = "select T2.id_Relacion,T1.id_Habitacion, T1.Numero_Habitacion, T1.precio, T2.Fecha_Ingreso, T2.Fecha_Salida, T2.Estadia, (T1.precio* T2.Estadia) AS Total_Pagar from Habitaciones AS T1 INNER JOIN R_Habitacion AS T2 ON T1.ID_Habitacion=T2.ID_Habitacion INNER JOIN Clientes AS T3 ON T3.ID=T2.ID  where T2.id='" + id2.Text+"'";
            cmd.ExecuteNonQuery();
            SqlDataReader read2 = cmd.ExecuteReader();
            if (read2.Read())
            {
                textBox17.Text = Convert.ToString(read2["Numero_Habitacion"]);
                textBox32.Text = Convert.ToString(read2["Estadia"]);
                textBox34.Text = Convert.ToString(read2["Precio"]);
                textBox18.Text = Convert.ToString(read2["Fecha_Ingreso"]);
                textBox19.Text = Convert.ToString(read2["Fecha_Salida"]);
                textBox33.Text = Convert.ToString(read2["Total_Pagar"]);
                id_r.Text = Convert.ToString(read2["id_Relacion"]);
                id_habitacion.Text = Convert.ToString(read2["id_Habitacion"]);
            }
            con.Close();
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Lo Siento ing, no me alcanzo el tiempo :( F
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Historial_Habitaciones(id_Relacion,ID_Habitacion,ID,Fecha_Ingreso,Fecha_Salida,Estadia,Total_Pagar,Precio) VALUES(" + id_r.Text + ", "+id_habitacion.Text+" , "+id2.Text+", '"+textBox18.Text+ "', '" + textBox19.Text + "', "+textBox32.Text+ ",  " + textBox33.Text + ", "+textBox34.Text+")";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE Habitaciones SET Disponibilidad= 'Disponible' WHERE Numero_Habitacion='"+textBox17.Text+"'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from R_Habitacion where id_Relacion='" + id_r.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Cuenta Pagada");
            if (textBox17.Text=="1")
            {
                pic_cama1.Visible = true;
                button7.Enabled = true;
                cama1.Text = "1";
            }
            if (textBox17.Text == "2")
            {
                pic_cama2.Visible = true;
                b1.Enabled = true;
                cama2.Text = "2";
            }
            if (textBox17.Text == "3")
            {
                pic_cama3.Visible = true;
                button9.Enabled = true;
                cama3.Text = "3";
            }
            if (textBox17.Text == "4")
            {
                pic_cama4.Visible = true;
                button10.Enabled = true;
                cama4.Text = "4";
            }

            if (textBox17.Text == "5")
            {
                pic_cama5.Visible = true;
                button11.Enabled = true;
                cama5.Text = "5";
            }
            //cargar3x2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cama1.Text = "1";
            tabControl1.SelectedTab = tabPage2;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Habitaciones WHERE Numero_Habitacion='" + cama1.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox14.Text = Convert.ToString(reader["Numero_Habitacion"]);
                textBox11.Text = (string)reader["Tipo"];
                textBox13.Text = Convert.ToString(reader["Numero_Camas"]);
                textBox9.Text = Convert.ToString(reader["Precio"]);
                id_h.Text = Convert.ToString(reader["ID_Habitacion"]);
            }
            con.Close();
            //cama1.Clear();
        }


        private void cargar()
        {
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=1";
            cmd2.ExecuteNonQuery();
            SqlDataReader readerr = cmd2.ExecuteReader();
            if (readerr.Read())
            {
                cama1.Text = Convert.ToString(readerr["Numero_Habitacion"]);
                precio1.Text= Convert.ToString(readerr["Precio"]);
                ncama1.Text= Convert.ToString(readerr["Numero_Camas"]);
            }
            con.Close();
        }

        private void cargar2()
        {
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=2";
            cmd2.ExecuteNonQuery();
            SqlDataReader readerr = cmd2.ExecuteReader();
            if (readerr.Read())
            {
                cama2.Text = Convert.ToString(readerr["Numero_Habitacion"]);
                precio2.Text = Convert.ToString(readerr["Precio"]);
                ncama2.Text = Convert.ToString(readerr["Numero_Camas"]);
            }
            con.Close();
        }

        private void cargar3()
        {
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=3";
            cmd2.ExecuteNonQuery();
            SqlDataReader readerr = cmd2.ExecuteReader();
            if (readerr.Read())
            {
                cama3.Text = Convert.ToString(readerr["Numero_Habitacion"]);
                precio3.Text = Convert.ToString(readerr["Precio"]);
                ncama3.Text = Convert.ToString(readerr["Numero_Camas"]);
            }
            con.Close();
        }

        private void cargar4()
        {
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=4";
            cmd2.ExecuteNonQuery();
            SqlDataReader readerr = cmd2.ExecuteReader();
            if (readerr.Read())
            {
                cama4.Text = Convert.ToString(readerr["Numero_Habitacion"]);
                precio4.Text = Convert.ToString(readerr["Precio"]);
                ncama4.Text = Convert.ToString(readerr["Numero_Camas"]);
            }
            con.Close();
        }

        private void cargar5()
        {
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=5";
            cmd2.ExecuteNonQuery();
            SqlDataReader readerr = cmd2.ExecuteReader();
            if (readerr.Read())
            {
                cama5.Text = Convert.ToString(readerr["Numero_Habitacion"]);
                precio5.Text = Convert.ToString(readerr["Precio"]);
                ncama5.Text = Convert.ToString(readerr["Numero_Camas"]);
            }
            con.Close();
        }

        private void cargar3x()
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=1";
            cmd1.ExecuteNonQuery();
            SqlDataReader readerr1 = cmd1.ExecuteReader();
            if (readerr1.Read())
            {
                cama1.Text = Convert.ToString(readerr1["Numero_Habitacion"]);
                precio1.Text = Convert.ToString(readerr1["Precio"]);
                ncama1.Text = Convert.ToString(readerr1["Numero_Camas"]);
            }
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=2";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cama2.Text = Convert.ToString(reader["Numero_Habitacion"]);
                precio2.Text = Convert.ToString(reader["Precio"]);
                ncama2.Text = Convert.ToString(reader["Numero_Camas"]);
            }
            con.Close();
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=3";
            cmd2.ExecuteNonQuery();
            SqlDataReader readerr = cmd2.ExecuteReader();
            if (readerr.Read())
            {
                cama3.Text = Convert.ToString(readerr["Numero_Habitacion"]);
                precio3.Text = Convert.ToString(readerr["Precio"]);
                ncama3.Text = Convert.ToString(readerr["Numero_Camas"]);
            }
            con.Close();

            con.Open();
            SqlCommand cmd4 = con.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=4";
            cmd4.ExecuteNonQuery();
            SqlDataReader readerr4 = cmd4.ExecuteReader();
            if (readerr4.Read())
            {
                cama4.Text = Convert.ToString(readerr4["Numero_Habitacion"]);
                precio4.Text = Convert.ToString(readerr4["Precio"]);
                ncama4.Text = Convert.ToString(readerr4["Numero_Camas"]);
            }
            con.Close();
        }

        private void cargar3x2()
        {
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=1";
            cmd1.ExecuteNonQuery();
            SqlDataReader readerr1 = cmd1.ExecuteReader();
            if (readerr1.Read())
            {
                cama1.Text = Convert.ToString(readerr1["Numero_Habitacion"]);
                precio1.Text = Convert.ToString(readerr1["Precio"]);
                ncama1.Text = Convert.ToString(readerr1["Numero_Camas"]);
            }
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=2";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cama2.Text = Convert.ToString(reader["Numero_Habitacion"]);
                precio2.Text = Convert.ToString(reader["Precio"]);
                ncama2.Text = Convert.ToString(reader["Numero_Camas"]);
            }
            con.Close();
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Numero_Habitacion, Precio, Numero_Camas FROM Habitaciones where Disponibilidad='Disponible' AND Numero_Habitacion=3";
            cmd2.ExecuteNonQuery();
            SqlDataReader readerr = cmd2.ExecuteReader();
            if (readerr.Read())
            {
                cama3.Text = Convert.ToString(readerr["Numero_Habitacion"]);
                precio3.Text = Convert.ToString(readerr["Precio"]);
                ncama3.Text = Convert.ToString(readerr["Numero_Camas"]);
            }
            con.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            cama1.Text = "1";
            tabControl1.SelectedTab = tabPage2;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Habitaciones WHERE Numero_Habitacion='" + cama1.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox14.Text = Convert.ToString(reader["Numero_Habitacion"]);
                textBox11.Text = (string)reader["Tipo"];
                textBox13.Text = Convert.ToString(reader["Numero_Camas"]);
                textBox9.Text = Convert.ToString(reader["Precio"]);
                id_h.Text = Convert.ToString(reader["ID_Habitacion"]);
            }
            con.Close();
        }

        private void n_habiacion_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void Check_in_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void Check_out_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void b1_Click_1(object sender, EventArgs e)
        {
            textBox3.Text = "0";
            cama1.Text = "0";
            tabControl1.SelectedTab = tabPage2;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Habitaciones WHERE Numero_Habitacion='" + cama2.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox14.Text = Convert.ToString(reader["Numero_Habitacion"]);
                textBox11.Text = (string)reader["Tipo"];
                textBox13.Text = Convert.ToString(reader["Numero_Camas"]);
                textBox9.Text = Convert.ToString(reader["Precio"]);
                id_h.Text = Convert.ToString(reader["ID_Habitacion"]);
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = "F";
            cama1.Text = "F";
            cama2.Text = "F";
            tabControl1.SelectedTab = tabPage2;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Habitaciones WHERE Numero_Habitacion='" + cama3.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox14.Text = Convert.ToString(reader["Numero_Habitacion"]);
                textBox11.Text = (string)reader["Tipo"];
                textBox13.Text = Convert.ToString(reader["Numero_Camas"]);
                textBox9.Text = Convert.ToString(reader["Precio"]);
                id_h.Text = Convert.ToString(reader["ID_Habitacion"]);
            }
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox3.Text = "a";
            cama1.Text = "a";
            cama2.Text = "a";
            cama3.Text = "a";
            tabControl1.SelectedTab = tabPage2;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Habitaciones WHERE Numero_Habitacion='" + cama4.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox14.Text = Convert.ToString(reader["Numero_Habitacion"]);
                textBox11.Text = (string)reader["Tipo"];
                textBox13.Text = Convert.ToString(reader["Numero_Camas"]);
                textBox9.Text = Convert.ToString(reader["Precio"]);
                id_h.Text = Convert.ToString(reader["ID_Habitacion"]);
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox3.Text = "c";
            cama1.Text = "c";
            cama2.Text = "c";
            cama3.Text = "c";
            cama4.Text = "c";
            tabControl1.SelectedTab = tabPage2;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Habitaciones WHERE Numero_Habitacion='" + cama5.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox14.Text = Convert.ToString(reader["Numero_Habitacion"]);
                textBox11.Text = (string)reader["Tipo"];
                textBox13.Text = Convert.ToString(reader["Numero_Camas"]);
                textBox9.Text = Convert.ToString(reader["Precio"]);
                id_h.Text = Convert.ToString(reader["ID_Habitacion"]);
            }
            con.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pc3.Visible = false;
            pc2.Visible = true;
            pc1.Visible = false;

        }

        private void bpc2_Click(object sender, EventArgs e)
        {
            
            pc3.Visible = false;
            pc2.Visible = false;
            pc1.Visible = true;
        }

        private void pc3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pc1.BackColor = Color.White;
            pc1.Visible = true;
            pc2.Visible = false;
            pc3.Visible = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            pc2.BackColor = Color.White;
            pc1.Visible = false;
            pc2.Visible = true;
            pc3.Visible = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            pc3.BackColor = Color.Red;
            pc1.Visible = false;
            pc2.Visible = false;
            pc3.Visible = true;
        }
    }
}
