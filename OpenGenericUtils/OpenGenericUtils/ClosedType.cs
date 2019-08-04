using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Instantiations = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public class ClosedType : IType {

        public ClosedType(Type type, Instantiations instantiations) { this.Type = type; }

        public Type Type { get; }

        public IType[] Implements {
            get {
                Type[] interfaces = this.Type.GetInterfaces();
                Type parentType = this.Type.BaseType;
                if (!(parentType is null)) {
                    return interfaces.Select(i => (IType)(ClosedType)i).ToArray();
                } else {
                    return interfaces.Append(parentType).Select(i => (IType)(ClosedType)i)
                                     .ToArray();
                }
            }
        }

        public bool Constructible => throw new NotImplementedException();
        public IEnumerable<IType[]> AvailableConstructorParamLists
            => this.Type.GetConstructors()
                        .Select(ci => ci.GetParameters()
                                        .Select(pi => pi.ParameterType.ToIType())
                                        .ToArray());
        public Instantiations Instantiations { get; }

        public UnifyResult InstantiateWith(Instantiations instantiations) => throw new NotImplementedException();

        public UnifyBinaryResult UnifyWith(IType other) => this.UnifyWith(other, this.Instantiations);
        public UnifyBinaryResult UnifyWith(IType other, Instantiations instantiations) => throw new NotImplementedException();

        public UnifyBinaryResult UnifyAsAssignableFrom(IType other, Instantiations instantiations) {
            if (other is ClosedType simpleOther) {
                if (simpleOther.Type.IsAssignableFrom(this.Type)) {
                    return new UnifyBinaryResult(this, simpleOther, this.Instantiations.Update(other.Instantiations));
                } else {
                    throw new UnificationException();
                }
            } else {
                throw new NotImplementedException();
            }
        }

        public UnifyBinaryResult UnifyAsAssignableFrom(IType other) => this.UnifyAsAssignableFrom(other, this.Instantiations);

        public bool ConstructibleWith(IType[] parameters) => throw new NotImplementedException();
        public ConstructedObject ConstructWith(params object[] parameters)
            => this.ConstructWithTyped(parameters.Select(p => new KeyValuePair<IType, object>((p?.GetType() ?? typeof(object)).ToIType(), p))
                                                 .ToArray());
        public ConstructedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters) => throw new NotImplementedException();
        public ConstructorInfo GetConstructor(params IType[] parameters) => throw new NotImplementedException();

        public static implicit operator Type(ClosedType type) => type.Type;
        public static implicit operator ClosedType(Type type) => new ClosedType(type, new Dictionary<Type, IType>());

    }
}
