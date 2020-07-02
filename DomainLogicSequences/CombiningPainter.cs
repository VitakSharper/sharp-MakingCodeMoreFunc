using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLogicSequences
{
    // If code has suddenly become simple, then you have probably found a good abstraction;
    public class CombiningPainter<TPainter> : CompositePainter<TPainter>
        where TPainter : IPainter
    {
        private IPaintingScheduler<TPainter> Scheduler { get; }

        public CombiningPainter(
            IEnumerable<TPainter> painters,
            IPaintingScheduler<TPainter> scheduler)
            : base(painters)
        {
            Scheduler = scheduler;
            Reduce = Combine;
        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            var availablePainters = painters.Where(painter => painter.IsAvailable);

            var schedule = Scheduler.Schedule(sqMeters, availablePainters);

            var time = schedule.Max(task => task.Painter.EstimateTimeToPaint(task.SquareMeters));

            var cost = schedule.Sum(task => task.Painter.EstimateCompensation(task.SquareMeters));

            return new ProportionalPainter
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}