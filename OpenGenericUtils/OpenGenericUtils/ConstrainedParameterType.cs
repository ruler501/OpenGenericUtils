using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Context = System.Collections.Generic.IReadOnlyDictionary<System.Type, OpenGenericUtils.IType>;

namespace OpenGenericUtils {
    public sealed class ConstrainedParameterType : TypeBase {

        public ConstrainedParameterType(Type type, Context context, IType[] additionalConstraints = null,
                                        GenericParameterAttributes additionalAttributes = GenericParameterAttributes.None)
                : base(context) {
            this.Type = type;

            GenericParameterAttributes attributes = this.Type.GenericParameterAttributes 
                                                     | additionalAttributes;
            this.Contravariant = (attributes & GenericParameterAttributes.Contravariant) != 0;
            this.Covariant = (attributes & GenericParameterAttributes.Covariant) != 0;
            this.Class = (attributes & GenericParameterAttributes.ReferenceTypeConstraint) != 0;
            this.Struct = (attributes & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0;
            this.New = (attributes & GenericParameterAttributes.DefaultConstructorConstraint) != 0;
            if ((this.Covariant && this.Contravariant) || (this.Class && this.Struct)) {
                throw new UnificationException();
            }
            this.Attributes = attributes;

            // TODO: Populate constraints
        }

        public Type Type { get; }
        public IType[] Constraints { get; }
        public bool Contravariant { get; }
        public bool Covariant { get; }
        public override bool Class { get; }
        public override bool Struct { get; }
        public override bool New { get; }
        public GenericParameterAttributes Attributes { get; }

        public override bool Constructible => false;
        
        public override IEnumerable<IType[]> AvailableConstructorParamLists => Enumerable.Empty<IType[]>();

        public override IEnumerable<IType> Implements => throw new NotImplementedException();

        public override bool ConstructibleWith(params IType[] parameters) => false;
        public override UnifiedObject ConstructWith(params object[] parameters) => throw new UnificationException();
        public override UnifiedObject ConstructWithTyped(params KeyValuePair<IType, object>[] parameters) => throw new UnificationException();
        public override UnifiedConstructorInfo GetConstructor(params IType[] parameters) => throw new UnificationException();
        // TODO: Do we need to propogate down into the Constraints?
        // TODO: Prevent from duplicating constraints
        public override IGeneric InstantiateWithAdditional(IReadOnlyDictionary<Type, IType> context)
            => new ConstrainedParameterType(this.Type, this.Context.AddNewKeysFrom(context), this.Constraints, this.Attributes);

        public override UnifyBinaryResult UnifyAsAssignableFrom(IGeneric other) => throw new NotImplementedException();
        public override UnifyBinaryResult UnifyAsEqual(IGeneric other) => throw new NotImplementedException();
        // TODO: Do we need to propogate down into the Constraints?
        // TODO: Prevent from duplicating constraints
        public override IGeneric WithDefaultContext() => new ConstrainedParameterType(this.Type, new Dictionary<Type, IType>(), this.Constraints, this.Attributes);

        public override bool IsInstance(object obj) => throw new NotImplementedException();
    }
}
