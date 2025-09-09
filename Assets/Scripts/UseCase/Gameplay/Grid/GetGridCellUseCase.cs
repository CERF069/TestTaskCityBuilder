using ContractsInterfaces.UseCasesApplication;
using Domain.Gameplay.Model.Grid;
using UnityEngine;
using VContainer;
namespace UseCase.Gameplay.Grid
{
        public class GetGridCellUseCase
        {
            private readonly IGridProvider _gridProvider;
            
            [Inject]
            public GetGridCellUseCase(IGridProvider gridProvider)
            {
                _gridProvider = gridProvider;
            }
            
            public GridModel CurrentGrid => _gridProvider.CurrentGrid;
            

            public GridCellModel Execute(int x, int y)
            {
                return CurrentGrid?.GetCell(x, y);
            }
            
            public GridCellModel Execute(Vector3 worldPosition)
            {
                if (CurrentGrid == null)
                    return null;

                // Предположим, что начало сетки в (0,0,0)
                Vector3 gridOrigin = Vector3.zero;

                return CurrentGrid.GetCellFromWorldPosition(worldPosition, gridOrigin);
            }
        }
}
