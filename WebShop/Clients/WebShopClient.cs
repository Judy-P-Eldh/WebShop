using Newtonsoft.Json;
using Plant.Core.Enteties;
using System.Net.Http.Headers;


namespace WebShop.Clients
{
    public class WebShopClient
    {
        private readonly HttpClient httpClient;

        public WebShopClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5138");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Event>> GetEventSreamsAsync() 
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/events");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Event> events;
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                response.EnsureSuccessStatusCode();
                using (var streamReader = new StreamReader(stream))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer();
                        events = serializer.Deserialize<IEnumerable<Event>>(jsonReader);
                    }
                }
            }
            return events;
        }
    }
}
