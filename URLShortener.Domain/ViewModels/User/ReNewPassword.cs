using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace URLShortener.Domain.ViewModels.User
{
    public class ReNewPassword
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")] 
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = " تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }

}
