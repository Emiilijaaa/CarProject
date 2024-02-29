using CarShop.API.DTO;
using System.Text.Json;

namespace CarShop.UI.Http.Clients;


public class CarHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAddress = "https://localhost:5010/api/";

    public CarHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{_baseAddress}Cars");
    }

    public async Task<List<CarGetDTO>> GetCarsAsync(int categoryId)
    {
        try
        {
            string relativePath = $"{_httpClient.BaseAddress}bycategory/{categoryId}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<CarGetDTO>>(resultStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new List<CarGetDTO>();
        }
        catch (Exception ex)
        {
            // Logga undantaget eller hantera det på lämpligt sätt
            return new List<CarGetDTO>();
        }
    }

}