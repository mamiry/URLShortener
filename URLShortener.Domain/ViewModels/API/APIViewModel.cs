using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortener.Domain.ViewModels.API
{
    public class APIViewModel
    {
        public bool Status { get; set; }

        public string Message { get; set; }
        public object ResultObject { get; set; }


    }
}
