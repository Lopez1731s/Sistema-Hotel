using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
namespace Hotel_System
{
    public partial class GerenteForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog=proyecto; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public GerenteForm()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select T2.Numero_Habitacion AS Habitaciones,SUM(T1.Precio) Total_Generado from Historial_Habitaciones AS T1 inner join Habitaciones AS T2 ON T1.ID_Habitacion= T2.ID_Habitacion GROUP BY T2.Numero_Habitacion, T1.Precio";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataRow dr;
            this.chart2.Palette = ChartColorPalette.SeaGreen;
            this.chart2.Titles.Add("Ganancias Por Habitaciones");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    Series series2 = this.chart2.Series.Add(dr.ItemArray[0].ToString());
                    series2.Points.Add(Convert.ToDouble(dr.ItemArray[1]));
                }
            }
            con.Close();
        }

        private void GerenteForm_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select T2.Numero_Habitacion AS Habitacion,COUNT(T1.ID_Habitacion) AS Total from Historial_Habitaciones AS T1 inner join Habitaciones as T2 on T1.ID_Habitacion= T2.ID_Habitacion GROUP BY T2.Numero_Habitacion";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            DataRow dr;
            this.chart1.Palette = ChartColorPalette.SeaGreen;
            this.chart1.Titles.Add("Habitaciones mas Demandadas");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    Series series = this.chart1.Series.Add(dr.ItemArray[0].ToString());
                    series.Points.Add(Convert.ToDouble(dr.ItemArray[1]));
                }
            }


            con.Close();
        }

        private void n_habiacion_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form mainform = new MainForm();
            mainform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
