using NullChecks.Common;
using System;

namespace NullChecks
{
    // Avoid branching over Boolean conditions calculated from the object's state; Make polymorphic calls on the state object instead;
    // Used in this class - Null object pattern, Special case pattern, State pattern, Strategy pattern;
    // Not used in this class - Branching instructions, Null references;
    // Optional objects - Handle cases where Null Object and Special Case are not applicable;
    // Object substitution eliminates branching based on object state; It cannot remove branching over method arguments;
    [Flags]
    enum DeviceStatus
    {
        AllFine = 0,
        NotOperational = 1,
        VisiblyDamaged = 2,
        CircuitryFailed = 4
    }

    internal class SoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; }

        //public IWarranty ExpressWarranty { get; }
        private IWarranty NotOperationalWarranty { get; }
        private Option<Part> Circuitry { get; set; } = Option<Part>.None();
        private IWarranty FailedCircuitryWarranty { get; set; }
        private IWarranty CircuitryWarranty { get; set; }
        public DeviceStatus OperationalStatus { get; set; }


        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            MoneyBackGuarantee = moneyBack ?? throw new ArgumentNullException(nameof(moneyBack));
            NotOperationalWarranty = express ?? throw new ArgumentNullException(nameof(express));

            //ExpressWarranty = VoidWarranty.Instance;
            CircuitryWarranty = VoidWarranty.Instance;
        }

        //public void VisibleDamage() => MoneyBackGuarantee = VoidWarranty.Instance;
        public void VisibleDamage()
        {
            OperationalStatus |= DeviceStatus.VisiblyDamaged;
        }

        public void NotOperational()
        {
            OperationalStatus |= DeviceStatus.NotOperational;
            //MoneyBackGuarantee = VoidWarranty.Instance;
            //ExpressWarranty = NotOperationalWarranty;
        }

        public void Repaired()
        {
            OperationalStatus &= ~DeviceStatus.NotOperational; 
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            switch (OperationalStatus)
            {
                case DeviceStatus.AllFine:
                    MoneyBackGuarantee.Claim(DateTime.Now, onValidClaim);
                    break;
                case DeviceStatus.NotOperational:
                case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged:
                case DeviceStatus.NotOperational | DeviceStatus.CircuitryFailed:
                case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged | DeviceStatus.CircuitryFailed:
                    NotOperationalWarranty.Claim(DateTime.Now, onValidClaim);
                    break;
                case DeviceStatus.VisiblyDamaged:
                    break;
                case DeviceStatus.CircuitryFailed:
                case DeviceStatus.VisiblyDamaged | DeviceStatus.CircuitryFailed:
                    Circuitry
                        .WhenSome()
                        .Do(c => CircuitryWarranty.Claim(DateTime.Now, onValidClaim))
                        .Execute();
                    break;
            }
        }


        // Easiest way to implement Optional Object is to implement as a collection;
        public void CircuitryNotOperations(DateTime detectedOn)
        {
            Circuitry
                .WhenSome()
                .Do(c =>
                {
                    c.MarkDefective(detectedOn);
                    OperationalStatus |= DeviceStatus.CircuitryFailed;
                })
                .Execute();
            //Circuitry.Do(circuitry => // if null (no objects in the List) then ForEach not executed
            //    {
            //        circuitry.MarkDefective(detectedOn); // These call may end in NullReferenceException
            //        CircuitryWarranty = FailedCircuitryWarranty;
            //    }
            //);
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            FailedCircuitryWarranty = extendedWarranty;
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            Circuitry.Do(circuitry =>
                    CircuitryWarranty.Claim(circuitry.DefectDetectedOn,
                        onValidClaim) // These call may end in NullReferenceException; Circuitry object might be null;
            );
        }
    }
}