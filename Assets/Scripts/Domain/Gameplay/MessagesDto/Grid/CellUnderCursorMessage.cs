using Domain.Gameplay.Model.Grid;

namespace Domain.Gameplay.MessagesDto.Grid
{
    public struct CellUnderCursorMessage
    {
        public readonly GridCellModel Cell;

        public CellUnderCursorMessage(GridCellModel cell)
        {
            Cell = cell;
        }
    }
}
