using Acts29Torch.MODEL.Common;
using Acts29Torch.WEB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Acts29Torch.WEB.Controllers
{
    public class BaseController : Controller
    {
        private readonly ApiHelper api;
        public SendInfo Send { get; private set; }
        public UserInfo UserInfo;
        public BaseController()
        {
            api = new ApiHelper();
        }
        /// <summary>
        /// ApiPost資料處理
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="Data"></param>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public TR ApiPost<TR, TS>(TS Data, string strUrl)
        {
            return Task.Run(() => api.Post<TR, TS>(strUrl, Data)).Result;
        }
        /// <summary>
        /// ApiGet資料處理
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public TR ApiGet<TR>(string strUrl)
        {
            return Task.Run(() => api.Get<TR>(strUrl)).Result;
        }
        /// <summary>
        /// 進入Action
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session == null || Session["UserInfo"] == null)
            {
                Send = new SendInfo(0, 1, 50);
            }
            else
            {
                UserInfo = (UserInfo)Session["UserInfo"];
                Send = new SendInfo(UserInfo.MemId, 1, 50);
            }
        }
        /// <summary>
        /// 紀錄Action訪問方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //log nlog log4net sql
        }
    }
}