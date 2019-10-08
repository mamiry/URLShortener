using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using URLShortener.Core.Converter;
using URLShortener.Core.Interfaces;
using URLShortener.Domain.Command.WebUrl;
using URLShortener.Domain.ViewModels.WebUrl;
using URLShortener.Domain.WebUrls;

namespace URLShortener.MVC.Controllers
{
    /// <summary>
    /// بررسی احراز هویت کاربر
    /// </summary>
    [Authorize]
    public class WebUrlsController : Controller
    {
        private IWebUrlService _webUrlService;

        public WebUrlsController(IWebUrlService webUrlService)
        {
            _webUrlService = webUrlService;
        }
        /// <summary>
        /// متد لیست لینک ها
        /// </summary>
        /// <param name="message">پیام نمایشی</param>
        /// <returns></returns>
        public  IActionResult  Index(string message = null)
        {
            ///بدست اوردن شناسه کاربر
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ViewBag.Message = message;
            return View(_webUrlService.GetAll(userId));
        }

        /// <summary>
        /// متد گت افزودن لینک
        /// </summary>
        /// <param name="message">پیام نمایشی</param>
        /// <returns></returns>
        // GET: WebUrls/Create
        public IActionResult Create(string message = null)
        {
            ViewBag.Message = message;
            return View();
        }

        /// <summary>
        /// متد پست افزودن لینک
        /// </summary>
        /// <param name="webUrlAddCommand">مدل اطلاعات لینک</param>
        /// <returns></returns>
        // POST: WebUrls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebUrlAddCommand webUrlAddCommand)
        {
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                
                if (!webUrlAddCommand.Url.ToFix().UrlChecker())
                {
                    return RedirectToAction("Create", new { message = URLShortener.Core.Resource.Resource_Fa.UrlIsNotValid });
                }
                var url = _webUrlService.GetWebUrl(webUrlAddCommand.Url.ToFix());
                if (url != null)
                {
                    return RedirectToAction("Create", new { message = URLShortener.Core.Resource.Resource_Fa.ThisFaNameIsAllready });
                }
                ///حلقه تولید لینک کوتاه و بررسی موجود نبودن در دیتا بیس
                string urlshort = string.Empty;
                string isurl = webUrlAddCommand.Url.ToFix();
                do
                {
                    urlshort = TextHelper.ToShortUrl(5, isurl);
                    isurl = string.Empty;
                } while (_webUrlService.ExistsUrlShort(urlshort));

                Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                WebUrl webUrl = new WebUrl()
                {
                    Id = Guid.Empty,
                    Url = webUrlAddCommand.Url.ToFix(),
                    UrlShort = urlshort,
                    CreateTime = DateTime.Now,
                    ClickCount = 0,
                    UserId = userId
                };
                _webUrlService.Add(webUrl);
                return RedirectToAction(nameof(Index));
            }
            return View(webUrlAddCommand);
        }

        /// <summary>
        /// متد گت ویرایش
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <param name="message">پیام نمایشی</param>
        /// <returns></returns>
        // GET: WebUrlss1/Edit/5
        public async Task<IActionResult> Edit(Guid id, string message = null)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var mdl = _webUrlService.GetWebUrl(id, userId);
            if (mdl == null)
            {
                return RedirectToAction(nameof(Index), new { message = URLShortener.Core.Resource.Resource_Fa.DoNotFindInfo });
            }
            ViewBag.Message = message;
            return View(mdl);
        }

        /// <summary>
        /// متد پست ویرایش لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <param name="webUrlViewModel">مدل اطلاعات لینک</param>
        /// <returns></returns>
        // POST: WebUrlss1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, WebUrlViewModel webUrlViewModel)
        {
            if (ModelState.IsValid)
            {
                var url = _webUrlService.GetWebUrl(webUrlViewModel.Url);
                if (url != null)
                {
                    if (url.Id != id)
                    {
                        return RedirectToAction("Edit", new { message = URLShortener.Core.Resource.Resource_Fa.ThisFaNameIsAllready });
                    }
                }

                _webUrlService.Edit(webUrlViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(webUrlViewModel);
        }


        /// <summary>
        /// متند گت حذف لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <returns></returns>

        public async Task<IActionResult> Delete(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var mdl = _webUrlService.GetWebUrl(id, userId);
            if (mdl == null)
            {
                return RedirectToAction(nameof(Index), new { message = URLShortener.Core.Resource.Resource_Fa.DoNotFindInfo });
            }

            return View(mdl);
        }

        /// <summary>
        /// متد پست حذف لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _webUrlService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
