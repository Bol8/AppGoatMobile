using System;
using Microsoft.Extensions.Caching.Memory;

namespace AppGoatMobile.Services
{
    public static class CacheProvider
    {
        private static readonly IMemoryCache _cache;

        static CacheProvider()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public static void Set<T>(string keyCache, T value, DateTimeOffset absoluteExpiry)
        {
            _cache.Set(keyCache, value);

        }

        public static void Remove(string keyCache)
        {
            _cache.Remove(keyCache);
        }

        public static T Get<T>(string keyCache)
        {
            return _cache.TryGetValue(keyCache, out T value) ? value : default(T);
        }
    }
}