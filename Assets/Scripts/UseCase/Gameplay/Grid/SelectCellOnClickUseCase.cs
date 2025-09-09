using Domain.Gameplay.Model.Grid;
using Infrastructure.Providers;
using UnityEngine;
using VContainer.Unity;

namespace UseCase.Gameplay.Grid
{
    public class SelectCellOnClickUseCase : ITickable
    {
        private readonly CellUnderCursorTracker _cursorTracker;
        private readonly SelectedCellProvider _selectedCellProvider;

        public SelectCellOnClickUseCase(
            CellUnderCursorTracker cursorTracker,
            SelectedCellProvider selectedCellProvider)
        {
            _cursorTracker = cursorTracker;
            _selectedCellProvider = selectedCellProvider;
        }
        
        public void Tick()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                GridCellModel cell = _cursorTracker.LastCellUnderCursor;
                if (cell != null)
                {
                    _selectedCellProvider.SetSelectedCell(cell);
                    Debug.Log($"Selected cell: {cell.X}, {cell.Y}");
                }
            }
        }
    }
}
