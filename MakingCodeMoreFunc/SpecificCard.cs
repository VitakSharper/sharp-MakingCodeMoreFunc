﻿using System;

namespace MakingCodeMoreFunc
{
    public class SpecificCard : SpecificMoney
    {
        private BankCard Card { get; }

        public SpecificCard(Currency currency, BankCard card) : base(currency)
        {
            this.Card = card ?? throw new ArgumentNullException(nameof(card));
        }

        public override Money On(Timestamp time) =>
            new SpecificCard(this.Currency, this.Card.CardOn(time));

        //public override (Amount taken, Money remaining) Take(decimal amount) =>
        //    this.Card.Take(base.Currency, amount);
        public override (Amount taken, Money remaining) Take(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}