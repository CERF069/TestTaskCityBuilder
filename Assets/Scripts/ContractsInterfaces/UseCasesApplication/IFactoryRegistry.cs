namespace ContractsInterfaces.UseCasesApplication
{
    public interface IFactoryRegistry { T GetFactory<T>() where T : class;}
}
