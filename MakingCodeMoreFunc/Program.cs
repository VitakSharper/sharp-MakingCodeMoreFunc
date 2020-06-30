using System;
using System.Collections.Generic;

namespace MakingCodeMoreFunc
{
    internal static class Program
    {
        private static void Main()
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


            //var amt = new Amount(Currency.USD, 100);

            //Console.WriteLine($"Have {amt}: ");
            // deconstructing into two variables
            // use _ to discard a component you don't need
            //(Amount taken, _) = amt.Of(Currency.USD).Take(50);
            //Console.WriteLine($"can take {taken}");

            IDictionary<Currency, Money> moneys = new Dictionary<Currency, Money>();

            Money money = new Amount(Currency.USD, 100);
            moneys.Add(Currency.USD, money);
            Console.WriteLine($"Added {money}");

            Console.WriteLine(moneys.ContainsKey(Currency.USD)
                ? $"Found {moneys[Currency.USD]}"
                : $"{Currency.USD} not found.");
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