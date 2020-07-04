using System;

namespace NullChecks
{
    internal class TimeLimitedWarranty : IWarranty
    {
        private DateTime DateIssued { get; }
        private TimeSpan Duration { get; }

        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            Duration = duration;
            DateIssued = dateIssued;
        }

        public bool IsValidOn(DateTime date) =>
            date.Date >= DateIssued && date.Date < DateIssued + Duration;
    }
}