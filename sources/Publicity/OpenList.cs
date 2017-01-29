using System.Collections;
using System.Dynamic;

namespace Publicity
{
    internal class OpenList : DynamicObject, IEnumerable
    {
        private readonly IList instance;

        public OpenList(IList instance)
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

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1 && indexes[0] is int)
            {
                result = instance[(int)indexes[0]].Open();
                return true;
            }

            return base.TryGetIndex(binder, indexes, out result);
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