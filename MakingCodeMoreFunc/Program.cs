namespace MakingCodeMoreFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            //var card = new BankCardTest
            //{
            //    ValidBefore = DateTime.Now.AddSeconds(2),
            //    Balance = 200
            //};

            //decimal available1 = card.GetAvailableAmount(20);

            //card.Balance = 17;
            //decimal available2 = card.GetAvailableAmount(20);

            //Thread.Sleep(3000);
            //decimal available3 = card.GetAvailableAmount(20);
        }
    }

    //class BankCardTest
    //{
    //    public DateTime ValidBefore { get; }
    //    public decimal Balance { get; }

    //    public BankCardTest(DateTime validBefore, decimal balance)
    //    {
    //        ValidBefore = validBefore;
    //        Balance = balance;
    //    }

    //    public decimal GetAvailableAmount(decimal desired, DateTime at) =>
    //        at.CompareTo(ValidBefore) >= 0
    //            ? 0
    //            : Math.Min(Balance, desired);
    //}
}