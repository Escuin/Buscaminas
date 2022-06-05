namespace Buscaminas
{
    /// <summary>
    /// Clase que representa la pantalla inicial de la aplicaci�n y sus distintas opciones
    /// </summary>
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bot�n de jugar: inicia la partida tras haber elegido una dificultad
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            switch (cboDifficulty.Text)
            {
                case "Modo f�cil":
                    var frm = new FormGame("Modo f�cil");
                    frm.Show();
                    break;
                case "Modo intermedio":
                    frm = new FormGame("Modo intermedio");
                    frm.Show();
                    break;
                case "Modo dif�cil":
                    frm = new FormGame("Modo dif�cil");
                    frm.Show();
                    break;
                default:
                    MessageBox.Show("No se puede jugar sin seleccionar una dificultad");
                    break;
            };
        }

        /// <summary>
        /// Bot�n de salir: cierra el juego tras un mensaje de confirmaci�n
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("�Est�s seguro de querer cerrar el juego?", "Cerrar juego", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Combo box de dificultad: despliega las dificultades y cambia el color del t�tulo seg�n la elecci�n
        /// </summary>
        private void cboDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboDifficulty.Text)
            {
                case "Modo f�cil":
                    lblTitle.ForeColor = Color.Green;
                    break;
                case "Modo intermedio":
                    lblTitle.ForeColor = Color.Orange;
                    break;
                case "Modo dif�cil":
                    lblTitle.ForeColor = Color.Red;
                    break;
                default:
                    break;
            };
        }

        /// <summary>
        /// Bot�n de ranking: abre un formulario que se conecta a la base de datos y muestra los tiempos registrados y su dificultad
        /// </summary>
        private void btnRanking_Click(object sender, EventArgs e)
        {
            var frm = new FormRanking();
            frm.Show();
        }
    }
}