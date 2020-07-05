using System;

namespace NullChecks
{
    public class Part
    {
        public DateTime InstallmentDate { get; }
        public DateTime DefectDetectedOn { get; set; }


        public Part(DateTime installmentDate)
        {
            InstallmentDate = installmentDate;
        }

        public void MarkDefective(DateTime withDate)
        {
            DefectDetectedOn = withDate;
        }
    }
}