using System;

namespace MoreObjectOriented.AccountState
{
    public class Active : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => this;

        public IFreezable Withdraw() => this;

        public IFreezable Freeze() => new Frozen(OnUnfreeze);
    }
}