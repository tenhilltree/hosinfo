using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSecond.Data;
using RazorSecond.Models;

namespace RazorSecond.Pages.TreatRecords
{
    public class CreateModel : PageModel
    {
        private readonly RazorSecond.Data.RecDbContext _context;

        public CreateModel(RazorSecond.Data.RecDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TreatRecord TreatRecord { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TreatRecord.Add(TreatRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
