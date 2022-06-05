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
    /// <summary>
    /// Clase que representa el ranking de los jugadores que han ganado alguna partida
    /// </summary>
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

        /// <summary>
        /// Se establece una conexión a la base de datos y se realiza una consulta del tiempo y la dificultad que se inserta en una tabla para visualizarla
        /// </summary>
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

        /// <summary>
        /// Método que establece la conexión con la base de datos y realiza una inserción y una consulta por medio de dos métodos
        /// </summary>
        /// <param name="time">Puntaje de tiempo</param>
        /// <param name="difficulty">Dificultad</param>
        private void InsertarYActualizar(string time, string difficulty)
        {
            using SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DBConnection"]);
            con.Open();
            Insertar(con, time, difficulty);
            Actualizar(con, time, difficulty);
        }

        /// <summary>
        /// Realiza una consulta del tiempo y la dificultad y la inserta en una tabla para visualizarla
        /// </summary>
        /// <param name="con">Conexión a la base de datos</param>
        /// <param name="time">Puntaje de tiempo</param>
        /// <param name="difficulty">Dificultad</param>
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

        /// <summary>
        /// Realiza una inserción en las columnas TIEMPO y DIFICULTAD del tiempo y la dificultad del ganador de la partida
        /// </summary>
        /// <param name="con">Conexión a la base de datos</param>
        /// <param name="time">Puntaje de tiempo</param>
        /// <param name="difficulty">Dificultad</param>
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