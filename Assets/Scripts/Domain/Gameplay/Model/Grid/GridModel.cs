using UnityEngine;

namespace Domain.Gameplay.Model.Grid
{
    public class GridModel
    {
        public int Width { get; }
        public int Height { get; }
        
        public float CellSize { get; }
        public GridCellModel[,] Cells { get; }
        
        public GridModel(int width, int height, float cellSize = 4f)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            Cells = new GridCellModel[width, height];
        }

        public GridCellModel GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return Cells[x, y];
        }
        
        public GridCellModel GetCellFromWorldPosition(Vector3 worldPos, Vector3 gridOrigin)
        {
            int x = Mathf.FloorToInt((worldPos.x - gridOrigin.x) / CellSize);
            int y = Mathf.FloorToInt((worldPos.z - gridOrigin.z) / CellSize);
            return GetCell(x, y);
        }
    }
}
