using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELearnerApi.Models;

namespace ElearnerWebApp.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public EditModel(ELearnerApi.Models.ElearnnerDBContext context)
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
           ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "ImgUrl");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsExists(Accounts.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AccountsExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
