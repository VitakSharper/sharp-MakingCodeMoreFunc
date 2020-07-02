using System.Collections.Generic;

namespace DomainLogicSequences
{
    internal static class Program
    {
        // Bad Bad Bad!!!
        //private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        //{
        //    double bestPrice = 0;
        //    IPainter cheapest = null;

        //    foreach (var painter in painters)
        //    {
        //        if (painter.IsAvailable)
        //        {
        //            var price = painter.EstimateCompensation(sqMeters);
        //            if (cheapest == null || price < bestPrice)
        //            {
        //                cheapest = painter;
        //            }
        //        }
        //    }

        //    return cheapest;
        //}

        // Sequence - A set of objects which follow each other in an order;
        // IEnumerable<T> defines a sequence. We intentionally avoid more detailed collection types;
        //                doesn't obligate its user to know the data structure;
        // If talking about painters, avoid presenting IEnumerable<Painter>;
        // Avoid artificial mapping between spoken language and code;
        // We speak of painters and see the type named Painters;
        // !!! Do not go open the Painters class and start coding it; Design the consuming end first!;


        static void Main()
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];

            var painter = CompositePainterFactories.CombineProportional(painters);
        }
    }
}