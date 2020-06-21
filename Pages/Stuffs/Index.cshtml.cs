using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IList<Stuff> Stuff { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genders { get; set; }
        [BindProperty(SupportsGet = true)]
        public Gender? Gender { get; set; }
        public SelectList Titles { get; set; }
        [BindProperty(SupportsGet = true)]
        public Title? Title { get; set; }
        public SelectList Departments { get; set; }
        [BindProperty(SupportsGet = true)]
        public Department? Department { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Gender> genderQuery = from m in _context.Stuff
                                             orderby m.Gender
                                             select m.Gender;
            IQueryable<Title?> titleQuery = from m in _context.Stuff
                                            orderby m.Title
                                            select m.Title;
            IQueryable<Department?> departmentQuery = from m in _context.Stuff
                                                      orderby m.Department
                                                      select m.Department;
            var stuffs = from m in _context.Stuff
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                stuffs = stuffs.Where(s => s.Name.Contains(SearchString));
            }
            if (Gender != null)
            {
                stuffs = stuffs.Where(s => s.Gender == Gender);
            }
            if (Title != null)
            {
                stuffs = stuffs.Where(s => s.Title == Title);
            }
            if (Department != null)
            {
                stuffs = stuffs.Where(s => s.Department == Department);
            }
            Genders = ViewData["Genders"] == null ? new SelectList(await genderQuery.Distinct().ToArrayAsync()) : (SelectList)ViewData["Genders"];
            Titles = new SelectList(await titleQuery.Distinct().ToArrayAsync());
            Departments = new SelectList(await departmentQuery.Distinct().ToArrayAsync());
            ViewData["Genders"] = Genders;
            Stuff = await ((IQueryable<Stuff>)stuffs.OrderBy(s => s.Department)).ToListAsync();
        }
    }
}
