using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class FormRanking : Form
    {
        public FormRanking()
        {
            InitializeComponent();
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FormRanking(string time, string difficulty)
        {
            InitializeComponent();
            try
            {
                InsertarYActualizar(time, difficulty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha habido un error con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            using SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DBConnection"]);
            con.Open();
            string qry = @"SELECT TIEMPO, DIFICULTAD
                           FROM [Buscaminas]
                           ORDER BY TIEMPO ASC, DIFICULTAD ASC;";
            SqlCommand cmd = new SqlCommand(qry, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dg.DataSource = null;
            dg.DataSource = table;
            dg.AutoResizeColumns();
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void InsertarYActualizar(string time, string difficulty)
        {
            using SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DBConnection"]);
            con.Open();
            Insertar(con, time, difficulty);
            Actualizar(con, time, difficulty);
        }

        private void Actualizar(SqlConnection con, string time, string difficulty)
        {
            string qry = @"SELECT TIEMPO, DIFICULTAD
                           FROM [Buscaminas]
                           ORDER BY TIEMPO ASC, DIFICULTAD ASC;";
            SqlCommand cmd = new SqlCommand(qry, con);
            using SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            dg.DataSource = null;
            dg.DataSource = table;
            dg.AutoResizeColumns();
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Insertar(SqlConnection con, string time, string difficulty)
        {
            string qry = @"INSERT INTO [Buscaminas]
            ([TIEMPO], [DIFICULTAD])
        VALUES
            (@TIEMPO, @DIFICULTAD);";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("TIEMPO", DateTime.Parse(time));
            cmd.Parameters.AddWithValue("DIFICULTAD", difficulty);

            cmd.ExecuteNonQuery();
        }
    }
}