using System;

namespace MoreObjectOriented.AccountState
{
    public class Frozen : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }


        public IFreezable Deposit() =>
            new Active(OnUnfreeze);

        public IFreezable Withdraw() =>
            new Active(OnUnfreeze);

        public IFreezable Freeze() => this;
    }
}