namespace MineFieldApp
{
    using System;

    public class Mine
    {
        public int X { get; set; }

        public int Y { get; set; }

        public static Mine Parse(string str)
        {
            if (str == null || str.Length < 3 || !str.Contains(" "))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            string[] splitString = str.Split(' ');

            int x;
            if (!int.TryParse(splitString[0], out x))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            int y;
            if (!int.TryParse(splitString[1], out y))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            return new Mine() { X = x, Y = y };
        }

        public static void Explode(Mine mine, char[,] field)
        {
            char mineType = field[mine.X, mine.Y];

            switch (mineType)
            {
                case '1':
                    Mine.ExplodeOne(mine, field);
                    break;
                case '2':
                    Mine.ExplodeTwo(mine, field);
                    break;
                case '3':
                    Mine.ExplodeThree(mine, field);
                    break;
                case '4':
                    Mine.ExplodeFour(mine, field);
                    break;
                case '5':
                    Mine.ExplodeFive(mine, field);
                    break;
            }
        }

        private static void ExplodeOne(Mine mine, char[,] field)
        {
            Mine upRightCorner = new Mine() { X = mine.X - 1, Y = mine.Y - 1 };
            Mine upLeftCorner = new Mine() { X = mine.X - 1, Y = mine.Y + 1 };
            Mine downRightCorner = new Mine() { X = mine.X + 1, Y = mine.Y - 1 };
            Mine downLeftCorner = new Mine() { X = mine.X + 1, Y = mine.Y + 1 };

            if (Helper.CheckIfInRange(field, mine.X, mine.Y))
            {
                field[mine.X, mine.Y] = 'X';
            }

            if (Helper.CheckIfInRange(field, upRightCorner.X, upRightCorner.Y))
            {
                field[upRightCorner.X, upRightCorner.Y] = 'X';
            }

            if (Helper.CheckIfInRange(field, upLeftCorner.X, upLeftCorner.Y))
            {
                field[upLeftCorner.X, upLeftCorner.Y] = 'X';
            }

            if (Helper.CheckIfInRange(field, downRightCorner.X, downRightCorner.Y))
            {
                field[downRightCorner.X, downRightCorner.Y] = 'X';
            }

            if (Helper.CheckIfInRange(field, downLeftCorner.X, downLeftCorner.Y))
            {
                field[downLeftCorner.X, downLeftCorner.Y] = 'X';
            }
        }

        private static void ExplodeTwo(Mine mine, char[,] field)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j++)
                {
                    if (Helper.CheckIfInRange(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }

        private static void ExplodeThree(Mine mine, char[,] field)
        {
            ExplodeTwo(mine, field);

            Mine up = new Mine() { X = mine.X - 2, Y = mine.Y };
            Mine down = new Mine() { X = mine.X + 2, Y = mine.Y };
            Mine left = new Mine() { X = mine.X, Y = mine.Y - 2 };
            Mine right = new Mine() { X = mine.X, Y = mine.Y + 2 };

            if (Helper.CheckIfInRange(field, up.X, up.Y))
            {
                field[up.X, up.Y] = 'X';
            }

            if (Helper.CheckIfInRange(field, down.X, down.Y))
            {
                field[down.X, down.Y] = 'X';
            }

            if (Helper.CheckIfInRange(field, left.X, left.Y))
            {
                field[left.X, left.Y] = 'X';
            }

            if (Helper.CheckIfInRange(field, right.X, right.Y))
            {
                field[right.X, right.Y] = 'X';
            }
        }

        private static void ExplodeFour(Mine mine, char[,] field)
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

                    if (Helper.CheckIfInRange(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }

        private static void ExplodeFive(Mine mine, char[,] field)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (Helper.CheckIfInRange(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }
    }
}