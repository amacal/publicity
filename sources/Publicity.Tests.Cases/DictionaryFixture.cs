using System.Collections;
using System.Collections.Generic;

namespace Publicity.Tests.Cases
{
    public class DictionaryFixture
    {
        public static object Root()
        {
            return new Hashtable
            {
                { "a", new { value = 1 } },
                { 123, new { value = 2 } }
            };
        }

        public static object Nested()
        {
            return new
            {
                items = new Hashtable
                {
                    { "a", new { value = 1 } },
                    { 123, new { value = 2 } }
                }
            };
        }

        public static object Generic()
        {
            return new Dictionary<string, object>
            {
                { "a", new { value = 1 } },
                { "b", new { value = 2 } }
            };
        }
    }
}