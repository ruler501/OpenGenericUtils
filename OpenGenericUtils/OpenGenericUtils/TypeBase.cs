using System.Collections.Generic;
using System.Linq;
using Context = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public abstract class TypeBase : GenericBase, IType {
        
        protected TypeBase(Context context) : base(context) {}

        public override UnifyBinaryResult UnifyAsAssignableTo(IType other) => other.UnifyAsAssignableFrom(this);

        public virtual UnifiedObject ConstructWith(params object[] parameters) 
            => this.ConstructWithTyped(parameters.Select(p 
                => new KeyValuePair<IType, object>(p?.GetType()
                                                     .ToIType() ?? new NullType(), p)).ToArray());

        public abstract bool                 Constructible                  { get; }
        public abstract IEnumerable<IType[]> AvailableConstructorParamLists { get; }
        public abstract IEnumerable<IType>   Implements                     { get; }
        public abstract bool Class { get; }
        public virtual bool New => this.ConstructibleWith();
        public abstract bool Struct { get; }

        public abstract UnifyBinaryResult UnifyAsAssignableFrom(IGeneric other);
        
        public abstract UnifiedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters);
        public abstract UnifiedConstructorInfo GetConstructor(params IType[]                  parameters);
        public abstract bool ConstructibleWith(params IType[]                                 parameters);
        
        public abstract bool IsInstance(object obj);

    }
}
