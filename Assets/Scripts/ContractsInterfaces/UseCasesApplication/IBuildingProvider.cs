using System.Collections.Generic;
using Domain.Gameplay.Model.Build;
using Domain.Gameplay.Model.Grid;

namespace ContractsInterfaces.UseCasesApplication
{
    /// <summary>
    /// Интерфейс провайдера (репозитория) для работы со зданиями.
    /// </summary>
    public interface IBuildingProvider
    {
        void AddBuilding(BuildingModel building);
        
        void RemoveBuilding(BuildingModel building);

        /// <summary>
        /// Получить все здания.
        /// </summary>
        IReadOnlyList<BuildingModel> GetAllBuildings();

        /// <summary>
        /// Получить первое здание по типу.
        /// </summary>
        BuildingModel GetBuildingByType(BuildingType type);

        /// <summary>
        /// Получить здание по условию (например, по occupiedCells или worldPosition).
        /// </summary>
        BuildingModel GetBuildingAtCell(GridCellModel cell);
        
        void SetSelectedBuilding(BuildingModel building);
        
        BuildingModel GetSelectedBuilding();
    }
}
