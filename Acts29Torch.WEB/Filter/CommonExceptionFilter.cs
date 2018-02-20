using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acts29Torch.WEB.Filter
{
    public class CommonExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }
            Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
            var view = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"//連結到錯誤網站
            };
            filterContext.Result = view;
            filterContext.ExceptionHandled = true;
        }
    }
}