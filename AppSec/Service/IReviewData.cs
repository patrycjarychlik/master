using OdeToFood.Models;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IReviewData {
        IEnumerable<Review> GetAll();
        IEnumerable<Review> GetAllByUser(string userId);
        Review Get(int id);
        Review Add(Review Review);
        Review Update(Review Review);
        
    }
}
