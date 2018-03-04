using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Robonauts.Pages.Workshop
{
    public class MumbaiUniversityModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Remove("linkTab");
            HttpContext.Session.SetString("linkTab", "galleryTab");
        }
    }
}