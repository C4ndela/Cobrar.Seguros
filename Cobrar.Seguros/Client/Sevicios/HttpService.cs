using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cobrar.Seguros.Client.Sevicios
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient http;

        public HttpService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DeserializarRespuesta<T>(response);
                return new HttpRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, response);
            }

        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage response)
        {
            var respuesataStr = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuesataStr,
                 new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
