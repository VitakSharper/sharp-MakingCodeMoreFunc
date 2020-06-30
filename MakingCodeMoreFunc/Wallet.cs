using System;
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

        private (Amount paid, Money remaining) Pay(Money money, Amount remainder)
        {
            var now = Timestamp.Now;
            switch (money)
            {
                case Amount amt when amt.Currency != remainder.Currency:
                    return (Amount.Zero(remainder.Currency), money);
                case Amount amt when amt.Value <= remainder.Value:
                    return (new Amount(amt.Currency, amt.Value), Amount.Zero(amt.Currency));
                case GiftCard gift when gift.Currency != remainder.Currency:
                    return (Amount.Zero(remainder.Currency), gift);
                case GiftCard gift when gift.ValidBefore.CompareTo(now) < 0:
                    return (Amount.Zero(remainder.Currency), Amount.Zero(gift.Currency));
                case GiftCard gift when gift.Value <= remainder.Value:
                    return (new Amount(gift.Currency, gift.Value), Amount.Zero(gift.Currency));
                case Amount amt:
                    return (remainder, amt.Subtract(remainder));
                case BankCard card when card.ValidBefore.CompareTo(now) < 0:
                    return (Amount.Zero(remainder.Currency), Amount.Zero(remainder.Currency));
                case BankCard _:
                    return (remainder, money);
                default:
                    throw new ArgumentException("Money type not supported.");
            }
        }
    }
}