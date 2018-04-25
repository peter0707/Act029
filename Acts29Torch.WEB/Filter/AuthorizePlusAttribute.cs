using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acts29Torch.WEB.Filter
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("https://......");//未登入連結到登入入口
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!string.IsNullOrEmpty((string)httpContext.Session["UserInfo"]))
            {
                string ID = httpContext.Session["MemId"].ToString();
                httpContext.Session["MemId"] = ID;
                return true;
            }
            //return false;//測試要調整為FALSE
            return true;
        }
    }
}