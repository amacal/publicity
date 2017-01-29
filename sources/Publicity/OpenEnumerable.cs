using System.Collections;

namespace Publicity
{
    internal class OpenEnumerable : IEnumerable, OpenTarget
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

        object OpenTarget.Instance
        {
            get { return instance; }
        }
    }
}