using System;
using System.Linq;
using URLShortener.Data.Context;
using URLShortener.Domain.Interfaces;
using URLShortener.Domain.Roles;
using URLShortener.Domain.Users;

namespace URLShortener.Data.Repositories
{

    /// <summary>
    /// کلاس ارتباط با دیتابیس کاربر 
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private MyContext _ctx;

        public UserRepository(MyContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// بررسی موجود بودن ایمیل
        /// </summary>
        /// <param name="email">ایمیل</param>
        /// <returns>بلی/خیر</returns>
        public bool CheckEmailExist(string email)
        {
            return _ctx.Users.Any(u => u.Email == email);
        }
        /// <summary>
        /// افزودن کاربر جدید
        /// </summary>
        /// <param name="user">مدل کاربر</param>
        /// <returns>شناسه کاربر افزوده شده</returns>
        public void AddUser(User user)
        {
            _ctx.Add(user);
            _ctx.SaveChanges();
        }

        /// <summary>
        /// بروزرسانی اطلاعات کاربر
        /// </summary>
        /// <param name="user">مدل اطلاعات کاربر</param>
        public void UpdateUser(User user)
        {
            _ctx.Update(user);
            _ctx.SaveChanges();
        }


        /// <summary>
        /// بررسی موجود بودن نام کاربری
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        /// <returns>بلی/خیر</returns>
        public bool IsExistUsername(string userName)
        {
            return _ctx.Users.Any(u => u.UserName == userName);
        }


        /// <summary>
        /// انتخاب شناسه نقش 
        /// </summary>
        /// <param name="rolName">نام انگلیسی نقش</param>
        /// <returns>شناسه نقش</returns>
        public Guid GetRolId(string rolName)
        {
            return _ctx.Roles.Where(u => u.EnName == rolName).Select(x => x.Id).SingleOrDefault();
        }

        /// <summary>
        /// افوزدن نقش
        /// </summary>
        /// <param name="role">مدل اطلاعات نقش</param>
        public void AddRol(Role role)
        {
            _ctx.Roles.Add(role);
            _ctx.SaveChanges();
        }

        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        public User GetUser(Guid userId)
        {
            return _ctx.Users.Where(u => u.Id == userId).SingleOrDefault();
        }

        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userName">نام کاربر</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        public User GetUser(string userName)
        {
            return _ctx.Users.Where(u => u.UserName == userName && u.IsEnable).SingleOrDefault();
        }

        /// <summary>
        /// انتخاب کاربر
        /// </summary>
        /// <param name="userName">نام کاربر</param>
        /// <param name="password">رمز عبور</param>
        /// <returns>مدل اطلاعات کاربر</returns>
        public User GetUser(string userName, string Password)
        {
            return _ctx.Users
                .Where(u => u.UserName == userName && u.Password == Password)
                //.Include(x => x.UserProfile)
                .SingleOrDefault();
        }

    }

}
