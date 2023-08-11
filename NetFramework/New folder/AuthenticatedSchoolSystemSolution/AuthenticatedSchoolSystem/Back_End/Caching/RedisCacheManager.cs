using System;

namespace AuthenticatedSchoolSystem.Back_End.Caching
{
    public class RedisCacheManager
    {
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            _ = Serialize(data);
            _ = TimeSpan.FromMinutes(cacheTime);

            //_db.StringSet(key, entryBytes, expiresIn);
        }

        private object Serialize(object data)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsSet(string key)
        {
            throw new NotImplementedException();
        }
    }
}