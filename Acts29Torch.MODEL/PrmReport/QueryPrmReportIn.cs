using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.MODEL.PrmReport
{
    public class QueryPrmReportIn
    {
        public string OrganizationName { get; set; }
        public string MeetingMemName { get; set; }
    }

    public class QueryPrmReportDetailIn
    {
        public long Aid { get; set; }
    }
}
