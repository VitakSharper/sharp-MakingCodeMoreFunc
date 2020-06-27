using System;

namespace MakingCodeMoreFunc
{
    public class GiftCard : Amount
    {
        public Date ValidBefore { get; }

        public GiftCard(Currency currency, decimal amount, Date validBefore)
            : base(currency, amount)
        {
            ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
        }

        public override Money On(Timestamp time) =>
            time.CompareTo(this.ValidBefore) >= 0
                ? Amount.Zero(base.Currency)
                : this;
    }
}