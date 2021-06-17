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
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotel_System
{
    public partial class GerenteC : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L6VLE82\SQLEXPRESS; Initial Catalog=proyecto; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public GerenteC()
        {
            InitializeComponent();
        }

        private void GerenteC_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select T2.Nombres,COUNT(T1.ID) as Total  from Historial_Habitaciones AS T1 INNER JOIN Clientes AS T2 ON T1.ID= T2.ID GROUP BY T1.ID, T2.Nombres";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataRow dr;
            this.chart2.Palette = ChartColorPalette.SeaGreen;
            this.chart2.Titles.Add("Clientes Frecuentes");
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form mainform = new MainForm();
            mainform.Show();
        }
    }
}
