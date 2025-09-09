namespace Domain.Gameplay.Model.Build
{
    /// <summary>
    /// Перечисление, описывающее текущее состояние здания.
    /// </summary>
    public enum BuildingState
    {
        /// <summary>
        /// Здание размещено, но еще не построено.
        /// </summary>
        Placed = 0,

        /// <summary>
        /// Здание находится в процессе строительства.
        /// </summary>
        UnderConstruction = 1,

        /// <summary>
        /// Здание полностью построено и работает.
        /// </summary>
        Active = 2,

        /// <summary>
        /// Здание повреждено и требует ремонта.
        /// </summary>
        Damaged = 3,

        /// <summary>
        /// Здание разрушено.
        /// </summary>
        Destroyed = 4
    }
}
