using System.Collections;
using System.Linq;

namespace Publicity.Tests.Cases
{
    public static class EnumerableFixture
    {
        public static object Root()
        {
            return Generate();
        }

        public static object Nested()
        {
            return new
            {
                items = Generate()
            };
        }

        public static object Query()
        {
            return Generate().AsQueryable();
        }

        private static IEnumerable Generate()
        {
            yield return new { value = 1 };
            yield return new { value = 2 };
        }
    }
}