using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.ViewModels.User
{
    /// <summary>
    /// مدل اطلاعات ثبت نام کاربر
    /// </summary>
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "پست الکترونیک")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

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
