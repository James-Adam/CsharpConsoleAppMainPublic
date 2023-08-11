//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace SchoolSystem.Caching
//{
//    public class RedisCacheManager
//    {


//        public virtual T Get<T>(string key)
//        {
//            if (_perRequestCacheManager.IsSet(key))
//                return _perRequestCacheManager.Get<T>(key);

//            var rValue = _db.StringGet(key);
//            if (!rValue.HasValue)
//                return default(T);
//            var result = Deserialize<T>(rValue.Value);

//            _perRequestCacheManager.Set(key, result, 0);
//            return result;
//        }

//        private object Deserialize<T>(object value)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void Set(string key, object data, int cacheTime)
//        {
//            if (data == null)
//                return;

//            var entryBytes = Serialize(data);
//            var expiresIn = TimeSpan.FromMinutes(cacheTime);

//            _db.StringSet(key, entryBytes, expiresIn);

//        }

//        private object Serialize(object data)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual bool IsSet(string key)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}