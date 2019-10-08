using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.ViewModels.User
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfirmViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")] 
        public string UserName { get; set; }

        [Display(Name = "کد تایید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(5, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        [DataType(DataType.Password)]
        public string VerifyCode { get; set; }


    }
}
