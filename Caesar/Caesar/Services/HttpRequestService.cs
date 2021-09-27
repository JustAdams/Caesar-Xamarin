using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Caesar.Services
{
    public class HttpRequestService
    {

        public HttpRequestService()
        {
        }

        public async Task<string> RecipeRequest(string ingredients)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://edamam-recipe-search.p.rapidapi.com/search?q={ingredients}"),
                    Headers =
                {
                    { "x-rapidapi-host", "edamam-recipe-search.p.rapidapi.com" },
                    { "x-rapidapi-key", "your-api-key-here" },
                },
                };
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    string body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return string.Empty;
        }




    }
}
