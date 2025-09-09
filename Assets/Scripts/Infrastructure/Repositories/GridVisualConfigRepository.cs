using UnityEngine;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Конфигурация визуальной сетки.
    /// </summary>
    [CreateAssetMenu(fileName = "GridVisualConfigRepository", menuName = "Config/Grid Visual Config Repository")]
    public class GridVisualConfigRepository : ScriptableObject
    {
        [Header("Line Appearance")]
        [field: SerializeField] public Color LineColor { get; private set; } = Color.green;
        [field: SerializeField, Range(0.07f, 0.5f)] public float LineWidth { get; private set; } = 0.05f;
    }
}
