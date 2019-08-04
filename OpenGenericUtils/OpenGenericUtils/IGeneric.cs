using Instantiations = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public interface IGeneric {

        Instantiations Instantiations { get; }

        // TODO: How to handle cases like KeyValuePair<IEnumerable<>, IEnumerable<>>?
        UnifyResult InstantiateWith(Instantiations instantiations);

        UnifyBinaryResult UnifyWith(IType other);
        UnifyBinaryResult UnifyWith(IType other, Instantiations instantiations);
        UnifyBinaryResult UnifyAsAssignableFrom(IType other, Instantiations instantiations);
        UnifyBinaryResult UnifyAsAssignableFrom(IType other);

    }
}
