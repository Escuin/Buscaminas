namespace Buscaminas
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botón de jugar: inicia la partida tras haber elegido una dificultad
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            switch (cboDifficulty.Text)
            {
                case "Modo fácil":
                    var frm = new FormGame("Modo fácil");
                    frm.Show();
                    break;
                case "Modo intermedio":
                    frm = new FormGame("Modo intermedio");
                    frm.Show();
                    break;
                case "Modo difícil":
                    frm = new FormGame("Modo difícil");
                    frm.Show();
                    break;
                default:
                    MessageBox.Show("No se puede jugar sin seleccionar una dificultad");
                    break;
            };
        }

        /// <summary>
        /// Botón de salir: cierra el juego tras un mensaje de confirmación
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de querer cerrar el juego?", "Cerrar juego", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Combo box de dificultad: despliega las dificultades y cambia el color del título según la elección
        /// </summary>
        private void cboDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboDifficulty.Text)
            {
                case "Modo fácil":
                    lblTitle.ForeColor = Color.Green;
                    break;
                case "Modo intermedio":
                    lblTitle.ForeColor = Color.Orange;
                    break;
                case "Modo difícil":
                    lblTitle.ForeColor = Color.Red;
                    break;
                default:
                    break;
            };
        }

        /// <summary>
        /// Botón de ranking: abre un formulario que se conecta a la base de datos y muestra los tiempos registrados y su dificultad
        /// </summary>
        private void btnRanking_Click(object sender, EventArgs e)
        {
            var frm = new FormRanking();
            frm.Show();
        }
    }
}