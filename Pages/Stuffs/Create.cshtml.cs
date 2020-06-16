using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSecond.Data;
using RazorSecond.Models;

namespace RazorSecond.Pages.Stuffs
{
    public class CreateModel : PageModel
    {
        private readonly RazorSecond.Data.HosDbContext _context;

        public CreateModel(RazorSecond.Data.HosDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stuff Stuff { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stuff.Add(Stuff);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
