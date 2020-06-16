using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorSecond.Data;
using RazorSecond.Models;

namespace RazorSecond.Pages.Stuffs
{
    public class DeleteModel : PageModel
    {
        private readonly RazorSecond.Data.HosDbContext _context;

        public DeleteModel(RazorSecond.Data.HosDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stuff Stuff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stuff = await _context.Stuff.FirstOrDefaultAsync(m => m.ID == id);

            if (Stuff == null)
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

            Stuff = await _context.Stuff.FindAsync(id);

            if (Stuff != null)
            {
                _context.Stuff.Remove(Stuff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
