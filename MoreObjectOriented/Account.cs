using MoreObjectOriented.AccountState;
using System;

// Turning Account class to Single Responsibility Principle - SRP;
// Each class is doing one thing;
// One new requirement means one new class will be added;
// New requirement doesn't require an existing class to change;
// Benefits of the State pattern;
// Class that uses states becomes simple;
// It can focus on its primary role;
// Other roles are delegated to concrete state classes;
// Each concrete class is simple;

namespace MoreObjectOriented
{
    public class Account
    {
        public decimal Balance { get; private set; }

        private IAccountState State { get; set; }

        public Account(Action onUnfreeze)
        {
            State = new NotVerified(onUnfreeze);
        }

        // Turn to callback pattern;
        public void Deposit(decimal amount) =>
            State = State.Deposit((() => { Balance += amount; }));


        public void Withdraw(decimal amount) =>
            State = State.Withdraw((() => { Balance -= amount; }));


        public void HolderVerified() =>
            State = State.HolderVerified();

        public void Close() =>
            State = State.Close();

        public void Freeze() =>
            State = State.Freeze();
    }
}