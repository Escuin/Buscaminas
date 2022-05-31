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

                    int width = 30;
                    int height = 30;
                    int x = 5;
                    int y = 5;

                    int[] b = new int[16];

                    foreach (var v in b)
                    {
                        foreach (var s in b)
                        {
                            Button but = new Button();
                            but.Visible = true;
                            this.Controls.Add(but);
                            but.Size = new Size(width, height);
                            but.Location = new Point(x, y);
                            x += 30;
                        }
                        x = 5;
                        y += 30;
                    }

                    break;
                case "Modo intermedio":
                    break;
                case "Modo difícil":
                    break;
                default:
                    break;
            }
        }
    }
}
