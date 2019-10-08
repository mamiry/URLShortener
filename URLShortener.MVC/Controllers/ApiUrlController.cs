using Microsoft.AspNetCore.Mvc;
using URLShortener.Core.Interfaces;
using URLShortener.Core.Resource;
using URLShortener.Core.Utilities;
using URLShortener.Domain.ViewModels.API;

namespace URLShortener.MVC.Controllers
{
    /// <summary>
    /// API  ارتباط با سایت
    /// </summary>
    [Route("api/Url")]
    [ApiController]
    public class ApiUrlController : ControllerBase
    {
        private IWebUrlService _webUrlService;
        public ApiUrlController(IWebUrlService webUrlService)
        {
            _webUrlService = webUrlService;
        }
        /// <summary>
        /// API دریافت اطلاعات یک لینک کوتاه
        /// </summary>
        /// <param name="url">لینک کوتاه</param>
        /// <returns>مدل اطلاعات سرویس</returns>
        // GET: api/Url/5
        [HttpGet("{id}/info")]
        public APIViewModel GetInfo(string id)
        {
            APIViewModel mdl = new APIViewModel();
            var weburl = _webUrlService.GetUrlShort(id);

            if (weburl == null)
            {
                mdl.ResultObject = null;
                mdl.Message = Resource_Fa.DoNotFindInfo;
                mdl.Status = false;
            }
            else
            {
                mdl.ResultObject = weburl;
                mdl.Message = Resource_Fa.ResualtOK;
                mdl.Status = true;
            }
            return mdl;
        }

        /// <summary>
        /// API دریافت آدرس اصلی لینک
        /// </summary>
        /// <param name="url">لینک کوتاه</param>
        /// <returns>مدل اطلاعات سرویس</returns>
        // GET: api/Url  
        [HttpGet("{id}")]
        public APIViewModel GetMainUrl(string id)
        {
            APIViewModel mdl = new APIViewModel();

            string weburl = _webUrlService.GetURL(id);
            if (string.IsNullOrEmpty(weburl))
            {
                mdl.ResultObject = null;
                mdl.Message = Resource_Fa.DoNotFindInfo;
                mdl.Status = false;
            }
            else
            {
                mdl.ResultObject =  StaticValues.SiteURL + weburl;
                mdl.Message = Resource_Fa.ResualtOK;
                mdl.Status = true;
                _webUrlService.IncClick(id);

            }
            return mdl;
        }

    }
}
