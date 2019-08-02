using System;
using System.Linq;

using Xunit;
using Xunit.Abstractions;

namespace OpenGenericUtils.Test
{
    public class PartiallyInstantiatedTypeTests {

        private ITestOutputHelper Output { get; }

        public PartiallyInstantiatedTypeTests(ITestOutputHelper output) { this.Output = output; }

        [Fact]
        public void Experiment() {
            Type bType = typeof(B<,>);
            this.PrintTypeInfo(bType);
        }

        private void PrintTypeInfo(Type type, string indent="") {
            this.Output.WriteLine($"{indent}{type}: {type.IsConstructedGenericType}(Constructed), {type.IsGenericParameter}(Parameter)");
            if (type.IsGenericType) {
                Type[] parameters = type.GetGenericArguments();
                this.Output.WriteLine($"    {indent}Parameters:");
                Array.ForEach(parameters,
                              parameter => PrintTypeInfo(parameter, "        " + indent));
            }

            if (type.IsGenericParameter) {
                Type[] constraints = type.GetGenericParameterConstraints();
                this.Output.WriteLine($"    {indent}Constraints:");
                Array.ForEach(constraints,
                              constraint => this.PrintTypeInfo(constraint, "        " + indent));
            }
        }

    }

    class A<T> where T : class { }

    class B<T, U>
            where T : A<U>
            where U : class { }
}
