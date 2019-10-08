using System;
using System.ComponentModel.DataAnnotations;
using URLShortener.Domain.Users;

namespace URLShortener.Domain.WebUrls
{
    /// <summary>
    /// جدول   آدرس سایت و لینک کوتاه 
    /// </summary>
    public class WebUrl
    {
        [Key]
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
        public string UrlShort { get; set; }

        [Display(Name = "تعداد کلیک")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int ClickCount { get; set; }

        [Display(Name = "زمان ایجاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public DateTime CreateTime { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
