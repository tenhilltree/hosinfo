using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorSecond.Data;
using RazorSecond.Models;

namespace RazorSecond.Pages.Medicines
{
    public class DeleteModel : PageModel
    {
        private readonly RazorSecond.Data.HosDbContext _context;

        public DeleteModel(RazorSecond.Data.HosDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medicine Medicine { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicine = await _context.Medicine.FirstOrDefaultAsync(m => m.ID == id);

            if (Medicine == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicine = await _context.Medicine.FindAsync(id);

            if (Medicine != null)
            {
                _context.Medicine.Remove(Medicine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
