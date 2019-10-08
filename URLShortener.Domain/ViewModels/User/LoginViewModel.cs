
using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.ViewModels.User
{
    /// <summary>
    /// مدل اطلاعات ورود کاربر
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        public string UserName { get; set; }
        /// <summary>
        /// رمز عبور
        /// </summary>
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        public string Password { get; set; }

        /// <summary>
        /// مرابخاطر بسپار
        /// </summary>
        [Display(Name = "مرا بخاطر بسپار")]
        public bool IsRemmember { get; set; }
    }
}
