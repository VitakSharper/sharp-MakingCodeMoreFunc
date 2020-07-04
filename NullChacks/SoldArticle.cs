namespace NullChecks
{
    internal class SoldArticle
    {
        public Warranty MoneyBackGuarantee { get; }
        public Warranty ExpressWarranty { get; }

        public SoldArticle(Warranty moneyBackGuarantee, Warranty expressWarranty)
        {
            MoneyBackGuarantee = moneyBackGuarantee;
            ExpressWarranty = expressWarranty;
        }
    }
}