namespace MineFieldApp.Mines.Generators
{
    using System;

    public class RandomMineGenerator : IMineGenerator
    {
        public Mine Generate(Position position)
        {
            int randomNumber = Helper.Randomizer.Next(5);

            switch (randomNumber)
            {
                case 0:
                    return new TinyMine(position);
                case 1:
                    return new SmallMine(position);
                case 2:
                    return new MediumMine(position);
                case 3:
                    return new BigMine(position);
                case 4:
                    return new GiantMine(position);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}