using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [EmailAddress(ErrorMessage = "آدرس ایمیل وارد شده معتبر نمی‌باشد")]
        [Display(Name = "ایمیل")]
        [Remote("VerifyEmail","Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور وارد شده مطابقت ندارد")]
        [Display(Name = "تکرار کلمه عبور")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [EmailAddress(ErrorMessage = "آدرس ایمیل وارد شده معتبر نمی‌باشد")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
