using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name="Restaurant Name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }
        public CuisineType Cuisine { get; set; }
        public string UserId { get; set; }
}
}
