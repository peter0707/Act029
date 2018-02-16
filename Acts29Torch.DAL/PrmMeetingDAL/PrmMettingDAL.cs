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
            try
            {
                var CreateInfo = _prmmeetingrep.GetAll().OrderByDescending(d => d.aid).Take(1).FirstOrDefault();
                var data = new prm_meeting_report()
                {
                    aid = CreateInfo == null ? 1 : CreateInfo.aid + 1,
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
                    disable = 0,
                    build_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    last_mod_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    last_mod_user_aid = MemId
                };
                _prmmeetingrep.Create(data);
                _prmmeetingrep.Save();
            }
            catch (CommonException e)
            {
                throw new CommonException(ReturnCode.CreateFail, e.Message);
            }

        }
        /// <summary>
        /// 修改一筆面談紀錄
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Edit(EditPrmReportIn Para, int MemId)
        {
            try
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
                EditInfo.last_mod_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                EditInfo.last_mod_user_aid = MemId;
                _prmmeetingrep.Save();
            }
            catch (CommonException e)
            {
                if (e.ReturnCode == ReturnCode.NoFoundTargetData)
                    throw new CommonException(ReturnCode.NoFoundTargetData);
                else
                    throw new CommonException(ReturnCode.EditFail, e.Message);
            }
        }
        /// <summary>
        /// 刪除一筆面談紀錄
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="MemId"></param>
        public void Delete(DeletePrmReportIn Para, int MemId)
        {
            try
            {
                var DelInfo = _prmmeetingrep.Query(d => d.aid == Para.Aid).FirstOrDefault();
                if (DelInfo == null)
                    throw new CommonException(ReturnCode.NoFoundTargetData);
                DelInfo.disable = 1;
                DelInfo.last_mod_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DelInfo.last_mod_user_aid = MemId;
                _prmmeetingrep.Save();
            }
            catch (CommonException e)
            {
                throw new CommonException(ReturnCode.DeleteFail, e.Message);
            }
        }
        public List<PrmMeetingSimpleOut> GetList(QueryPrmMettingIn Para)
        {
            try
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
                               }).ToList();
                    return data;
                }
            }
            catch (CommonException e)
            {
                throw new CommonException(ReturnCode.GetDataFail, e.Message);
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
        public QueryPrmReportOut GetSingle(QueryPrmMettingDetailIn Para)
        {
            return _prmmeetingrep.Query(d => d.aid == Para.Aid)
                .Select(d=>new QueryPrmReportOut {
                    Aid = d.aid,
                    MeetingType = d.meeting_type,
                    IfHeld = d.if_held,
                    PrmOrganizationPrivilegeAid = d.prm_organization_privilege_aid,
                    MeetingLocation = d.meeting_location,
                    AccountAid=d.account_aid,
                    MeetingStartDate = d.meeting_start_date,
                    MeetingStartDateTime = d.meeting_start_date_time,
                    MeetingEndDate = d.meeting_end_date,
                    MeetingEndDateTime =d.meeting_end_date_time,
                    MeetingDesc = d.meeting_desc,
                    MeetingMembers = d.meeting_members,
                    Acts29ChurchAid = d.acts29_church_aid                
                })
                .FirstOrDefault();
        }
    }
}
