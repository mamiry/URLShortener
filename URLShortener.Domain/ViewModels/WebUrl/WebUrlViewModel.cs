using System;
using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.ViewModels.WebUrl
{
    /// <summary>
    /// مدل اطلاعات لینک
    /// </summary>
    public class WebUrlViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "لینک سایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1024, ErrorMessage = "{0} نمی تواند از {1} حرف بیشتر باشد")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند از {1} حرف کمتر باشد")]
        public string Url { get; set; }
         

        [Display(Name = "لینک جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1024, ErrorMessage = "{0} نمی تواند از {1} حرف بیشتر باشد")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند از {1} حرف کمتر باشد")]
        public string UrlShort  { get; set; }
 

        [Display(Name = "تعداد بازدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")] 
        public int ClickCount { get; set; }
    }
}
