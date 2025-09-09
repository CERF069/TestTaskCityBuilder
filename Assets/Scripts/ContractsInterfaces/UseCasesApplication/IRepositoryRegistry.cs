using UnityEngine;

namespace ContractsInterfaces.UseCasesApplication
{
    public interface IRepositoryRegistry { T GetRepository<T>() where T : ScriptableObject; }
}
