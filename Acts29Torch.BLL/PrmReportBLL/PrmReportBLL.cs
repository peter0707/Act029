using Acts29Torch.DAL.PrmReportDAL;
using Acts29Torch.DAL.Repository;
using Acts29Torch.MODEL.Common;
using Acts29Torch.MODEL.Enum;
using Acts29Torch.MODEL.PrmReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.BLL.PrmReportBLL
{
    public class PrmReportBLL
    {
        private readonly PrmReportDAL _prmreportDAL;
        public PrmReportBLL()
        {
            var unitOfWork = new EFUnitOfWork();
            _prmreportDAL = new PrmReportDAL(unitOfWork);
        }
        /// <summary>
        /// 新增一筆面談資料
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Create(CreatePrmReportIn Para, int MemId)
        {
            _prmreportDAL.Create(Para, MemId);
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
            _prmreportDAL.Edit(Para, MemId);
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
            _prmreportDAL.Delete(Para, MemId);
        }
        /// <summary>
        /// 取得面談清單
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public PageListInfo<PrmReportSimpleOut> GetList(QueryPrmReportIn Para, int Page, int PageCount)
        {
            return _prmreportDAL.GetList(Para, Page, PageCount);
        }
        /// <summary>
        /// 取得單筆面談紀錄
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public QueryPrmReportOut GetSingle(QueryPrmReportDetailIn Para)
        {
            return _prmreportDAL.GetSingle(Para);
        }
    }
}
