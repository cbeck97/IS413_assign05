using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Assignment_05.Infastructure
{
    public static class SessionExtensions
    {
        //This is a tool to convert our cart object to a Json (string) file and then back
        //Cannot store carts in a session
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
