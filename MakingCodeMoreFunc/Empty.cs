using System;

namespace MakingCodeMoreFunc
{
    public class Empty : SpecificMoney
    {
        public Empty(Currency currency)
            : base(currency)
        {
        }

        public override Money On(Timestamp time) =>
            this;

        public override Tuple<Amount, Money> Take(decimal amount) =>
            Tuple.Create(Amount.Zero(base.Currency), (Money)this);
    }
}