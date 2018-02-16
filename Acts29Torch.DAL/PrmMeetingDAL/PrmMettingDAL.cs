using Acts29Torch.DAL.Repository;
using Acts29Torch.EF;
using Acts29Torch.MODEL;
using Acts29Torch.MODEL.Common;
using Acts29Torch.MODEL.Enum;
using Acts29Torch.MODEL.PrmReport;
using Acts29Torch.TOOLS;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.DAL.PrmReportDAL
{
    public class PrmMettingDAL
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<prm_meeting_report> _prmmeetingrep;
        public PrmMettingDAL(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            _prmmeetingrep = new Repository<prm_meeting_report>(unitOfWork);
        }
        /// <summary>
        /// 新增一筆面談紀錄
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Create(CreatePrmReportIn Para, int MemId)
        {
            var CreateInfo = _prmmeetingrep.GetAll().OrderByDescending(d => d.aid).Take(1).FirstOrDefault();
            if (CreateInfo == null)
                throw new CommonException(ReturnCode.CreateFail);
            var data = new prm_meeting_report()
            {
                aid = CreateInfo.aid + 1,
                meeting_type = Para.MeetingType,
                if_held = Para.IfHeld,
                prm_organization_privilege_aid = Para.PrmOrganizationPrivilegeAid,
                meeting_location = Para.MeetingLocation,
                account_aid = Para.AccountAid,
                meeting_start_date = Para.MeetingStartDate,
                meeting_start_date_time = Para.MeetingStartDateTime,
                meeting_end_date = Para.MeetingEndDate,
                meeting_end_date_time = Para.MeetingEndDateTime,
                meeting_desc = Para.MeetingDesc,
                meeting_members = Para.MeetingMembers,
                acts29_church_aid = Para.Acts29ChurchAid,
                disable = Para.Disable,
                build_datetime = Para.BuildDatetime,
                last_mod_time = DateTime.Now.ToString(),
                last_mod_user_aid = MemId
            };
            _prmmeetingrep.Create(data);
            _prmmeetingrep.Save();
        }
        /// <summary>
        /// 修改一筆面談紀錄
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Edit(EditPrmReportIn Para, int MemId)
        {
            var EditInfo = _prmmeetingrep.Query(d => d.aid == Para.Aid).FirstOrDefault();
            if (EditInfo == null)
                throw new CommonException(ReturnCode.NoFoundTargetData);
            EditInfo.aid = Para.Aid;
            EditInfo.meeting_type = Para.MeetingType;
            EditInfo.if_held = Para.IfHeld;
            EditInfo.prm_organization_privilege_aid = Para.PrmOrganizationPrivilegeAid;
            EditInfo.meeting_location = Para.MeetingLocation;
            EditInfo.account_aid = Para.AccountAid;
            EditInfo.meeting_start_date = Para.MeetingStartDate;
            EditInfo.meeting_start_date_time = Para.MeetingStartDateTime;
            EditInfo.meeting_end_date = Para.MeetingEndDate;
            EditInfo.meeting_end_date_time = Para.MeetingEndDateTime;
            EditInfo.meeting_desc = Para.MeetingDesc;
            EditInfo.meeting_members = Para.MeetingMembers;
            EditInfo.acts29_church_aid = Para.Acts29ChurchAid;
            EditInfo.disable = Para.Disable;
            EditInfo.last_mod_time = DateTime.Now.ToString();
            EditInfo.last_mod_user_aid = MemId;
            _prmmeetingrep.Save();
        }
        /// <summary>
        /// 刪除一筆面談紀錄
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Delete(DeletePrmReportIn Para, int MemId)
        {
            var DelInfo = _prmmeetingrep.Query(d => d.aid == Para.Aid).FirstOrDefault();
            if (DelInfo == null)
                throw new CommonException(ReturnCode.NoFoundTargetData);
            DelInfo.disable = 1;
            DelInfo.last_mod_time = DateTime.Now.ToString();
            DelInfo.last_mod_user_aid = MemId;
            _prmmeetingrep.Save();
        }
        public IQueryable<PrmMeetingSimpleOut> GetList(QueryPrmMettingIn Para)
        {
            using (var db = new Acts29TorchEntities())
            {
                var data = (from t1 in db.prm_meeting_report
                            join t2 in db.account on t1.account_aid equals t2.aid
                            join t3 in db.prm_organization_privilege on t1.prm_organization_privilege_aid equals t3.aid
                            select new MulitTable
                            {
                                t1 = t1,
                                t2 = t2,
                                t3 = t3
                            }).AsExpandable()
                           .Where(PrmMeeingCondition(Para))
                           .GroupBy(d => new { d.t1.aid, d.t2.user_name, d.t3.organization_name })
                           .Select(d => new PrmMeetingSimpleOut()
                           {
                               Aid = d.Key.aid,
                               AccountMem = d.Key.user_name,
                               OrganizationName = d.Key.organization_name
                           });
                return data;                         
            }
        }
        private class MulitTable
        {
            public prm_meeting_report t1 { get; set; }
            public account t2 { get; set; }
            public prm_organization_privilege t3 { get; set; }
        }
        private Expression<Func<MulitTable, bool>> PrmMeeingCondition(QueryPrmMettingIn Para)
        {
            var Search = PredicateBuilder.New<MulitTable>();
            Search.And(d => true);
            if (!string.IsNullOrEmpty(Para.MeetingMemName))
            {
                Search.And(d => d.t2.user_name == Para.MeetingMemName);
            }
            if (!string.IsNullOrEmpty(Para.OrganizationName))
            {
                Search.And(d => d.t3.organization_name == Para.OrganizationName);
            }
            return Search;
        }
    }
}
