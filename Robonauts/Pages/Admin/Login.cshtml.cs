using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Robonauts.Pages.Admin
{
    public class UserLoginClass
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LoginModel : PageModel
    {
        private readonly Robonauts.Models.UserDbContext _context;

        public LoginModel(Robonauts.Models.UserDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserLoginClass CurrentUser { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var Users = await _context.User.ToListAsync();
            foreach (var item in Users)
            {
                if(item.UserName==CurrentUser.UserName)
                {
                    if(item.Password==CurrentUser.Password)
                    {
                        TempData.Add("LoggedUserName", CurrentUser.UserName);
                        return RedirectToPage("/Admin/Admin");
                    }
                    Message = "Username or Password is Incorrect.";
                    return Page();
                }
            }
            Message = "Username or Password is Incorrect.";
            return Page();
            
        }

        
    }
}