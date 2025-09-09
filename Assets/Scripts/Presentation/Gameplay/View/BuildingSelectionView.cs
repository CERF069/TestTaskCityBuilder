/*
using ContractsInterfaces.UseCasesGameplay;
using UnityEngine;
using UnityEngine.UIElements;
using Domain.Gameplay.Model.Build;
using VContainer;

namespace Presentation.Gameplay.View
{
    public class BuildingSelectionView : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;

        [Inject] private IBuildingPlacementUseCase _useCase;
        

        private void OnEnable()
        {
            if (uiDocument == null)
            {
                Debug.LogError("[BuildingSelectionView] UIDocument is null! Please assign it in the Inspector.");
                return;
            }

            Debug.Log(_useCase);
            var root = uiDocument.rootVisualElement;
            if (root == null)
            {
                Debug.LogError("[BuildingSelectionView] rootVisualElement is null! UIDocument not initialized yet.");
                return;
            }

            // Находим кнопки по имени
            var farmButton = root.Q<Button>("FarmButton");
            var houseButton = root.Q<Button>("HouseButton");
            var mineButton = root.Q<Button>("MineButton");

            // Проверяем, что кнопки найдены
            if (farmButton == null) Debug.LogError("[BuildingSelectionView] FarmButton not found!");
            if (houseButton == null) Debug.LogError("[BuildingSelectionView] HouseButton not found!");
            if (mineButton == null) Debug.LogError("[BuildingSelectionView] MineButton not found!");

            // Подписываемся на событие клика
            if (farmButton != null) farmButton.clicked += this.OnFarmButtonClicked;
            if (houseButton != null) houseButton.clicked += this.OnHouseButtonClicked;
            if (mineButton != null) mineButton.clicked += this.OnMineButtonClicked;

            Debug.Log("[BuildingSelectionView] Buttons successfully hooked.");
        }

        private void OnDisable()
        {
            if (uiDocument == null || uiDocument.rootVisualElement == null) return;

            var root = uiDocument.rootVisualElement;
            Button button = root.Q<Button>("FarmButton");
            if (button != null) button.clicked -= this.OnFarmButtonClicked;
            Button button1 = root.Q<Button>("HouseButton");
            if (button1 != null) button1.clicked -= this.OnHouseButtonClicked;
            Button button2 = root.Q<Button>("MineButton");
            if (button2 != null) button2.clicked -= this.OnMineButtonClicked;
        }

        private void OnFarmButtonClicked()
        {
            if (_useCase == null)
            {
                Debug.LogError("[BuildingSelectionView] _useCase is null on FarmButton click!");
                return;
            }
            Debug.Log("[BuildingSelectionView] FarmButton clicked.");
            _useCase.SelectBuilding(BuildingType.Farm);
        }

        private void OnHouseButtonClicked()
        {
            if (_useCase == null)
            {
                Debug.LogError("[BuildingSelectionView] _useCase is null on HouseButton click!");
                return;
            }
            Debug.Log("[BuildingSelectionView] HouseButton clicked.");
            _useCase.SelectBuilding(BuildingType.House);
        }

        private void OnMineButtonClicked()
        {
            if (_useCase == null)
            {
                Debug.LogError("[BuildingSelectionView] _useCase is null on MineButton click!");
                return;
            }
            Debug.Log("[BuildingSelectionView] MineButton clicked.");
            _useCase.SelectBuilding(BuildingType.Mine);
        }
    }
}
*/
