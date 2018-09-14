using AppSec.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IReviewData _reviewData;

        public HomeController(IRestaurantData restaurantData, IReviewData reviewData)
        {
            _reviewData = reviewData;
            _restaurantData = restaurantData;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult About(CuisineType type) {
            PersonalModel model = new PersonalModel(_restaurantData);
            model.CurrentCuisine = type;
            return View("Personal", model);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }


        [HttpGet]
        public IActionResult CreateReview() {
            ViewData["Restaurant"] = _restaurantData.GetAll().Select(n => new SelectListItem {
           Value = n.Id.ToString(),
           Text = n.Name
       }).ToList();
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Description = model.Description;
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult CreateReview(ReviewEditModel model)
        {
            if (ModelState.IsValid)
            {
                int stars = 0;
                stars = Star(stars, model.One);
                stars = Star(stars, model.Two);
                stars = Star(stars, model.Three);
                stars = Star(stars, model.Four);
                stars = Star(stars, model.Five);

                var newReview = new Review();
                newReview.Name = model.Name;
                newReview.Text = model.Text;
                newReview.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newReview.Stars = stars;
                newReview.restaurantId = model.Restaurant;
                newReview = _reviewData.Add(newReview);

                return RedirectToPage("/Shared/ReviewPage");
            }
            else
            {
                return View();
            }
        }

        private int Star(int stars, String radio) {
            if (radio != null) {
                stars = +Convert.ToInt32(radio);
            }
            return stars;
        }
    }
}
