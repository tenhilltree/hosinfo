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

        public IList<Medicine> Medicine { get;set; }

        public async Task OnGetAsync()
        {
            Medicine = await _context.Medicine.ToListAsync();
        }
    }
}
