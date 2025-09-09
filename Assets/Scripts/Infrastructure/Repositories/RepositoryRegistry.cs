using ContractsInterfaces.UseCasesApplication;
using UnityEngine;

namespace Infrastructure.Repositories
{
    public class RepositoryRegistry : IRepositoryRegistry
    {
        private readonly GridRepository _gridRepository;

        public RepositoryRegistry(GridRepository gridRepository)
        {
            _gridRepository = gridRepository;
        }

        public T GetRepository<T>() where T : ScriptableObject
        {
            if (typeof(T) == typeof(GridRepository)) return _gridRepository as T;
            return null;
        }
    }
}
