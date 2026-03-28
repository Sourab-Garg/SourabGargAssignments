using WebApplication1.Models;
using System.Text.Json;
using System.Text;

namespace WebApplication1.Services
{
    public interface IProductApiService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel?> GetProductByIdAsync(int id);
        Task<ProductViewModel> CreateProductAsync(ProductViewModel product);
        Task<ProductViewModel> UpdateProductAsync(int id, ProductViewModel product);
        Task<bool> DeleteProductAsync(int id);
    }

    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7085";
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            try
            {
                var url = $"{_apiUrl}/api/products";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return new List<ProductViewModel>();

                var json = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<ProductViewModel>>(json, _jsonOptions);

                return products ?? new List<ProductViewModel>();
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }

        public async Task<ProductViewModel?> GetProductByIdAsync(int id)
        {
            try
            {
                var url = $"{_apiUrl}/api/products/{id}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductViewModel>(json, _jsonOptions);
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductViewModel product)
        {
            try
            {
                var url = $"{_apiUrl}/api/products";
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);
                var responseJson = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return product;

                var created = JsonSerializer.Deserialize<ProductViewModel>(responseJson, _jsonOptions);
                return created ?? product;
            }
            catch
            {
                return product;
            }
        }

        public async Task<ProductViewModel> UpdateProductAsync(int id, ProductViewModel product)
        {
            try
            {
                var url = $"{_apiUrl}/api/products/{id}";
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);
                var responseJson = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return product;

                var updated = JsonSerializer.Deserialize<ProductViewModel>(responseJson, _jsonOptions);
                return updated ?? product;
            }
            catch
            {
                return product;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var url = $"{_apiUrl}/api/products/{id}";
                var response = await _httpClient.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
