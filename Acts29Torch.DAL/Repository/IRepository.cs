using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; set; }
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        void Create(T _entity);
        void Create(List<T> _entity);
        void Delete(T _entity);
        void Delete(List<T> _entity);
        void Save();
    }
}
