using Domain.Gameplay.MessagesDto.Camera;
using Domain.Gameplay.MessagesDto.Grid;
using Domain.Gameplay.Model.Grid;
using UnityEngine;
using MessagePipe;
using VContainer.Unity;

namespace UseCase.Gameplay.Grid
{
    public class CellUnderCursorTracker : ITickable
    {
        private readonly GetGridCellUseCase _getCellUseCase;
        private readonly IPublisher<CellUnderCursorMessage> _publisher;
        private readonly float _selectionRadius;
        private GridCellModel _lastCellUnderCursor;
        public GridCellModel LastCellUnderCursor => _lastCellUnderCursor;
        private bool _cameraDragging;

        public CellUnderCursorTracker(
            GetGridCellUseCase getCellUseCase,
            IPublisher<CellUnderCursorMessage> publisher,
            ISubscriber<CameraDragStartedMessage> dragStart,
            ISubscriber<CameraDragEndedMessage> dragEnd,
            float selectionRadius = 0f)
        {
            _getCellUseCase = getCellUseCase;
            _publisher = publisher;
            _selectionRadius = selectionRadius;

            // Подписываемся на события через MessagePipe
            dragStart.Subscribe(_ => _cameraDragging = true);
            dragEnd.Subscribe(_ => _cameraDragging = false);
        }

        public void Tick()
        {
            if (_cameraDragging) return;
            SelectNearestCell();
        }

        private void SelectNearestCell()
        {
            if (_getCellUseCase.CurrentGrid == null)
            {
                _publisher.Publish(new CellUnderCursorMessage(null));
                _lastCellUnderCursor = null;
                return;
            }

            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            if (!plane.Raycast(ray, out float distance))
            {
                _publisher.Publish(new CellUnderCursorMessage(null));
                _lastCellUnderCursor = null;
                return;
            }

            Vector3 hitPoint = ray.GetPoint(distance);

            GridCellModel nearestCell = null;
            float minDistance = float.MaxValue;
            GridModel grid = _getCellUseCase.CurrentGrid;

            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    GridCellModel cell = grid.GetCell(x, y);
                    if (cell != null)
                    {
                        float dist = Vector3.Distance(hitPoint, cell.WorldPosition);
                        if (dist <= _selectionRadius && dist < minDistance)
                        {
                            nearestCell = cell;
                            minDistance = dist;
                        }
                    }
                }
            }

            if (nearestCell != _lastCellUnderCursor)
            {
                _lastCellUnderCursor = nearestCell;
                _publisher.Publish(new CellUnderCursorMessage(nearestCell));
            }
        }
    }
}
