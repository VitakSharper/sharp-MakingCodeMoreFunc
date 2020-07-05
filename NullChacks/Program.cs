using NullChecks.Common;
using System;

namespace NullChecks
{
    internal static class Program
    {
        // Beware of Boolean method arguments; Their appearance is the indication of leaving the OO design principles;
        // Tell the objects what to do; Let them decide how to do it; With Boolean flags its the client who has to decide how to perform operations;
        // Rules of good OO design - Object keeps track of its state; Object doesn't return null from its methods;
        // Avoiding null references Devise an object that will stand in place of a null;
        // Substitute object must behave exactly as the proper object;
        // Don't branch over null tests; Substitute objects to choose one execution path or the other;
        // Start from the feature consumer; Let the consumer define which calls it would like to make;
        // Don't start from the feature provider. It might not understand caller's needs well;
        static void ClaimWarranty(SoldArticle article)
        {
            var now = DateTime.Now;

            article.MoneyBackGuarantee.Claim(now, () =>
                Console.WriteLine("Offer money back."));

            article.ExpressWarranty.Claim(now, () => Console.WriteLine("Offer repair."));
        }

        private static void Main()
        {
            //var sellingDate = new DateTime(2020, 1, 10);
            //var moneyBackSpan = TimeSpan.FromDays(30);
            //var warrantySpan = TimeSpan.FromDays(365);

            //IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            //IWarranty warranty = new LifeTimeWarranty(sellingDate);

            //var goods = new SoldArticle(VoidWarranty.Instance, warranty);
            //ClaimWarranty(goods);

            Option<string> name = Option<string>.Some("SomeName");

            //name
            //    .When(s => s.Length > 3).Do(s => Console.WriteLine($"{s} long"))
            //    .WhenSome().Do(s => Console.WriteLine($"{s} short"))
            //    .WhenNone().Do(() => Console.WriteLine("missing"))
            //    .Execute();

            //var label =
            //    name
            //        .When(s => s.Length > 3).MapTo(s => s.Substring(0, 3) + ".")
            //        .WhenSome().MapTo(s => s)
            //        .WhenNone().MapTo("<empty>")
            //        .Map();
        }
    }
}