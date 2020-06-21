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
    public class IndexModel : PageModel
    {
        private readonly RazorSecond.Data.HosDbContext _context;

        public IndexModel(RazorSecond.Data.HosDbContext context)
        {
            _context = context;
        }

        public IList<Medicine> Medicine { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public MedicineType? MedicineType { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<Medicine> medicines = from m in _context.Medicine
                                             orderby m.Code
                                             select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                medicines = medicines.Where(s => s.Name.Contains(SearchString) ||
                s.Code.Contains(SearchString) ||
                s.Factory.Contains(SearchString));
            }
            if (MedicineType != null)
            {
                medicines = medicines.Where(s => s.Type == MedicineType);
            }
            Medicine = await medicines.ToListAsync();
        }
    }
}
