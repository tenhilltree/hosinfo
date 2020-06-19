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
    public class IndexModel : PageModel
    {
        private readonly RazorSecond.Data.RecDbContext _context;

        public IndexModel(RazorSecond.Data.RecDbContext context)
        {
            _context = context;
        }

        public IList<TreatRecord> TreatRecord { get;set; }

        public async Task OnGetAsync()
        {
            TreatRecord = await _context.TreatRecord.ToListAsync();
        }
    }
}
