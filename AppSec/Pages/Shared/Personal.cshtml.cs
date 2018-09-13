using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace AppSec.Pages {
    [Authorize]
    public class PersonalModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty]
        public IEnumerable<CuisineType> Cuisines { get; set; }

        [BindProperty]
        public CuisineType CurrentCuisine { get; set; }

        private IRestaurantData _restaurantData;

        public PersonalModel(IRestaurantData restaurantData) {
            _restaurantData = restaurantData;

        }


        public void OnGet()
        {
            if (CurrentCuisine == CuisineType.None) {
                Restaurants = _restaurantData.GetAllByUserAndCategory(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            } else {
                Restaurants = _restaurantData.GetAllByUserAndCategory(User.FindFirst(ClaimTypes.NameIdentifier).Value, CurrentCuisine);
            }
            Cuisines = _restaurantData.GetAllCuisines();

        }

        public async Task<IActionResult> OnPost() {
            if (CurrentCuisine == CuisineType.None) {
                Restaurants = _restaurantData.GetAllByUserAndCategory(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            } else {
                Restaurants = _restaurantData.GetAllByUserAndCategory(User.FindFirst(ClaimTypes.NameIdentifier).Value, CurrentCuisine);
            }
            Cuisines = _restaurantData.GetAllCuisines();

            return RedirectToPage("/Shared/Personal");
        }
    }
}