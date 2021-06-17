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
    public partial class Extras : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog=proyecto; Integrated Security=True");
        SqlCommand cmd;
        public Extras()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT t1.ID, t1.Nombres, t1.Apellidos, t1.Direccion, t1.Pais, t1.Telefono, t2.Estadia FROM Clientes as t1 INNER JOIN Historial_Habitaciones as t2 ON t1.ID=t2.ID WHERE DUI='" + textBox10.Text + "' or Pasaporte='" + textBox10.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox4.Text = (string)reader["Nombres"];
                textBox5.Text = (string)reader["Apellidos"];
                textBox8.Text = (string)reader["Direccion"];
                textBox7.Text = (string)reader["Pais"];
                textBox6.Text = Convert.ToString(reader["Telefono"]);
                textBox2.Text = Convert.ToString(reader["Estadia"]);
                id.Text = Convert.ToString(reader["ID"]);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double es = Convert.ToDouble(textBox2.Text);
            double wf = Convert.ToDouble(checkBox1.Tag);
            double sc = Convert.ToDouble(checkBox2.Tag);
            double gm = Convert.ToDouble(checkBox3.Tag);
            double sp = Convert.ToDouble(checkBox4.Tag);
            double sh = Convert.ToDouble(checkBox5.Tag);

            if (checkBox1.Checked == true)
            {
                wf = 2 * es;
                listBox1.Items.Add("Wifi                                      $" + wf);
            }
            if (checkBox2.Checked == true)
            {
                sc = 1.50 * es;
                listBox1.Items.Add("Snacks                                $" + sc);
            }
            if (checkBox3.Checked == true)
            {
                gm = 10 * es;
                listBox1.Items.Add("Gimnasio                              $" + gm);
            }
            if (checkBox4.Checked == true)
            {
                sp = 20 * es;
                listBox1.Items.Add("Spa                                      $" + sp);
            }
            if (checkBox5.Checked == true)
            {
                sh = 15 * es;
                listBox1.Items.Add("Servicios de habitación        $" + sh);
            }
            double total;
            total = wf + sc + gm + sp + sh;
            textBox1.Text = total.ToString();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Total_Servicio(ID, Total_Servicio) VALUES(" + id.Text + "," + textBox1.Text + ")";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Servicios registrados");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " SELECT t1.ID_HServicio, t2.ID, t2.DUI, t2.Pasaporte, t1.Total_Servicio FROM Total_Servicio as t1 INNER JOIN Clientes as t2 ON t1.ID = t2.ID";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form back = new MainForm();
            back.Show();
        }

        private void n_habiacion_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
