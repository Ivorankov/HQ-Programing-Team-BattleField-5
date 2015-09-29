namespace MineFieldApp.RNGs
{
    using System.Collections.Generic;

    public interface IRandomGenerator
    {
        int GetRandomIndex();

        int GetRandomBetween(int minValue, int maxValue);

        HashSet<Position> GetUniquePointsBetween(int count, Position first, Position second);
    }
}