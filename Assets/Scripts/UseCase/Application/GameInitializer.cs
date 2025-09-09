using ContractsInterfaces.UseCasesApplication;
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
        
        [Inject]
        public GameInitializer(
            IFactoryRegistry factoryRegistry,
            IRepositoryRegistry repositoryRegistry,
            IGridProvider gridProvider)
        {
            _factoryRegistry = factoryRegistry;
            _repositoryRegistry = repositoryRegistry;
            _gridProvider = gridProvider;
        }

        public void Initialize()
        {
            CreateGrid();
            Debug.Log("Game initialized");
        }

        private void CreateGrid()
        {
            IGridFactory  gridFactory = _factoryRegistry.GetFactory<IGridFactory>();
            GridRepository gridConfig = _repositoryRegistry.GetRepository<GridRepository>();
            
            GridModel grid = gridFactory.CreateGrid(gridConfig.Width, gridConfig.Height, gridConfig.CellSize);
            _gridProvider.SetGrid(grid);
        }
    }
}
