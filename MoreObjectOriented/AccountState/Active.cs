using System;

// State pattern consequences
// No more branching;
// Runtime type of the state object replaces branching;
// Dynamic dispatch used to choose one implementation or the other; 

namespace MoreObjectOriented.AccountState
{
    public class Active : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Freeze() => new Frozen(OnUnfreeze);
        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}