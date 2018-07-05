using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class Form1 : Form
    {
        // Constants
        const int BLACK = 1;
        const int WHITE = -1;
        const int NOTHING = 0;

        public Form1()
        {
            InitializeComponent();

            // Initialize a game.
            Board[3, 3] = WHITE;
            Board[4, 4] = WHITE;
            Board[3, 4] = BLACK;
            Board[4, 3] = BLACK;
        }
        
        int[,] Board = new int[8, 8];

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Initialize variables.
            int w = this.panel1.Width / 8;
            int h = this.panel1.Height / 8;

            // Clear screen.
            e.Graphics.Clear(Color.White);

            // Draw lines.
            int x = 0, y = 0;
            for (int i = 0; i < 7; i++)
            {
                x += w;
                y += h;
                e.Graphics.DrawLine(
                    Pens.Black, x, 0, x, this.panel1.Height);
                e.Graphics.DrawLine(
                    Pens.Black, 0, y, this.panel1.Width, y);
            }

            // Draw stone.
            x = 0; y = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (Board[i, k] == BLACK)
                    {
                        e.Graphics.FillPie(
                            Brushes.Black, w * i, h * k, w, h, 0, 360);
                    }
                    if (Board[i, k] == WHITE)
                    {
                        e.Graphics.DrawPie(
                            Pens.Black, w * i, h * k, w, h, 0, 360);
                    }
                }
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // Initialize variales.
            int w = this.panel1.Width / 8;
            int h = this.panel1.Height / 8;

            // Calculate location in board.
            int x = this.Location.X / w;
            int y = this.Location.Y / h;
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            // Redraw game screen.
            this.Refresh();
        }
    }
}
