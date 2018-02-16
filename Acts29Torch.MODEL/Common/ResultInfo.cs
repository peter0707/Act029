using Acts29Torch.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.MODEL.Common
{
    public class ResultInfo
    {
        public int RC { get; set; }
        public string RM { get; set; }

        public ResultInfo()
        { }
        public ResultInfo(ReturnCode _RC)
        {
            RC = (int)_RC;
            RM = _RC.ToString();
        }
        public ResultInfo(int _RC, string _RM)
        {
            RC = _RC;
            RM = _RM;
        }

        public ResultInfo NonResult(int _RC, string _RM)
        {
            return new ResultInfo(_RC, _RM);
        }

        public ResultInfo NonResult(ReturnCode _RC, string _RM)
        {
            return new ResultInfo((int)_RC, _RM);
        }
        public ResultInfo NonResult(ReturnCode _RC)
        {
            return new ResultInfo((int)_RC, _RC.ToString());
        }
        public ResultInfo<T> GetResult<T>(ReturnCode _RC, string _RM, T _Result)
        {
            if (_Result == null)
                return new ResultInfo<T>((int)ReturnCode.DataNotFound, ReturnCode.DataNotFound.ToString());
            return new ResultInfo<T>((int)_RC, _RM, _Result);
        }

        public ResultInfo<List<T>> GetList<T>(ReturnCode _RC, string _RM, List<T> _Result)
        {
            if (_Result == null || _Result.Count() == 0)
                return new ResultInfo<List<T>>((int)ReturnCode.DataNotFound, ReturnCode.DataNotFound.ToString());
            return new ResultInfo<List<T>>((int)_RC, _RM, _Result);
        }

        public ResultInfo<PageListInfo<T>> GetPageList<T>(ReturnCode _RC, PageListInfo<T> _Result)
        {
            if (_Result == null || _Result.Data.Count == 0)
                return new ResultInfo<PageListInfo<T>>((int)ReturnCode.DataNotFound, ReturnCode.DataNotFound.ToString());
            return new ResultInfo<PageListInfo<T>>((int)_RC, _RC.ToString(), _Result);
        }

        public ResultInfo DataNotFound()
        {
            return new ResultInfo((int)ReturnCode.DataNotFound, ReturnCode.DataNotFound.ToString());
        }
    }
    public class ResultInfo<T> : ResultInfo
    {
        public T Result { get; set; }

        public ResultInfo()
        {
        }
        public ResultInfo(int _RC, string _RM)
        {
            RC = _RC;
            RM = _RM;
        }
        public ResultInfo(int _RC, string _RM, T _Result)
        {
            RC = _RC;
            RM = _RM;
            Result = _Result;
        }
        public ResultInfo<T> GetResult<T>(int _RC, string _RM, T _Result)
        {
            return new ResultInfo<T>(_RC, _RM, _Result);
        }
    }
    public class PageListInfo<T>
    {
        public int Count { get; set; }
        public List<T> Data { get; set; }
        public PageListInfo()
        { }
        public PageListInfo(int _count, List<T> _data)
        {
            Count = _count;
            Data = _data;
        }
    }
}
