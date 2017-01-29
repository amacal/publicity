using System.Collections;
using NUnit.Framework.Constraints;

namespace Publicity.Tests.Constraints
{
    public static class Enumerates
    {
        public static Constraint To(int count)
        {
            return new ToConstraint(count);
        }

        private class ToConstraint : Constraint
        {
            private readonly int count;

            public ToConstraint(int count)
            {
                this.count = count;
            }

            public override ConstraintResult ApplyTo<TActual>(TActual actual)
            {
                int counter = 0;
                IEnumerable target = actual as IEnumerable;
                IEnumerator enumerator = target?.GetEnumerator();

                while (enumerator?.MoveNext() == true)
                {
                    counter++;
                }

                return new ConstraintResult(this, actual, counter == count);
            }
        }
    }
}