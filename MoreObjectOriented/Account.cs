using MoreObjectOriented.AccountState;
using System;

namespace MoreObjectOriented
{
    public class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private IFreezable Freezable { get; set; }

        public Account(Action onUnfreeze)
        {
            Freezable = new Active(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed) return;
            // Deposit money;
            Freezable = Freezable.Deposit();
            Balance += amount;
        }


        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            Freezable = Freezable.Withdraw();
            Balance -= amount;
            // Withdraw money;
        }


        public void HolderVerified()
        {
            IsVerified = true;
        }

        public void Close()
        {
            IsClosed = true;
        }

        public void Freeze()
        {
            if (IsClosed) return; // Account must not be closed;
            if (!IsVerified) return; // Account must be verified;
            Freezable = Freezable.Freeze();
        }
    }
}