using System.Collections.Generic;
using UnityEngine;

namespace SpellBoundAR.URLUtilities
{
    public static class URLImageCache
    {
        public static readonly Dictionary<string, Sprite> Cache = new ();

        public static void AddToCache(string url, Sprite sprite)
        {
            if (string.IsNullOrWhiteSpace(url)) return;
            if (Cache.ContainsKey(url)) Cache[url] = sprite;
            else Cache.Add(url, sprite);
        }

        public static Sprite LoadFromCache(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            return Cache.ContainsKey(url) ? Cache[url] : null;
        }

        public static void RemoveFromCache(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return;
            if (Cache.ContainsKey(url)) Cache.Remove(url);
        }
    }
}