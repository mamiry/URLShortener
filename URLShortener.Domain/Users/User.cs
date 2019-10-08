using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using URLShortener.Domain.Roles;
using URLShortener.Domain.WebUrls;

namespace URLShortener.Domain.Users
{
    /// <summary>
    /// جدول کاربران
    /// </summary>
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        public string Password { get; set; }

        [Display(Name = "پست الکترونیک")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 


        [Display(Name = "تاریخ ثبت نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public DateTime CreationTime { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsEnable { get; set; }
         

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public List<WebUrl> WebUrls { get; set; }
    }
}
