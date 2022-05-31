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
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Visible = true;
            this.Controls.Add(b);
            b.Size = new Size(30, 30);
            b.Location = new Point(5, 5);
        }
    }
}
