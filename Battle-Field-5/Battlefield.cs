namespace BattleField
{
    using System;

   public class Battlefield
    {
        public Battlefield()
        {
            this.GameField = null;
        }

        public char[,] GameField { get; private set; }

        public void Start()
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
                this.Start();
            }
            else
            {
                this.GameField = GameServices.GenerateField(size);
                this.StartInteraction();
            }
        }

        private void StartInteraction()
        {
            string readBuffer = null;
            int explodedMinesCount = 0;
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine();
            while (GameServices.ContainsMines(this.GameField))
            {
                GameServices.PrintResult(this.GameField);
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                Mine mineToBlow = GameServices.ExtractMineFromString(readBuffer);

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                }

                if (!GameServices.IsValidMove(this.GameField, mineToBlow.X, mineToBlow.Y))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                GameServices.Explode(this.GameField, mineToBlow);
                explodedMinesCount++;
            }

            GameServices.PrintResult(this.GameField);
            Console.WriteLine("Game over. Detonated mines: {0}", explodedMinesCount);
        }
    }
}
