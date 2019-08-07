using Context = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public interface IGeneric {

        Context Context { get; }

        IGeneric InstantiateWithAdditional(Context context);
        IGeneric WithDefaultContext();
        UnifyBinaryResult UnifyAsEqual(IGeneric other);
        UnifyBinaryResult UnifyAsAssignableTo(IType other);

    }
}
