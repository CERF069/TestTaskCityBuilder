namespace UseCase.Gameplay
{
    using ContractsInterfaces.UseCasesApplication;

    namespace UseCase.Gameplay
    {
        public class FactoryRegistry : IFactoryRegistry
        {
            private readonly IGridFactory _gridFactory;

            public FactoryRegistry(
                IGridFactory gridFactory
               )
            {
                _gridFactory = gridFactory;
            }

            public T GetFactory<T>() where T : class
            {
                if (typeof(T) == typeof(IGridFactory)) return _gridFactory as T;
                return null;
            }
        }
    }

}
