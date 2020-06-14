using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorSecond.Pages
{
    public class StuffModel : PageModel
    {
        private readonly ILogger<StuffModel> _logger;

        public StuffModel(ILogger<StuffModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
