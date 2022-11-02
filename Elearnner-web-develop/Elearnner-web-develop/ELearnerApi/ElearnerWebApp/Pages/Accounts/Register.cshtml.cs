using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ELearnerApi.Models;

namespace ElearnerWebApp.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public RegisterModel(ELearnerApi.Models.ElearnnerDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "ImgUrl");
            return Page();
        }

        [BindProperty]
        public ELearnerApi.Models.Accounts Accounts { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_context.Accounts.SingleOrDefault(p => p.Email == Accounts.Email) is not null)
            {
                ViewData["msg"] = "Duplicate email";
                return Page();
            }

            Accounts.Role = "user";
            Accounts.Status = "none";
            _context.Accounts.Add(Accounts);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/Login");
        }
    }
}
