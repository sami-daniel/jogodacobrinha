using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Cobrinha
{
    public partial class Form1 : Form
    {
        Game Game;
        public Form1()
        {
            InitializeComponent();
            Game = new Game(ref Frame, ref lblPoints, ref pnTela);
        }

        private void iniciarJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.StartGame();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frame_Tick(object sender, EventArgs e)
        {
            Game.Tick();
        }

        private void click(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                Game.ArrowKeys = e.KeyCode;
            }
        }
    }
}
