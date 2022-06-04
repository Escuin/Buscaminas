using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class FormGame : Form
    {
        private readonly string difficulty;
        private DateTime start;
        private int fieldCounter = 0;
        private int easyLives = 5;
        private int mediumLives = 3;
        private int hardLives = 1;
        public FormGame()
        {
            InitializeComponent();
            difficulty = "Modo fácil";
        }

        public FormGame(string diff)
        {
            InitializeComponent();
            difficulty = diff;
        }
        private List<Button> botones;

        private void FormGame_Load(object sender, EventArgs e)
        {
            timer1.Start();
            start = DateTime.Now;

            switch (difficulty)
            {
                case "Modo fácil":
                    int[] b = new int[13];
                    crearBotones(difficulty, b);
                    botones = crearBotones(difficulty, b);
                    lblTimer.ForeColor = Color.Green;
                    lblLives.Text = "VIDAS: 5";
                    MessageBox.Show(botones[0].Name);
                    break;

                case "Modo intermedio":
                    b = new int[16];
                    crearBotones(difficulty, b);
                    botones = crearBotones(difficulty, b);
                    lblTimer.ForeColor = Color.Orange;
                    lblLives.Text = "VIDAS: 3";
                    break;

                case "Modo difícil":
                    b = new int[19];
                    crearBotones(difficulty, b);
                    botones = crearBotones(difficulty, b);
                    lblTimer.ForeColor = Color.Red;
                    lblLives.Text = "VIDAS: 1";
                    break;

                default:
                    break;
            }
        }
        private List<Button> crearBotones(string difficulty, int[] b)
        {
            Random r = new Random();
            switch (difficulty)
            {
                case "Modo fácil":
                    int width = 30;
                    int height = 30;
                    int x = 5;
                    int y = 5;
                    int counter = 0;
                    List<Button> botones = new List<Button>();
                    int[] mines = new int[30];
                    for (int i = 0; i < 30; i++)
                    {
                        int aux = r.Next(0, 13 * 13);
                        while (mines.Contains(aux))
                        {
                            aux = r.Next(0, 13 * 13);
                        }
                        mines[i] = aux;
                    }

                    foreach (var v in b)
                    {
                        foreach (var s in b)
                        {
                            Button but = new Button();
                            but.Visible = true;
                            this.Controls.Add(but);
                            but.BackColor = Color.FromArgb(50, Color.LightGreen);
                            but.Size = new Size(width, height);
                            but.Location = new Point(x, y);
                            but.Name = counter.ToString();
                            counter++;
                            if (mines.Contains(int.Parse(but.Name)))
                            {
                                but.Name = "Mine"; but.Click += new EventHandler(mine_Click);
                            }
                            else
                            {
                                but.Name = "Field"; but.Click += new EventHandler(field_Click);
                            }
                            Controls.Add(but);
                            botones.Add(but);
                            x += 30;
                        }
                        x = 5;
                        y += 30;
                    }
                    int contador = 0;
                    foreach (Button btn in botones)
                    {
                        int minas = 0;
                        if (btn.Name == "Field")
                        {
                            minas = cuentaMinas(difficulty, botones, contador, minas);
                        }
                        btn.Tag = minas;
                        minas = 0;
                        contador++;
                    }
                    return botones;
                case "Modo intermedio":
                    width = 30;
                    height = 30;
                    x = 5;
                    y = 5;
                    counter = 0;
                    botones = new List<Button>();
                    mines = new int[45];
                    for (int i = 0; i < 45; i++)
                    {
                        int aux = r.Next(0, 16 * 16);
                        while (mines.Contains(aux))
                        {
                            aux = r.Next(0, 16 * 16);
                        }
                        mines[i] = aux;
                    }
                    foreach (var v in b)
                    {
                        foreach (var s in b)
                        {
                            Button but = new Button();
                            but.Visible = true;
                            this.Controls.Add(but);
                            but.BackColor = Color.FromArgb(50, Color.Orange);
                            but.Size = new Size(width, height);
                            but.Location = new Point(x, y);
                            but.Name = counter.ToString();
                            counter++;
                            if (mines.Contains(int.Parse(but.Name)))
                            {
                                but.Name = "Mine"; but.Click += new EventHandler(mine_Click);
                            }
                            else
                            {
                                but.Name = "Field"; but.Click += new EventHandler(field_Click);
                            }
                            Controls.Add(but);
                            botones.Add(but);
                            x += 30;
                        }
                        x = 5;
                        y += 30;
                    }
                    contador = 0;
                    foreach (Button btn in botones)
                    {
                        int minas = 0;
                        if (btn.Name == "Field")
                        {
                            minas = cuentaMinas(difficulty, botones, contador, minas);
                        }
                        btn.Tag = minas;
                        minas = 0;
                        contador++;
                    }
                    return botones;
                case "Modo difícil":
                    width = 30;
                    height = 30;
                    x = 5;
                    y = 5;
                    counter = 0;
                    botones = new List<Button>();
                    mines = new int[60];
                    for (int i = 0; i < 60; i++)
                    {
                        int aux = r.Next(0, 19 * 19);
                        while (mines.Contains(aux))
                        {
                            aux = r.Next(0, 19 * 19);
                        }
                        mines[i] = aux;
                    }
                    foreach (var v in b)
                    {
                        foreach (var s in b)
                        {
                            Button but = new Button();
                            but.Visible = true;
                            this.Controls.Add(but);
                            but.BackColor = Color.FromArgb(50, Color.Red);
                            but.Size = new Size(width, height);
                            but.Location = new Point(x, y);
                            but.Name = counter.ToString();
                            counter++;
                            if (mines.Contains(int.Parse(but.Name)))
                            {
                                but.Name = "Mine"; but.Click += new EventHandler(mine_Click);
                            }
                            else
                            {
                                but.Name = "Field"; but.Click += new EventHandler(field_Click);
                            }
                            Controls.Add(but);
                            botones.Add(but);
                            x += 30;
                        }
                        x = 5;
                        y += 30;
                    }
                    contador = 0;
                    foreach (Button btn in botones)
                    {
                        int minas = 0;
                        if (btn.Name == "Field")
                        {
                            minas = cuentaMinas(difficulty, botones, contador, minas);
                        }
                        btn.Tag = minas;
                        minas = 0;
                        contador++;
                    }
                    return botones;
                default:
                    MessageBox.Show("Error inesperado, no se han podido generar las casillas");
                    List<Button> error = new List<Button>();
                    return error;
            }
        }

        private static int cuentaMinas(string difficulty, List<Button> botones, int contador, int minas)
        {
            switch (difficulty)
            {
                case "Modo fácil":
                    if (contador > 0 && botones[contador - 1].Name.Contains("Mine") && (contador != 13 && contador != 26 && contador != 39 && contador != 52 && contador != 65 && contador != 78
                                                                                    && contador != 91 && contador != 104 && contador != 117 && contador != 130 && contador != 143 && contador != 156))
                    {
                        minas++;
                    }
                    if (contador < 168 && botones[contador + 1].Name.Contains("Mine") && (contador != 12 && contador != 25 && contador != 38 && contador != 51 && contador != 64 && contador != 77
                                                                                      && contador != 90 && contador != 103 && contador != 116 && contador != 129 && contador != 142 && contador != 155))
                    {
                        minas++;
                    }
                    if (contador >= 12 && botones[contador - 12].Name.Contains("Mine") && (contador != 12 && contador != 25 && contador != 38 && contador != 51 && contador != 64 && contador != 77
                                                                                       && contador != 90 && contador != 103 && contador != 116 && contador != 129 && contador != 142 && contador != 155))
                    {
                        minas++;
                    }
                    if (contador >= 13 && botones[contador - 13].Name.Contains("Mine"))
                    {
                        minas++;
                    }
                    if (contador >= 14 && botones[contador - 14].Name.Contains("Mine") && (contador != 26 && contador != 39 && contador != 52 && contador != 65 && contador != 78
                                                                                       && contador != 91 && contador != 104 && contador != 117 && contador != 130 && contador != 143 && contador != 156))
                    {
                        minas++;
                    }
                    if (contador <= 156 && botones[contador + 12].Name.Contains("Mine") && (contador != 0 && contador != 13 && contador != 26 && contador != 39 && contador != 52 && contador != 65 && contador != 78
                                                                                        && contador != 91 && contador != 104 && contador != 117 && contador != 130 && contador != 143 && contador != 156))
                    {
                        minas++;
                    }
                    if (contador <= 155 && botones[contador + 13].Name.Contains("Mine"))
                    {
                        minas++;
                    }
                    if (contador <= 154 && botones[contador + 14].Name.Contains("Mine") && (contador != 12 && contador != 25 && contador != 38 && contador != 51 && contador != 64 && contador != 77
                                                                                        && contador != 90 && contador != 103 && contador != 116 && contador != 129 && contador != 142 && contador != 155))
                    {
                        minas++;
                    }
                    return minas;
                case "Modo intermedio":
                    if (contador > 0 && botones[contador - 1].Name.Contains("Mine") && (contador != 16 && contador != 32 && contador != 48 && contador != 64 && contador != 80 && contador != 96
                                                                                    && contador != 112 && contador != 128 && contador != 144 && contador != 160 && contador != 176 && contador != 192
                                                                                    && contador != 208 && contador != 224 && contador != 240))
                    {
                        minas++;
                    }
                    if (contador < 255 && botones[contador + 1].Name.Contains("Mine") && (contador != 15 && contador != 31 && contador != 47 && contador != 63 && contador != 79 && contador != 95
                                                                                      && contador != 111 && contador != 127 && contador != 143 && contador != 159 && contador != 175 && contador != 191
                                                                                      && contador != 207 && contador != 223 && contador != 239))
                    {
                        minas++;
                    }
                    if (contador >= 15 && botones[contador - 15].Name.Contains("Mine") && (contador != 15 && contador != 31 && contador != 47 && contador != 63 && contador != 79 && contador != 95
                                                                                       && contador != 111 && contador != 127 && contador != 143 && contador != 159 && contador != 175 && contador != 191
                                                                                       && contador != 207 && contador != 223 && contador != 239))
                    {
                        minas++;
                    }
                    if (contador >= 16 && botones[contador - 16].Name.Contains("Mine"))
                    {
                        minas++;
                    }
                    if (contador >= 17 && botones[contador - 17].Name.Contains("Mine") && (contador != 32 && contador != 48 && contador != 64 && contador != 80 && contador != 96
                                                                                       && contador != 112 && contador != 128 && contador != 144 && contador != 160 && contador != 176 && contador != 192
                                                                                       && contador != 208 && contador != 224 && contador != 240))
                    {
                        minas++;
                    }
                    if (contador <= 240 && botones[contador + 15].Name.Contains("Mine") && (contador != 0 && contador != 16 && contador != 32 && contador != 48 && contador != 64 && contador != 80 && contador != 96
                                                                                        && contador != 112 && contador != 128 && contador != 144 && contador != 160 && contador != 176 && contador != 192
                                                                                        && contador != 208 && contador != 224 && contador != 240))
                    {
                        minas++;
                    }
                    if (contador <= 239 && botones[contador + 16].Name.Contains("Mine"))
                    {
                        minas++;
                    }
                    if (contador <= 238 && botones[contador + 17].Name.Contains("Mine") && (contador != 15 && contador != 31 && contador != 47 && contador != 63 && contador != 79 && contador != 95
                                                                                        && contador != 111 && contador != 127 && contador != 143 && contador != 159 && contador != 175 && contador != 191
                                                                                        && contador != 207 && contador != 223))
                    {
                        minas++;
                    }
                    return minas;
                case "Modo difícil":
                    if (contador > 0 && botones[contador - 1].Name.Contains("Mine") && (contador != 19 && contador != 38 && contador != 57 && contador != 76 && contador != 95 && contador != 114
                                                                                    && contador != 133 && contador != 152 && contador != 171 && contador != 190 && contador != 209 && contador != 228
                                                                                    && contador != 247 && contador != 266 && contador != 285 && contador != 304 && contador != 323 && contador != 342))
                    {
                        minas++;
                    }
                    if (contador < 360 && botones[contador + 1].Name.Contains("Mine") && (contador != 18 && contador != 37 && contador != 56 && contador != 75 && contador != 94 && contador != 113
                                                                                      && contador != 132 && contador != 151 && contador != 170 && contador != 181 && contador != 208 && contador != 227
                                                                                      && contador != 246 && contador != 265 && contador != 284 && contador != 303 && contador != 322 && contador != 341))
                    {
                        minas++;
                    }
                    if (contador >= 18 && botones[contador - 18].Name.Contains("Mine") && (contador != 18 && contador != 37 && contador != 56 && contador != 75 && contador != 94 && contador != 113
                                                                                       && contador != 132 && contador != 151 && contador != 170 && contador != 181 && contador != 208 && contador != 227
                                                                                       && contador != 246 && contador != 265 && contador != 284 && contador != 303 && contador != 322 && contador != 341))
                    {
                        minas++;
                    }
                    if (contador >= 19 && botones[contador - 19].Name.Contains("Mine"))
                    {
                        minas++;
                    }
                    if (contador >= 20 && botones[contador - 20].Name.Contains("Mine") && (contador != 38 && contador != 57 && contador != 76 && contador != 95 && contador != 114
                                                                                       && contador != 133 && contador != 152 && contador != 171 && contador != 190 && contador != 209 && contador != 228
                                                                                       && contador != 247 && contador != 266 && contador != 285 && contador != 304 && contador != 323 && contador != 342))
                    {
                        minas++;
                    }
                    if (contador <= 342 && botones[contador + 18].Name.Contains("Mine") && (contador != 0 && contador != 19 && contador != 38 && contador != 57 && contador != 76 && contador != 95 && contador != 114
                                                                                        && contador != 133 && contador != 152 && contador != 171 && contador != 190 && contador != 209 && contador != 228
                                                                                        && contador != 247 && contador != 266 && contador != 285 && contador != 304 && contador != 323 && contador != 342))
                    {
                        minas++;
                    }
                    if (contador <= 341 && botones[contador + 19].Name.Contains("Mine"))
                    {
                        minas++;
                    }
                    if (contador <= 340 && botones[contador + 20].Name.Contains("Mine") && (contador != 18 && contador != 37 && contador != 56 && contador != 75 && contador != 94 && contador != 113
                                                                                        && contador != 132 && contador != 151 && contador != 170 && contador != 181 && contador != 208 && contador != 227
                                                                                        && contador != 246 && contador != 265 && contador != 284 && contador != 303 && contador != 322))
                    {
                        minas++;
                    }
                    return minas;
                default:
                    MessageBox.Show("Error inesperado");
                    return minas;
            }

        }

        private void field_Click(object sender, EventArgs e)
        {
            fieldCounter++;
            Button field = (Button)sender;
            field.Image = Image.FromFile($@"{Directory.GetCurrentDirectory()}\images\number{field.Tag}.png");
            field.Enabled = false;
            switch (difficulty)
            {
                case "Modo fácil":
                    if (fieldCounter == ((13 * 13) - 30 - 1))
                    {
                        timer1.Stop();
                        MessageBox.Show("Felicidades has ganado");
                        string time = lblTimer.Text;
                        FormRanking frm = new FormRanking(time, difficulty);
                        frm.Show();
                    }
                    break;
                case "Modo intermedio":
                    if (fieldCounter == ((16 * 16) - 45 - 1))
                    {
                        timer1.Stop();
                        MessageBox.Show("Felicidades has ganado");
                        string time = lblTimer.Text;
                        FormRanking frm = new FormRanking(time, difficulty);
                        frm.Show();
                    }
                    break;
                case "Modo difícil":
                    if (fieldCounter == ((19 * 19) - 60 - 1))
                    {
                        timer1.Stop();
                        MessageBox.Show("Felicidades has ganado");
                        string time = lblTimer.Text;
                        FormRanking frm = new FormRanking(time, difficulty);
                        frm.Show();
                    }
                    break;
            }
        }

        private void mine_Click(object sender, EventArgs e)
        {
            Button mine = (Button)sender;
            mine.Image = Image.FromFile(@$"{Directory.GetCurrentDirectory()}\images\mina.png");
            mine.Enabled = false;
            switch (difficulty)
            {
                case "Modo fácil":
                    easyLives--;
                    if (easyLives == 0)
                    {
                        mine.Image = Image.FromFile(@$"{Directory.GetCurrentDirectory()}\images\mina.png");
                        lblLives.Text = $"VIDAS: {easyLives}";
                        timer1.Stop();
                        MessageBox.Show("¡Boom!, has perdido... Fin del juego");
                        //Close();
                    }
                    lblLives.Text = $"VIDAS: {easyLives}";
                    break;
                case "Modo intermedio":
                    mediumLives--;
                    if (mediumLives == 0)
                    {
                        mine.Image = Image.FromFile(@$"{Directory.GetCurrentDirectory()}\images\mina.png");
                        lblLives.Text = $"VIDAS: {mediumLives}";
                        timer1.Stop();
                        MessageBox.Show("¡Boom!, has perdido... Fin del juego");
                        //Close();
                    }
                    lblLives.Text = $"VIDAS: {mediumLives}";
                    break;
                case "Modo difícil":
                    hardLives--;
                    if (hardLives == 0)
                    {
                        mine.Image = Image.FromFile(@$"{Directory.GetCurrentDirectory()}\images\mina.png");
                        lblLives.Text = $"VIDAS: {hardLives}";
                        timer1.Stop();
                        MessageBox.Show("¡Boom!, has perdido... Fin del juego");
                        //Close();
                    }
                    lblLives.Text = $"VIDAS: {hardLives}";
                    break;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("¿Estás seguro de querer volver a la pantalla de título?", "Cerrar partida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var diff = DateTime.Now - start;
            lblTimer.Text = diff.ToString("hh':'mm':'ss");
        }
    }
}
