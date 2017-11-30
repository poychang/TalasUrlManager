using System;
using System.Collections;
using DataAccess.Repository;
using DataAccess.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccess
{
    public class DbManager : IDbManager
    {
        /// <summary>資料庫 Context</summary>
        protected DbContext Context;

        /// <summary>Repository 池</summary>
        protected Hashtable Repositories;

        /// <summary>是否已清除</summary>
        protected bool Disposed;

        /// <summary></summary>
        protected IOptions<DbManagerOptions> OptionsAccessor;

        /// <summary>建構式</summary>
        /// <param name="optionsAccessor"></param>
        public DbManager(IOptions<DbManagerOptions> optionsAccessor)
        {
            OptionsAccessor = optionsAccessor;
            InitDbContext();
        }

        /// <summary>初始化 DbContext</summary>
        private void InitDbContext()
        {
            UseDbContext();
            Console.WriteLine("Initialed Database");
        }

        /// <summary>使用 InMemory 資料庫</summary>
        protected virtual void UseDbContext()
        {
            var contextOptions = new DbContextOptionsBuilder<TalasUrlDbContext>()
                .UseInMemoryDatabase(databaseName: "MyDatabase")
                .Options;
            Context = new TalasUrlDbContext(contextOptions);
        }

        /// <summary>解構式</summary>
        ~DbManager()
        {
            Dispose(false);
        }

        /// <summary>清除此類別資源</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>清除此類別資源</summary>
        /// <param name="disposing">是否在清理中</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            Disposed = true;
        }

        /// <summary>儲存所有異動</summary>
        public void Save()
        {
            Context.SaveChanges();
        }

        /// <summary>檢查資料庫是否存在</summary>
        /// <returns>是否存在</returns>
        public bool IsDatabasebExist()
        {
            return Context.Database.EnsureCreated();
        }

        /// <summary>取得某一個 Entity Repository。如果沒有取過會初始化一個，如果有就取得之前的</summary>
        /// <typeparam name="TEntity">此 DbContext 裡面的 Entity Type</typeparam>
        /// <returns>Entity Repository</returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (Repositories == null)
            {
                Repositories = new Hashtable();
            }

            // 檢查是否已經初始化過類別為 TEntity 的 Entity Repository
            var type = typeof(TEntity).Name;
            if (Repositories.ContainsKey(type)) return (IRepository<TEntity>)Repositories[type];

            // 將初始化的 Entity Repository 實體存放進 Repository 池
            var repositoryType = typeof(EFGenericRepository<>);
            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), Context);
            Repositories.Add(type, repositoryInstance);

            return (IRepository<TEntity>)Repositories[type];
        }
    }
}
