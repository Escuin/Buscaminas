using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public FormGame()
        {
            InitializeComponent();
        }

        public FormGame(string diff)
        {
            InitializeComponent();
            difficulty = diff;
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            switch (difficulty)
            {
                case "Modo fácil":
                    int[] b = new int[14]; //14*14 = 196 casillas
                    crearBotones(difficulty, b);
                    break;

                case "Modo intermedio":
                    b = new int[17]; //17*17 = 289 casillas
                    crearBotones(difficulty, b);
                    break;

                case "Modo difícil":
                    b = new int[20]; //20*20 = 400 casillas
                    crearBotones(difficulty, b);
                    break;

                default:
                    break;
            }
        }

        private List<Button> crearBotones(string difficulty, int[] b)
        {
            switch (difficulty)
            {
                case "Modo fácil":
                    int width = 30;
                    int height = 30;
                    int x = 95;
                    int y = 50;
                    List<Button> botones = new List<Button>();
                    foreach (var v in b)
                    {
                        foreach (var s in b)
                        {
                            Button but = new Button();
                            but.Visible = true;
                            this.Controls.Add(but);
                            but.BackColor = Color.LightCyan;
                            but.Size = new Size(width, height);
                            but.Location = new Point(x, y);
                            botones.Add(but);
                            x += 30;
                        }
                        x = 95;
                        y += 30;
                    }
                    return botones;
                case "Modo intermedio":
                    width = 30;
                    height = 30;
                    x = 50;
                    y = 50;
                    botones = new List<Button>();
                    foreach (var v in b)
                    {
                        foreach (var s in b)
                        {
                            Button but = new Button();
                            but.Visible = true;
                            this.Controls.Add(but);
                            but.BackColor = Color.LightCyan;
                            but.Size = new Size(width, height);
                            but.Location = new Point(x, y);
                            botones.Add(but);
                            x += 30;
                        }
                        x = 50;
                        y += 30;
                    }
                    return botones;
                case "Modo difícil":
                    width = 30;
                    height = 30;
                    x = 5;
                    y = 5;
                    botones = new List<Button>();
                    foreach (var v in b)
                    {
                        foreach (var s in b)
                        {
                            Button but = new Button();
                            but.Visible = true;
                            this.Controls.Add(but);
                            but.BackColor = Color.LightCyan;
                            but.Size = new Size(width, height);
                            but.Location = new Point(x, y);
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
    }
}
