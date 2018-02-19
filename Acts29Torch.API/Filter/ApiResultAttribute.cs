using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Acts29Torch.API.Filter
{
    public class ApiResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //log 記錄地方 Log4Net Nlog SQL 
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}