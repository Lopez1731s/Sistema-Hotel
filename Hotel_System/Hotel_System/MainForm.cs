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
    public partial class MainForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog= proyecto; Integrated Security=True");

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog=proyecto; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public MainForm()
        {
            InitializeComponent();
            textBox3.Visible = false;
            label10.Text = Form1.variable;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from clientes WHERE DUI='" + textBox2.Text + "' or Pasaporte='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox3.Text= Convert.ToString(reader["DUI"]);
                if (textBox3.Text=="")
                {
                    textBox3.Text = Convert.ToString(reader["Pasaporte"]);
                }
            }

            if (textBox2.Text==textBox3.Text)
            {
                MessageBox.Show("Usuario Registrado", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario No registrado", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
           
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select rango from Usuarios WHERE Nombre_Usuario='" + label10.Text + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label11.Text = Convert.ToString(reader["rango"]);
            }
            con.Close();
        }
      
        private void clientes_Click(object sender, EventArgs e)
        {

            if (label11.Text == "Gerente")
            {
                Form gerentec = new GerenteC();
                gerentec.Show();
            }
            else
            {
                clientes.BackColor = Color.Azure;
                this.Close();
                Form userform = new Users();
                userform.Show();
            }
        }

        private void Habitaciones_Click(object sender, EventArgs e)
        {
            if (label11.Text=="Gerente")
            {
                this.Close();
                Form gerente = new GerenteForm();
                gerente.Show();
            }
            else
            {
                this.Close();
                Form rooms = new Rooms();
                rooms.Show();
            }
        }

        private void Huespedes_Click(object sender, EventArgs e)
        {
            this.Close();
            Form inout = new Checkin_outForm();
            inout.Show();
        }

        private void extras_Click(object sender, EventArgs e)
        {
            Form extras = new Extras();
            extras.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (label11.Text == "Gerente")
            {
                Form gerentec = new GerenteC();
                gerentec.Show();
            }
            else
            {
                clientes.BackColor = Color.Azure;
                this.Close();
                Form userform = new Users();
                userform.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (label11.Text == "Gerente")
            {
                this.Close();
                Form gerente = new GerenteForm();
                gerente.Show();
            }
            else
            {
                this.Close();
                Form rooms = new Rooms();
                rooms.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form inout = new Checkin_outForm();
            inout.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form extras = new Extras();
            extras.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
