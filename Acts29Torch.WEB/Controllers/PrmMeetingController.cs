using Acts29Torch.MODEL.Common;
using Acts29Torch.MODEL.PrmReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acts29Torch.WEB.Controllers
{
    public class PrmMeetingController : BaseController
    {
        // GET: PrmMeeting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(CreatePrmReportIn Data)
        {
            var SData=Send.SetData(Data);
            var result = ApiPost<ResultInfo,SendInfo<CreatePrmReportIn>>(SData, "PrmReport/Create");
            return Json(result,JsonRequestBehavior.DenyGet);
        }

        public ActionResult CreateView()
        {
            var result = ApiGet<ResultInfo<List<QueryMemSelect>>>("PrmReport/GetMemSelectList");
            ViewBag.MemList = result.Result.Select(item => new SelectListItem { Value = item.MemId.ToString(), Text = item.MemName });
            return View();
        }
    }
}