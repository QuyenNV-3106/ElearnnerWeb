using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ELearnerApi.Models;

namespace ElearnerWebApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ElearnnerDBContext _context;

        public IndexModel(ElearnnerDBContext context)
        {
            _context = context;
        }

        public IList<ELearnerApi.Models.Account> Accounts { get;set; }

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
                    where account.Role == "user"
                    select account;

            Accounts = a
                .Include(a => a.Topic).ToList();
            return Page();
        }
    }
}
