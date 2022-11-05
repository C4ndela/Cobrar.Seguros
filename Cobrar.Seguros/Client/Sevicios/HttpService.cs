using System.Security.Cryptography;
using System.Text;
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

        public async Task<HttpRespuesta<object>> Post<T>(string url,T enviar)
        {
            try
            {
                var enviaJson = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviaJson,
                                                      Encoding.UTF8,
                                                      "aplication/json"); 

                var respuesta = await http.PostAsync(url, enviarContent);
                return new HttpRespuesta<object>(null, 
                                                 !respuesta.IsSuccessStatusCode, 
                                                 respuesta);
            }
            catch(Exception e)
            {
                throw; 
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
