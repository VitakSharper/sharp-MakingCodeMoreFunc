namespace MakingCodeMoreFunc
{
    public abstract class Money
    {
        // Filter by time
        public abstract Money On(Timestamp time);

        // Filter by currency
        public abstract SpecificMoney Of(Currency currency);
    }
}