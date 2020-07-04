using System;

namespace NullChecks
{
    internal class SoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; }
        public IWarranty ExpressTimeLimitedWarranty { get; }

        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            MoneyBackGuarantee = moneyBack ?? throw new ArgumentNullException(nameof(moneyBack));
            ExpressTimeLimitedWarranty = express ?? throw new ArgumentNullException(nameof(express));
        }
    }
}