using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSecond.Data;
using RazorSecond.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RazorSecond.Pages.TreatRecords
{
    public class CreateModel : PageModel
    {
        private readonly RazorSecond.Data.RecDbContext _context;
        private readonly RazorSecond.Data.HosDbContext _hosContext;

        public CreateModel(RazorSecond.Data.RecDbContext context, HosDbContext hosContext)
        {
            _context = context;
            _hosContext = hosContext;
        }

        public async Task<IActionResult> OnGet()
        {
            IQueryable<SelectListItem> doctorQuery = from m in _hosContext.Stuff
                                                     orderby m.Department
                                                     select new SelectListItem { Value = m.ID.ToString(), Text = $"{m.Name}({m.Department})" };
            IQueryable<SelectListItem> medicineQuery = from m in _hosContext.Medicine
                                                     orderby m.Name
                                                     select new SelectListItem { Value = m.ID.ToString(), Text = $"{m.Name}({m.Code})" };
            Doctors = await doctorQuery.ToArrayAsync();
            Medicines = await medicineQuery.ToArrayAsync();
            return Page();
        }

        [BindProperty]
        public TreatRecord TreatRecord { get; set; }

        public SelectListItem[] Doctors { get; set; }
        public SelectListItem[] Medicines { get; set; }

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
