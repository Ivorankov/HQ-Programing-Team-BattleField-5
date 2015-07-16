namespace BattleField
{
    using System;
    using System.Collections.Generic;

    public class GameServices
    {
        private const double MinMineCount = 0.15;
        private const double MaxMineCount = 0.3;
        private static readonly Random Rand = new Random();

        public static char[,] GenerateField(int size)
        {
            char[,] field = new char[size, size];
            int minesCount = DetermineMineCount(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<Mine> mines = new List<Mine>();
            for (int i = 0; i < minesCount; i++)
            {
                int mineX = Rand.Next(0, size);
                int mineY = Rand.Next(0, size);
                Mine newMine = new Mine() { X = mineX, Y = mineY };

                if (GameServices.Contains(mines, newMine))
                {
                    i--;
                    continue;
                }

                int mineType = Rand.Next('1', '6');
                field[mineX, mineY] = Convert.ToChar(mineType);
            }

            return field;
        }

        public static bool ContainsMines(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != '-' && field[i, j] != 'X')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsValidMove(char[,] field, int x, int y)
        {
            if (!CheckIfInRange(field, x, y))
            {
                return false;
            }
            else if (field[x, y] == 'X' || field[x, y] == '-')
            {
                return false;
            }

            return true;
        }

        public static void Explode(char[,] field, Mine mine)
        {
            char mineType = field[mine.X, mine.Y];

            switch (mineType)
            {
                case '1':
                    {
                        ExplodeOne(field, mine);
                    }

                    break;
                case '2':
                    {
                        ExplodeTwo(field, mine);
                    }

                    break;
                case '3':
                    {
                        ExplodeThree(field, mine);
                    }

                    break;
                case '4':
                    {
                        ExplodeFour(field, mine);
                    }

                    break;
                case '5':
                    {
                        ExplodeFive(field, mine);
                    }

                    break;
            }
        }

        public static void PrintResult(char[,] field)
        {
            Console.Write("   ");
            int size = field.GetLength(0);
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

        public static Mine ExtractMineFromString(string line)
        {
            if (line == null || line.Length < 3 || !line.Contains(" "))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            string[] splited = line.Split(' ');

            int x = 0;
            int y = 0;

            if (!int.TryParse(splited[0], out x))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            if (!int.TryParse(splited[1], out y))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            return new Mine() { X = x, Y = y };
        }

        private static int DetermineMineCount(int size)
        {
            double fields = (double)size * size;
            int lowBound = (int)(MinMineCount * fields);
            int upperBound = (int)(MaxMineCount * fields);

            return Rand.Next(lowBound, upperBound);
        }

        private static bool Contains(List<Mine> list, Mine mine)
        {
            foreach (Mine mina in list)
            {
                if (mina.X == mine.X && mina.Y == mine.Y)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckIfInRange(char[,] field, int x, int y)
        {
            if (x < 0 || y < 0 || x >= field.GetLength(0) || y >= field.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static void ExplodeOne(char[,] field, Mine mine)
        {
            Mine upRightCorner = new Mine() { X = mine.X - 1, Y = mine.Y - 1 };
            Mine upLeftCorner = new Mine() { X = mine.X - 1, Y = mine.Y + 1 };
            Mine downRightCorner = new Mine() { X = mine.X + 1, Y = mine.Y - 1 };
            Mine downLeftCorner = new Mine() { X = mine.X + 1, Y = mine.Y + 1 };

            if (CheckIfInRange(field, mine.X, mine.Y))
            {
                field[mine.X, mine.Y] = 'X';
            }

            if (CheckIfInRange(field, upRightCorner.X, upRightCorner.Y))
            {
                field[upRightCorner.X, upRightCorner.Y] = 'X';
            }

            if (CheckIfInRange(field, upLeftCorner.X, upLeftCorner.Y))
            {
                field[upLeftCorner.X, upLeftCorner.Y] = 'X';
            }

            if (CheckIfInRange(field, downRightCorner.X, downRightCorner.Y))
            {
                field[downRightCorner.X, downRightCorner.Y] = 'X';
            }

            if (CheckIfInRange(field, downLeftCorner.X, downLeftCorner.Y))
            {
                field[downLeftCorner.X, downLeftCorner.Y] = 'X';
            }
        }

        private static void ExplodeTwo(char[,] field, Mine mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j++)
                {
                    if (CheckIfInRange(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }

        private static void ExplodeThree(char[,] field, Mine mine)
        {
            ExplodeTwo(field, mine);
            Mine up = new Mine() { X = mine.X - 2, Y = mine.Y };
            Mine down = new Mine() { X = mine.X + 2, Y = mine.Y };
            Mine left = new Mine() { X = mine.X, Y = mine.Y - 2 };
            Mine right = new Mine() { X = mine.X, Y = mine.Y + 2 };

            if (CheckIfInRange(field, up.X, up.Y))
            {
                field[up.X, up.Y] = 'X';
            }

            if (CheckIfInRange(field, down.X, down.Y))
            {
                field[down.X, down.Y] = 'X';
            }

            if (CheckIfInRange(field, left.X, left.Y))
            {
                field[left.X, left.Y] = 'X';
            }

            if (CheckIfInRange(field, right.X, right.Y))
            {
                field[right.X, right.Y] = 'X';
            }
        }

        private static void ExplodeFour(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    bool upRight = i == mine.X - 2 && j == mine.Y - 2;
                    bool upLeft = i == mine.X - 2 && j == mine.Y + 2;
                    bool downRight = i == mine.X + 2 && j == mine.Y - 2;
                    bool downLeft = i == mine.X + 2 && j == mine.Y + 2;

                    if (upRight)
                    {
                        continue;
                    }
                    else if (upLeft)
                    {
                        continue;
                    }
                    else if (downRight)
                    {
                        continue;
                    }
                    else if (downLeft)
                    {
                        continue;
                    }

                    if (CheckIfInRange(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }

        private static void ExplodeFive(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (CheckIfInRange(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }
    }
}
