namespace Domain.Gameplay.Model
{
    public class CoinModel
    {
        public int Coins { get; private set; }

        public CoinModel(int initialCoins = 0)
        {
            Coins = initialCoins;
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
        }

        public void RemoveCoins(int amount)
        {
            Coins -= amount;
            if (Coins < 0) Coins = 0;
        }
    }
}
