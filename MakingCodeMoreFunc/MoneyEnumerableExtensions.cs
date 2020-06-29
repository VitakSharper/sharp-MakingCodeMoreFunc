using System.Collections.Generic;
using System.Linq;

namespace MakingCodeMoreFunc
{
    public static class MoneyEnumerableExtensions
    {
        public static IEnumerable<Money> On(this IEnumerable<Money> moneys, Timestamp time) =>
            moneys.Select(m => m.On(time));

        public static IEnumerable<SpecificMoney> Of(this IEnumerable<SpecificMoney> moneys, Currency currency) =>
            moneys.Select(m => m.Of(currency));

        public static IEnumerable<(Amount, Money)> Take(this IEnumerable<SpecificMoney> moneys, decimal amount)
        {
            decimal rest = amount;
            foreach (var money in moneys)
            {
                (Amount, Money) current = money.Take(rest);
                yield return current;
                rest -= current.Item1.Value;
            }
        }
    }
}