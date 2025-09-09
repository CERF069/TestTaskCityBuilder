using Domain.Gameplay.Model.Grid;

namespace ContractsInterfaces.UseCasesApplication
{
    public interface IGridProvider
    {
        GridModel CurrentGrid { get; }
        void SetGrid(GridModel grid);
    }
}
