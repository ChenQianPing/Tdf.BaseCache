using System;
using System.Runtime.Caching;

namespace Tdf.BaseCache
{
    public class RuntimeCaching : ICacheManager
    {
        public void Clear()
        {
            foreach (var item in MemoryCache.Default)
            {
                this.Remove(item.Key);
            }
        }

        public bool Exists(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        public T Get<T>(string key)
        {
            return (T)MemoryCache.Default.Get(key);
        }

        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public void Set(string key, object value, double cacheTime)
        {
            if (value == null)
                return;

            var policy = new CacheItemPolicy {AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)};

            MemoryCache.Default.Add(new CacheItem(key, value), policy);
        }
    }
}
