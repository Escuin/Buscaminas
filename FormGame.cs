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
                    return botones;
                case "Modo intermedio":
                    width = 30;
                    height = 30;
                    x = 5;
                    y = 5;
                    counter = 0;
                    botones = new List<Button>();
                    mines = new int[45];
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

        private void field_Click(object sender, EventArgs e)
        {
            Button field = (Button)sender;
        }

        private void mine_Click(object sender, EventArgs e)
        {
            Button mine = (Button)sender;
            mine.Image = Image.FromFile(@$"{Directory.GetCurrentDirectory()}\images\mina.png");
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
