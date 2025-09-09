using Infrastructure.Providers;
using VContainer.Unity;

namespace UseCase.Gameplay.Build
{
    public class PlaceBuildingOnCellUseCase : ITickable
    {
        private readonly SelectedCellProvider _selectedCellProvider;
        private readonly BuildingProvider _buildingProvider;

        public PlaceBuildingOnCellUseCase(
            SelectedCellProvider selectedCellProvider,
            BuildingProvider buildingProvider)
        {
            _selectedCellProvider = selectedCellProvider;
            _buildingProvider = buildingProvider;
        }

        public void Tick()
        {
            
        }
    }
}
