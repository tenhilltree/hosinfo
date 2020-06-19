using System;
using System.ComponentModel.DataAnnotations;

namespace RazorSecond.Models
{
    public class Medicine
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int LeftMonths { get; set; }

        public string Factory { get; set; }
    }

    public enum MedicineType
    {
        甲 = 1,
        乙,
        丙
    }
}