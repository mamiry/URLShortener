using System;
using System.Collections.Generic;
using URLShortener.Core.Interfaces;
using URLShortener.Domain.Interfaces;
using URLShortener.Domain.ViewModels.WebUrl;
using URLShortener.Domain.WebUrls;

namespace URLShortener.Core.Services
{
    /// <summary>
    /// سرویس لینک 
    /// </summary>
    public class WebUrlService : IWebUrlService
    {
        IWebUrlRepository _webUrlRepository;
        public WebUrlService(IWebUrlRepository webUrlRepository)
        {
            _webUrlRepository = webUrlRepository;
        }

        /// <summary>
        /// انتخاب لیست لینک ها
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>لیست مدل اطلاعات لینک</returns>
        public IEnumerable<WebUrl> GetAll(Guid userId)
        {
            return _webUrlRepository.GetAll(userId);
        }

        /// <summary>
        /// افزودن لینک
        /// </summary>
        /// <param name="webUrl">مدل اطلاعات لینک</param>
        public void Add(WebUrl webUrl)
        {
            _webUrlRepository.Add(webUrl);
        }

        /// <summary>
        /// بروزرسانی لینک
        /// </summary>
        /// <param name="webUrl">مدل اطلاعات لینک</param>
        public void Edit(WebUrlViewModel webUrl)
        {
            _webUrlRepository.Edit(webUrl);
        }
        /// <summary>
        /// حذف لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        public void Delete(Guid id)
        {
            _webUrlRepository.Delete(id);
        }
        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>مدل اطلاعات لینک</returns>
        public WebUrlViewModel GetWebUrl(Guid id, Guid userId)
        {
            return _webUrlRepository.GetWebUrl(id, userId);
        }
        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="url">  لینک اصلی</param>
        /// <returns>مدل اطلاعات لینک</returns>

        public WebUrlViewModel GetWebUrl(string url)
        {
            return _webUrlRepository.GetWebUrl(url);
        }

        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="url">  لینک کوتاه</param>
        /// <returns>مدل اطلاعات لینک</returns>

        public WebUrlSummaryViewModel GetUrlShort(string url)
        {
            return _webUrlRepository.GetUrlShort(url);
        }
        /// <summary>
        /// بررسی موجود بودن لینک کوتاه
        /// </summary>
        /// <param name="urlShort">لینک کوتاه</param>
        /// <returns>بلی/خیر</returns>
        public bool ExistsUrlShort(string urlShort)
        {
            return _webUrlRepository.ExistsUrlShort(urlShort);
        }

        /// <summary>
        /// انتخاب آدرس اصلی
        /// </summary>
        /// <param name="urlShort">آدرس کوتاه</param>
        /// <returns>آدرس اصلی</returns>
        public string GetURL(string urlShort)
        {
            return _webUrlRepository.GetURL(urlShort);
        }

        public void IncClick(string urlShort)
        {
              _webUrlRepository.IncClick(urlShort); 
        }
    }
}
