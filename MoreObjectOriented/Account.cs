using MoreObjectOriented.AccountState;
using System;

// Turning Account class to Single Responsibility Principle - SRP;
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