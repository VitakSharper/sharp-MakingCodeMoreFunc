using System;

namespace MoreObjectOriented
{
    public class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }
        private Action OnUnfreeze { get; }

        public Account(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed) return;
            // Deposit money;
            ManageUnfreezing();

            Balance += amount;
        }


        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            ManageUnfreezing();
            Balance -= amount;
            // Withdraw money;
        }

        private void ManageUnfreezing()
        {
            if (IsFrozen)
            {
                IsFrozen = false;
                OnUnfreeze();
            }
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
            IsFrozen = true;
        }
    }
}