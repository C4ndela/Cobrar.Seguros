namespace Cobrar.Seguros.Client.Sevicios
{
    public interface IHttpService
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}