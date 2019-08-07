using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Context = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public sealed class PartiallyInstantiatedType : TypeBase {

        public PartiallyInstantiatedType(Type generic, Context context)
                : base(context) {
            this.OpenGeneric = generic;
            IList<IType> actualParameterTypes = new List<IType>(this.GenericsParameterTypes.Length);
            foreach (Type parameterType in this.GenericsParameterTypes) {
                if (context.ContainsKey(parameterType)) {
                    actualParameterTypes.Add(context[parameterType]);
                } else {
                    ConstrainedParameterType parameter = new ConstrainedParameterType(parameterType, context, parameterType.GetITypeConstraints());
                    // TODO: Propagate constraints
                    actualParameterTypes.Add(parameter);
                }
            }
            this.ActualParameterTypes = actualParameterTypes.ToArray();
        }

        public Type OpenGeneric { get; }
        public Type[] GenericsParameterTypes => this.OpenGeneric.GetGenericArguments();
        public IType[] ActualParameterTypes { get; }
        public override bool Constructible => throw new NotImplementedException();
        public override IEnumerable<IType[]> AvailableConstructorParamLists => throw new NotImplementedException();
        public override IEnumerable<IType> Implements => throw new NotImplementedException();

        public override bool Class => throw new NotImplementedException();
        public override bool Struct => throw new NotImplementedException();

        public override bool ConstructibleWith(params IType[] parameters) => throw new NotImplementedException();
        public override UnifiedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters) => throw new NotImplementedException();
        public override UnifiedConstructorInfo GetConstructor(params IType[] parameters) => throw new NotImplementedException();
        public override IGeneric InstantiateWithAdditional(Context context)
            => new PartiallyInstantiatedType(this.OpenGeneric, this.Context.AddNewKeysFrom(context));
        public override UnifyBinaryResult UnifyAsAssignableFrom(IGeneric other) => throw new NotImplementedException();
        public override UnifyBinaryResult UnifyAsEqual(IGeneric other) => throw new NotImplementedException();
        // TODO: Do we need to propogate down into the Constraints?
        public override IGeneric WithDefaultContext() => new PartiallyInstantiatedType(this.OpenGeneric, new Dictionary<Type, IType>());

        public override bool IsInstance(object obj) => throw new NotImplementedException();
    }
}
