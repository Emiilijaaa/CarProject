using AutoMapper;
using CarShop.API.DTO.DTOs;
using CarShop.UI.Models.Link;
using CarShop.UI.Storage.Services;
using System.Net.NetworkInformation;
using System.ComponentModel;

namespace CarShop.UI.Services
{
    public class UIService(CategoryHttpClient categoryHttp, CarHttpClient carHttp, IMapper mapper, I﻿StorageService storage)
    {
        public List<CategoryGetDTO> Categories { get; set; } = new();
        public List<CarGetDTO> Cars { get; private set; } = [];
        public List<CartItemDTO> CartItems { get; set; } = [];

        public int CurrentCategoryId { get; set; }

        public async Task GetCategories()

        {
            Categories = await categoryHttp.GetCategoriesAsync();
        }
        public int CurrentCarId { get; set; }
        public async Task<List<CarGetDTO>> GetCarsByCategory(int id)
        {
            Cars = await carHttp.GetCarsAsync(id);
            return Cars;
        }


        public async Task GetProductsAsync()
        {
            Cars = await carHttp.GetCarsAsync(CurrentCarId);
           
        }

        public async Task<T> ReadStorage<T>(string key) 
        {
            //if (string.IsNullOrEmpty(key) || storage is not null) return;
            return await storage.GetAsync<T>(key);
        }

        public async Task<T> ReadSingleStorage<T>(string key)
        {
            return await storage.GetAsync<T>(key);
        }
        public async Task SaveToStorage<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key) || storage is null) return;
            await storage.SetAsync<T>(key, value);
        }
        public async Task RemoveFromStorage<T>(string key)
        {
            if (string.IsNullOrEmpty(key) || storage is null) return;
            await storage.RemoveAsync(key);
        }


    }





    //    public async Task GetProductsAsync() =>

    //        Products = await productHttp.GetProductsAsync(CurrentCategoryId);


    //}
}

