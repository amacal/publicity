using System.Collections;

namespace Publicity.Tests.Cases
{
    public static class ListFixture
    {
        public static object Root()
        {
            return new ArrayList
            {
                new { value = 1 },
                new { value = 2 }
            };
        }

        public static object Nested()
        {
            return new
            {
                items = new ArrayList
                {
                    new { value = 1 },
                    new { value = 2 }
                }
            };
        }
    }
}