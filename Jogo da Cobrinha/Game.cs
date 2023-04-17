
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Cobrinha
{
    class Game
    {
        public Keys Direction { get; set; }
        public Keys ArrowKeys{ get; set; }

        private Timer frame {  get; set; }
        private Label lblPoints { get; set; }
        private Panel pnTela{ get; set; }

        private int pontos = 0;

        private Food Food;

        private Snake Snake;

        private Bitmap offScreenBitmap;

        private Graphics bitmapGraphics;

        private Graphics screenGraphics;

        public Game(ref Timer timer, ref Label label, ref Panel panel)

        {
            pnTela = panel;

            frame = timer;

            lblPoints = label;

            offScreenBitmap = new Bitmap(428, 428);

            Snake = new Snake();
            Food = new Food();
            Direction = Keys.Left;
            ArrowKeys = Direction;  
        }
        public void StartGame()
        {
            Snake.reset();
            Food.NewFood();
            Direction = Keys.Left;
            bitmapGraphics = Graphics.FromImage(offScreenBitmap);
            screenGraphics = pnTela.CreateGraphics();
            frame.Enabled = true;
            
        }
        public void Tick()
        {
           if (((ArrowKeys == Keys.Left)&&(Direction != Keys.Right)) ||
                ((ArrowKeys == Keys.Right) && (Direction != Keys.Left))||
                ((ArrowKeys == Keys.Up) && (Direction != Keys.Down))|| 
                ((ArrowKeys == Keys.Down) && (Direction != Keys.Up))){
                Direction = ArrowKeys;
            }
           switch(Direction)
            {
                case Keys.Left:
                    Snake.Left();break; 
                case Keys.Right: 
                    Snake.Right();break; 
                case Keys.Up:
                    Snake.Up();break; 
                case Keys.Down:
                    Snake.Down();break;
            }
            bitmapGraphics.Clear(Color.White);
            bitmapGraphics.DrawImage(Properties.Resources.image_removebg_preview__1_,(Food.location.X * 15),(Food.location.Y*15),15,15);
            bool gameover = false;

            for(int i = 0; i < Snake.length; i++)
            {
                if (i == 0)
                {
                    bitmapGraphics.FillRectangle(new SolidBrush(Color.Black), (Snake.location[i].X * 15), (Snake.location[i].Y * 15), 15, 15);
                }
                else
                {
                    bitmapGraphics.FillRectangle(new SolidBrush(Color.BlueViolet), (Snake.location[i].X * 15), (Snake.location[i].Y * 15), 15, 15);
                }
                if ((Snake.location[i] == Snake.location[0]) && (i > 0))
                {
                    gameover = true;
                }
                if ((Snake.location[0].Y < 0) || (Snake.location[0].Y > 27) || (Snake.location[0].X < 0) || (Snake.location[0].X > 27))
                {
                    gameover = true;
                }
            }
            screenGraphics.DrawImage(offScreenBitmap, 0, 0);
            CheckCollision();
            if (gameover)
            {
                Gameover();
            }
        }
        public void Gameover()
        {
            frame.Enabled = false;
            bitmapGraphics.Dispose();
            screenGraphics.Dispose();
            lblPoints.Text = "Pontuação: 0";
            MessageBox.Show("Game Over");
        }
        public void CheckCollision()
        {
            if (Snake.location[0] == Food.location)
            {
                Snake.eat();
                Food.NewFood();
                pontos += 1;
                lblPoints.Text = "Pontuação: " + pontos;
                
            }
        }
    }
}
