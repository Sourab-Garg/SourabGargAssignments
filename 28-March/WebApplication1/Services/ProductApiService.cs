using WebApplication1.Models;
using System.Text.Json;

namespace WebApplication1.Services
{
    public interface IProductApiService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel?> GetProductByIdAsync(int id);
        Task<ProductViewModel> CreateProductAsync(ProductViewModel product);
        Task<ProductViewModel> UpdateProductAsync(int id, ProductViewModel product);
        Task<bool> DeleteProductAsync(int id);
    }

    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductApiService> _logger;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public ProductApiService(HttpClient httpClient, IConfiguration configuration, ILogger<ProductApiService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        private string GetApiUrl() => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7085";

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            try
            {
                var url = $"{GetApiUrl()}/api/products";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return new List<ProductViewModel>();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(json, _jsonOptions) ?? new List<ProductViewModel>();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching products from API: {ex.Message}");
                throw new Exception($"Error fetching products from API: {ex.Message}", ex);
            }
        }

        public async Task<ProductViewModel?> GetProductByIdAsync(int id)
        {
            try
            {
                var url = $"{GetApiUrl()}/api/products/{id}";
                var response = await _httpClient.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductViewModel>(json, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching product with id {id} from API: {ex.Message}");
                throw new Exception($"Error fetching product with id {id} from API: {ex.Message}", ex);
            }
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductViewModel product)
        {
            try
            {
                var url = $"{GetApiUrl()}/api/products";
                _logger.LogInformation($"Creating product at: {url}");

                var json = JsonSerializer.Serialize(product);
                _logger.LogInformation($"Request body: {json}");

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"API returned status code: {response.StatusCode}. Content: {errorContent}");
                    throw new Exception($"API returned {response.StatusCode}: {errorContent}");
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Product created successfully. Response: {responseJson}");

                return JsonSerializer.Deserialize<ProductViewModel>(responseJson, _jsonOptions) ?? product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product in API: {ex.Message}");
                throw new Exception($"Error creating product in API: {ex.Message}", ex);
            }
        }

        public async Task<ProductViewModel> UpdateProductAsync(int id, ProductViewModel product)
        {
            try
            {
                var url = $"{GetApiUrl()}/api/products/{id}";
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API returned {response.StatusCode}: {errorContent}");
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductViewModel>(responseJson, _jsonOptions) ?? product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating product in API: {ex.Message}");
                throw new Exception($"Error updating product in API: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var url = $"{GetApiUrl()}/api/products/{id}";
                _logger.LogInformation($"Deleting product at: {url}");

                var response = await _httpClient.DeleteAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    _logger.LogWarning($"Product with id {id} not found");
                    return false;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"API returned status code: {response.StatusCode}. Content: {errorContent}");
                    throw new Exception($"API returned {response.StatusCode}: {errorContent}");
                }

                _logger.LogInformation($"Product deleted successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting product in API: {ex.Message}");
                throw new Exception($"Error deleting product in API: {ex.Message}", ex);
            }
        }
    }
}
