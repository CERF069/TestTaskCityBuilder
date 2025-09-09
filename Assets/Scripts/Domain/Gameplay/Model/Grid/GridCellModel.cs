using UnityEngine;

namespace Domain.Gameplay.Model.Grid
{
    public class GridCellModel
    {
        public int X { get; }
        
        public int Y { get; }
        
        public GridCellState State { get; set; }
        public Vector3 WorldPosition { get; set; }

        /// <summary>Инициализация клетки</summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public GridCellModel(int x, int y)
        {
            X = x;
            Y = y;
            State = GridCellState.Empty;
        }
    }
}
