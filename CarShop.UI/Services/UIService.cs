using AutoMapper;
using CarShop.API.DTO.DTOs;
using CarShop.UI.Models.Link;
using System.Net.NetworkInformation;

namespace CarShop.UI.Services
{
    public class UIService(CategoryHttpClient categoryHttp, CarHttpClient productHttp, IMapper mapper)
    {
        public List<CategoryGetDTO> Categories { get; set; } = new();
        //{
          // new CategoryGetDTO{Name="Coupe", Id=1},
           //new CategoryGetDTO{Name="Familjebil", Id=2},
        //};

        public List<CarGetDTO> Cars { get; private set; } = [];



        public int CurrentCategoryId { get; set; }

           public async Task GetCategories()

           {

                Categories = await categoryHttp.GetCategoriesAsync();

    

           }



        //    public async Task GetProductsAsync() =>

        //        Products = await productHttp.GetProductsAsync(CurrentCategoryId);


        //}
    }
}
