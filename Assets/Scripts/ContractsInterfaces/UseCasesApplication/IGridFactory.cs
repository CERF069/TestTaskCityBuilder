using Domain.Gameplay.Model.Grid;
using UnityEngine;

namespace ContractsInterfaces.UseCasesApplication
{ 
    public interface IGridFactory { GridModel CreateGrid(int width, int height, float cellSize); }
}
