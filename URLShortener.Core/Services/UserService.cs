using System;
using URLShortener.Core.Interfaces;
using URLShortener.Domain.Interfaces;
using URLShortener.Domain.Roles;
using URLShortener.Domain.Users;

namespace URLShortener.Core.Services
{
    /// <summary>
    /// سرویس کاربر
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// ایجاد اینترفیس از ریپوزیتوری کاربر
        /// </summary>
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// بررسی موجود بودن ایمیل
        /// </summary>
        /// <param name="email">ایمیل</param>
        /// <returns>بلی/خیر</returns>
        public bool CheckEmailExist(string email)
        {
            return _userRepository.CheckEmailExist(email);
        }

        /// <summary>
        /// افزودن کاربر
        /// </summary>
        /// <param name="user">مدل اطلاعات کاربر</param>
        /// <returns>شناسه کاربر افزوده شده</returns>
        public Guid AddUser(User user)
        {
            _userRepository.AddUser(user); 
            return user.Id;
        }
        /// <summary>
        /// بروزرسانی کاربر
        /// </summary>
        /// <param name="user">مدل اطلاعات کاربر</param>
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user); 
        }

        /// <summary>
        /// انتخاب شناسه نقش 
        /// </summary>
        /// <param name="rolName">نام انگلیسی نقش</param>
        /// <returns>شناسه نقش</returns>
        public Guid GetRolId(string rolName)
        {
            ///بررسی موجود بودن اطلاعات نقش پیش فرض جدول نقش ها
            /// این متد فقط برای این پروزه نوشته شده که در هنگام تست و بررسی با خطا نبودن مواجه نشود
            CheckSeedRol();
            return _userRepository.GetRolId(rolName);
        }
        /// <summary>
        /// بررسی موجود بودن نقش های پیش فرض
        /// </summary>
        private void CheckSeedRol()
        {
            ///نقش مدیر
            var rolAdmin = _userRepository.GetRolId("Admin");
            if (rolAdmin == Guid.Empty)
            {
                _userRepository.AddRol(new Role()
                {
                    Id = Guid.NewGuid(),
                    EnName = "Admin",
                    FaName = "مدیر",
                    Users = null
                });
            }
            ///نقش کاربر عادی
            var rolUser = _userRepository.GetRolId("User");
            if (rolUser == Guid.Empty)
            {
                _userRepository.AddRol(new Role()
                {
                    Id = Guid.NewGuid(),
                    EnName = "User",
                    FaName = "کاربر",
                    Users = null
                });
            }
        }

        /// <summary>
        /// بررسی موجود بودن نام کاربری
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        /// <returns>بلی/خیر</returns>
        public bool CheckUserNameExist(string userName)
        {
            return _userRepository.IsExistUsername(userName);
        }

        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        public User GetUser(Guid userId)
        {
            return _userRepository.GetUser(userId);
        }

        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userName">نام کاربر</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        public User GetUser(string userName)
        {
            return _userRepository.GetUser(userName);
        }
        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userName">نام کاربر</param>
        /// <param name="password">رمز عبور</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        public User GetUser(string userName, string password)
        {
            return _userRepository.GetUser(userName, password);
        }
    }
}
