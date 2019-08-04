using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Instantiations = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils
{
    public class PartiallyInstantiatedType : IType {

        public PartiallyInstantiatedType(Type                               generic,
                                         Instantiations                     instantiatedParameters,
                                         IReadOnlyDictionary<Type, IType[]> constraints) {
            this.OpenGeneric            = generic;
            this.InstantiatedParameters = instantiatedParameters;
            this.Constraints            = constraints;
        }

        public Type OpenGeneric { get; }
        public Type[] ParameterTypes => this.OpenGeneric.GetGenericArguments();
        public IReadOnlyDictionary<Type, IType> InstantiatedParameters { get; }
        public IReadOnlyDictionary<Type, IType[]> Constraints { get; }
        public bool Constructible { get; }
        public IEnumerable<IType[]> AvailableConstructorParamLists { get; }
        public IType[] Implements { get; }
        public IReadOnlyDictionary<Type, IType> Instantiations { get; }

        public bool ConstructibleWith(IType[] parameters) => throw new NotImplementedException();
        public ConstructedObject ConstructWith(params object[] parameters)
            => this.ConstructWithTyped(parameters.Select(p => new KeyValuePair<IType, object>((p?.GetType() ?? typeof(object)).ToIType(), p))
                                                 .ToArray());
        public ConstructedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters) => throw new NotImplementedException();
        public ConstructorInfo GetConstructor(params IType[] parameters) => throw new NotImplementedException();
        public UnifyResult InstantiateWith(Instantiations instantiations) => throw new NotImplementedException();

        public UnifyBinaryResult UnifyAsAssignableFrom(IType other, Instantiations instantiations) => throw new NotImplementedException();
        public UnifyBinaryResult UnifyAsAssignableFrom(IType other)
            => this.UnifyAsAssignableFrom(other, this.Instantiations);
        public UnifyBinaryResult UnifyWith(IType other)
            => this.UnifyWith(other, this.Instantiations);
        public UnifyBinaryResult UnifyWith(IType other, Instantiations instantiations) => throw new NotImplementedException();
    }
}
