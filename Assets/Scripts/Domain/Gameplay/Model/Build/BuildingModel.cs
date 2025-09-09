using System.Collections.Generic;
using UnityEngine;
using Domain.Gameplay.Model.Grid; 

namespace Domain.Gameplay.Model.Build
{
    public class BuildingModel
    {
        public BuildingType Type { get; }
        
        public BuildingState State { get; set; }
        
        public int Level { get; set; }

        /// <summary>
        /// Клетки, которые занимает здание.
        /// </summary>
        public IReadOnlyList<GridCellModel> OccupiedCells { get; }
        public Vector3 WorldPosition { get; }

        /// <summary>
        /// Инициализация модели здания.
        /// </summary>
        /// <param name="type">Тип здания.</param>
        /// <param name="state">Состояние здания.</param>
        /// <param name="level">Уровень здания.</param>
        /// <param name="worldPosition">Позиция в мировых координатах.</param>
        /// <param name="occupiedCells">Список клеток, которые занимает здание.</param>
        public BuildingModel(
            BuildingType type,
            BuildingState state,
            int level,
            Vector3 worldPosition,
            List<GridCellModel> occupiedCells)
        {
            Type = type;
            State = state;
            Level = level;
            WorldPosition = worldPosition;
            OccupiedCells = occupiedCells.AsReadOnly();
        }
    }
}

