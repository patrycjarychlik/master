using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetAllByUserAndCategory(string userId, CuisineType type);
        IEnumerable<Restaurant> GetAllByUserAndCategory(string userId);
        Restaurant Get(int id);
        Restaurant Add(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
        IEnumerable<CuisineType> GetAllCuisines();
    }
}
