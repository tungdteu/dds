using System;
using SharedCache.WinServiceCommon.Provider.Cache;

namespace Common.Caching
{
    /// <summary>
    ///     Represents a DistributeCacheManager
    /// </summary>
    public class DistributeCacheManager : ICacheManager
    {
        /// <summary>
        ///     Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public T Get<T>(string key)
        {
            return IndexusDistributionCache.SharedCache.Get<T>(key);
        }

        /// <summary>
        ///     Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time in minus</param>
        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            IndexusDistributionCache.SharedCache.Add(key, data, DateTime.Now.AddMinutes(cacheTime));
        }

        /// <summary>
        ///     Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public bool IsSet(string key)
        {
            return IndexusDistributionCache.SharedCache.GetAllKeys().Contains(key);
        }

        /// <summary>
        ///     Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public void Remove(string key)
        {
            IndexusDistributionCache.SharedCache.Remove(key);
        }

        /// <summary>
        ///     Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public void RemoveByPattern(string pattern)
        {
            IndexusDistributionCache.SharedCache.RegexRemove(pattern);
        }

        /// <summary>
        ///     Clear all cache data
        /// </summary>
        public void Clear()
        {
            IndexusDistributionCache.SharedCache.Clear();
        }
    }
}