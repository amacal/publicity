using System;
using System.Collections;
using System.Dynamic;

namespace Publicity
{
    internal class OpenArray : DynamicObject, IEnumerable, OpenTarget
    {
        private readonly Array instance;

        public OpenArray(Array instance)
        {
            this.instance = instance;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            switch (binder.Name)
            {
                case "Count":
                case "Length":
                    result = instance.Length;
                    return true;

                case "Rank":
                    result = instance.Rank;
                    return true;

                default:
                    return base.TryGetMember(binder, out result);
            }
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == instance.Rank)
            {
                int[] indices = new int[instance.Rank];

                for (int i = 0; i < instance.Rank; i++)
                {
                    indices[i] = (int)indexes[i];
                }

                result = instance.GetValue(indices).Open();
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

        object OpenTarget.Instance
        {
            get { return instance; }
        }
    }
}