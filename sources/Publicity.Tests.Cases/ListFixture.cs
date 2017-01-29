using System.Collections;
using System.Collections.Generic;

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

        public static object Generic()
        {
            return new List<object>
            {
                new { value = 1 },
                new { value = 2 }
            };
        }
    }
}