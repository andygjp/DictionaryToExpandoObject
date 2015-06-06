namespace DictionaryToExpandoObject
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    public static class ToExpandoExtension
    {
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary) => dictionary.GetKeyValuePairs().ToExpando();

        static ExpandoObject ToExpando(this IEnumerable<KeyValuePair<string, object>> kvps) => new ExpandoObject().AddRange(kvps);

        static IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs(this IDictionary<string, object> dictionary) => dictionary.Select(GetKeyValuePair);

        static KeyValuePair<string, object> GetKeyValuePair(KeyValuePair<string, object> kvp) => KeyValuePair.Create(kvp.Key, kvp.Value.SafelyGetValue());
        
        static object SafelyGetValue(this object value) => value.TryCast<ICollection<object>>()?.ToCollection() ?? value.SafelyGetExpando();

        static object SafelyGetExpando(this object value) => value.TryCast<IDictionary<string, object>>()?.ToExpando() ?? value;

        static T TryCast<T>(this object obj) where T : class => obj as T;

        static IEnumerable<object> ToCollection(this IEnumerable<object> collection) => collection.Select(SafelyGetExpando);
    }
}
