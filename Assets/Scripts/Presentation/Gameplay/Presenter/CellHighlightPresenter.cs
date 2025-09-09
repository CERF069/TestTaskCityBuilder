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
    public class CellHighlightPresenter : IInitializable, IDisposable, ITickable
    {
        private readonly ISubscriber<CellUnderCursorMessage> _subscriber;
        private readonly Transform _cellMeshObject;
        private readonly CellHighlightConfigRepository _config;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private Vector3 _targetPosition;

        public CellHighlightPresenter(
            ISubscriber<CellUnderCursorMessage> subscriber,
            Transform cellMeshObject,
            CellHighlightConfigRepository config)
        {
            _subscriber = subscriber;
            _cellMeshObject = cellMeshObject;
            _config = config;

            ApplySpriteAndColors();
        }

        public void Initialize()
        {
            _subscriber
                .Subscribe(OnCellUnderCursor)
                .AddTo(_disposables);
        }

        private void OnCellUnderCursor(CellUnderCursorMessage msg)
        {
            if (_cellMeshObject == null)
                return;

            if (msg.Cell == null)
            {
                _cellMeshObject.gameObject.SetActive(false);
                return;
            }

            _targetPosition = msg.Cell.WorldPosition;
            _cellMeshObject.gameObject.SetActive(true);
            
            SpriteRenderer sr = _cellMeshObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = msg.Cell.State == GridCellState.Empty
                    ? _config.EmptyCellColor
                    : _config.OccupiedCellColor;
            }
        }

        public void Tick()
        {
            if (_cellMeshObject != null && _cellMeshObject.gameObject.activeSelf)
            {
                _cellMeshObject.position = Vector3.Lerp(
                    _cellMeshObject.position,
                    _targetPosition,
                    Time.deltaTime * _config.MoveSpeed
                );
            }
        }

        private void ApplySpriteAndColors()
        {
            if (_cellMeshObject == null)
                return;

            SpriteRenderer sr = _cellMeshObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sprite = _config.HighlightSprite;
                sr.color = _config.EmptyCellColor;
            }
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}
