namespace DictionaryToExpandoObject
{
    using System.Collections.Generic;

    static class KeyValuePair
    {
        public static KeyValuePair<TKey, TValue> Create<TKey, TValue>(TKey key, TValue value) => new KeyValuePair<TKey, TValue>(key, value);
    }
}