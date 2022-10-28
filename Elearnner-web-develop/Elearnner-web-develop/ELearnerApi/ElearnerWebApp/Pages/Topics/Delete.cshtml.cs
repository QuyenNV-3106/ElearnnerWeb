using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElearnerApi.Models;

namespace ElearnerWebApp.Pages.Topics
{
    public class DeleteModel : PageModel
    {
        private readonly ElearnnerDBContext _context;

        public DeleteModel(ElearnnerDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = await _context.Topics.FirstOrDefaultAsync(m => m.Id == id);

            if (Topic == null)
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

            Topic = await _context.Topics.FindAsync(id);

            if (Topic != null)
            {
                _context.Topics.Remove(Topic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
