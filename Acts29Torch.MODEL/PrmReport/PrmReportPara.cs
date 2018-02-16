using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.MODEL.PrmReport
{
    public class PrmReportPara
    {
        public Nullable<int> MeetingType { get; set; }
        public Nullable<byte> IfHeld { get; set; }
        public Nullable<int> PrmOrganizationPrivilegeAid { get; set; }
        public string MeetingLocation { get; set; }
        public Nullable<long> AccountAid { get; set; }
        public string MeetingStartDate { get; set; }
        public string MeetingStartDateTime { get; set; }
        public string MeetingEndDate { get; set; }
        public string MeetingEndDateTime { get; set; }
        public string MeetingDesc { get; set; }
        public string MeetingMembers { get; set; }
        public Nullable<long> Acts29ChurchAid { get; set; }
        public Nullable<byte> Disable { get; set; }
        public string BuildDatetime { get; set; }
    }

    public class CreatePrmReportIn : PrmReportPara
    {
    }

    public class EditPrmReportIn : PrmReportPara
    {
        public long Aid { get; set; }
    }

    public class QueryPrmReportOut : PrmReportPara
    {
        public long Aid { get; set; }
    }

    public class DeletePrmReportIn
    {
        public long Aid { get; set; }
    }
}
