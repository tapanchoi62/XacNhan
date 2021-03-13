using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XacNhan.Models
{
    public class LoginInfo:CommonPropertis
    { 
        [Key]
        public int UserInfo { get; set; }

        public string EmailId { get;set; }

        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassWord { get; set; }

        public bool IsEmailConfirm { get; set; }
    }
}
