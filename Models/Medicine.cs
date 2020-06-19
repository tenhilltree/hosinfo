using System;
using System.ComponentModel.DataAnnotations;

namespace RazorSecond.Models
{
    public class Medicine
    {
        public Guid ID { get; set; }

        [MaxLength(10)]
        [Display(Name = "药品编码")]
        [Required(ErrorMessage = "请输入药品编码")]
        public string Code { get; set; }

        [MaxLength(20)]
        [Display(Name = "名称")]
        [Required(ErrorMessage = "请输入名称")]
        public string Name { get; set; }

        [Display(Name = "种类")]
        [Required(ErrorMessage = "请选择种类")]
        public MedicineType Type { get; set; }

        [Display(Name = "生产日期")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "请选择生产日期")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "有效期限(月)")]
        [Required(ErrorMessage = "请输入有效期限")]
        public int LeftMonths { get; set; }

        [Display(Name = "厂家")]
        [Required(ErrorMessage = "请输入厂家")]
        [MaxLength(50)]
        public string Factory { get; set; }
    }

    public enum MedicineType
    {
        甲 = 1,
        乙,
        丙
    }
}