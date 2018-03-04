using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Robonauts.Models;

namespace Robonauts.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly Robonauts.Models.QueryMessageDbContext _context;

        [TempData]
        public string Message { get; set; }

        public ContactUsModel(Robonauts.Models.QueryMessageDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("linkTab");
            HttpContext.Session.SetString("linkTab", "registerTab");
            return Page();
        }

        [BindProperty]
        public QueryMessage QueryMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.QueryMessage.Add(QueryMessage);
            await _context.SaveChangesAsync();
            Message = "We will contact you soon "+ QueryMessage.Name+".";
            return RedirectToPage("/ContactUs");
        }
    }
}