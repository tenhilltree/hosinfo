using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorSecond.Data;
using RazorSecond.Models;

namespace RazorSecond.Pages.Medicines
{
    public class EditModel : PageModel
    {
        private readonly RazorSecond.Data.HosDbContext _context;

        public EditModel(RazorSecond.Data.HosDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Medicine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(Medicine.ID))
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

        private bool MedicineExists(Guid id)
        {
            return _context.Medicine.Any(e => e.ID == id);
        }
    }
}
