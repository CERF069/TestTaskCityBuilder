using ContractsInterfaces.UseCasesGameplay;
using Domain.Gameplay.Model;

namespace Infrastructure.Providers
{
    public class CoinProvider : ICoinProvider
    {
        private readonly CoinModel _coinModel;

        public CoinProvider()
        {
            _coinModel = new CoinModel();
        }

        public int Coins => _coinModel.Coins;

        public void AddCoins(int amount)
        {
            _coinModel.AddCoins(amount);
        }

        public void RemoveCoins(int amount)
        {
            _coinModel.RemoveCoins(amount);
        }
    }
}
