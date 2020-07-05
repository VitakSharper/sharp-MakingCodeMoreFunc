using System;

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
        private Part Circuitry { get; set; }
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

        public void CircuitryNotOperations(DateTime detectedOn)
        {
            if (Circuitry == null) return;
            Circuitry.MarkDefective(detectedOn); // These call may end in NullReferenceException
            CircuitryWarranty = FailedCircuitryWarranty;
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = circuitry;
            FailedCircuitryWarranty = extendedWarranty;
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            if (Circuitry == null) return;
            CircuitryWarranty.Claim(Circuitry.DefectDetectedOn,
                onValidClaim); // These call may end in NullReferenceException; Circuitry object might be null;
        }
    }
}