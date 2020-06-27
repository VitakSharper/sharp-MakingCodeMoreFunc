using System;

namespace MakingCodeMoreFunc
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            _ = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
            ValidBefore = validBefore;
        }

        public override decimal Withdraw(Currency currency, decimal amount) =>
            ValidBefore.CompareTo(DateTime.Now) <= 0
                ? 0
                : amount;
    }
}