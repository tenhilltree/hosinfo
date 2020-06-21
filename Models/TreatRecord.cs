using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace RazorSecond.Models
{
    public class TreatRecord
    {
        public Guid ID { get; set; }

        [MaxLength(3)]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "患者编码必须为3位数字")]
        [Display(Name = "患者编码")]
        [Required(ErrorMessage = "请输入患者编码")]
        [PageRemote(
            ErrorMessage = "已存在相同的编码",
            // AdditionalFields = "__RequestVerificationToken",
            HttpMethod = "get",
            PageHandler = "CheckCode"
        )]
        public string Code { get; set; }

        [MaxLength(10)]
        [Display(Name = "患者姓名")]
        [Required(ErrorMessage = "请输入患者姓名")]
        public string Name { get; set; }

        [Display(Name = "患者年龄")]
        [Required(ErrorMessage = "请输入患者年龄")]
        public int Age { get; set; }

        [Required(ErrorMessage = "请选择主治医师")]
        [Display(Name = "主治医师")]
        public int DoctorId { get; set; }

        [NotMapped]
        public string DoctorName { get; set; }

        [Display(Name = "用药名称")]
        public string MedicineId { get; set; }

        [NotMapped]
        public string MedicineName { get; set; }

        [Display(Name = "接诊日期")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "请选择接诊日期")]
        public DateTime ReleaseDate { get; set; }
    }
}