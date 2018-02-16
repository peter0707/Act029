using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.MODEL.Common
{
    public class SendInfo
    {
        /// <summary>
        /// 會員Id
        /// </summary>
        public int MemId { get; set; }
        /// <summary>
        /// 查詢頁數
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 查詢筆數
        /// </summary>
        public int PageCount { get; set; }
        public SendInfo()
        { }
        public SendInfo(int _memid, int _page, int _pagecount)
        {
            MemId = _memid;
            Page = _page;
            PageCount = _pagecount;
        }
        public SendInfo SetMemId(int _memid)
        {
            return new SendInfo(_memid, Page, PageCount);
        }
        public SendInfo<T> SetData<T>(T Data)
        {
            return new SendInfo<T>(MemId, Page, PageCount, Data);
        }
    }

    public class SendInfo<T> : SendInfo
    {
        public T Data { get; set; }
        public SendInfo()
        { }

        public SendInfo(int _memid, int _page, int _pagecount, T _data)
        {
            MemId = _memid;
            Page = _page;
            PageCount = _pagecount;
            Data = _data;
        }
    }
}
