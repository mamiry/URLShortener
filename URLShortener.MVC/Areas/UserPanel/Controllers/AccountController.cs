using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using URLShortener.Core.Converter;
using URLShortener.Core.Interfaces;
using URLShortener.Core.Resource;
using URLShortener.Core.Security;
using URLShortener.Domain.Users;
using URLShortener.Domain.ViewModels.User;

namespace URLShortener.MVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]

    public class AccountController : Controller
    {
        /// <summary>
        /// سرویس کاربر
        /// </summary>
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #region RegisterUser
        /// <summary>
        /// متد گت ثبت نام کاربر
        /// </summary>
        /// <returns></returns>
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// متد پست ثبت نام کاربر
        /// </summary>
        /// <param name="register">مدل اطللاعات ثبت نام</param>
        /// <returns></returns>
        [Route("Register")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = Resource_Fa.CompletIedtems;
                return View(register);
            }
            ///بررسی موجود بودن اطلاعات کاربر
            if (_userService.CheckUserNameExist(register.UserName.ToFix()))
            {
                ViewBag.ErrorMessage = Resource_Fa.UserNameIsAllready;
                return View(register);
            }
            ///بررسی جوجود بودن ایمیل
            if (_userService.CheckEmailExist(register.Email.ToFix()))
            {
                ViewBag.ErrorMessage = Resource_Fa.EmailIsAllready;
                return View(register);
            }

            Guid rolId = _userService.GetRolId("User");
            User users = new User
            {
                UserName = register.UserName.ToFix(),
                IsEnable = true,
                CreationTime = DateTime.Now,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                Id = Guid.NewGuid(),
                Email = register.Email.ToFix(),
                RoleId = rolId,
                Role = null,
            };
            _userService.AddUser(users);
            return RedirectToAction("Login", new { message = Resource_Fa.InfoSuccessInsert });

        }
        /// <summary>
        /// متد  گت ورود کاربر
        /// </summary>
        /// <param name="message">پیام جهت نمایش</param>
        /// <returns></returns>
        [Route("Login")]
        public ActionResult Login(string message = null)
        {
            ViewBag.Message = message;
            return View();
        }

        /// <summary>
        /// متد پست ورود کاربر
        /// </summary>
        /// <param name="login">مدل اطلاعات کاربر</param>
        /// <param name="returnUrl">ادرس ورود از دیگر صفحه ها</param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginViewModel login, string returnUrl = "/")
        {
            if (ModelState.IsValid)
            {

                ///رمز عبور تبدیل شده
                string pass = PasswordHelper.EncodePasswordMd5(login.Password);


                var mdl = _userService.GetUser(login.UserName.ToFix(), pass);

                if (mdl != null)
                {
                    if (mdl.IsEnable)
                    {
                        ///جهت ذخیره سازی اطلاعات ورود در سیستم
                        var claims = new List<Claim>()
                             {
                                new Claim(ClaimTypes.Name,mdl.UserName.ToFix()),
                                new Claim(ClaimTypes.NameIdentifier,mdl.Id.ToString()),
                                new Claim(ClaimTypes.IsPersistent,login.IsRemmember.ToString())
                               };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var pricipal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = login.IsRemmember
                        };

                        HttpContext.SignInAsync(pricipal, properties);

                        ///برررسی صحت آدرس بازگشت 
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }

                        return Redirect("/");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = Resource_Fa.UserNotFound;
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = Resource_Fa.UserNotFound;
                }
            }
            else
            {
                ViewBag.ErrorMessage = Resource_Fa.CompletIedtems;
            }
            return View(login);
        }

        /// <summary>
        /// متد خروج
        /// </summary>
        /// <returns></returns>

        [Route("LogOff")]
        public ActionResult LogOff()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }


        #endregion

    }
}