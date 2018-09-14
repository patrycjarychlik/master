using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;
using Microsoft.EntityFrameworkCore;
using AppSec.Data;

namespace OdeToFood.Services {
    public class SqlReviewData : IReviewData {
        private ApplicationDbContext _context;

        public SqlReviewData(ApplicationDbContext context) {
            _context = context;
        }

        public Review Add(Review Review) {
            _context.Reviews.Add(Review);
            _context.SaveChanges();
            return Review;
        }

        public Review Get(int id) {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public Review Update(Review Review) {
            _context.Attach(Review).State =
                EntityState.Modified;
            _context.SaveChanges();
            return Review;
        }

        public IEnumerable<Review> GetAll() {
            return _context.Reviews.OrderBy(r => r.Name);
        }

        public IEnumerable<Review> GetAllByUser(string userId) {
            return _context.Reviews.Where(r => r.UserId == userId);
        }
    }
}
