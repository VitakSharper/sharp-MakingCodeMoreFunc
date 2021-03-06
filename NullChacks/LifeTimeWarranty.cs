﻿using System;

namespace NullChecks
{
    // Special Case pattern
    // Provide an object which universally addresses one situation;
    // Special Case object contains no specific information;
    // Unlike Null Objects, they contain some logic;
    internal class LifeTimeWarranty : IWarranty
    {
        private DateTime IssuingDate { get; }

        public LifeTimeWarranty(DateTime issuingDate)
        {
            IssuingDate = issuingDate.Date;
        }

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate)) return;
            onValidClaim();
        }

        private bool IsValidOn(DateTime date) => date.Date >= IssuingDate;
    }
}