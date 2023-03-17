using System.Collections.Generic;
using UnityEngine;

namespace SpellBoundAR.URLUtilities
{
    public static class URLImageCache
    {
        public static readonly Dictionary<string, Sprite> Cache = new ();

        public static void AddToCache(string url, Sprite sprite)
        {
            if (Cache.ContainsKey(url)) Cache[url] = sprite;
            Cache.Add(url, sprite);
        }

        public static Sprite LoadFromCache(string url)
        {
            return Cache.ContainsKey(url) ? Cache[url] : null;
        }

        public static void RemoveFromCache(string url)
        {
            if (Cache.ContainsKey(url)) Cache.Remove(url);
        }
    }
}