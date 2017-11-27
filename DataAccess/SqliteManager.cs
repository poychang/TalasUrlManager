using System;
using System.Collections;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    /// <summary>SQLite 資料庫管理者</summary>
    /// <remarks>REF: 實現標準 Dispose 模式 ( https://dotblogs.com.tw/larrynung/2011/03/10/21774 )</remarks>
    public class SqliteManager : IDbManager
    {
        /// <summary>Database Context</summary>
        private readonly DbContext _context;

        /// <summary>是否已清除</summary>
        private bool _disposed;

        /// <summary>Repository 池</summary>
        private Hashtable _repositories;

        /// <summary>建構式</summary>
        /// <param name="context">設定 context</param>
        public SqliteManager(DbContext context)
        {
            Console.WriteLine("Connect to Database");
            _context = context;
        }

        /// <summary>解構式</summary>
        ~SqliteManager()
        {
            Dispose(false);
        }

        /// <summary>清除此 Class 的資源</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>清除此 Class 的資源</summary>
        /// <param name="disposing">是否在清理中</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>儲存所有異動</summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>檢查資料庫是否存在</summary>
        /// <returns>是否存在</returns>
        public bool DbIsExist()
        {
            return _context.Database.EnsureCreated();
        }

        /// <summary>取得某一個 Entity Repository。如果沒有取過會初始化一個，如果有就取得之前的</summary>
        /// <typeparam name="TEntity">此 DbContext 裡面的 Entity Type</typeparam>
        /// <returns>Entity Repository</returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;
            // 檢查是否已經初始化過類行為 TEntity 的 Entity Repository
            if (_repositories.ContainsKey(type)) return (IRepository<TEntity>)_repositories[type];

            var repositoryType = typeof(EfGenericRepository<>);
            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), _context);
            // 將初始化的 Entity Repository 實體存放進 Repository 池
            _repositories.Add(type, repositoryInstance);

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
