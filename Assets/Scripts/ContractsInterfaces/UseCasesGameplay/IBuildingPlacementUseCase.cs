using Domain.Gameplay.Model.Build;
using Domain.Gameplay.Model.Grid;

namespace ContractsInterfaces.UseCasesGameplay
{
    public interface IBuildingPlacementUseCase
    {
        BuildingType? SelectedBuildingType { get; }

        void SelectBuilding(BuildingType type);
        void DeselectBuilding();
        bool TryPlaceBuilding(GridCellModel cell, UnityEngine.Vector3 worldPosition);
    }
}
