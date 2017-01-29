using System;
using System.Collections;
using System.Dynamic;
using System.Linq;

namespace Publicity
{
    public static class OpenReflector
    {
        public static OpenType Classify(object instance)
        {
            Type type = instance?.GetType();
            Type[] exceptions = { typeof(string) };

            if (type == null)
                return OpenType.Null;

            if (exceptions.Contains(type))
                return OpenType.Regular;

            if (type.IsArray)
                return OpenType.Array;

            if (typeof(DynamicObject).IsAssignableFrom(type))
                return OpenType.Dynamic;

            if (typeof(IDictionary).IsAssignableFrom(type))
                return OpenType.Dictionary;

            if (typeof(IList).IsAssignableFrom(type))
                return OpenType.List;

            if (typeof(ICollection).IsAssignableFrom(type))
                return OpenType.Collection;

            if (typeof(IEnumerable).IsAssignableFrom(type))
                return OpenType.Enumerable;

            if (type.IsNotPublic)
                return OpenType.Anonymous;

            return OpenType.Regular;
        }
    }
}