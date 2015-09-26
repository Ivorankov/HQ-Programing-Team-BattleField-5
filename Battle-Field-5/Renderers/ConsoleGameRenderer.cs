using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineFieldApp
{
    class ConsoleGameRenderer : IGameRenderer
    {

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

        public void DrawGameFiled(int height, int width)
        {
            this.FieldHeight = height;
            this.FieldWidth = width;

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void DrawGameField()
        {
            throw new NotImplementedException();
        }

    }
}
