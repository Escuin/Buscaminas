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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

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
    }
}