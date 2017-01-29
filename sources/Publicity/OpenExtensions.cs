using System;
using System.Collections;

namespace Publicity
{
    public static class OpenExtensions
    {
        public static dynamic Open(this object instance)
        {
            switch (OpenReflector.Classify(instance))
            {
                case OpenType.Null:
                    return null;

                case OpenType.Array:
                    return new OpenArray((Array)instance);

                case OpenType.Dictionary:
                    return new OpenDictionary((IDictionary)instance);

                case OpenType.List:
                    return new OpenList((IList)instance);

                case OpenType.Collection:
                    return new OpenCollection((ICollection)instance);

                case OpenType.Enumerable:
                    return new OpenEnumerable((IEnumerable)instance);

                case OpenType.Anonymous:
                    return new OpenObject(instance.GetType(), instance);

                default:
                    return instance;
            }
        }
    }
}