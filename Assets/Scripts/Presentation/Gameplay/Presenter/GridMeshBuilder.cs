using System.Collections.Generic;
using Domain.Gameplay.Model.Grid;
using UnityEngine;

namespace Presentation.Gameplay.Presenter
{
    public class GridMeshBuilder
    {
        public GameObject BuildGridMesh(GridModel grid, Vector3 origin, Material material, float lineWidth)
        {
            GameObject go = new GameObject("GridMesh");
            
            for (int x = 0; x <= grid.Width; x++)
            {
                float halfCell = grid.CellSize * 0.5f;
                float startX = grid.Cells[0, 0].WorldPosition.x - halfCell;
                float startZ = grid.Cells[0, 0].WorldPosition.z - halfCell;

                float xPos = startX + x * grid.CellSize;
                float zStart = startZ;
                float zEnd = startZ + grid.Height * grid.CellSize;

                CreateLine(go.transform, new Vector3(xPos, origin.y, zStart), new Vector3(xPos, origin.y, zEnd), material, lineWidth);
            }
            
            for (int y = 0; y <= grid.Height; y++)
            {
                float halfCell = grid.CellSize * 0.5f;
                float startX = grid.Cells[0, 0].WorldPosition.x - halfCell;
                float startZ = grid.Cells[0, 0].WorldPosition.z - halfCell;

                float zPos = startZ + y * grid.CellSize;
                float xStart = startX;
                float xEnd = startX + grid.Width * grid.CellSize;

                CreateLine(go.transform, new Vector3(xStart, origin.y, zPos), new Vector3(xEnd, origin.y, zPos), material, lineWidth);
            }

            return go;
        }

        private void CreateLine(Transform parent, Vector3 start, Vector3 end, Material material, float lineWidth)
        {
            GameObject line = new GameObject("Line");
            line.transform.parent = parent;
            LineRenderer lr = line.AddComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
            lr.material = material;
            lr.startWidth = lineWidth;
            lr.endWidth = lineWidth;
            lr.useWorldSpace = true;
        }
    }
}
