using System;

namespace MoreObjectOriented.AccountState
{
    public class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(OnUnfreeze);

        public IAccountState Close() => new Closed();
    }
}