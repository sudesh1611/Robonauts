using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Robonauts.Models;

namespace Robonauts.Pages.Students
{
    public class RegisterStudentModel : PageModel
    {
        private readonly Robonauts.Models.StudentDbContext _context;

        [TempData]
        public string Message { get; set; }

        [TempData]
        public string EmailErrorMessage { get; set; }

        public RegisterStudentModel(Robonauts.Models.StudentDbContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("linkTab");
            HttpContext.Session.SetString("linkTab", "subscribeTab");
            return Page();
        }

        //[HttpPost]
        //[Route("/Students/RegisterStudent/EmailCheck")]
        //public string EmailCheck(string email)
        //{
        //    foreach (var item in EmailList)
        //    {
        //        if (item == email)
        //        {
        //            return "tru";
        //        }
        //    }
        //    return "fals";
        //}

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var tempStudents = _context.Student.ToList();
            foreach (var item in tempStudents)
            {
                if(item.Email==Student.Email)
                {
                    EmailErrorMessage = "Email ID is already registered";
                    return Page();
                }
            }
            _context.Student.Add(Student);
            await _context.SaveChangesAsync();
            Message = Student.FirstName + " "+Student.LastName+" registered successfully.";
            return RedirectToPage("/Students/RegisterStudent");
        }
    }
}