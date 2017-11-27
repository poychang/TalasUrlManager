using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    /// <summary>實作 Entity Framework Generic Repository</summary>
    /// <remarks>
    /// REF: 搭配 Repository Pattern ( https://ithelp.ithome.com.tw/articles/10157484 )
    /// </remarks>
    /// <typeparam name="TEntity">Entity Framework Model 裡面的 Entity Type</typeparam>
    public class EfGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DbContext DbContext { get; }

        /// <summary>建構式</summary>
        /// <param name="dbContext">Entity 所在的 DbContext</param>
        public EfGenericRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>新增一筆資料</summary>
        /// <param name="entity">要新增的 Entity</param>
        public void Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>取得第一筆符合條件的資料</summary>
        /// <param name="predicate">取得資料的條件運算式</param>
        /// <returns>第一筆符合條件的資料</returns>
        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        /// <summary>取得全部資料</summary>
        /// <returns>可查詢的 Entity 資料</returns>
        public IQueryable<TEntity> Read()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        /// <summary>更新一筆資料</summary>
        /// <param name="entity">要被更新的 Entity</param>
        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>更新一筆資料，只更新有指定的Property</summary>
        /// <param name="entity">要被更新的 Entity</param>
        /// <param name="updateProperties">需要更新的欄位</param>
        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            DbContext.Entry(entity).State = EntityState.Unchanged;

            if (updateProperties == null) return;
            foreach (var property in updateProperties)
            {
                DbContext.Entry(entity).Property(property).IsModified = true;
            }
        }

        /// <summary>刪除一筆資料</summary>
        /// <param name="entity">要被刪除的 Entity</param>
        public void Delete(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>儲存異動</summary>
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
