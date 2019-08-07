using Context = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils
{
    public abstract class GenericBase : IGeneric
    {
        protected GenericBase(Context context) {
            this.Context = context;
        }

        public Context Context { get; }

        public abstract IGeneric InstantiateWithAdditional(Context context);
        public abstract IGeneric WithDefaultContext();
        public abstract UnifyBinaryResult UnifyAsAssignableTo(IType other);
        public abstract UnifyBinaryResult UnifyAsEqual(IGeneric other);
    }
}
