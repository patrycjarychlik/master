using OdeToFood.Models;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    public class Advert

    {

        public Advert() {
        }

        public Advert(string url, string name) {
            Url = url;
            Name = name;
        }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
