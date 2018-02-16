using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.MODEL.PrmReport
{
    public class PrmMeetingSimpleOut
    {
        /// <summary>
        /// 面談編號
        /// </summary>
        public long Aid { get; set; }
        /// <summary>
        /// 同工人員
        /// </summary>
        public string AccountMem { get; set; }
        /// <summary>
        /// 小組名稱
        /// </summary>
        public string OrganizationName { get; set; }
    }
}
