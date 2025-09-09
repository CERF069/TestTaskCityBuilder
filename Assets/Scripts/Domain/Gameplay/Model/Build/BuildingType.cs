namespace Domain.Gameplay.Model.Build
{
    /// <summary>
    /// Перечисление, представляющее типы зданий в игре.
    /// </summary>
    public enum BuildingType
    {
        /// <summary>
        /// Жилой дом — базовое здание, в котором живут жители.
        /// </summary>
        House,

        /// <summary>
        /// Ферма — производит еду или ресурсы для населения.
        /// </summary>
        Farm,

        /// <summary>
        /// Шахта — добывает золото или другие ресурсы.
        /// </summary>
        Mine
    }
}
