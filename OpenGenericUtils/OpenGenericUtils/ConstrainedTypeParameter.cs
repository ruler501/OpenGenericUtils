using System;
using System.Collections.Generic;
using System.Reflection;

using Instantiations = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    class ConstrainedTypeParameter : IType {

        public ConstrainedTypeParameter(Type type, IType[] constraints,
                                        Instantiations instantiations) {
            this.Type = type;
            this.Constraints = constraints;
            this.Instantiations = instantiations;
        }

        public Type Type { get; }
        public IType[] Constraints { get; }
        public bool Constructible => false;
        public IEnumerable<IType[]> AvailableConstructorParamLists => throw new NotImplementedException();
        public IType[] Implements => throw new NotImplementedException();
        public IReadOnlyDictionary<Type, IType> Instantiations { get; }

        public bool ConstructibleWith(IType[] parameters) => false;
        public ConstructedObject ConstructWith(params object[] parameters) => throw new UnificationException();
        public ConstructedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters) => throw new UnificationException();
        public ConstructorInfo GetConstructor(params IType[] parameters) => throw new UnificationException();

        public UnifyResult InstantiateWith(IReadOnlyDictionary<Type, IType> instantiations) => throw new NotImplementedException();
        public UnifyBinaryResult UnifyAsAssignableFrom(IType other, IReadOnlyDictionary<Type, IType> instantiations) => throw new NotImplementedException();
        public UnifyBinaryResult UnifyAsAssignableFrom(IType other) => throw new NotImplementedException();
        public UnifyBinaryResult UnifyWith(IType other) => throw new NotImplementedException();
        public UnifyBinaryResult UnifyWith(IType other, IReadOnlyDictionary<Type, IType> instantiations) => throw new NotImplementedException();

    }
}
