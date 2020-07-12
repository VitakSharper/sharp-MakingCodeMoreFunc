using NullChecks.Common;
using System;
using System.Collections.Generic;

namespace NullChecks
{
    // Avoid branching over Boolean conditions calculated from the object's state; Make polymorphic calls on the state object instead;
    // Used in this class - Null object pattern, Special case pattern, State pattern, Strategy pattern;
    // Not used in this class - Branching instructions, Null references;
    // Optional objects - Handle cases where Null Object and Special Case are not applicable;
    // Object substitution eliminates branching based on object state; It cannot remove branching over method arguments;

    // Avoid using enumerations; They only represent state; In OO design we want state and behavior;
    //[Flags]
    //enum DeviceStatus
    //{
    //    AllFine = 0,
    //    NotOperational = 1,
    //    VisiblyDamaged = 2,
    //    CircuitryFailed = 4
    //}

    // Substitute collaborating objects at run time;
    // Use substitution ot modify behavior;
    // Do not modify behavior by modifying code;
    // Move complicated code into separate classes;


    internal class SoldArticle
    {
        private IWarranty MoneyBackGuarantee { get; }

        //public IWarranty ExpressWarranty { get; }
        private IWarranty NotOperationalWarranty { get; }
        private Option<Part> Circuitry { get; set; } = Option<Part>.None();
        private IWarranty FailedCircuitryWarranty { get; set; }
        private IWarranty CircuitryWarranty { get; set; }
        private DeviceStatus OperationalStatus { get; set; }
        private IReadOnlyDictionary<DeviceStatus, Action<Action>> WarrantyMap { get; set; }


        public SoldArticle(IWarranty moneyBack, IWarranty express, IWarrantyMapFactory rulesFactory)
        {
            MoneyBackGuarantee = moneyBack ?? throw new ArgumentNullException(nameof(moneyBack));
            NotOperationalWarranty = express ?? throw new ArgumentNullException(nameof(express));

            //ExpressWarranty = VoidWarranty.Instance;
            CircuitryWarranty = VoidWarranty.Instance;
            OperationalStatus = DeviceStatus.AllFine();
            WarrantyMap = rulesFactory.Create(
                ClaimMoneyBack, ClaimOperationalWarranty, ClaimCircuitryWarranty);
        }

        private void ClaimOperationalWarranty(Action obj)
        {
            throw new NotImplementedException();
        }

        private void ClaimMoneyBack(Action obj)
        {
            throw new NotImplementedException();
        }

        //public void VisibleDamage() => MoneyBackGuarantee = VoidWarranty.Instance;
        public void VisibleDamage()
        {
            OperationalStatus = OperationalStatus.WithVisibleDamage();
        }

        public void NotOperational()
        {
            OperationalStatus = OperationalStatus.NotOperational();
            //MoneyBackGuarantee = VoidWarranty.Instance;
            //ExpressWarranty = NotOperationalWarranty;
        }


        public void Repaired()
        {
            OperationalStatus = OperationalStatus.Repaired();
        }

        // switch instruction jumps in O(1) time;
        // switch only supports trivial values; it not applicable to objects;

        public void ClaimWarranty(Action onValidClaim)
        {
            WarrantyMap[OperationalStatus].Invoke(onValidClaim);
        }


        // Easiest way to implement Optional Object is to implement as a collection;
        public void CircuitryNotOperational(DateTime detectedOn)
        {
            Circuitry
                .WhenSome()
                .Do(c =>
                {
                    c.MarkDefective(detectedOn);
                    OperationalStatus = OperationalStatus.CircuitryFailed();
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
            OperationalStatus = OperationalStatus.CircuitryReplaced();
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