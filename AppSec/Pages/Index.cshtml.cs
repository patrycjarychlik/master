﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.WebSockets.Internal;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace AppSec.Pages {
    [AllowAnonymous]
    public class IndexModel : PageModel {
        public void OnGet() {

       }
    }
}
