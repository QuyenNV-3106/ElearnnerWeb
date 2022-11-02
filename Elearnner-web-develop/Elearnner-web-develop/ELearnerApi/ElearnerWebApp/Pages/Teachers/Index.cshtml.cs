using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ELearnerApi.Models;

namespace ElearnerWebApp.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public IndexModel(ELearnerApi.Models.ElearnnerDBContext context)
        {
            _context = context;
        }

        public IList<ELearnerApi.Models.Accounts> Account { get; set; }

        public IActionResult OnGetAsync()
        {
            if (!User.IsInRole("admin"))
            {
                if (User.IsInRole("teacher")) { return RedirectToPage("/TopicsTeacher/TopicTeacher"); }
                else
                {
                    return RedirectToPage("/Index");
                }

            }
            var a = from account in _context.Accounts
                    where account.Role == "teacher" || account.Role == "user"
                    select account;

            Account = a
                .Include(a => a.Topic).ToList();
            return Page();
        }
    }
}
