namespace MakingCodeMoreFunc
{
    public abstract class Money
    {
        public abstract SpecificMoney Of(Currency currency);
        public abstract decimal Withdraw(Currency currency, decimal amount);
    }

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

    public class Empty : SpecificMoney
    {
        public Empty(Currency currency)
            : base(currency)
        {
        }

        public override decimal Withdraw(Currency currency, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}