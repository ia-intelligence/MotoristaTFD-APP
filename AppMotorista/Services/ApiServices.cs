using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AppMotorista.Services
{
    public class ApiServices
    {
        private readonly HttpClient _httpClient;
        //private static string _baseUrl = "https://apipaciente.iaintelligence.com.br/";
        private readonly ILogger<ApiServices> _logger;
        private readonly JsonSerializerOptions _serializerOptions;

        public ApiServices(HttpClient httpClient, ILogger<ApiServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
    }
}
