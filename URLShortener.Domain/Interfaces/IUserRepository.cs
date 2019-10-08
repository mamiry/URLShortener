using System;
using URLShortener.Domain.Roles;
using URLShortener.Domain.Users;

namespace URLShortener.Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// بررسی موجود بودن نام کاربری
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        /// <returns>بلی/خیر</returns>
        bool IsExistUsername(string userName);
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
        void AddUser(User users);
        /// <summary>
        /// بروزرسانی اطلاعات کاربر
        /// </summary>
        /// <param name="user">مدل اطلاعات کاربر</param>
        void UpdateUser(User users);

        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        User GetUser(Guid userId);
        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userName">نام کاربر</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        User GetUser(string userName);
        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userName">نام کاربر</param>
        /// <param name="password">رمز عبور</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        User GetUser(string userName, string Password);

        /// <summary>
        /// انتخاب شناسه نقش 
        /// </summary>
        /// <param name="rolName">نام انگلیسی نقش</param>
        /// <returns>شناسه نقش</returns>
        Guid GetRolId(string rolName);
        /// <summary>
        /// افوزدن نقش
        /// </summary>
        /// <param name="role">مدل اطلاعات نقش</param>
        void AddRol(Role rolName);


    }

}
