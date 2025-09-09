using ContractsInterfaces.UseCasesApplication;
using Domain.Gameplay.Model.Build;
using UnityEngine;
using VContainer.Unity;

namespace UseCase.Gameplay.Build
{
    public class SelectBuildingByKey: ITickable
    {
        private readonly IBuildingProvider _buildingProvider;
        
        public SelectBuildingByKey(IBuildingProvider buildingProvider)
        {
            _buildingProvider = buildingProvider;
        }

        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
                SelectBuilding(BuildingType.House);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
                SelectBuilding(BuildingType.Farm);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
                SelectBuilding(BuildingType.Mine);
        }

        private void SelectBuilding(BuildingType type)
        {
            var building = _buildingProvider.GetBuildingByType(type);
            if (building != null)
            {
                _buildingProvider.SetSelectedBuilding(building);
                Debug.Log($"Выбрано здание: {building.Type}");
            }
            else
            {
                Debug.Log($"Здание типа {type} не найдено");
            }
        }
    }
}
