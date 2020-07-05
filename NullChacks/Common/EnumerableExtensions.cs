using System;
using System.Collections.Generic;

namespace NullChecks.Common
{
    // Beware of accidental introduction of costly operations; This ToList() call requires O(n) memory;
    // Sequence itself might require O(1) only;
    public static class EnumerableExtensions
    {
        public static void Do<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T obj in sequence)
                action(obj);
        }
    }
}