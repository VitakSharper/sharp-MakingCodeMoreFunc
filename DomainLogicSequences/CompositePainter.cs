using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLogicSequences
{
    // Composite Pattern - Hides a collection of objects of certain type and exposes the same interface as a single object
    //                     of the same type;
    // Benefits from having a custom collection - The goal is to encapsulate the concept of a collection;
    //                                            Callers don't have to know how to manipulate objects;
    public class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
    {
        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        private IEnumerable<TPainter> Painters { get; }
        private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public CompositePainter(
            IEnumerable<TPainter> painters,
            Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            Reduce = reduce;
            Painters = painters.ToList();
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            Reduce(sqMeters, Painters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            Reduce(sqMeters, Painters).EstimateCompensation(sqMeters);
    }
}