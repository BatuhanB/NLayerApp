using System.Text.Json;
using NLayerApp.Core.DTOs;

namespace NLayerApp.Web.Services
{
    public class CategoryApiService
    {
        private readonly  HttpClient _httpClient;
        private T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json);
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            using var http = new HttpClient();  
            var json = await http.GetStringAsync("categories");
            var result = Deserialize<CustomResponseDto<List<CategoryDto>>>(json);
            if(result.Errors.Count > 0 || result.Errors is not null) {
                throw new Exception(result.Errors.ToString());    
            }
            return result!.Data;
            //var response  = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("categories");
            //return response?.Data;
        }
    }
}
