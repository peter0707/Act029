using Acts29Torch.EF;
using Acts29Torch.TOOLS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.DAL.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }
        private bool _disposed;
        public EFUnitOfWork()
        {
            Context = new Acts29TorchEntities();
        }
        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        /// <param name="disposing">是否在清理中？</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
        /// <summary>
        /// 儲存整個異動
        /// </summary>
        public void Save()
        {
            try
            {
                Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var errors = new List<string>();
                foreach (var e in ex.EntityValidationErrors)
                {
                    errors.AddRange(e.ValidationErrors.Select(e2 => string.Join("Validation Error :: ", e2.PropertyName, " : ", e2.ErrorMessage)));
                }
                var error = string.Join("\r\n", errors);
                var betterException = new Exception(error, ex);

                throw betterException;
            }
        }
    }
}
