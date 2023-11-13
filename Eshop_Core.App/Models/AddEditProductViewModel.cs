using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public decimal Price { get; set; }
        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int QuantityInStock { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name="تصویر")]
        public IFormFile Picturee { get; set; }
        public List<Category> Categories { get; set; }
        public List<int> selectedGroups { get; set; }
    }
}
