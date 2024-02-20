using CarShop.API.DTO;
using System.Text.Json;

namespace CarShop.UI.Http.Clients;


public class CarHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAddress = "https://localhost:5500/api/";

    public CarHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{_baseAddress}products");
    }

    public async Task<List<CarPostDTO>> GetProductsAsync(int categoryId)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"productsbycategory/{categoryId}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<CarPostDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? [];
        }
        catch (Exception ex)
        {
            return [];
        }
    }
}