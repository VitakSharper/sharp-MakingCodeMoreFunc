using System;

namespace MakingCodeMoreFunc
{
    public class GiftCard : FixedMoney
    {
        public Date ValidBefore { get; }

        public GiftCard(Currency currency, decimal amount, Date validBefore)
            : base(currency, amount)
        {
            _ = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
            ValidBefore = validBefore;
        }

        public override decimal Withdraw(Currency currency, decimal amount) =>
            ValidBefore.CompareTo(DateTime.Now) <= 0
                ? 0
                : base.Withdraw(currency, amount);
    }
}