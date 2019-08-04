using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGenericUtils {
    public class ConstructedObject {

        public ConstructedObject(object constructed, UnifyResult typeInfo) {
            this.Constructed = constructed;
            this.TypeInfo = typeInfo;
        }

        object      Constructed { get; }
        UnifyResult TypeInfo    { get; }

    }
}
