using System;
using System.Collections.Generic;

namespace NullChecks
{
    // Avoid branching over Boolean conditions calculated from the object's state; Make polymorphic calls on the state object instead;
    // Used in this class - Null object pattern, Special case pattern, State pattern, Strategy pattern;
    // Not used in this class - Branching instructions, Null references;
    // Optional objects - Handle cases where Null Object and Special Case are not applicable;
    // Object substitution eliminates branching based on object state; It cannot remove branching over method arguments;
    internal class SoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        private IWarranty NotOperationalWarranty { get; }
        private List<Part> Circuitry { get; set; } = new List<Part>();
        private IWarranty FailedCircuitryWarranty { get; set; }
        private IWarranty CircuitryWarranty { get; set; }

        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            MoneyBackGuarantee = moneyBack ?? throw new ArgumentNullException(nameof(moneyBack));
            NotOperationalWarranty = express ?? throw new ArgumentNullException(nameof(express));

            ExpressWarranty = VoidWarranty.Instance;
            CircuitryWarranty = VoidWarranty.Instance;
        }

        public void VisibleDamage() => MoneyBackGuarantee = VoidWarranty.Instance;

        public void NotOperational()
        {
            MoneyBackGuarantee = VoidWarranty.Instance;
            ExpressWarranty = NotOperationalWarranty;
        }

        // Easiest way to implement Optional Object is to implement as a collection;
        public void CircuitryNotOperations(DateTime detectedOn)
        {
            Circuitry.ForEach(circuitry => // if null (no objects in the List) then ForEach not executed
                {
                    circuitry.MarkDefective(detectedOn); // These call may end in NullReferenceException
                    CircuitryWarranty = FailedCircuitryWarranty;
                }
            );
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = new List<Part>() { circuitry };
            FailedCircuitryWarranty = extendedWarranty;
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            Circuitry.ForEach(circuitry =>
                    CircuitryWarranty.Claim(circuitry.DefectDetectedOn,
                        onValidClaim) // These call may end in NullReferenceException; Circuitry object might be null;
            );
        }
    }
}