﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Robonauts.Models;

namespace Robonauts.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Robonauts.Models.StudentDbContext _context;

        public IndexModel(Robonauts.Models.StudentDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
