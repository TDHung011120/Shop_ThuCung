using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop_ThuCung.Models
{
    public class LoginAdminModel
    {
        [Required(ErrorMessage ="Mời bạn nhập UserName")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập PassWord")]
        public string Password { get; set; }

        public Boolean RememberMe { get; set; }
    }
}