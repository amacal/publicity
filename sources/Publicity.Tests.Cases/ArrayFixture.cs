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
    }
}