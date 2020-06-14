using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorSecond.Pages
{
    public class DepartmentModel : PageModel
    {
        private readonly ILogger<DepartmentModel> _logger;

        public DepartmentModel(ILogger<DepartmentModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
