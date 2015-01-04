namespace Common.Caching
{
    /// <summary>
    ///     ICache manager is an interface to indicate all common methods , properties which going to implement by different
    ///     cache systems for this project.
    ///     For example , the memory cache system will have different methodology to implement with share cache system; however
    ///     each system should have an
    ///     inheritance all wraped  behaviours that assign in this interface, and other class in projects can manipulate cache
    ///     system with a same way.
    /// </summary>
    /// <remarks>
    ///     http://www.sirentuan.com/2653434/codep1/best-practices-for-cache-and-session-manager-for-an-mvc-application 
    ///     http://www.nopcommerce.com/
    ///     Thank for all expert from around the world , I show deep gratitude with your contribution for community !
    /// </remarks>
    public interface ICacheManager
    {
        /// <summary>
        ///     Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        ///     Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        ///     Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        bool IsSet(string key);

        /// <summary>
        ///     Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        void Remove(string key);

        /// <summary>
        ///     Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        ///     Clear all cache data
        /// </summary>
        void Clear();
    }
}