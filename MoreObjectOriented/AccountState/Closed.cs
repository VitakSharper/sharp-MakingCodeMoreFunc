namespace MoreObjectOriented.AccountState
{
    public class Closed : IAccountState
    {
        public IAccountState Deposit() => this;

        public IAccountState Withdraw() => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}