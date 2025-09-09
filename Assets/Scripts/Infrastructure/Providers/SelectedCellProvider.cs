using Domain.Gameplay.Model.Grid;
using UniRx;

namespace Infrastructure.Providers
{
    public class SelectedCellProvider
    {
        public readonly ReactiveProperty<GridCellModel> SelectedCell = new ReactiveProperty<GridCellModel>(null);

        public void SetSelectedCell(GridCellModel cell)
        {
            SelectedCell.Value = cell;
        }
    }
}
