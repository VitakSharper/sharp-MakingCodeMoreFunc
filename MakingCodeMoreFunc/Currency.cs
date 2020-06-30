using System;

namespace MakingCodeMoreFunc
{
    // implement IEquatable<T> if you know the type to overload;
    // sealed to not extend a value type;
    // see pic2.JPG
    public sealed class Currency : IEquatable<Currency>
    {
        public string Symbol { get; }

        private Currency(string symbol)
        {
            Symbol = symbol;
        }

        public static Currency USD => new Currency("USD");
        public static Currency EUR => new Currency("EUR");
        public static Currency JPY => new Currency("JPY");

        // operators is & as failed on runtime, operators && failed on compile time;
        public override bool Equals(object obj) =>
            Equals(obj as Currency);

        public bool Equals(Currency other) =>
            other != null && Symbol == other.Symbol;

        // !! Importance of overriding the GetHashCode();
        // Always returns the same result from a given object;
        // Equal objects must return equal hash codes;
        // Hash code can only depend on components used in Equals();
        // GetHashCode() of components must satisfy all the rules, too;
        public override int GetHashCode() => Symbol.GetHashCode();
        // example if need to add other components, use ^ sign;
        // public override int GetHashCode() => Symbol.GetHashCode() ^ otherComponent.GetHashCode();

        // if you overload the equality operator you must overload the inequality operator too;
        public static bool operator ==(Currency a, Currency b) =>
            object.ReferenceEquals(a, null)
                ? object.ReferenceEquals(b, null)
                : a.Equals(b);

        public static bool operator !=(Currency a, Currency b) => !(a == b);

        public override string ToString() => Symbol;
    }
}