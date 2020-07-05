using System.Collections;
using System.Collections.Generic;

namespace NullChecks.Common
{
    // Option (Maybe) type - Either contains value, or contains nothing; Option is not a wrapper around null;
    // Ensure that there is never more than one value;
    public class Option<T> : IEnumerable<T>
    {
        private IEnumerable<T> Content { get; }

        private Option(IEnumerable<T> content)
        {
            Content = content;
        }

        public static Option<T> Some(T value) => new Option<T>(new[] { value });

        public static Option<T> None() => new Option<T>(new T[0]);

        public IEnumerator<T> GetEnumerator() => Content.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}