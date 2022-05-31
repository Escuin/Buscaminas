namespace Buscaminas
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            switch (cboDifficulty.Text)
            {
                case "Modo fácil":
                    var frm = new FormGame();
                    frm.Show();
                    break;
                case "Modo intermedio":
                    break;
                case "Modo difícil":
                    break;
                default:
                    MessageBox.Show("No se puede jugar sin seleccionar una dificultad");
                    break;
            };
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}