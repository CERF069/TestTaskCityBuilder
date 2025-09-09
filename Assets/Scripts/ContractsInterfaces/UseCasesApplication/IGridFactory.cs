using Domain.Gameplay.Model.Grid;

namespace ContractsInterfaces.UseCasesApplication
{ 
    public interface IGridFactory { GridModel CreateGrid(int width, int height, float cellSize); }
}
