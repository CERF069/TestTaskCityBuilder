using UnityEngine;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Конфигурация визуализации подсветки клетки.
    /// </summary>
    [CreateAssetMenu(fileName = "CellHighlightConfigRepository", menuName = "Config/Cell Highlight Config Repository")]
    public class CellHighlightConfigRepository : ScriptableObject
    {
        [Header("Movement")]
        [Tooltip("Скорость следования объекта подсветки")]
        [SerializeField, Min(10f)] private float moveSpeed = 25f;
        public float MoveSpeed => moveSpeed;

        [Header("Sprites")]
        [Tooltip("Спрайт для объекта подсветки")]
        [SerializeField] private Sprite highlightSprite;
        public Sprite HighlightSprite => highlightSprite;

        [Header("Colors")]
        [Tooltip("Цвет для свободной клетки")]
        [SerializeField] private Color emptyCellColor = Color.green;
        public Color EmptyCellColor => emptyCellColor;

        [Tooltip("Цвет для занятой клетки")]
        [SerializeField] private Color occupiedCellColor = Color.red;
        public Color OccupiedCellColor => occupiedCellColor;
    }
}
