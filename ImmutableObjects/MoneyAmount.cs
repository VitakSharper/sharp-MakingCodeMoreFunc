using System;

namespace ImmutableObjects
{
    // Impossible to reproduce aliasing bug on an immutable object;
    internal sealed class MoneyAmount : IEquatable<MoneyAmount>
    {
        public decimal Amount { get; }
        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            Amount = amount;
            CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor) =>
            new MoneyAmount(Amount * factor, CurrencySymbol);

        // Avoid to overloads operator and let consumers rely on proper method calls;
        public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => 
            amount.Scale(factor);

        // obj can be a different object than MoneyAmount , let cast it to MoneyAmount;
        public override bool Equals(object obj) =>
            Equals(obj as MoneyAmount);

        // Value-typed equality - Two objects are equal if their types are the same and their contained values are the same;
        public bool Equals(MoneyAmount other) =>
            other != null &&
            Amount == other.Amount &&
            CurrencySymbol == other.CurrencySymbol;

        // Whenever you override Equals() method, you have to override GetHashCode() as well;
        // ^ OR exclusive XOR
        public override int GetHashCode() =>
            Amount.GetHashCode() ^ CurrencySymbol.GetHashCode();

        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            (ReferenceEquals(a, null) && ReferenceEquals(b, null)) ||
            (!ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) => !(a == b);

        public override string ToString() => $"{Amount} {CurrencySymbol}";
    }
}