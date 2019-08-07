using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Instantiations = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public sealed class ClosedType : TypeBase {

        public ClosedType(Type type) : base(new Dictionary<Type, IType>()) {
            this.Type = type;
        }

        public Type Type { get; }

        public override IEnumerable<IType> Implements {
            get {
                foreach(Type interface_ in this.Type.GetInterfaces()) {
                    yield return interface_.ToIType();
                }
                Type parentType = this.Type.BaseType;
                while(!(parentType is null)) {
                    yield return parentType.ToIType();
                    parentType = parentType.BaseType;
                }
            }
        }

        public override bool Constructible => throw new NotImplementedException();

        public override IEnumerable<IType[]> AvailableConstructorParamLists { get; }
        public override bool Class => throw new NotImplementedException();
        public override bool Struct => throw  new NotImplementedException();

        public override UnifyBinaryResult UnifyAsEqual(IGeneric other) {
            if (other is ClosedType simpleOther && simpleOther.Type == this.Type) {
                return new UnifyBinaryResult(this, simpleOther);
            } else {
                throw new NotImplementedException();
            }
        }
        public override UnifyBinaryResult UnifyAsAssignableTo(IType other) {
            if ((other is ClosedType simpleOther && simpleOther.Type.IsAssignableFrom(this.Type))
                 || (other is NullType && this.Class)) {
                return new UnifyBinaryResult(this, other);
            } else {
                throw new NotImplementedException();
            }
        }

        public override bool ConstructibleWith(IType[] parameters) => throw new NotImplementedException();
        public override UnifiedObject ConstructWith(params object[] parameters)
            => this.ConstructWithTyped(parameters.Select(p => new KeyValuePair<IType, object>(p?.GetType().ToIType() ?? new NullType(), p))
                                                 .ToArray());
        public override UnifiedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters) => throw new NotImplementedException();
        public override UnifiedConstructorInfo GetConstructor(params IType[] parameters) => throw new NotImplementedException();
        public override UnifyBinaryResult UnifyAsAssignableFrom(IGeneric other) => throw new NotImplementedException();
        public override IGeneric InstantiateWithAdditional(Instantiations context) => throw new NotImplementedException();
        public override IGeneric WithDefaultContext() => throw new NotImplementedException();

        public static implicit operator Type(ClosedType type) => type.Type;
        public static implicit operator ClosedType(Type type) => new ClosedType(type);

        public override bool IsInstance(object obj) => throw new NotImplementedException();

    }
}
