using System;
using System.Collections.Generic;

namespace OpenGenericUtils {
    public static class IReadOnlyDictionaryExtensions {

        public static IReadOnlyDictionary<TKey, TValue> AddNewKeysFrom<TKey, TValue>(
                this IReadOnlyDictionary<TKey, TValue> self,
                IReadOnlyDictionary<TKey, TValue> other)
            => throw new NotImplementedException();

        }
}
