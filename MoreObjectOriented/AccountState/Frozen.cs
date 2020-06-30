using System;

namespace MoreObjectOriented.AccountState
{
    public class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }


        public IAccountState Deposit(Action addToBalance)
        {
            OnUnfreeze();
            addToBalance();
            return new Active(OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            OnUnfreeze();
            subtractFromBalance();
            return new Active(OnUnfreeze);
        }

        public IAccountState Freeze() => this;
        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}