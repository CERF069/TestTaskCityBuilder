using ContractsInterfaces.UseCasesApplication;
using Domain.Gameplay.Model.Grid;
using UnityEngine;

namespace UseCase.Gameplay.Factories
{
    public class GridFactory : IGridFactory
    {
        public GridModel CreateGrid(int width, int height, float cellSize)
        {
            GridModel grid = new GridModel(width, height, cellSize);
            Vector3 origin = Vector3.zero;

            // Смещение для того, чтобы сетка была от центра
            float offsetX = -(width - 1) * cellSize * 0.5f;
            float offsetZ = -(height - 1) * cellSize * 0.5f;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    GridCellModel cell = new GridCellModel(x, y);
                    cell.WorldPosition = new Vector3(
                        origin.x + offsetX + x * cellSize,
                        origin.y,
                        origin.z + offsetZ + y * cellSize
                    );
                    grid.Cells[x, y] = cell;
                }
            }

            Debug.Log("Grid Created from center");
            return grid;
        }
    }
    }
