using System;

// Try to invent classes that support both real and imaginary concepts; That is how you invent abstractions;

namespace DomainLogicSequences
{
    class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double DollarsPerHour { get; set; }
        public bool IsAvailable => true;

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeSpan.FromHours(TimePerSqMeter.TotalHours * sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * DollarsPerHour;
    }
}