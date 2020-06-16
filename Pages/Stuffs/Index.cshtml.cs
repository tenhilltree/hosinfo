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
    public class IndexModel : PageModel
    {
        private readonly RazorSecond.Data.HosDbContext _context;

        public IndexModel(RazorSecond.Data.HosDbContext context)
        {
            _context = context;
        }

        public IList<Stuff> Stuff { get;set; }

        public async Task OnGetAsync()
        {
            Stuff = await _context.Stuff.ToListAsync();
        }
    }
}
