using System.Reflection;

namespace OpenGenericUtils {
    public class UnifiedObject {

        public UnifiedObject(object constructed, IType type) {
            this.Constructed = constructed;
            this.Type = type;
        }

        public object Constructed { get; }
        public IType  Type        { get; }

    }

    public class UnifiedConstructorInfo {
        
        public UnifiedConstructorInfo(ConstructorInfo constructorInfo, IType type) {
            this.ConstructorInfo = constructorInfo;
            this.Type            = type;
        }

        public ConstructorInfo ConstructorInfo { get; }
        public IType           Type            { get; }

    }
}
