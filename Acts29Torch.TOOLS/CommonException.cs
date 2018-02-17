using Acts29Torch.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.TOOLS
{
    public class CommonException : Exception
    {
        public ReturnCode ReturnCode { get; set; }
        public CommonException()
        { }
        public CommonException(ReturnCode _code) : base(_code.ToString())
        {
            ReturnCode = _code;
        }
        public CommonException(ReturnCode _code, string msg) : base(msg)
        {
            ReturnCode = _code;
        }
    }
}
