using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace AppSec.Pages
{
    public class ReviewPageModel : PageModel
    {
     
        [BindProperty]
        public IEnumerable<Review> Reviews { get; set; }

        private IReviewData _reviewData;

        public ReviewPageModel(IReviewData data) {
            _reviewData = data;

        }

        public void OnGet() {
            Reviews = _reviewData.GetAll();
        }
    }
}