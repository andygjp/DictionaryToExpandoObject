namespace DictionaryToExpandoObject
{
    using System.Collections.Generic;

    static class DictionaryExtension
    {
        public static TDic AddRange<TDic, TKey, TValue>(this TDic dictionary, IEnumerable<KeyValuePair<TKey, TValue>> objs) where TDic : IDictionary<TKey, TValue>
        {
            foreach (var obj in objs)
            {
                dictionary[obj.Key] = obj.Value;
            }
            return dictionary;
        }
    }
}