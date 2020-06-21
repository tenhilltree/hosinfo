using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorSecond.Data;

namespace RazorSecond.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private HosDbContext _hosContext;
        private RecDbContext _recContext;

        public IndexModel(ILogger<IndexModel> logger, HosDbContext hosContext, RecDbContext recContext)
        {
            _logger = logger;
            _hosContext = hosContext;
            _recContext = recContext;
        }

        public async Task OnGet()
        {
            var stuffs = (from s in _hosContext.Stuff
                          group s by s.Department into g
                          select new
                          {
                              value = g.Count(),
                              name = g.Key.ToString(),
                          });
            ViewData["CountPerDep"] = (await stuffs.ToListAsync()).OrderByDescending(s => s.value);

            var treatRecords = await _recContext.TreatRecord.Select(tr => tr.Age).ToListAsync();
            List<int> ages = Enumerable.Repeat(0, 5).ToList();
            foreach (int record in treatRecords)
            {
                if (record <= 20)
                {
                    ages[0]++;
                }
                else if (record <= 40)
                {
                    ages[1]++;
                }
                else if (record <= 60)
                {
                    ages[2]++;
                }
                else if (record <= 80)
                {
                    ages[3]++;
                }
                else
                {
                    ages[4]++;
                }
            }
            ViewData["PersonsPerAge"] = ages;

        }
    }
}
