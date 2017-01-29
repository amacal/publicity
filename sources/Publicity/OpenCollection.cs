using System.Collections;
using System.Dynamic;

namespace Publicity
{
    internal class OpenCollection : DynamicObject, IEnumerable
    {
        private readonly ICollection instance;

        public OpenCollection(ICollection instance)
        {
            this.instance = instance;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            switch (binder.Name)
            {
                case "Count":
                case "Length":
                    result = instance.Count;
                    return true;

                default:
                    return base.TryGetMember(binder, out result);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (object item in instance)
            {
                yield return item.Open();
            }
        }
    }
}