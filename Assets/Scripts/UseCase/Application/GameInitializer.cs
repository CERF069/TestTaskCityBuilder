using System.Collections.Generic;
using ContractsInterfaces.UseCasesApplication;
using ContractsInterfaces.UseCasesGameplay;
using Domain.Gameplay.Model.Build;
using Domain.Gameplay.Model.Grid;
using Infrastructure.Repositories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UseCase.Application
{
    public class GameInitializer : IInitializable
    {
        private readonly IFactoryRegistry _factoryRegistry;
        private readonly IRepositoryRegistry _repositoryRegistry;
        private readonly IGridProvider _gridProvider;
        private readonly ICameraMovementUseCase _cameraMovementUseCase;
        private readonly ICoinProvider _coinProvider;
        private readonly IBuildingProvider _buildingProvider;

        [Inject]
        public GameInitializer(
            IFactoryRegistry factoryRegistry,
            IRepositoryRegistry repositoryRegistry,
            IGridProvider gridProvider,
            ICameraMovementUseCase cameraMovementUseCase,
            ICoinProvider coinProvider,
            IBuildingProvider buildingProvider)
        {
            _factoryRegistry = factoryRegistry;
            _repositoryRegistry = repositoryRegistry;
            _gridProvider = gridProvider;
            _cameraMovementUseCase = cameraMovementUseCase;
            _coinProvider = coinProvider;
            _buildingProvider = buildingProvider;
        }

        public void Initialize()
        {
            _cameraMovementUseCase.Enable();
            CreateGrid();
            
            _coinProvider.AddCoins(100);
            
            CreateDefaultBuildings(_repositoryRegistry.GetRepository<BuildingConfigRepository>());
            
            Debug.Log($"Game initialized, camera enabled, starting coins: {_coinProvider.Coins}");
        }
        private void CreateDefaultBuildings(BuildingConfigRepository repository)
        {
            if (repository == null)
            {
                Debug.LogError("BuildingConfigRepository == null! Проверь, что он назначен в инспекторе.");
                return;
            }

            foreach (BuildingConfigElement buildingConfig in repository.Buildings)
            {
                if (buildingConfig == null)
                {
                    Debug.LogWarning("Найден null в списке Buildings");
                    continue;
                }

                BuildingModel building = new BuildingModel(
                    buildingConfig.Type,
                    BuildingState.Placed,
                    1,
                    Vector3.zero,
                    new List<GridCellModel>()
                );

                _buildingProvider.AddBuilding(building);
                Debug.Log($"Здание типа {building.Type} добавлено в провайдер.");
            }
        }
        
        private void CreateGrid()
        {
            IGridFactory gridFactory = _factoryRegistry.GetFactory<IGridFactory>();
            GridRepository gridConfig = _repositoryRegistry.GetRepository<GridRepository>();

            GridModel grid = gridFactory.CreateGrid(gridConfig.Width, gridConfig.Height, gridConfig.CellSize);
            _gridProvider.SetGrid(grid);
        }
    }
}
