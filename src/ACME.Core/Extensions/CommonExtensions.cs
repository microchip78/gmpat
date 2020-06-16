using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ACME.Core.Extensions
{
    public static class CommonExtensions
    {
        public static T GetValue<T>(this IDictionary<string, string> properties, string key)
        {
            var value = properties[key];

            if (typeof(T) == typeof(string) || typeof(T) == typeof(int) || typeof(T) == typeof(double) || typeof(T) == typeof(float))
            {
                value = $"'{value}'";
            }

            return JsonConvert.DeserializeObject<T>(value);
        }

        public static string GetUniqueId(this string value)
        {
            var append = string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : $":{value.Trim().ToLower()}";

            return $"{ Guid.NewGuid().ToString().Replace("-", string.Empty) }{ append }"
                .ToLower()
                .Trim();
        }

        public static string GetValues<TEnum>() where TEnum : struct
        {
            return string.Join(",", Enum.GetNames(typeof(TEnum)).OrderBy(x => x));
        }

        public static string GetValues<TEnum>(TEnum exclude) where TEnum : struct
        {
            return string.Join(",", Enum.GetNames(typeof(TEnum)).Where(x => x.ToUpper() != exclude.ToString().ToUpper()).OrderBy(x => x));
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }

        public static T GetEnvironmentVariableValue<T>(this string variableName, T defaultValue)
        {
            var result = Environment.GetEnvironmentVariable(variableName) ?? defaultValue.ToString();

            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter != null)
                {
                    return (T)converter.ConvertFromString(result);
                }
            }
            catch (Exception)
            {

            }

            return defaultValue;
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem,
            Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        public static string GetAllMessages(this Exception exception)
        {
            var messages = exception.FromHierarchy(ex => ex.InnerException)
                .Select(ex => ex.Message.Trim().EndsWith(".") ? ex.Message.Trim() : string.Format("{0}.", ex.Message.Trim()));

            return String.Join(" ", messages);
        }
    }
}