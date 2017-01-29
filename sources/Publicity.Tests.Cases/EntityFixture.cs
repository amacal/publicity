using System.Collections;

namespace Publicity.Tests.Cases
{
    public static class EntityFixture
    {
        public static object Empty()
        {
            return new { };
        }

        public static object Property()
        {
            return new { value = 1 };
        }

        public static object Nested()
        {
            return new
            {
                data = new
                {
                    value = 1
                }
            };
        }

        public static object Null()
        {
            return null;
        }

        public static object Nulled()
        {
            return new
            {
                data = default(IEnumerable)
            };
        }

        public static object Regular()
        {
            return new RegularClass { value = 1 };
        }

        private class RegularClass
        {
            public int value { get; set; }
        }
    }
}