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
        public FormGame()
        {
            InitializeComponent();
            difficulty = "";
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
                    break;

                case "Modo intermedio":
                    b = new int[16];
                    crearBotones(difficulty, b);
                    botones = crearBotones(difficulty, b);
                    lblTimer.ForeColor = Color.Orange;
                    break;

                case "Modo difícil":
                    b = new int[19];
                    crearBotones(difficulty, b);
                    botones = crearBotones(difficulty, b);
                    lblTimer.ForeColor = Color.Red;
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
                            minas = cuentaMinas(botones, contador, minas);
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
                    return botones;
                default:
                    MessageBox.Show("Error inesperado, no se han podido generar las casillas");
                    List<Button> error = new List<Button>();
                    return error;
            }
        }

        private static int cuentaMinas(List<Button> botones, int contador, int minas)
        {
            if (contador > 0 && botones[contador - 1].Name.Contains("Mine"))
            {
                minas++;
            }
            if (contador < 168 && botones[contador + 1].Name.Contains("Mine"))
            {
                minas++;
            }
            if (contador >= 12 && botones[contador - 12].Name.Contains("Mine"))
            {
                minas++;
            }
            if (contador >= 13 && botones[contador - 13].Name.Contains("Mine"))
            {
                minas++;
            }
            if (contador >= 14 && botones[contador - 14].Name.Contains("Mine"))
            {
                minas++;
            }
            if (contador <= 156 && botones[contador + 12].Name.Contains("Mine"))
            {
                minas++;
            }
            if (contador <= 155 && botones[contador + 13].Name.Contains("Mine"))
            {
                minas++;
            }
            if (contador <= 154 && botones[contador + 14].Name.Contains("Mine"))
            {
                minas++;
            }
            return minas;
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
                    if (fieldCounter == 13 * 13 - 30)
                    {
                        timer1.Stop();
                        MessageBox.Show("Felicidades has ganado");
                        string time = lblTimer.Text;
                        FormRanking frm = new FormRanking(time, difficulty);
                        frm.Show();
                    }
                    break;
                case "Modo intermedio":
                    if (fieldCounter == 16 * 16 - 45)
                    {
                        timer1.Stop();
                        MessageBox.Show("Felicidades has ganado");
                        string time = lblTimer.Text;
                        FormRanking frm = new FormRanking(time, difficulty);
                        frm.Show();
                    }
                    break;
                case "Modo difícil":
                    if (fieldCounter == 19 * 19 - 60)
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
            timer1.Stop();
            MessageBox.Show("¡Boom!, has perdido... Fin del juego");
            Close();
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
