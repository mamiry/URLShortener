using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using URLShortener.Domain.Users;

namespace URLShortener.Domain.Roles
{
    /// <summary>
    /// جدول  نقش کاربر
    /// </summary>
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        public string FaName { get; set; }
        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند از {1} بیشتر باشد")]
        public String EnName { get; set; }

        public List<User> Users { get; set; }
    }

}
