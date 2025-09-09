namespace ContractsInterfaces.UseCasesGameplay
{
    public interface ICoinProvider
    {
        int Coins { get; }
        void AddCoins(int amount);
        void RemoveCoins(int amount);
    }
}
