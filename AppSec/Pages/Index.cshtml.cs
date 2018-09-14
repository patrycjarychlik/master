using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Authorization;
using OdeToFood.ViewModels;
using Microsoft.AspNetCore.WebSockets.Internal;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace AppSec.Pages {
    [AllowAnonymous]
    public class IndexModel : PageModel {
        [BindProperty]
        public List<Advert> Adverts1 { get; set; }
        public List<Advert> Adverts2 { get; set; }
        public List<Advert> Adverts3 { get; set; }
        public List<Advert> Adverts4 { get; set; }

        public IndexModel() {
        Adverts1 = new List<Advert>();
        Adverts2 = new List<Advert>();
        Adverts3 = new List<Advert>();
        Adverts4 = new List<Advert>();
        }

        public void OnGet() {

            var proxy = new ServiceReference1.Service1Client();

            List<string[]> fetched1 = new List<string[]>(proxy.GetAdvertAsync(1).GetAwaiter().GetResult());
            fetched1.ForEach(ad => Adverts1.Add(new Advert(ad[0], ad[1])));

            List<string[]> fetched2 = new List<string[]>(proxy.GetAdvertAsync(2).GetAwaiter().GetResult());
            fetched2.ForEach(ad => Adverts2.Add(new Advert(ad[0], ad[1])));

            List<string[]> fetched3 = new List<string[]>(proxy.GetAdvertAsync(3).GetAwaiter().GetResult());
            fetched3.ForEach(ad => Adverts3.Add(new Advert(ad[0], ad[1])));

            List<string[]> fetched4 = new List<string[]>(proxy.GetAdvertAsync(4).GetAwaiter().GetResult());
            fetched4.ForEach(ad => Adverts4.Add(new Advert(ad[0], ad[1])));
        

        }

    }

}
