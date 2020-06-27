namespace MakingCodeMoreFunc
{
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