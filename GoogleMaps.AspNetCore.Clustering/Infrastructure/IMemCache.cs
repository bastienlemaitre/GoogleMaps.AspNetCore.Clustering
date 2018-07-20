using System;

namespace GoogleMaps.AspNetCore.Clustering.Infrastructure
{
    public interface IMemCache // TODO: make internal?
    {
        T Get<T>(string key) where T : class;

        bool Add<T>(string key, T objectToCache, TimeSpan timespan);

        void Set<T>(string key, T objectToCache, TimeSpan timespan);

        object Remove(string key);

        bool Exists(string key);
    }
}
