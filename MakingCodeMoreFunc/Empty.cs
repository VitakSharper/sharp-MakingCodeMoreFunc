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

        public override (Amount taken, Money remaining) Take(decimal amount) =>
            (Amount.Zero(base.Currency), (Money)this);
    }
}