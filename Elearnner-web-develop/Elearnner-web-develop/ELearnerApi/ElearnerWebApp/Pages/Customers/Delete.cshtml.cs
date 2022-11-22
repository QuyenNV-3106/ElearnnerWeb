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
    public class DeleteModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public DeleteModel(ELearnerApi.Models.ElearnnerDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ELearnerApi.Models.Account Accounts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accounts = await _context.Accounts
                .Include(a => a.Topic).FirstOrDefaultAsync(m => m.Id == id);

            if (Accounts == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accounts = await _context.Accounts.FindAsync(id);

            if (Accounts != null)
            {
                _context.Accounts.Remove(Accounts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
