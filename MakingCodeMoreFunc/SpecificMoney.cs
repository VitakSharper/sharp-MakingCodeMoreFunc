namespace MakingCodeMoreFunc
{
    public abstract class SpecificMoney : Money
    {
        public Currency Currency { get; }

        protected SpecificMoney(Currency currency)
        {
            Currency = currency;
        }

        public override SpecificMoney Of(Currency currency) =>
            currency.Equals(Currency)
                ? this
                : new Empty(currency);
    }
}