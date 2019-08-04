using Instantiations = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils
{

    public class UnifyResult {

        public UnifyResult(IType thisType, Instantiations instantiations) {
            this.ThisType = thisType;
            this.Instantiations = instantiations;
        }

        IType          ThisType       { get; }
        Instantiations Instantiations { get; }

    }

    public class UnifyBinaryResult : UnifyResult {

        public UnifyBinaryResult(IType thisType, IType otherType, Instantiations instantiations) :
                base(thisType, instantiations) {
            this.OtherType = otherType;
        }

        IType OtherType { get; }

    }
}
