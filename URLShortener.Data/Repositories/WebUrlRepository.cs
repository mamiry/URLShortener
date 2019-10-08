using System;
using System.Collections.Generic;
using System.Linq;
using URLShortener.Data.Context;
using URLShortener.Domain.Interfaces;
using URLShortener.Domain.ViewModels.WebUrl;
using URLShortener.Domain.WebUrls;

namespace URLShortener.Data.Repositories
{
    /// <summary>
    /// کلاس ارتباط با دیتابیس لینک 
    /// </summary>
    public class WebUrlRepository : IWebUrlRepository
    {
        private MyContext _ctx;


        public WebUrlRepository(MyContext ctx)
        {
            _ctx = ctx;
        }


        /// <summary>
        /// انتخاب لیست لینک ها
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>لیست مدل اطلاعات لینک</returns>
        public IEnumerable<WebUrl> GetAll(Guid userId)
        {
            return _ctx.WebUrls
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.CreateTime)
                .ToList();
        }
        /// <summary>
        /// افزودن لینک
        /// </summary>
        /// <param name="webUrl">مدل اطلاعات لینک</param>

        public void Add(WebUrl webUrl)
        {
            _ctx.WebUrls.Add(webUrl);
            _ctx.SaveChanges();
        }

        /// <summary>
        /// بروزرسانی لینک
        /// </summary>
        /// <param name="webUrl">مدل اطلاعات لینک</param>
        public void Edit(WebUrlViewModel webUrlViewModel)
        {
            WebUrl mdl = _ctx.WebUrls.Find(webUrlViewModel.Id);
            if (mdl != null)
            {
                mdl.Url = webUrlViewModel.Url;
                _ctx.WebUrls.Update(mdl);
                _ctx.SaveChanges();
            }
        }

        /// <summary>
        /// حذف لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        public void Delete(Guid id)
        {
            _ctx.WebUrls.Remove(_ctx.WebUrls.Find(id));
            _ctx.SaveChanges();
        }

        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns>مدل اطلاعات لینک</returns>
        public WebUrlViewModel GetWebUrl(Guid id, Guid userId)
        {
            return _ctx.WebUrls
                .Where(x => x.Id == id && x.UserId == userId)
                .Select(c => new WebUrlViewModel()
                {
                    Url = c.Url,
                    UrlShort  = c.UrlShort,
                    ClickCount = c.ClickCount,
                    Id = c.Id

                }).SingleOrDefault();
        }


        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="url">  لینک اصلی</param>
        /// <returns>مدل اطلاعات لینک</returns>
        public WebUrlViewModel GetWebUrl(string url)
        {

            return _ctx.WebUrls
                .Where(x => x.Url == url)
                .Select(c => new WebUrlViewModel()
                {
                    Url = c.Url,
                    UrlShort  = c.UrlShort,
                    ClickCount = c.ClickCount,
                    Id = c.Id

                }).SingleOrDefault();
        }
        /// <summary>
        /// انتخاب لینک
        /// </summary>
        /// <param name="url">  لینک کوتاه</param>
        /// <returns>مدل اطلاعات لینک</returns>
        public WebUrlSummaryViewModel GetUrlShort(string url)
        {

            return _ctx.WebUrls
                .Where(x => x.UrlShort == url)
                .Select(c => new WebUrlSummaryViewModel()
                {
                    Url = c.Url,
                    UrlShort  = c.UrlShort,
                    ClickCount = c.ClickCount, 

                }).SingleOrDefault();
        }

        /// <summary>
        /// بررسی موجود بودن لینک کوتاه
        /// </summary>
        /// <param name="urlShort">لینک کوتاه</param>
        /// <returns>بلی/خیر</returns>
        public bool ExistsUrlShort(string urlShort)
        {
            return _ctx.WebUrls.Any(e => e.UrlShort == urlShort);
        }

        /// <summary>
        /// انتخاب آدرس اصلی
        /// </summary>
        /// <param name="urlShort">آدرس کوتاه</param>
        /// <returns>آدرس اصلی</returns>
        public string GetURL(string urlShort)
        {
            var mdl = _ctx.WebUrls.SingleOrDefault(e => e.UrlShort == urlShort);
            if (mdl != null)
            {
                return mdl.Url;
            }
            return null;

        }

        /// <summary>
        /// افزایش تعداد کلیک 
        /// </summary>
        /// <param name="urlShort">لینک کوتاه</param> 
        public void IncClick(string urlShort)
        {
            var mdl =  _ctx.WebUrls.SingleOrDefault(e => e.UrlShort == urlShort);
            if(mdl!=null)
            {
                mdl.ClickCount += 1;
                _ctx.SaveChanges();
            }
        }
    }
}
