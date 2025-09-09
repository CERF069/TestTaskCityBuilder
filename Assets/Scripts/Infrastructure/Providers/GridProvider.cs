using ContractsInterfaces.UseCasesApplication;
using Domain.Gameplay.MessagesDto.Grid;
using Domain.Gameplay.Model.Grid;
using MessagePipe;

namespace Infrastructure.Providers
{
    public class GridProvider : IGridProvider
    {
       private readonly IPublisher<GridCreatedMessage> _publisher;

        public GridProvider(IPublisher<GridCreatedMessage> publisher)
        {
            this._publisher = publisher;
        }

        public GridModel CurrentGrid { get; private set; }

        public void SetGrid(GridModel grid)
        {
            this.CurrentGrid = grid;
            this._publisher.Publish(new GridCreatedMessage(grid));
        }
    }
}
