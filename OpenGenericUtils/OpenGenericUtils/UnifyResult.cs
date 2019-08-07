namespace OpenGenericUtils
{
    public class UnifyBinaryResult {

        public UnifyBinaryResult(IType type, IGeneric generic) {
            this.Type = type;
            this.Generic = generic;
        }

        public IType Type { get; }
        public IGeneric Generic { get; }

    }
}
