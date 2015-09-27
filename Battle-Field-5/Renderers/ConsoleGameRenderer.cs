using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    class ConsoleGameRenderer : IGameRenderer
    {
        private int fieldSize;

        public ConsoleGameRenderer()
        {

        }

        public int FieldWidth
        {
            get { throw new NotImplementedException(); }
            private set { }
        }

        public int FieldHeight
        {
            get { throw new NotImplementedException(); }
            private set { }
        }

        public void ShowStartScreen()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            Console.Write("Enter battle field size: n=");
        }

        public void ShowEndScreen()
        {
            Console.WriteLine("God damn this game is boring!");
        }

        public void DrawGameField(int size, char[,] field)
        {
            Console.Write("   ");
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < size * 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} |", i);
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", field[i, j]);
                }

                Console.WriteLine();
            }

        }

        public int FieldSize
        {
            get
            {
                return this.fieldSize;
            }
            set
            {
                this.fieldSize = value;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
