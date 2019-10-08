using System;
using URLShortener.Domain.Users;

namespace URLShortener.Core.Interfaces
{
    /// <summary>
    /// اینترفیس سرویس کاربر
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// بررسی موجود بودن نام کاربری
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        /// <returns>بلی/خیر</returns>
        bool CheckUserNameExist(string userName);
        /// <summary>
        /// بررسی موجود بودن ایمیل
        /// </summary>
        /// <param name="email">ایمیل</param>
        /// <returns>بلی/خیر</returns>
        bool CheckEmailExist(string email);
        /// <summary>
        /// افزودن کاربر جدید
        /// </summary>
        /// <param name="user">مدل کاربر</param>
        /// <returns>شناسه کاربر افزوده شده</returns>
        Guid AddUser(User user);
        /// <summary>
        /// انتخاب اطلاعات کاربر
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>اطلاعات کاربر مدل کاربر</returns>
        User GetUser(Guid userId);
        /// <summary>
        /// انتخاب اطلات کاربر با نام کاربرری
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        /// <returns>اطلاعات کاربر</returns>
        User GetUser(string userName);
        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        /// <param name="password">رمز عبور</param>
        /// <returns>اطلاعات کاربر</returns>
        User GetUser(string userName, string password);
        /// <summary>
        /// بروزرسانی اطلاعات کاربر
        /// </summary>
        /// <param name="user">مدل اطلاعات کاربر</param>
        void UpdateUser(User user);

        /// <summary>
        /// انتخاب شناسه نقش  
        /// </summary>
        /// <param name="rolName">نام انگلیسی نقش</param>
        /// <returns>شناسه نقش</returns>
        Guid GetRolId(string rolName);

    }

}
