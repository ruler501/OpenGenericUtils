using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Text;

namespace OpenGenericUtils {
    public static class IReadOnlyDictionaryExtensions {

        public static IReadOnlyDictionary<TKey, TValue> Update<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> self,
                                                                           IReadOnlyDictionary<TKey, TValue> other)
            => throw new NotImplementedException();

        }
}
