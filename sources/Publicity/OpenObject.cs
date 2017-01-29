using System;
using System.Dynamic;
using System.Reflection;

namespace Publicity
{
    internal class OpenObject : DynamicObject, OpenTarget
    {
        private readonly Type type;
        private readonly object instance;

        public OpenObject(Type type, object instance)
        {
            this.type = type;
            this.instance = instance;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            PropertyInfo property = type.GetProperty(binder.Name);

            if (property != null)
            {
                result = property.GetValue(instance).Open();
                return true;
            }

            return base.TryGetMember(binder, out result);
        }

        object OpenTarget.Instance
        {
            get { return instance; }
        }
    }
}