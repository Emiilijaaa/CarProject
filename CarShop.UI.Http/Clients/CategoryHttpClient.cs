using CarShop.API.DTO;
using CarShop.API.DTO.DTOs;
using System.Text.Json;

namespace CarShop.UI.Http.Clients
{
    public class CategoryHttpClient
    {
        private readonly HttpClient _httpClient;
        private string _baseAddress = "https://localhost:5001/api/";

        public CategoryHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"{_baseAddress}categorys");
        }

        public async Task<List<CategoryGetDTO>> GetCategoriesAsync()
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("");
                response.EnsureSuccessStatusCode();

                var result = await JsonSerializer.DeserializeAsync<List<CategoryGetDTO>>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                var convertedResult = result?? new List<CategoryGetDTO>();
                return convertedResult;
            }
            catch (Exception ex)
            {
                return new List<CategoryGetDTO>();
            }
        }


        private CategoryPutDTO ConvertToCategoryPutDTO(CategoryGetDTO categoryGetDTO)
        {
            return new CategoryPutDTO();
        }


    }
}
