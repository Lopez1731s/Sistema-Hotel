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
    public partial class Users : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog=proyecto; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Users()
        {
            InitializeComponent();
            comboBox1.Items.Add("DUI");
            comboBox1.Items.Add("Pasaporte");
            comboBox3.Items.Add("DUI");
            comboBox3.Items.Add("Pasaporte");
            comboBox2.Items.Add("Hombre");
            comboBox2.Items.Add("Mujer");
            sesion.Text = Form1.variable;
            sesion.Visible = false;
            sesion2.Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form back = new MainForm();
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.SelectedItem.ToString()=="" || comboBox2.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Por favor ingresar todos los campos necesarios","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime dt = dateTimePicker1.Value.Date;

                //DUI
                if (comboBox1.SelectedItem.ToString() == "DUI" && comboBox2.SelectedItem.ToString() == "Hombre")
                {
                    cmd.CommandText = "insert into Clientes(Nombres, Apellidos, DUI, Genero, Direccion, Nacionalidad, Pais, Fecha_Nacimiento, correo, telefono, Estado) values('" + textBox1.Text + "', '" + textBox2.Text + "', " + textBox4.Text + ",'Hombre', '" + textBox5.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "','" + dt + "', '" + textBox7.Text + "', '" + textBox8.Text + "', 1)";
                    cmd.ExecuteNonQuery();
                }
                else if (comboBox1.SelectedItem.ToString() == "DUI" && comboBox2.SelectedItem.ToString() == "Mujer")
                {
                    cmd.CommandText = "insert into Clientes(Nombres, Apellidos, DUI, Genero, Direccion, Nacionalidad, Pais, Fecha_Nacimiento, correo, telefono, Estado) values('" + textBox1.Text + "', '" + textBox2.Text + "', " + textBox4.Text + ",'Mujer', '" + textBox5.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "','" + dt + "', '" + textBox7.Text + "', '" + textBox8.Text + "', 1)";
                    cmd.ExecuteNonQuery();
                }

                //Pasaporte
                if (comboBox1.SelectedItem.ToString() == "Pasaporte" && comboBox2.SelectedItem.ToString() == "Hombre")
                {
                    cmd.CommandText = "insert into Clientes(Nombres, Apellidos, Pasaporte, Genero, Direccion, Nacionalidad, Pais, Fecha_Nacimiento, correo, telefono, Estado) values('" + textBox1.Text + "', '" + textBox2.Text + "', " + textBox4.Text + ",'Hombre', '" + textBox5.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "','" + dt + "', '" + textBox7.Text + "', '" + textBox8.Text + "', 1)";
                    cmd.ExecuteNonQuery();
                }
                else if (comboBox1.SelectedItem.ToString() == "Pasaporte" && comboBox2.SelectedItem.ToString() == "Mujer")
                {
                    cmd.CommandText = "insert into Clientes(Nombres, Apellidos, Pasaporte, Genero, Direccion, Nacionalidad, Pais, Fecha_Nacimiento, correo, telefono, Estado) values('" + textBox1.Text + "', '" + textBox2.Text + "', " + textBox4.Text + ",'Mujer', '" + textBox5.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "','" + dt + "', '" + textBox7.Text + "', '" + textBox8.Text + "', 1)";
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                MessageBox.Show("Registro agreagado con exito");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox10.Text=="")
            {
                MessageBox.Show("Ingrese un DUI o Pasaporte Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from clientes WHERE DUI='" + textBox10.Text + "' or Pasaporte='" + textBox10.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from clientes WHERE Estado=1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {
                MessageBox.Show("Ingrese un DUI o Pasaporte Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from clientes WHERE DUI='" + textBox20.Text + "' or Pasaporte='" + textBox20.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
        }

        private void mostrar()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from clientes WHERE DUI='" + textBox20.Text + "' or Pasaporte='" + textBox20.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void updateafter()
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {
                MessageBox.Show("Ingrese un DUI o Pasaporte Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro de Eliminar al Cliente?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result== DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update clientes set Estado=0 WHERE DUI='" + textBox20.Text + "' or Pasaporte='" + textBox20.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    mostrar();
                }
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Operacion Cancelada");
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                MessageBox.Show("Ingrese un DUI o Pasaporte Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from clientes WHERE DUI='" + textBox11.Text + "' or Pasaporte='" + textBox11.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox9.Text = Convert.ToString(reader["Genero"]);
                    textBox12.Text = (string)reader["Nombres"];
                    textBox13.Text = (string)reader["Apellidos"];
                    textBox14.Text = (string)reader["Nacionalidad"];
                    textBox15.Text = Convert.ToString(reader["DUI"]);
                    textBox16.Text = (string)reader["Direccion"];
                    textBox17.Text = (string)reader["Pais"];
                    textBox18.Text = Convert.ToString(reader["Telefono"]);
                    textBox19.Text = (string)reader["Correo"];
                    textBox21.Text = Convert.ToString(reader["Fecha_nacimiento"]);
                    comboBox3.Text = "DUI";
                    if (textBox15.Text == "")
                    {
                        textBox9.Text = Convert.ToString(reader["Genero"]);
                        textBox12.Text = (string)reader["Nombres"];
                        textBox13.Text = (string)reader["Apellidos"];
                        textBox14.Text = (string)reader["Nacionalidad"];
                        textBox15.Text = Convert.ToString(reader["Pasaporte"]);
                        textBox16.Text = (string)reader["Direccion"];
                        textBox17.Text = (string)reader["Pais"];
                        textBox18.Text = Convert.ToString(reader["Telefono"]);
                        textBox19.Text = (string)reader["Correo"];
                        textBox21.Text = Convert.ToString(reader["Fecha_nacimiento"]);
                        comboBox3.Text = "Pasaporte";
                    }

                }
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox9.Text=="" || textBox12.Text=="" || textBox13.Text == "" || textBox14.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "" || textBox18.Text == "" || textBox19.Text == "" || textBox21.Text == "" || comboBox3.SelectedItem.ToString()=="")
            {
                MessageBox.Show("Por favor ingresar todos los campos necesarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                if (comboBox3.SelectedItem.ToString()=="DUI")
                {
                    cmd.CommandText = "update Clientes set Nombres='" + textBox12.Text + "', Apellidos='" + textBox13.Text + "', Nacionalidad='" + textBox14.Text + "', DUI=" + textBox15.Text + ", Direccion='" + textBox16.Text + "', Pais='" + textBox17.Text + "', Telefono=" + textBox18.Text + ", Correo='" + textBox19.Text + "', Fecha_Nacimiento='" + textBox21.Text + "'  where DUI='" + textBox11.Text + "' or Pasaporte='" + textBox11.Text + "'";
                    cmd.ExecuteNonQuery();
                }

                else if (comboBox3.SelectedItem.ToString() == "Pasaporte")
                {
                    cmd.CommandText = "update Clientes set Nombres='" + textBox12.Text + "', Apellidos='" + textBox13.Text + "', Nacionalidad='" + textBox14.Text + "', Pasaporte=" + textBox15.Text + ", Direccion='" + textBox16.Text + "', Pais='" + textBox17.Text + "', Telefono=" + textBox18.Text + ", Correo='" + textBox19.Text + "', Fecha_Nacimiento='" + textBox21.Text + "'  where DUI='" + textBox11.Text + "' or Pasaporte='" + textBox11.Text + "'";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Registro actualizado");
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
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
                button6.Enabled = false;
            }
        }

        private void n_habiacion_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void Check_in_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void Check_out_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void label34_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

//, Pasaporte=" + textBox15.Text + "

/*
cmd.CommandText = "update Clientes set Nombres='" + textBox12.Text + "', Apellidos='" + textBox13.Text + "', Nacionalidad='" + textBox14.Text + "', DUI=" + textBox15.Text + ", Direccion='" + textBox16.Text + "', Pais='" + textBox17.Text + "', Telefono=" + textBox18.Text + ", Correo='" + textBox19.Text + "', Fecha_Nacimiento='" + textBox21.Text + "'  where DUI='" + textBox11.Text + "' or Pasaporte='" + textBox11.Text + "'";
cmd.ExecuteNonQuery();
*/
