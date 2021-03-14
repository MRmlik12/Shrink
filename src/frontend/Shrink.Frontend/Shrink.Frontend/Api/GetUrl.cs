using System;
using System.Threading.Tasks;
using RestSharp;
using Shrink.Frontend.Models;
using Newtonsoft.Json;

namespace Shrink.Frontend.Api
{
    public static class GetUrl
    {
        public static async Task<UrlShrink> GetUrlByCode(string url, string code)
        {
            var client = new RestClient($"{url}/Url/{code}");
            var response = await client.ExecuteAsync(new RestRequest(Method.GET));
            return JsonConvert.DeserializeObject<UrlShrink>(response.Content);
        }
    }
}