using System.Collections;

namespace Publicity.Tests.Cases
{
    public static class CollectionFixture
    {
        public static object Root()
        {
            Queue queue = new Queue();

            queue.Enqueue(new { value = 1 });
            queue.Enqueue(new { value = 1 });

            return queue;
        }

        public static object Nested()
        {
            Queue queue = new Queue();

            queue.Enqueue(new { value = 1 });
            queue.Enqueue(new { value = 1 });

            return new
            {
                items = queue
            };
        }
    }
}