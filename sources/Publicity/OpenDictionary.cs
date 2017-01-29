using System.Collections;
using System.Dynamic;

namespace Publicity
{
    internal class OpenDictionary : DynamicObject, IEnumerable, OpenTarget
    {
        private readonly IDictionary instance;

        public OpenDictionary(IDictionary instance)
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

                case "Keys":
                    result = instance.Keys.Open();
                    return true;

                case "Values":
                    result = instance.Values.Open();
                    return true;

                default:
                    return base.TryGetMember(binder, out result);
            }
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1)
            {
                object index = indexes[0];

                if (index is OpenTarget)
                {
                    index = ((OpenTarget)index).Instance;
                }

                result = instance[index].Open();
                return true;
            }

            return base.TryGetIndex(binder, indexes, out result);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (DictionaryEntry entry in instance)
            {
                yield return new DictionaryEntry
                {
                    Key = entry.Key,
                    Value = entry.Value.Open()
                };
            }
        }

        object OpenTarget.Instance
        {
            get { return instance; }
        }
    }
}