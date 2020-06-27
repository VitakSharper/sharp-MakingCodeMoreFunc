using System.Collections.Generic;

namespace MakingCodeMoreFunc
{
    public class Wallet
    {
        public IList<Money> Content { get; } = new List<Money>();
        public void Add(Money money) => Content.Add(money);

        public void Charge(Currency currency, decimal amount)
        {
            decimal remaining = amount;

            using IEnumerator<Money> money = Content.GetEnumerator();
            while (money.MoveNext() && remaining > 0)
            {
                var paid = money.Current.Withdraw(currency, remaining);
                remaining -= paid;
            }
        }
    }
}