using ContractsInterfaces.UseCasesApplication;
using Domain.Gameplay.MessagesDto.Grid;
using Domain.Gameplay.Model.Grid;
using MessagePipe;

namespace UseCase.Gameplay.Grid
{
    public class GridProvider : IGridProvider
    {
       private readonly IPublisher<GridCreatedMessage> _publisher;

        public GridProvider(IPublisher<GridCreatedMessage> publisher)
        {
            _publisher = publisher;
        }

        public GridModel CurrentGrid { get; private set; }

        public void SetGrid(GridModel grid)
        {
            CurrentGrid = grid;
            _publisher.Publish(new GridCreatedMessage(grid));
        }
    }
}
