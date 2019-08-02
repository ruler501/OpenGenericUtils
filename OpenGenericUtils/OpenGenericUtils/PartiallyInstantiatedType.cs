using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenGenericUtils
{
    public class PartiallyInstantiatedType : IType {

        public Type OpenGeneric { get; }
        public Type[] Parameters => this.OpenGeneric.GetGenericArguments();
        public IReadOnlyDictionary<Type, IType> InstantiatedParameters { get; }
        public IReadOnlyDictionary<Type, IType[]> Constraints { get; }
        public IType[] Parents {
            get {
                throw new NotImplementedException();
            }
        }

        public PartiallyInstantiatedType(Type                         generic,
                                         IReadOnlyDictionary<Type, IType> instantiatedParameters,
                                         IReadOnlyDictionary<Type, IType[]> constraints) {
            this.OpenGeneric = generic;
            this.InstantiatedParameters = instantiatedParameters;
            this.Constraints = constraints;
        }

        public static Type[] FindRemainingOpen(Type generic,
                                               KeyValuePair<Type, Type[]>[]
                                                   parametersWithConstraints) => null;
        public IType Simplify() => throw new NotImplementedException();

        public IType Simplify(IReadOnlyDictionary<Type, IType> fixedParameters) {
            // Populate with current instantiated Params and fixedParameters. If any don't unify return null.
            IDictionary<Type, IType> newInstantiatedParameters = new Dictionary<Type, IType>();

            // Apply all instantiated Params to Constraints, Propagating results out to other Params
            // If one simplifies to false return null
            // If one simplifies to a single type remove it from Constraints and add it to the list of instantiated.

            PartiallyInstantiatedType newType = new PartiallyInstantiatedType(this.OpenGeneric,
                                                                              this.InstantiatedParameters,
                                                                              this.Constraints);
            return newType.Simplify();
        }
        public ConstructorInfo TryGetConstructor(params Type[] parameters) => throw new NotImplementedException();
        public bool IsConstructibleFrom(params Type[] parameters) => throw new NotImplementedException();
        public ConstructorInfo GetConstructor(params Type[] parameters) => throw new NotImplementedException();
        public bool IsAssignableFrom(IType other) => throw new NotImplementedException();
        public bool IsConstructibleFrom(params IType[] parameters) => throw new NotImplementedException();
        public ConstructorInfo GetConstructor(params IType[] parameters) => throw new NotImplementedException();
        public IDictionary<Type, IType> UnifyWith(IType other) => throw new NotImplementedException();
        public bool IsEquivalentTo(IType other) => throw new NotImplementedException();
    }
}
