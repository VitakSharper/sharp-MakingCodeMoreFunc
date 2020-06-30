using System;

namespace MoreObjectOriented
{
    public class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }

        public Account(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
            ManageUnfreezing = StayUnfrozen;
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


        private void StayUnfrozen()
        {
        }

        private void Unfreeze()
        {
            OnUnfreeze();
            ManageUnfreezing = StayUnfrozen;
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
            ManageUnfreezing = Unfreeze;
        }
    }
}