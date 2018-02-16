using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        void Save();

        DbContext Context { get; set; }
    }
}
