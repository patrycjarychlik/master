using OdeToFood.Models;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    public class ReviewEditModel {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Restaurant { get; set; }

        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Zero { get; set; }
    }
}
