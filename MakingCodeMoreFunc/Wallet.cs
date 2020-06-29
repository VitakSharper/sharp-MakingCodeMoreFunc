using System.Collections.Generic;

namespace MakingCodeMoreFunc
{
    public class Wallet
    {
        public IList<Money> Content { get; set; } = new List<Money>();
        public void Add(Money money) => Content.Add(money);

        /// <summary>
        /// go to pic1.JPG
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Amount Charge(Currency currency, Amount toCharge)
        {
            //var split =
            //    Content
            //        .On(Timestamp.Now)
            //        .Of(toCharge.Currency)
            //        .Take(toCharge.Value)
            //        .ToList();

            //Content = split.Select(tuple => tuple.Item2).ToList();
            //var total = split.Sum(tuple => tuple.Item1.Value);
            //return new Amount(toCharge.Currency, total);
            return null;
        }
    }
}