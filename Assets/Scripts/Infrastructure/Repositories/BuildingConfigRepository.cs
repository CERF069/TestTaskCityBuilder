using System.Collections.Generic;
using Domain.Gameplay.Model.Build;
using UnityEngine;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий конфигураций зданий. Содержит все типы зданий и их параметры.
    /// </summary>
    [CreateAssetMenu(fileName = "BuildingConfigRepository", menuName = "Config/Building Config Repository")]
    public class BuildingConfigRepository : ScriptableObject
    {
        [Header("Все доступные здания")]
        [SerializeField] private List<BuildingConfigElement> _buildings = new();

        /// <summary>
        /// Получить список всех зданий.
        /// </summary>
        public IReadOnlyList<BuildingConfigElement> Buildings => _buildings;

        /// <summary>
        /// Получить конфигурацию конкретного здания по типу.
        /// </summary>
        public BuildingConfigElement GetBuildingConfig(BuildingType type) =>
            _buildings.Find(b => b.Type == type);
    }

    [System.Serializable]
    public class BuildingConfigElement
    {
        [Header("Тип здания")]
        public BuildingType Type;

        
        [Header("3D модель (Prefab) здания")]
        public GameObject Prefab;
        
        [Header("Стоимость постройки")]
        public int Cost;

        [Header("Доход/эффект")]
        public float GoldPerMinute;

        [Header("Максимальный уровень")]
        public int MaxLevel = 3;

        [Header("Стоимость улучшений по уровням")]
        public List<int> UpgradeCosts = new();

        [Header("Эффекты по уровням")]
        public List<float> UpgradeGoldPerMinute = new();
    }
}
