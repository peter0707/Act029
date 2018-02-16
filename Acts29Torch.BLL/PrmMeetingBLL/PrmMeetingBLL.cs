using Acts29Torch.DAL.PrmReportDAL;
using Acts29Torch.DAL.Repository;
using Acts29Torch.MODEL;
using Acts29Torch.MODEL.Common;
using Acts29Torch.MODEL.Enum;
using Acts29Torch.MODEL.PrmReport;
using Acts29Torch.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.BLL.PrmMeetingBLL
{
    public class PrmMeetingBLL
    {
        private readonly PrmMettingDAL _prmmettingDAL;
        public PrmMeetingBLL()
        {
            var unitOfWork = new EFUnitOfWork();
            _prmmettingDAL = new PrmMettingDAL(unitOfWork);
        }
        /// <summary>
        /// 新增一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Create(CreatePrmReportIn Para, int MemId)
        {
            _prmmettingDAL.Create(Para, MemId);
        }
        /// <summary>
        /// 修改一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Edit(EditPrmReportIn Para, int MemId)
        {
            if (Para.Aid == 0)
                throw new CommonException(ReturnCode.NoTargetId);
            _prmmettingDAL.Edit(Para, MemId);
        }
        /// <summary>
        /// 刪除一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Delete(DeletePrmReportIn Para, int MemId)
        {
            if (Para.Aid == 0)
                throw new CommonException(ReturnCode.NoTargetId);
            _prmmettingDAL.Delete(Para, MemId);
        }
        /// <summary>
        /// 取得面談清單
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public PageListInfo<PrmMeetingSimpleOut> GetList(QueryPrmMettingIn Para, int Page, int PageCount)
        {
            var data = _prmmettingDAL.GetList(Para);
            var result = new PageListInfo<PrmMeetingSimpleOut>()
            {
                Data = data.Skip(PageCount * (Page - 1)).Take(PageCount).ToList(),
                Count = data.Count()
            };
            return result;
        }
        /// <summary>
        /// 取得單筆面談紀錄
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public QueryPrmReportOut GetSingle(QueryPrmMettingDetailIn Para)
        {
            return _prmmettingDAL.GetSingle(Para);
        }
    }
}
