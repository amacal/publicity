using System.Collections;

namespace Publicity
{
    internal class OpenEnumerable : IEnumerable
    {
        private readonly IEnumerable instance;

        public OpenEnumerable(IEnumerable instance)
        {
            this.instance = instance;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (object item in instance)
            {
                yield return item.Open();
            }
        }
    }
}