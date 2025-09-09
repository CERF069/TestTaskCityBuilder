using UnityEngine;
namespace Infrastructure.Repositories
{
    /// <summary>
    /// Конфигурация сетки (на которой будут размещаться здания).
    /// </summary>
    [CreateAssetMenu(fileName = "GridConfigRepository",
        menuName = "Config/Grid Config Repository")]
    public class GridRepository : ScriptableObject
    {
        [Header("Size")] 
        [field: SerializeField, Min(1)]
        public int Width { get; private set; } = 32;

        [field: SerializeField, Min(1)]
        public int Height { get; private set; } = 32;
        
        [field: SerializeField, Min(1)] 
        public float CellSize { get; set; }
    }
}
