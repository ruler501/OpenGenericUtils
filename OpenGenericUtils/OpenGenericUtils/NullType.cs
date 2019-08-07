using System;
using System.Collections.Generic;
using System.Linq;

using Context = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public sealed class NullType : GenericBase, IType {

        public NullType() : base(new Dictionary<Type, IType>()) {}
        
        public override IGeneric InstantiateWithAdditional(Context context) => this;
        public override IGeneric WithDefaultContext() => this;
        public bool Constructible => false;
        public IEnumerable<IType[]> AvailableConstructorParamLists { get; } = Enumerable.Empty<IType[]>();
        public IEnumerable<IType> Implements { get; } = typeof(object).ToIType().Yield();
        public bool Class => true;
        public bool New => true;
        public bool Struct => false;

        // TODO: Figure out if these are really the correct behaviors.
        public UnifyBinaryResult UnifyAsAssignableFrom(IGeneric other) => this.UnifyAsEqual(other);
        public override UnifyBinaryResult UnifyAsAssignableTo(IType other) {
            if(other.Class) {
                return new UnifyBinaryResult(this, other);
            } else {
                throw new UnificationException();
            }
        }
        public override UnifyBinaryResult UnifyAsEqual(IGeneric other) => new UnifyBinaryResult(this, other);

        public bool ConstructibleWith(IType[] parameters) => false;
        public UnifiedObject ConstructWith(params object[] parameters) => throw new UnificationException();
        public UnifiedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters) => throw new UnificationException();
        public UnifiedConstructorInfo GetConstructor(params IType[] parameters) => throw new UnificationException();

        public bool IsInstance(object obj) => obj is null;

    }
}
