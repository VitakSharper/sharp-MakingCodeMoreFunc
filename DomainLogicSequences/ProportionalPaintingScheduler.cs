using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLogicSequences
{
    // Don't change existing classes when a requirement is changed or added;
    // Add one more class to the design instead;
    // Replace objects at run time to select one implementation or the other;
    class ProportionalPaintingScheduler : IPaintingScheduler<ProportionalPainter>
    {
        public IEnumerable<PaintingTask<ProportionalPainter>> Schedule(double sqMeters,
            IEnumerable<ProportionalPainter> painters)
        {
            IEnumerable<Tuple<ProportionalPainter, double>> velocities =
                painters
                    .Select(painter =>
                        Tuple.Create(painter, sqMeters / painter.EstimateTimeToPaint(sqMeters).TotalHours))
                    .ToList();

            var totalVelocity = velocities.Sum(tuple => tuple.Item2);

            IEnumerable<PaintingTask<ProportionalPainter>> schedule =
                velocities
                    .Select(tuple =>
                        new PaintingTask<ProportionalPainter>(
                            tuple.Item1, sqMeters * tuple.Item2 / totalVelocity))
                    .ToList();

            return schedule;
        }
    }
}