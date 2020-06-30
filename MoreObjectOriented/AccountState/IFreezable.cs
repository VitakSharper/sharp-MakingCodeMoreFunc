namespace MoreObjectOriented.AccountState
{
    public interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();
    }
}