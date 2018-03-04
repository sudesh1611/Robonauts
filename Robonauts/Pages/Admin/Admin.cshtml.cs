using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Robonauts.Models;

namespace Robonauts.Pages.Admin
{
    public class AdminModel : PageModel
    {
        private readonly UserDbContext _userContext;
        private readonly QueryMessageDbContext _queryContext;
        private readonly StudentDbContext _studentContext;
        public AdminModel(UserDbContext UserContext,QueryMessageDbContext QueryContext,StudentDbContext StudentContext)
        {
            _userContext = UserContext;
            _queryContext = QueryContext;
            _studentContext = StudentContext;
        }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public string AddedUserMessage { get; set; }

        public List<User> UserAccounts { get; set; }
        public List<Student> Subscribers { get; set; }
        public List<QueryMessage> QueryMessages { get; set; }

        [BindProperty]
        public User NewUser { get; set; }

        public async void OnGetAsync()
        {
            UserAccounts = new List<User>();
            Subscribers = new List<Student>();
            QueryMessages = new List<QueryMessage>();
            //Problem solution is here
            if (TempData.Peek("LoggedUserName") ==null)
            {
                Message = "You Have To Log In First";
            }
            else
            {
                TempData.Clear();
                UserAccounts = await _userContext.User.ToListAsync();
                Subscribers = await _studentContext.Student.ToListAsync();
                QueryMessages = await _queryContext.QueryMessage.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (TempData.Peek("LoggedUserName") == null)
            {
                Message = "You Have To Log In First";
                return RedirectToPage("/Admin/Login");
            }
            foreach (var item in _userContext.User.ToList())
            {
                if(item.UserName==NewUser.UserName)
                {
                    AddedUserMessage = NewUser.UserName + " already exists!";
                    return Page();
                }
            }
            _userContext.User.Add(NewUser);
            await _userContext.SaveChangesAsync();
            Message = "";
            AddedUserMessage = NewUser.UserName + " added successfully.";
            return RedirectToPage("/Admin/Admin");
        }
    }
}