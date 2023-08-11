using System;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    internal class PropertyByName<T>
    {
        private readonly string v;
        private readonly Func<object, object> value;

        public PropertyByName(string v, Func<object, object> value)
        {
            this.v = v;
            this.value = value;
        }
    }
}