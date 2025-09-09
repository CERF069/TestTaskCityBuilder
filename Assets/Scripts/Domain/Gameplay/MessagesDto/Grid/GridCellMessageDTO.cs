using Domain.Gameplay.Model.Grid;

namespace Domain.Gameplay.MessagesDto.Grid
{
    public readonly struct GridCreatedMessage
    {
        public GridModel Grid { get; }

        public GridCreatedMessage(GridModel grid)
        {
            Grid = grid;
        }
    }
}
