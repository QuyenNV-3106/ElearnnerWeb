using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELearnerApi.Models;

namespace ElearnerWebApp.Pages.Teachers
{
    public class EditModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public EditModel(ELearnerApi.Models.ElearnnerDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ELearnerApi.Models.Accounts Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = await _context.Accounts
                .Include(a => a.Topic).FirstOrDefaultAsync(m => m.Id == id);

            if (Account == null)
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
            ELearnerApi.Models.Accounts account = new ELearnerApi.Models.Accounts();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_context.Accounts.SingleOrDefault(p => p.Email == Account.Email) is not null)
            {
                ViewData["msg"] = "Duplicate email";
                return Page();
            }

            _context.Attach(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.Id))
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

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
