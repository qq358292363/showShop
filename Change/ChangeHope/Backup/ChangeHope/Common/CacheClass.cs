namespace ChangeHope.Common
{
    using System;
    using System.Collections;
    using System.Web;
    using System.Web.Caching;

    public class CacheClass
    {
        public static object GetCache(string CacheKey)
        {
            return HttpRuntime.Cache[CacheKey];
        }

        public static void RemoveAllCache()
        {
            Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = cache.GetEnumerator();
            if (cache.Count > 0)
            {
                ArrayList list = new ArrayList();
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Key);
                }
                foreach (string str in list)
                {
                    cache.Remove(str);
                }
            }
        }

        public static void RemoveOneCache(string CacheKey)
        {
            HttpRuntime.Cache.Remove(CacheKey);
        }

        public static void SetCache(string CacheKey, object objObject)
        {
            HttpRuntime.Cache.Insert(CacheKey, objObject);
        }

        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            HttpRuntime.Cache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        public static ArrayList ShowAllCache()
        {
            ArrayList list = new ArrayList();
            Cache cache = HttpRuntime.Cache;
            if (cache.Count > 0)
            {
                IDictionaryEnumerator enumerator = cache.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Key);
                }
            }
            return list;
        }
    }
}

