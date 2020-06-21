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
        private readonly RecDbContext _context;
        private readonly HosDbContext _hosContext;

        public IndexModel(RecDbContext context, HosDbContext hosContext)
        {
            _context = context;
            _hosContext = hosContext;
        }

        public List<TreatRecord> TreatRecord { get; set; }

        Func<TreatRecord, Stuff, Medicine, TreatRecord> Fill = (TreatRecord tr, Stuff s, Medicine m) =>
        {
            tr.MedicineName = m == null ? "" : m.Name;
            tr.DoctorName = s.Name;
            return tr;
        };
        public async Task OnGetAsync()
        {
            var doctors = await _hosContext.Stuff.ToListAsync();
            var medicines = await _hosContext.Medicine.ToListAsync();
            var treatRecords = await _context.TreatRecord.ToListAsync();

            var result = from tr in treatRecords
                         join m in medicines on new { id = (tr.MedicineId ?? "").ToUpper() } equals new { id = m.ID.ToString().ToUpper() } into t
                         from rt in t.DefaultIfEmpty()
                         join s in doctors on tr.DoctorId equals s.ID
                         select Fill(tr, s, rt);

            // var entryPoint = from tr in _context.TreatRecord
            //                  join m in _hosContext.Medicine  on tr.MedicineId equals m.ID.ToString()
            //                  join s in _hosContext.Stuff on tr.DoctorId equals s.ID
            //                  select Fill(tr, s, m);
            TreatRecord = result.ToList();
        }
    }
}
