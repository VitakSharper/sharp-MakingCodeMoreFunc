using System;

namespace MakingCodeMoreFunc
{
    public abstract class SpecificMoney : Money
    {
        public Currency Currency { get; }

        protected SpecificMoney(Currency currency)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        // Functional Object Filter, Isolated,Reusable,Will never change;

        /// <summary>
        /// Filters money object by currency
        /// Overloading the Equality and Inequality operators
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override SpecificMoney Of(Currency currency) =>
            currency == Currency
                ? this
                : new Empty(currency);


        /// <summary>
        /// receives the amount to take from the Money object 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>a tuple of Amount taken and Remaining money</returns>
        public abstract (Amount taken, Money remaining) Take(decimal amount);
    }
}