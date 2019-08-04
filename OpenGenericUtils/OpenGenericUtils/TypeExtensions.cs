using System;
using System.Collections.Generic;

using Instantiations = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;


namespace OpenGenericUtils {
    public static class TypeExtensions {

        public static IType ToIType(this Type type)
            => TypeExtensions.ToIType(type, new Dictionary<Type, IType>());
        public static IType ToIType(this Type type, Instantiations instantiations) => throw new NotImplementedException();

    }
}
