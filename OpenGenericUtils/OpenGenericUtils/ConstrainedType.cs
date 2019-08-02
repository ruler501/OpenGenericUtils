using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenGenericUtils
{
    class ConstrainedType : IType {

        public IType[] Parents {
            get {
                throw new NotImplementedException();
            }
        }

        public ConstructorInfo GetConstructor(params IType[] parameters) => throw new NotImplementedException();
        public bool IsAssignableFrom(IType other) => throw new NotImplementedException();
        public bool IsConstructibleFrom(params IType[] parameters) => throw new NotImplementedException();
        public bool IsEquivalentTo(IType other) => throw new NotImplementedException();
        public IType Simplify() => throw new NotImplementedException();
        public IType Simplify(IReadOnlyDictionary<Type, IType> fixedParameters) => throw new NotImplementedException();
        public IDictionary<Type, IType> UnifyWith(IType other) => throw new NotImplementedException();

    }
}
