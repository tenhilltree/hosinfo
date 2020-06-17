using System;
using System.ComponentModel.DataAnnotations;

namespace RazorSecond.Models
{
    public class Stuff
    {
        public int ID { get; set; }

        [MaxLength(10)]
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "123")]
        public string Name { get; set; }

        [Display(Name = "性别")]
        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "职务")]
        public Title? Title { get; set; }

        [Display(Name = "所在科室")]
        public Department? Department { get; set; }
    }

    public enum Gender
    {

        [Display(Name = "男")]
        male = 1,
        [Display(Name = "女")]
        female,
    }

    public enum Department
    {
        [Display(Name = "眼科")]
        眼科 = 1,
        [Display(Name = "口腔科")]
        口腔科,
        [Display(Name = "骨科")]
        骨科
    }

    public enum Title
    {
        [Display(Name = "主任医师")]
        主任医师 = 1,
        [Display(Name = "副主任医师")]
        副主任医师,

    }
}