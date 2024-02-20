using AutoMapper;
using CarShop.API.DTO.DTOs;
using CarShop.UI.Models.Link;
using System.Net.NetworkInformation;

namespace CarShop.UI.Services
{
    public class UIService()//CategoryHttpClient categoryHttp, CarHttpClient productHttp, IMapper mapper)
    {
        List<CategoryGetDTO> Categories { get; set; } = [];

        public List<CarGetDTO> Cars { get; private set; } = [];

        public List<VehicleTypeGetDTO> VehicleTypes { get; set; } = new()
    {
       new VehicleTypeGetDTO{Name="Coupe", Id=1},
       new VehicleTypeGetDTO{Name="Familjebil", Id=2},

    };


        public int CurrentCategoryId { get; set; }

        //    public async Task GetVehicleTypes()

        //    {

        //        Categories = await categoryHttp.GetCategoriesAsync();

    

        //    }



        //    public async Task GetProductsAsync() =>

        //        Products = await productHttp.GetProductsAsync(CurrentCategoryId);


        //}
    }
}
