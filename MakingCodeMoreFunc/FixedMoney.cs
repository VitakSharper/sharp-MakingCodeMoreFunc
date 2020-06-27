using System;

namespace MakingCodeMoreFunc
{
    public class FixedMoney : Money
    {
        public Currency Currency { get; }
        public decimal Amount { get; private set; }

        protected FixedMoney(Currency currency, decimal amount)
        {
            _ = currency ?? throw new ArgumentNullException(nameof(currency));
            if (amount < 0) throw new ArgumentException("Negative amount.");
            Currency = currency;
            Amount = amount;
        }

        public override decimal Withdraw(Currency currency, decimal amount)
        {
            if (currency != Currency) return 0;
            var paid = Math.Min(Amount, amount);
            Amount -= paid;
            return paid;
        }
    }
}