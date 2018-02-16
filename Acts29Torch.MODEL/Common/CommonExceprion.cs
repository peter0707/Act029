using Acts29Torch.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.MODEL
{
    public class CommonExceprion : Exception
    {
        public ReturnCode ReturnCode { get; set; }
        public CommonExceprion()
        { }
        public CommonExceprion(ReturnCode _code)
        {
            ReturnCode = _code;
        }
        public CommonExceprion(ReturnCode _code, string _rm) : base(_rm)
        {
            ReturnCode = _code;
        }
    }
}
