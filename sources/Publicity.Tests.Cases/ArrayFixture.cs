namespace Publicity.Tests.Cases
{
    public static class ArrayFixture
    {
        public static object Root()
        {
            return new[]
            {
                new { value = 1 },
                new { value = 2 }
            };
        }

        public static object Nested()
        {
            return new
            {
                items = new[]
                {
                    new { value = 1 },
                    new { value = 2 }
                }
            };
        }

        public static object Jagged()
        {
            return new[]
            {
                new[] { new { value = 1 } },
                new[] { new { value = 2 } }
            };
        }

        public static object Multi()
        {
            return new[,]
            {
                { new { value = 1 }, new { value = 3 } },
                { new { value = 2 }, new { value = 4 } }
            };
        }
    }
}