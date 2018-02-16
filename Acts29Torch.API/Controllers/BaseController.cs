using Acts29Torch.MODEL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acts29Torch.API.Controllers
{
    public class BaseController : ApiController
    {
        public readonly ResultInfo _resultInfo;
        public BaseController()
        {
            _resultInfo = new ResultInfo();
        }
    }
}
