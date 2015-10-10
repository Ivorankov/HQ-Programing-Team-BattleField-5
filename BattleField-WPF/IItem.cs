namespace BattleField_WPF
{
    using System.Windows.Media;

    public interface IItem
    {
        ImageBrush GetBrush(int index);
    }
}
