using System;
using System.ComponentModel.DataAnnotations;

namespace RazorSecond.Models
{
    public class Stuff
    {
        public int ID { get; set; }

        [MaxLength(10)]
        [Display(Name = "姓名*")]
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }

        [Display(Name = "性别*")]
        [Required(ErrorMessage = "请选择性别")]
        public Gender Gender { get; set; }

        [Display(Name = "职务")]
        public Title? Title { get; set; }

        [Display(Name = "所在科室")]
        public Department? Department { get; set; }
    }

    public enum Gender
    {
        男 = 1,
        女,
    }

    public enum Department
    {
        眼科 = 1,
        口腔科, 骨科, 心脏外科, 泌尿外科, 普通外科, 烧伤外科, 胸外科, 肝胆外科, 血管外科, 胸腺外科, 器官移植科, 儿科, 疼痛科, 麻醉科, 重症医学科, 皮肤科, 妇产科, 针灸科
    }

    public enum Title
    {
        主任医师 = 1,
        副主任医师,
        主治医师,
        住院医师,
        医师
    }
}