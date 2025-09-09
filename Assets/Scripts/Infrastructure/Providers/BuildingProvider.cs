using System.Collections.Generic;
using System.Linq;
using ContractsInterfaces.UseCasesApplication;
using Domain.Gameplay.Model.Build;
using Domain.Gameplay.Model.Grid;

namespace Infrastructure.Providers
{
    /// <summary>
    /// Провайдер зданий. Хранит все созданные здания и управляет ими.
    /// </summary>
    public class BuildingProvider : IBuildingProvider
    {
        private readonly List<BuildingModel> _buildings = new();
        private BuildingModel _selectedBuilding;
        
        public void AddBuilding(BuildingModel building)
        {
            if (!this._buildings.Contains(building))
            {
                this._buildings.Add(building);
            }
        }

        public void RemoveBuilding(BuildingModel building) => this._buildings.Remove(building);

        public IReadOnlyList<BuildingModel> GetAllBuildings() => this._buildings.AsReadOnly();

        public BuildingModel GetBuildingByType(BuildingType type) => 
            this._buildings.FirstOrDefault(b => b.Type == type);

        public BuildingModel GetBuildingAtCell(GridCellModel cell) => 
            this._buildings.FirstOrDefault(b => b.OccupiedCells.Contains(cell));
        
        public void SetSelectedBuilding(BuildingModel building)
        {
            if (_buildings.Contains(building))
                _selectedBuilding = building;
        }

        public BuildingModel GetSelectedBuilding() => _selectedBuilding;
    }
}
