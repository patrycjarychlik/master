using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;
using Microsoft.EntityFrameworkCore;
using AppSec.Data;

namespace OdeToFood.Services {
    public class SqlRestaurantData : IRestaurantData {
        private ApplicationDbContext _context;

        public SqlRestaurantData(ApplicationDbContext context) {
            _context = context;
        }

        public Restaurant Add(Restaurant restaurant) {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id) {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAllByUserAndCategory(string userId, CuisineType type) {
            return _context.Restaurants.Where(r => r.UserId == userId && r.Cuisine == type);
        }

        public IEnumerable<Restaurant> GetAllByUserAndCategory(string userId) {
            return _context.Restaurants.Where(r => r.UserId == userId);
        }

        public IEnumerable<Restaurant> GetAll(int userId) {
            return _context.Restaurants.Where(r => r.UserId.Equals(userId));
        }
        public IEnumerable<CuisineType> GetAllCuisines() {
            return _context.Restaurants.Select(r => r.Cuisine);
        }

        public Restaurant Update(Restaurant restaurant) {
            _context.Attach(restaurant).State =
                EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll() {
            return _context.Restaurants.OrderBy(r => r.Name);
        }
    }
}
