using Acts29Torch.BLL.PrmMeetingBLL;
using Acts29Torch.MODEL;
using Acts29Torch.MODEL.Common;
using Acts29Torch.MODEL.Enum;
using Acts29Torch.MODEL.PrmReport;
using Acts29Torch.TOOLS;
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
                _rc = ReturnCode.DeleteFail;
            }
            return Json(_resultInfo.NonResult(_rc));
        }
        /// <summary>
        /// 取得所有面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <returns></returns>
        [ResponseType(typeof(ResultInfo))]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost]
        public IHttpActionResult GetList(SendInfo<QueryPrmMettingIn> Para)
        {
            try
            {
                var data = _prmmeetingBll.GetList(Para.Data, Para.Page, Para.PageCount);
                if (data == null)
                    return Json(_resultInfo.DataNotFound());
                else
                    return Json(_resultInfo.GetPageList(ReturnCode.GetDataSuccess, data));
            }
            catch (CommonException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                return Json(_resultInfo.NonResult(ReturnCode.GetDataFail));
            }
        }
        /// <summary>
        /// 取得一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost]
        public IHttpActionResult GetSingle(SendInfo<QueryPrmMettingDetailIn> Para)
        {
            try
            {
                var data = _prmmeetingBll.GetSingle(Para.Data);
                if (data == null)
                    return Json(_resultInfo.DataNotFound());
                else
                    return Json(_resultInfo.GetResult(ReturnCode.GetDataSuccess, data));

            }
            catch (CommonException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                return Json(_resultInfo.NonResult(ReturnCode.GetDataFail));
            }
        }
    }
}
