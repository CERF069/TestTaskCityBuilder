using System;
using ContractsInterfaces.UseCasesApplication;
using ContractsInterfaces.UseCasesGameplay;
using Domain.Gameplay.MessagesDto.Camera;
using Domain.Gameplay.MessagesDto.Grid;
using Infrastructure.Providers;
using Infrastructure.Repositories;
using UnityEngine;
using UseCase.Application;
using UseCase.Gameplay.Factories;
using UseCase.Gameplay.Grid;
using UseCase.Gameplay.UseCase.Gameplay;
using UseCase.Gameplay.Camera;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using Presentation.Gameplay.Presenter;
using UseCase.Gameplay.Build;

namespace Installers.Gameplay
{
    public class GameplayInstaller : LifetimeScope
    {
        [Header("Grid Config")]
        [SerializeField] private GridRepository gridConfig;

        [Header("Grid Visual Config")]
        [SerializeField] private GridVisualConfigRepository gridVisualConfig;

        [Header("Cell Highlight Config")]
        [SerializeField] private CellHighlightConfigRepository cellHighlightConfig;

        [Header("Highlight Object")]
        [SerializeField] private Transform cellMeshObject;

        [Header("Camera Config")]
        [SerializeField] private CameraConfigRepository cameraConfig;

        [Header("Building Config")]
        [SerializeField] private BuildingConfigRepository buildingConfigRepository;

        protected override void Configure(IContainerBuilder builder)
        {
      
            builder.RegisterMessagePipe();

      
            RegisterRepositories(builder);
            
        
            RegisterProviders(builder);

          
            RegisterFactories(builder);
            RegisterFactoryRegistry(builder);
            
         
            RegisterPresenters(builder);
            RegisterGetGridUseCases(builder);
            RegisterSelectedCellSystem(builder);

          
            RegisterGameInitializer(builder);
            
            RegisterCameraSystem(builder);

            RegicterSelectBuildingByKey(builder);

           
        }

        private void RegisterSelectedCellSystem(IContainerBuilder builder)
        {
            builder.Register<SelectedCellProvider>(Lifetime.Singleton);
            
            builder.Register<SelectCellOnClickUseCase>(Lifetime.Singleton)
                .As<ITickable>();
            
        }

        private void RegicterSelectBuildingByKey(IContainerBuilder builder)
        {
            builder.Register<SelectBuildingByKey>(Lifetime.Singleton)
                .As<ITickable>();
        }

        private void RegisterRepositories(IContainerBuilder builder)
        {
            builder.RegisterInstance(gridConfig).As<GridRepository>();
            builder.RegisterInstance(cellHighlightConfig).As<CellHighlightConfigRepository>();
            builder.RegisterInstance(buildingConfigRepository).As<BuildingConfigRepository>();

            builder.Register<RepositoryRegistry>(Lifetime.Singleton)
                .As<IRepositoryRegistry>();
        }

        private void RegisterProviders(IContainerBuilder builder)
        {
            builder.Register<GridProvider>(Lifetime.Singleton).As<IGridProvider>();
            
            builder.Register<BuildingProvider>(Lifetime.Singleton).As<IBuildingProvider>();
            
            builder.Register<CoinProvider>(Lifetime.Singleton).As<ICoinProvider>();
        }

        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<GridFactory>(Lifetime.Singleton).As<IGridFactory>();
        }

        private void RegisterFactoryRegistry(IContainerBuilder builder)
        {
            builder.Register<FactoryRegistry>(Lifetime.Singleton).As<IFactoryRegistry>();
        }
        

        private void RegisterPresenters(IContainerBuilder builder)
        {
            builder.Register<GridMeshBuilder>(Lifetime.Singleton);

            builder.Register<GridVisualPresenter>(resolver =>
                    new GridVisualPresenter(
                        resolver.Resolve<ISubscriber<GridCreatedMessage>>(),
                        resolver.Resolve<GridMeshBuilder>(),
                        gridVisualConfig
                    ),
                    Lifetime.Singleton)
                .As<IInitializable>();

            builder.Register(resolver =>
                    new CellHighlightPresenter(
                        resolver.Resolve<ISubscriber<CellUnderCursorMessage>>(),
                        cellMeshObject,
                        cellHighlightConfig
                    ),
                    Lifetime.Singleton)
                .As<IInitializable>()
                .As<ITickable>();
        }

        private void RegisterGetGridUseCases(IContainerBuilder builder)
        {
            builder.Register<GetGridCellUseCase>(Lifetime.Singleton);

            builder.Register(resolver =>
                    new CellUnderCursorTracker(
                        resolver.Resolve<GetGridCellUseCase>(),
                        resolver.Resolve<IPublisher<CellUnderCursorMessage>>(),
                        resolver.Resolve<ISubscriber<CameraDragStartedMessage>>(),
                        resolver.Resolve<ISubscriber<CameraDragEndedMessage>>(),
                        selectionRadius: 1f
                    ),
                    Lifetime.Singleton)
                .As<CellUnderCursorTracker>() 
                .As<ITickable>();
            
        }

        private void RegisterGameInitializer(IContainerBuilder builder)
        {
            builder.Register<GameInitializer>(Lifetime.Singleton).As<IInitializable>();
        }

        private void RegisterCameraSystem(IContainerBuilder builder)
        {
            Camera mainCamera = Camera.main;

            builder.Register(resolver =>
                    new CameraMovement(
                        mainCamera,
                        resolver.Resolve<IPublisher<CameraDragStartedMessage>>(),
                        resolver.Resolve<IPublisher<CameraDragEndedMessage>>(),
                        cameraConfig.MoveSpeed,
                        cameraConfig.DragSpeed,
                        cameraConfig.ZoomSpeed,
                        cameraConfig.MinZoom,
                        cameraConfig.MaxZoom
                    ),
                    Lifetime.Singleton)
                .As<ICameraMovementUseCase>()
                .As<ITickable>()
                .As<IInitializable>()
                .As<IDisposable>();
        }
    }
}
