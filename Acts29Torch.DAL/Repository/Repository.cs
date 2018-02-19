using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acts29Torch.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        private DbSet<T> _Dbset;
        private DbSet<T> Dbset
        {
            get
            {
                if (_Dbset == null)
                {
                    _Dbset = UnitOfWork.Context.Set<T>();
                }
                return _Dbset;
            }
        }
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        /// <summary>
        /// 建立一筆資料
        /// </summary>
        /// <param name="_entity"></param>
        public void Create(T _entity)
        {
            Dbset.Add(_entity);
        }
        /// <summary>
        /// 建立多筆資料
        /// </summary>
        /// <param name="_entity"></param>
        public void Create(List<T> _entity)
        {
            Dbset.AddRange(_entity);
        }
        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        /// <param name="_entity"></param>
        public void Delete(T _entity)
        {
            Dbset.Remove(_entity);
        }
        /// <summary>
        /// 刪除多筆資料
        /// </summary>
        /// <param name="_entity"></param>
        public void Delete(List<T> _entity)
        {
            Dbset.RemoveRange(_entity);
        }
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Dbset;
        }
        /// <summary>
        /// 取得某一筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return Dbset.Find(id);
        }
        /// <summary>
        /// 取得查詢後的資料
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return Dbset.Where(filter);
        }
        /// <summary>
        /// 儲存資料表
        /// </summary>
        public void Save()
        {
            UnitOfWork.Save();
        }
        /// <summary>
        /// 判斷是否有相關資料
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> filter)
        {
            return Dbset.Any(filter);
        }
    }
}
