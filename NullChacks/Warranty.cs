using System;

namespace NullChecks
{
    internal class Warranty
    {
        private DateTime DateIssued { get; }
        private TimeSpan Duration { get; }

        public Warranty(TimeSpan duration, DateTime dateIssued)
        {
            Duration = duration;
            DateIssued = dateIssued;
        }

        public bool IsValidOn(DateTime date) =>
            date.Date >= DateIssued && date.Date < DateIssued + Duration;
    }
}