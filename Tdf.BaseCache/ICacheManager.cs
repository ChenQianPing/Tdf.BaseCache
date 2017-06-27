namespace Tdf.BaseCache
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Set(string key, object value, double cacheTime);
        bool Exists(string key);
        void Remove(string key);
        void Clear();
    }
}
