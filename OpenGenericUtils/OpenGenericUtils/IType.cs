using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenGenericUtils
{
    public interface IType {

        IType Simplify();
        IType Simplify(IReadOnlyDictionary<Type, IType> fixedParameters);

        bool IsConstructibleFrom(params IType[] parameters);
        ConstructorInfo GetConstructor(params IType[] parameters);

        IDictionary<Type, IType> UnifyWith(IType other);

        bool IsAssignableFrom(IType other);
        bool IsEquivalentTo(IType other);

        IType[] Parents { get; }

    }
}
