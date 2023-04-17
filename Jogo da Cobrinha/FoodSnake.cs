using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Cobrinha
{
    //partes referente a cobra e a comida
    
    
        class Food
        {
            //gerador da posição de nascimento da comida aleatoriamente
            public Point location { get; private set; }
            public void NewFood()
            {
                Random random = new Random();
                location = new Point(random.Next(0, 27), random.Next(0, 27));
            }

        }
    
    
        class Snake
        {
            //metodo referente ao tamanho
            public int length { get; private set; }
            //metodo referente a localização da cobrinha
            public Point[] location { get; private set; }
            //Local utilizavel
            public Snake()
            {
                location = new Point[28*28];

            }
            //metodo inicial para a cobrinha, tamanho e posicao inicial
            public void reset()
            {
                length = 2;
                for (int i = 0; i < length; i++)
                {
                    location[i].X = 12;
                    location[i].Y = 12;
                }
            }
            //metodo para fazer o corpo da cobrinha seguir e ocupar a posicao anterior do ultimo corpo
            public void follow()
            {
                for (int i = length - 1; i > 0; i--)
                {
                    location[i] = location[i - 1];
                }
            }
            //metodo para fazer a cobra andar para cima
            public void Up()
            {
                follow();
                location[0].Y--;
                if (location[0].Y < 0)
                {

                }
            }
            //metodo para fazer a cobra andar para baixo
            public void Down()
            {
                follow();
                location[0].Y++;
                if (location[0].Y > 27)
                {

                }
            }
            //metodo para fazer a cobra andar para a esquerda
            public void Left()
            {
                follow();
                location[0].X--;
                if (location[0].X < 0)
                {

                }
            }
            //metodo para fazer a cobra andar para a direita
            public void Right()
            {
                follow();
                location[0].X++;
                if (location[0].X > 27)
                {

                }
            }
            //metodo para se a cobrinha comer aumentar 1 em tamanho
            public void eat()
            {
                length++;
            }
        }
    }
    

