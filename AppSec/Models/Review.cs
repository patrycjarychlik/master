using OdeToFood.Models;
using OdeToFood.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeToFood.Models {

    public class Review {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(80)]
        public string Name { get; set; }
        [Required, MaxLength(5000)]
        public string Text { get; set; }
        public string UserId { get; set; }
        public string ReviewId { get; set; }
        public string restaurantId { get; set; }
        public int Stars{ get; set; }

}
}
