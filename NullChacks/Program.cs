using System;

namespace NullChecks
{
    internal static class Program
    {
        // Beware of Boolean method arguments; Their appearance is the indication of leaving the OO design principles;
        // Tell the objects what to do; Let them decide how to do it; With Boolean flags its the client who has to decide how to perform operations;
        static void ClaimWarranty(SoldArticle article, bool isInGoodCondition, bool isBroken)
        {
            var now = DateTime.Now;

            if (isInGoodCondition && !isBroken &&
                article.MoneyBackGuarantee != null &&
                article.MoneyBackGuarantee.IsValidOn(now))
            {
                Console.WriteLine("Offer money back.");
            }

            if (isBroken && article.ExpressWarranty != null &&
                article.ExpressWarranty.IsValidOn(now))
            {
                Console.WriteLine("Offer repair.");
            }
        }

        private static void Main()
        {
        }
    }
}