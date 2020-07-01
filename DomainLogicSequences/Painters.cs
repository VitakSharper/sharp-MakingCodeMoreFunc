using System.Collections.Generic;
using System.Linq;

namespace DomainLogicSequences
{
    public class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters) =>
            ContainedPainters = painters.ToList();

        public Painters GetAvailable() =>
            new Painters(ContainedPainters.Where(painter => painter.IsAvailable));

        public IPainter GetCheapestOne(double sqMeters) =>
            ContainedPainters.WithMinimum(painter => painter.EstimateCompensation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            ContainedPainters.WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
    }
}