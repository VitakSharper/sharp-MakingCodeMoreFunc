using System;
using System.Collections.Generic;
using System.Linq;

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
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    // Selection - Standard query operation which filters out unwanted elements;
                    .Where(painter => painter.IsAvailable)
                    // Aggregate function - Takes a sequence and returns a single value or object;
                    .OrderBy(painter => painter.EstimateCompensation(sqMeters))
                    .FirstOrDefault();
        }

        static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}