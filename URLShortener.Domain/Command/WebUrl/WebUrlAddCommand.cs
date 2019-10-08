using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.Command.WebUrl
{
    /// <summary>
    /// مدل اطلاعات افزودن لینک
    /// </summary>
    public class WebUrlAddCommand
    {
        [Display(Name = "لینک سایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1024, ErrorMessage = "{0} نمی تواند از {1} حرف بیشتر باشد")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند از {1} حرف کمتر باشد")]
        public string Url { get; set; }
         
    }
}
