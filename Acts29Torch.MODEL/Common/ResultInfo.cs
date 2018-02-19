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
        public ResultInfo<T> GetResult<T>(ReturnCode _RC, T _Result)
        {
            return new ResultInfo<T>((int)_RC, _RC.ToString(), _Result);
        }
        public ResultInfo<T> GetResult<T>(ReturnCode _RC, string _RM, T _Result)
        {
            return new ResultInfo<T>((int)_RC, _RM, _Result);
        }
    }
    public class ResultInfo<T> : ResultInfo
    {
        public T Result { get; set; }

        public ResultInfo()
        {
        }
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
        public ResultInfo(int _RC, string _RM, T _Result)
        {
            RC = _RC;
            RM = _RM;
            Result = _Result;
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
