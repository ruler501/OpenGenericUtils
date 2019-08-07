using System.Collections.Generic;
using System.Reflection;

namespace OpenGenericUtils {
    public interface IType : IGeneric {

        bool                 Constructible                  { get; }
        bool                 Class                          { get; }
        bool                 New                            { get; }
        bool                 Struct                         { get; }
        IEnumerable<IType[]> AvailableConstructorParamLists { get; }
        IEnumerable<IType>   Implements                     { get; }


        UnifyBinaryResult UnifyAsAssignableFrom(IGeneric other);

        bool ConstructibleWith(params IType[]                                 parameters);
        UnifiedObject ConstructWith(params object[]                           parameters);
        UnifiedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters);
        UnifiedConstructorInfo GetConstructor(params IType[]                  parameters);

        bool IsInstance(object obj);

    }
}