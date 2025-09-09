using System;
using Domain.Gameplay.MessagesDto.Grid;
using Domain.Gameplay.Model.Grid;
using MessagePipe;
using UniRx;
using UnityEngine;
using VContainer.Unity;
using Infrastructure.Repositories;

namespace Presentation.Gameplay.Presenter
{
    public class GridVisualPresenter : IInitializable, IDisposable
    {
        private readonly ISubscriber<GridCreatedMessage> _subscriber;
        private readonly GridMeshBuilder _meshBuilder;
        private readonly GridVisualConfigRepository _visualConfig;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private GameObject _gridMeshObject;

        public GridVisualPresenter(
            ISubscriber<GridCreatedMessage> subscriber,
            GridMeshBuilder meshBuilder,
            GridVisualConfigRepository visualConfig)
        {
            _subscriber = subscriber;
            _meshBuilder = meshBuilder;
            _visualConfig = visualConfig;
        }

        public void Initialize()
        {
            _subscriber
                .Subscribe(OnGridCreated)
                .AddTo(_disposables);
        }

        private void OnGridCreated(GridCreatedMessage msg)
        {
            GridModel grid = msg.Grid;
            Material material = new Material(Shader.Find("Unlit/Color"))
            {
                color = _visualConfig.LineColor
            };

            if (_gridMeshObject != null)
                GameObject.Destroy(_gridMeshObject);

            _gridMeshObject = _meshBuilder.BuildGridMesh(grid, Vector3.zero, material, _visualConfig.LineWidth);

            Debug.Log("Grid Visual created with color: " + _visualConfig.LineColor);
        }

        public void Dispose()
        {
            _disposables?.Dispose();
            if (_gridMeshObject != null)
                GameObject.Destroy(_gridMeshObject);
        }
    }
}
