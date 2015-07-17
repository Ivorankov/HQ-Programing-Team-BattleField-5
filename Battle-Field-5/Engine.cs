namespace MineFieldApp
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class Engine
    {
        private static char[,] GameField { get; set; }

        public static void PrintResult()
        {
            Console.Write("   ");
            int size = Engine.GameField.GetLength(0);
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
                    Console.Write("{0} ", Engine.GameField[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void Start()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            int size = 0;
            string readBuffer = null;
            Console.Write("Enter battle field size: n=");
            readBuffer = Console.ReadLine();
            while (!int.TryParse(readBuffer, out size))
            {
                Console.WriteLine("Wrong format!");
                Console.Write("Enter battle field size: n=");
            }

            if (size > 10 || size <= 0)
            {
                Engine.Start();
            }
            else
            {
                Engine.GameField = Field.GenerateField(size);
                Engine.BeginGame();
            }
        }

        private static void BeginGame()
        {
            string readBuffer = null;
            int explodedMinesCount = 0;
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine();
            while (Field.ContainsMines(Engine.GameField))
            {
                Engine.PrintResult();
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                Mine mineToBlow = Mine.Parse(readBuffer);

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = Mine.Parse(readBuffer);
                }

                if (!Field.IsPositionMine(mineToBlow.X, mineToBlow.Y, Engine.GameField))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                Mine.Explode(mineToBlow, Engine.GameField);
                explodedMinesCount++;
            }

            Engine.PrintResult();
            Console.WriteLine("Game over. Detonated mines: {0}", explodedMinesCount);
        }
    }
}