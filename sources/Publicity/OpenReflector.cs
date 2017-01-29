using System;
using System.Collections;

namespace Publicity
{
    public static class OpenReflector
    {
        public static OpenType Classify(object instance)
        {
            Type type = instance?.GetType();

            if (type == null)
                return OpenType.Null;

            if (type.IsArray)
                return OpenType.Array;

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