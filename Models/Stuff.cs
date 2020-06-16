using System;
using System.ComponentModel.DataAnnotations;

namespace RazorSecond.Models
{
    public class Stuff
    {
        public int ID { get; set; }

        [MaxLength(10)]
        [Display(Name = "姓名")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "性别")]
        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "职务")]
        public Title Title { get; set; }

        [Display(Name = "所在科室")]
        public Department Department { get; set; }
    }

    public enum Gender
    {
        男,
        女,
    }

    public enum Department
    {
        眼科,
        口腔科,
        骨科
    }

    public enum Title
    {
        主任医师,
        副主任医师,

    }
}