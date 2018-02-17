using Acts29Torch.MODEL.Common;
using Acts29Torch.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Acts29Torch.API.Filter
{
    public class ElmahErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
            ResultInfo ResultInfo = new ResultInfo()
            {
                RC = (int)ReturnCode.Exception,
                RM = "伺服器異常錯誤．"
            };
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(ResultInfo);
        }
    }
}