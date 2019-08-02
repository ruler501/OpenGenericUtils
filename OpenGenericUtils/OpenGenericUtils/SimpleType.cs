using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenGenericUtils
{
    public class SimpleType : IType {

        public SimpleType(Type type) { this.Type = type; }

        public Type Type { get; }

        public IType[] Parents {
            get {
                Type[] interfaces = this.Type.GetInterfaces();
                Type parentType = this.Type.BaseType;
                if (!(parentType is null)) {
                    return interfaces.Select(i => (IType)(SimpleType)i).ToArray();
                } else {
                    return interfaces.Append(parentType).Select(i => (IType)(SimpleType)i)
                                     .ToArray();
                }
            }
        }

        public IType Simplify() => this;

        public IType Simplify(IReadOnlyDictionary<Type, IType> fixedParameters) {
            if (this.Type.IsGenericParameter && fixedParameters.ContainsKey(this.Type)) {
                return fixedParameters[this.Type];
            } else {
                return this;
            }
        }

        public bool IsConstructibleFrom(params IType[] parameters) => throw new NotImplementedException();

        public ConstructorInfo GetConstructor(params IType[] parameters) => throw new NotImplementedException();

        public bool IsAssignableFrom(IType other) {
            if (other is SimpleType simpleOther) {
                return this.Type.IsAssignableFrom(simpleOther);
            } else {
                throw new NotImplementedException();
            }
        }

        public IDictionary<Type, IType> UnifyWith(IType other) => throw new NotImplementedException();
        public bool IsEquivalentTo(IType other) => throw new NotImplementedException();

        public static implicit operator Type(SimpleType type) => type.Type;
        public static implicit operator SimpleType(Type type) => new SimpleType(type);

    }
}
