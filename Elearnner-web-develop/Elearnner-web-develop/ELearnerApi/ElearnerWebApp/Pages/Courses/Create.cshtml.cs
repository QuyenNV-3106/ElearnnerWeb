using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ELearnerApi.Models;
using ElearnnerApi;
using ElearnnerApi.Models;

namespace ElearnerWebApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public CreateModel(ELearnerApi.Models.ElearnnerDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Kindd> Kinds { get; set; }

        public IActionResult OnGet()
        {
            ViewData["kind"] = new SelectList(AutoGenerate.GenerateKindTopics(), nameof(Kindd.Kind), nameof(Kindd.Kind));
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
