namespace BattleField.Enums
{
    public enum CellType
    {
        EMPTY = 0,
        BOMBED = 1,
        MINE = 2,
        GIANTMINE = (1 << 2) | MINE,
        HUGEMINE = (2 << 2) | MINE,
        BIGMINE = (3 << 2) | MINE,
        SMALLMINE = (4 << 2) | MINE,
        TINYMINE = (5 << 2) | MINE,
    }
}
