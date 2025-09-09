using ContractsInterfaces.UseCasesApplication;
using Infrastructure.Repositories;
using UnityEngine;

public class RepositoryRegistry : IRepositoryRegistry
{
    private readonly GridRepository _gridRepository;
    private readonly BuildingConfigRepository _buildingConfigRepository;
    private readonly CellHighlightConfigRepository _cellHighlightConfigRepository;

    public RepositoryRegistry(
        GridRepository gridRepository,
        BuildingConfigRepository buildingConfigRepository,
        CellHighlightConfigRepository cellHighlightConfigRepository)
    {
        _gridRepository = gridRepository;
        _buildingConfigRepository = buildingConfigRepository;
        _cellHighlightConfigRepository = cellHighlightConfigRepository;
    }

    public T GetRepository<T>() where T : ScriptableObject
    {
        if (typeof(T) == typeof(GridRepository)) return _gridRepository as T;
        if (typeof(T) == typeof(BuildingConfigRepository)) return _buildingConfigRepository as T;
        if (typeof(T) == typeof(CellHighlightConfigRepository)) return _cellHighlightConfigRepository as T;

        Debug.LogError($"Repository of type {typeof(T)} not found!");
        return null;
    }
}
