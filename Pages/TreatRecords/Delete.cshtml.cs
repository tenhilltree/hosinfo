using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorSecond.Data;
using RazorSecond.Models;

namespace RazorSecond.Pages.TreatRecords
{
    public class DeleteModel : PageModel
    {
        private readonly RazorSecond.Data.RecDbContext _context;

        public DeleteModel(RazorSecond.Data.RecDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TreatRecord TreatRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TreatRecord = await _context.TreatRecord.FirstOrDefaultAsync(m => m.ID == id);

            if (TreatRecord == null)
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

            TreatRecord = await _context.TreatRecord.FindAsync(id);

            if (TreatRecord != null)
            {
                _context.TreatRecord.Remove(TreatRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
