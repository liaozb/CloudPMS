using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudPMS.Web.Models
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "请输入姓名。"),MaxLength(10,ErrorMessage = "最长10个字符")]
        public string UserName { get; set; }
    }
}