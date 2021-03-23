using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Restaurant_Website.Infrastructure.Extensions
{
    public static class SessionExtensions
    {
        public static async Task<T> GetObjectAsync<T>(this ISession session, string key)
        {
            await session.LoadAsync();
            string value = session.GetString(key);

            return JsonConvert.DeserializeObject<T>(value);
        }

        public static async Task SetObjectAsync<T>(this ISession session, string key, T value)
        {
            string cookie = JsonConvert.SerializeObject(value);

            session.SetString(key, cookie);
            await session.CommitAsync();
        }
    }
}
