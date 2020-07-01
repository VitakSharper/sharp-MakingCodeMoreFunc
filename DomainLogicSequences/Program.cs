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
        // IEnumerable<T> defines a sequence. We intentionally avoid more detailed collection types;
        //                doesn't obligate its user to know the data structure;
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters) =>
            painters
                // Selection - Standard query operation which filters out unwanted elements;
                .Where(painter => painter.IsAvailable)
                // Aggregate function - Takes a sequence and returns a single value or object;
                .WithMinimum(painter => painter.EstimateCompensation(sqMeters));

        private static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }

        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                    painters
                        .Where(painter => painter.IsAvailable)
                        .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum());

            double cost = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter =>
                    painter.EstimateCompensation(sqMeters) /
                    painter.EstimateTimeToPaint(sqMeters).TotalHours *
                    time.TotalHours)
                .Sum();

            return new ProportionalPainter
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }

        static void Main()
        {
        }
    }
}