using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RazorSecond.Models
{
    public class TreatRecord
    {
        public Guid ID { get; set; }

        [MaxLength(3)]
        [RegularExpression(@"^\d3$", ErrorMessage = "患者编码必须为3位数字")]
        [Display(Name = "患者编码")]
        [Required(ErrorMessage = "请输入患者编码")]
        public string Code { get; set; }

        [MaxLength(10)]
        [Display(Name = "患者姓名")]
        [Required(ErrorMessage = "请输入患者姓名")]
        public string Name { get; set; }

        [Display(Name = "患者年龄")]
        [Required(ErrorMessage = "请输入患者年龄")]
        public int Age { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string MedicineId { get; set; }

        [Display(Name = "接诊日期")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "请选择接诊日期")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "主治医师")]
        [Required(ErrorMessage = "请选择主治医师")]
        [NotMapped]
        public Stuff Doctor { get; set; }

        [Display(Name = "用药名称")]
        [Required(ErrorMessage = "请选择药品")]
        [NotMapped]
        public Medicine Medicine { get; set; }
    }
}