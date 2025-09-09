using System;
using ContractsInterfaces.UseCasesApplication;
using Domain.Gameplay.MessagesDto.Grid;
using Infrastructure.Repositories;
using UnityEngine;
using UseCase.Application;
using UseCase.Gameplay.Factories;
using UseCase.Gameplay.Grid;
using UseCase.Gameplay.UseCase.Gameplay;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using Presentation.Gameplay.Presenter;

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
        
        



        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();

            RegisterRepositories(builder);
            RegisterFactories(builder);
            RegisterProviders(builder);
            RegisterFactoryRegistry(builder);

            RegisterPresenters(builder);

            RegisterGetGridUseCases(builder);

            RegisterGameInitializer(builder);
        }

        private void RegisterCameraSystem(IContainerBuilder builder)
        {
      
        }
        private void RegisterPresenters(IContainerBuilder builder)
        {
            builder.Register<GridMeshBuilder>(Lifetime.Singleton);

            builder.Register<GridVisualPresenter>(resolver =>
                    new GridVisualPresenter(
                        resolver.Resolve<ISubscriber<GridCreatedMessage>>(),
                        resolver.Resolve<GridMeshBuilder>(),
                        gridVisualConfig
                    ), Lifetime.Singleton)
                .As<IInitializable>();

            builder.Register(resolver =>
            {
                return new CellHighlightPresenter(
                    resolver.Resolve<ISubscriber<CellUnderCursorMessage>>(),
                    cellMeshObject,
                    cellHighlightConfig
                );
            }, Lifetime.Singleton)
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
                        selectionRadius: 1f
                    ), Lifetime.Singleton)
                .As<ITickable>();
        }

        private void RegisterRepositories(IContainerBuilder builder)
        {
            builder.RegisterInstance(gridConfig).As<GridRepository>();
            builder.RegisterInstance(cellHighlightConfig).As<CellHighlightConfigRepository>();

            builder.Register<RepositoryRegistry>(Lifetime.Singleton)
                .As<IRepositoryRegistry>();
        }

        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<GridFactory>(Lifetime.Singleton)
                .As<IGridFactory>();
        }

        private void RegisterProviders(IContainerBuilder builder)
        {
            builder.Register<GridProvider>(Lifetime.Singleton)
                .As<IGridProvider>();
        }

        private void RegisterFactoryRegistry(IContainerBuilder builder)
        {
            builder.Register<FactoryRegistry>(Lifetime.Singleton)
                .As<IFactoryRegistry>();
        }

        private void RegisterGameInitializer(IContainerBuilder builder)
        {
            builder.Register<GameInitializer>(Lifetime.Singleton)
                .As<IInitializable>();
        }
    }
}
