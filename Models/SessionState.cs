using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Store.Models;
namespace Store.Models
{
    public static class SessionState 
    {
        public static void SetJson<T>(this ISession session,string key, T cart)
        {
            session.SetString(key, JsonConvert.SerializeObject(cart));
        }
        public static T GetCart<T>(this ISession session,string key)
        {
            var result = session.GetString(key);
            return result == null ? default(T) : JsonConvert.DeserializeObject<T>(result); 
        }
    }
}
