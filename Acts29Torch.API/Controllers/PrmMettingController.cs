using Acts29Torch.BLL.PrmMeetingBLL;
using Acts29Torch.MODEL.Common;
using Acts29Torch.MODEL.Enum;
using Acts29Torch.MODEL.PrmReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Acts29Torch.API.Controllers
{
    public class PrmMettingController : BaseController
    {
        private readonly PrmMeetingBLL _prmmeetingBll;
        public PrmMettingController()
        {
            _prmmeetingBll = new PrmMeetingBLL();
        }
        /// <summary>
        /// 新增一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <returns></returns>
        [ResponseType(typeof(ResultInfo))]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost]
        public IHttpActionResult Create(SendInfo<CreatePrmReportIn> Para)
        {
            var _rc = ReturnCode.CreateSuccess;
            try
            {
                _prmmeetingBll.Create(Para.Data, Para.MemId);
            }
            catch (CommonException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                _rc = ReturnCode.CreateFail;
            }
            return Json(_resultInfo.NonResult(_rc));
        }
        /// <summary>
        /// 修改一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <returns></returns>
        [ResponseType(typeof(ResultInfo))]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost]
        public IHttpActionResult Edit(SendInfo<EditPrmReportIn> Para)
        {
            var _rc = ReturnCode.EditSuccess;
            try
            {
                _prmmeetingBll.Edit(Para.Data, Para.MemId);
            }
            catch (CommonException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                if (e.ReturnCode == ReturnCode.NoFoundTargetData ||
                    e.ReturnCode == ReturnCode.NoTargetId)
                    _rc = e.ReturnCode;
                else
                    _rc = ReturnCode.EditFail;
            }
            return Json(_resultInfo.NonResult(_rc));
        }
        /// <summary>
        /// 刪除一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <returns></returns>
        [ResponseType(typeof(ResultInfo))]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost]
        public IHttpActionResult Delete(SendInfo<DeletePrmReportIn> Para)
        {
            var _rc = ReturnCode.DeleteSuccess;
            try
            {
                _prmmeetingBll.Delete(Para.Data, Para.MemId);
            }
            catch (CommonException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                if (e.ReturnCode == ReturnCode.NoFoundTargetData ||
                    e.ReturnCode == ReturnCode.NoTargetId)
                    _rc = e.ReturnCode;
                else
                    _rc = ReturnCode.DeleteFail;
            }
            return Json(_resultInfo.NonResult(_rc));
        }
        /// <summary>
        /// 取得所有面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <returns></returns>
        [ResponseType(typeof(ResultInfo<PageListInfo<PrmMeetingSimpleOut>>))]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost]
        public IHttpActionResult GetList(SendInfo<QueryPrmMettingIn> Para)
        {
            var result = new PageListInfo<PrmMeetingSimpleOut>();
            var _rc = ReturnCode.GetDataSuccess;
            try
            {
                result = _prmmeetingBll.GetList(Para.Data, Para.Page, Para.PageCount);
                if (result == null || result.Data == null || result.Data.Count() == 0)
                    _rc = ReturnCode.DataNotFound;
            }
            catch (CommonException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                _rc = ReturnCode.GetDataFail;
                result = null;
            }
            return Json(_resultInfo.GetResult(_rc, result));
        }
        /// <summary>
        /// 取得一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <returns></returns>
        [ResponseType(typeof(ResultInfo<QueryPrmReportOut>))]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost]
        public IHttpActionResult GetSingle(SendInfo<QueryPrmMettingDetailIn> Para)
        {
            var _rc = ReturnCode.GetDataSuccess;
            var data = new QueryPrmReportOut();
            try
            {
                data = _prmmeetingBll.GetSingle(Para.Data);
                if(data == null)
                    _rc = ReturnCode.DataNotFound;
            }
            catch (CommonException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                _rc = ReturnCode.GetDataFail;
                data = null;
            }
            return Json(_resultInfo.GetResult(_rc, data));
        }
    }
}
