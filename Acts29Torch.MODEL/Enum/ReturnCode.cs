﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.MODEL.Enum
{
    public enum ReturnCode
    {
        CreateSuccess = 101,
        CreateFail = 102,
        EditSuccess = 201,
        EditFail = 202,
        DeleteSuccess = 301,
        DeleteFail = 302,
        NoTargetId = 401,
        NoFoundTargetData = 402,
        GetDataSuccess = 501,
        GetDataFail = 502,
        DataNotFound = 503,
        Exception = 9999
    }
}
