using NLayerApp.Core.DTOs;
using System.Text.Json;

namespace NLayerApp.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json);

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            using var http = new HttpClient();
            var json = await http.GetStringAsync("products/GetProductsWithCategory");
            var result = Deserialize<CustomResponseDto<List<ProductWithCategoryDto>>>(json);

            if (result.Errors.Count > 0 || result.Errors is not null)
            {
                throw new Exception(result.Errors.ToString());
            }
            return result!.Data;

            //var response =
            //    await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>(
            //        "products/GetProductsWithCategory");

            //return response!.Data;
        }

        public async Task<ProductDto> SaveAsync(ProductDto product)
        {
            var response = await _httpClient.PostAsJsonAsync("products", product);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody!.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto product)
        {
            var response = await _httpClient.PutAsJsonAsync("products", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Products/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"Products/{id}");
            //if (response.Errors.Any())
            //{

            //}
            return response!.Data;
        }
    }
}
