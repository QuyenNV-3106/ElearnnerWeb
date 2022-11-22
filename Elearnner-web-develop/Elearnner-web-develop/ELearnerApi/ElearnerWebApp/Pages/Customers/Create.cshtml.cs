using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ELearnerApi.Models;
using ElearnnerApi;

namespace ElearnerWebApp.Pages.Customers
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
        ViewData["status"] = new SelectList(AutoGenerate.GenerateStatusUser(), "Kind", "Kind");
            return Page();
        }

        [BindProperty]
        public ELearnerApi.Models.Account Accounts { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accounts.Add(Accounts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
