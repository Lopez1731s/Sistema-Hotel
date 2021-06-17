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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog=proyecto; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            comboBox1.Items.Add("Administrador");
            comboBox1.Items.Add("Gerente");
            comboBox1.Items.Add("Empleado");
            nombre.Visible = false;
            password.Visible = false;
            admin.Visible = false;
            apassword.Visible = false;
            rango.Visible = false;
        }
        public static string variable;
        private void button1_Click(object sender, EventArgs e)
        {
            variable = textBox1.Text;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Nombre_Usuario, Contraseña, Rango from Usuarios where Nombre_Usuario='"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                nombre.Text = Convert.ToString(reader["Nombre_Usuario"]);
                password.Text = Convert.ToString(reader["Contraseña"]);
            }

            if (textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("Por favor ingresar todos los campos necesarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            else if (textBox1.Text!= nombre.Text || textBox2.Text!=password.Text)
            {
                MessageBox.Show("Usuario o contraseña no validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            else if (textBox1.Text == nombre.Text && textBox2.Text == password.Text)
            {
                MessageBox.Show("Bienvenido: "+variable, "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form main = new MainForm();
                main.Show();
            }

            
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox4.Visible = true;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DateTime dt = dateTimePicker1.Value.Date;
            cmd.CommandText = "INSERT INTO Usuarios VALUES('"+textBox4.Text+"', '"+textBox3.Text+"', '"+dt+"', '"+comboBox1.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Usuario Registrado");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Nombre_Usuario, Contraseña, Rango from Usuarios where Nombre_Usuario='" + textBox6.Text + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                admin.Text = Convert.ToString(reader["Nombre_Usuario"]);
                apassword.Text = Convert.ToString(reader["Contraseña"]);
                rango.Text = Convert.ToString(reader["Rango"]); 
            }

            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Por favor ingresar todos los campos necesarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            else if (textBox6.Text != admin.Text || textBox5.Text != apassword.Text)
            {
                MessageBox.Show("Usuario o contraseña no validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            else if (textBox6.Text == admin.Text && textBox5.Text == apassword.Text && rango.Text != "Administrador")
            {
                MessageBox.Show("Usted no tiene los sufucientes permisos para realizar esta operacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            else if (textBox6.Text==admin.Text && textBox5.Text==apassword.Text && rango.Text=="Administrador")
            {
                MessageBox.Show("Bienvenido " + admin.Text);
                textBox5.Clear();
                textBox6.Clear();
                groupBox4.Visible = false;
                groupBox2.Visible = true;
            }
            con.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }
    }
}
