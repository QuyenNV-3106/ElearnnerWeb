using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ELearnerApi.Models;

namespace ElearnerWebApp.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public CreateModel(ELearnerApi.Models.ElearnnerDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "ImgUrl");
            return Page();
        }

        [BindProperty]
        public ELearnerApi.Models.Account Account { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_context.Accounts.SingleOrDefault(p => p.Email == Account.Email) is not null)
            {
                ViewData["msg"] = "Duplicate email";
                return Page();
            }

            Account.Role = "teacher";
            Account.Status = "enable";

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
