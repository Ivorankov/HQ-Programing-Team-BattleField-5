﻿namespace MineFieldApp
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class Engine
    {
        private static char[,] GameField { get; set; }

        public static void PrintField()
        {
            int size = Engine.GameField.GetLength(0);
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
                    Console.Write("{0} ", Engine.GameField[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void Start()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            Console.Write("Enter battle field size: n=");
            string input = Console.ReadLine();

            int size = 0;
            while (!int.TryParse(input, out size))
            {
                Console.WriteLine("Wrong format!");
                Console.Write("Enter battle field size: n=");
            }

            if (size < 1 || 10 < size)
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
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine();

            int explodedMinesCount = 0;
            while (Field.ContainsMines(Engine.GameField))
            {
                Engine.PrintField();

                string input;
                Mine mineToBlow;
                do
                {
                    Console.Write("Please enter coordinates: ");
                    input = Console.ReadLine();
                    mineToBlow = Mine.Parse(input);
                } while (mineToBlow == null);

                if (!Field.IsPositionMine(mineToBlow.X, mineToBlow.Y, Engine.GameField))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                Mine.Explode(mineToBlow, Engine.GameField);
                explodedMinesCount++;
            }

            Engine.PrintField();
            Console.WriteLine("Game over. Detonated mines: {0}", explodedMinesCount);
        }
    }
}