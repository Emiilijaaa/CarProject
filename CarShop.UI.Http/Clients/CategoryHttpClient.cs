using CarShop.API.DTO;
using System.Text.Json;

namespace CarShop.UI.Http.Clients
{
    internal class CategoryHttpClient
    {
        private readonly HttpClient _httpClient;
        private string _baseAddress = "https://localhost:5000/api/";

        public CategoryHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"{_baseAddress}categories");
        }

        public async Task<List<CategoryPutDTO>> GetCategoriesAsync()
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("");
                response.EnsureSuccessStatusCode();

                var result = await JsonSerializer.DeserializeAsync<List<CategoryGetDTO>>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                var convertedResult = result?.Select(c => ConvertToCategoryPutDTO(c)).ToList() ?? new List<CategoryPutDTO>();
                return convertedResult;
            }
            catch (Exception ex)
            {
                return new List<CategoryPutDTO>();
            }
        }


        private CategoryPutDTO ConvertToCategoryPutDTO(CategoryGetDTO categoryGetDTO)
        {
            return new CategoryPutDTO();
        }
    }
}
