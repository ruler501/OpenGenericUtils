using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenGenericUtils {
    public static class TypeExtensions {

        public static IType ToIType(this Type type) {
            if (type.IsGenericParameter) {
                return new ConstrainedParameterType(type, new Dictionary<Type, IType>());
            } else if (type.IsGenericType) {
                if (type.IsConstructedGenericType) {
                    return new ClosedType(type);
                } else {
                    return new PartiallyInstantiatedType(type, new Dictionary<Type, IType>());
                }
            } else {
                return new ClosedType(type);
            }
        }

        public static bool IsClosedType(this Type type)
            => !type.IsGenericParameter && !(type.IsGenericType && !type.IsConstructedGenericType);

        public static IType[] ToITypes(this Type[] types) => types.Select(TypeExtensions.ToIType).ToArray();

        public static IType[] GetITypeConstraints(this Type parameterType) {
            if (!parameterType.IsGenericParameter) {
                throw new ArgumentException("Must supply a GenericParameter type.", nameof(parameterType));
            }

            return parameterType.GetGenericParameterConstraints().ToITypes();
        }

    }
}
