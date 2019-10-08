using System;
using System.Collections.Generic;
using URLShortener.Domain.ViewModels.WebUrl;
using URLShortener.Domain.WebUrls;

namespace URLShortener.Core.Interfaces
{
    /// <summary>
    /// اینترفیس سرویس لینک ها
    /// </summary>
    public interface IWebUrlService
    {
        /// <summary>
        /// انتخاب لیست لینک
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>لیست اطلاعات لینک ها</returns>
        IEnumerable<WebUrl> GetAll(Guid userId);

        /// <summary>
        /// افزودن لینک
        /// </summary>
        /// <param name="webUrl">مدل اطلاعات لینک</param>
        void Add(WebUrl webUrl);

        /// <summary>
        /// بروزرسانی لینک
        /// </summary>
        /// <param name="webUrl">مدل اطلاعات لینک</param>
        void Edit(WebUrlViewModel webUrl);

        /// <summary>
        /// حذف لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        void Delete(Guid id);

        /// <summary>
        /// انتخاب   لینک  
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>مدل اطلاعات لینک</returns>
        WebUrlViewModel GetWebUrl(Guid id, Guid userId);

        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="url">  لینک اصلی</param>
        /// <returns>مدل اطلاعات لینک</returns>
        WebUrlViewModel GetWebUrl(string url);

        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="url">  لینک کوتاه</param>
        /// <returns>مدل اطلاعات لینک</returns>
        WebUrlSummaryViewModel GetUrlShort(string url);

        /// <summary>
        /// بررسی موجود بودن لینک کوتاه
        /// </summary>
        /// <param name="urlShort">لینک کوتاه</param>
        /// <returns>بلی/خیر</returns>
        bool ExistsUrlShort(string urlShort);

        /// <summary>
        /// انتخاب آدرس اصلی
        /// </summary>
        /// <param name="urlShort">آدرس کوتاه</param>
        /// <returns>آدرس اصلی</returns>
        string GetURL(string urlShort);
        /// <summary>
        /// افزایش تعداد کلیک 
        /// </summary>
        /// <param name="urlShort">لینک کوتاه</param>
        void IncClick(string urlShort);
    }
}
