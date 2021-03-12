using System;
using System.Collections.Generic;

namespace CloudNativeApplicationComponents.Utils
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            _ = collection
                ?? throw new ArgumentNullException(nameof(collection));
            _ = action
                ?? throw new ArgumentNullException(nameof(action));

            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            _ = collection
                   ?? throw new ArgumentNullException(nameof(collection));
            _ = action
                ?? throw new ArgumentNullException(nameof(action));

            var i = 0;
            foreach (var item in collection)
            {
                action(i, item);
                i++;
            }
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));

            TValue value = default;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = dictionary[key] = func(key);
            }
            return value;
        }
    }
}
