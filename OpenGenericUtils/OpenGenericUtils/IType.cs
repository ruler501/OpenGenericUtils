using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenGenericUtils {
    public interface IType : IGeneric {

        bool Constructible { get; }
        IEnumerable<IType[]> AvailableConstructorParamLists { get; }

        bool ConstructibleWith(IType[] parameters);
        ConstructedObject ConstructWith(params object[] parameters);
        ConstructedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters);
        ConstructorInfo GetConstructor(params IType[] parameters);

        IType[] Implements { get; }

    }
}
