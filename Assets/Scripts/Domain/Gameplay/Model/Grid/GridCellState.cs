namespace Domain.Gameplay.Model.Grid
{
    /// <summary>
    /// Перечисление, представляющее текущее состояние клетки сетки
    /// </summary>
    public enum GridCellState
    {
        /// <summary>
        /// Клетка пуста, на неё можно ставить объекты
        /// </summary>
        Empty = 0,

        /// <summary>
        /// Клетка занята объектом
        /// </summary>
        Occupied = 1,
    }
}
