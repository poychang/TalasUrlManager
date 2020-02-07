using DataAccess.AzureTable.Repository;
using DataAccess.Common;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;
using System;
using System.Collections;

namespace DataAccess.AzureTable
{
    public class TableManager : ITableManager
    {
        /// <summary>Repository 池</summary>
        protected Hashtable Repositories;
        /// <summary>是否已清除</summary>
        protected bool Disposed;
        /// <summary>選項存取子</summary>
        protected IOptions<TableManagerOptions> OptionsAccessor;
        /// <summary></summary>
        protected CloudStorageAccount CloudStorageAccount;
        /// <summary></summary>
        protected CloudTableClient TableClient;

        /// <summary>建構式</summary>
        /// <param name="optionsAccessor"></param>
        public TableManager(IOptions<TableManagerOptions> optionsAccessor)
        {
            OptionsAccessor = optionsAccessor;
            CloudStorageAccount = CloudStorageAccount.Parse(OptionsAccessor.Value.ConnectionString);
            TableClient = CloudStorageAccount.CreateCloudTableClient(new TableClientConfiguration());
        }

        /// <summary>初始化 Azure Table</summary>
        /// <param name="tableName">資料表名稱</param>
        public void InitTable(string tableName)
        {
            var table = TableClient.GetTableReference(tableName);
            var isTableExist = table.CreateIfNotExistsAsync().GetAwaiter().GetResult();

            Console.WriteLine(isTableExist
                ? $"Created Table named: {tableName}"
                : $"Table {tableName} already exists"
            );
        }

        /// <summary>檢查資料表是否存在</summary>
        /// <param name="tableName">資料表名稱</param>
        /// <returns>是否存在</returns>
        public bool IsTableExist(string tableName)
        {
            return TableClient.GetTableReference(tableName).Exists();
        }

        /// <summary></summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public CloudTable GetCloudTable<TEntity>(string tableName = null)
        {
            tableName = tableName ?? nameof(TEntity);

            if (!IsTableExist(tableName)) InitTable(tableName);

            return TableClient.GetTableReference(tableName);
        }

        /// <summary>取得某一個 Entity Repository。如果沒有取過會初始化一個，如果有就取得之前的</summary>
        /// <typeparam name="TEntity">此 DbContext 裡面的 Entity Type</typeparam>
        /// <returns>Entity Repository</returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : TableEntity, new()
        {
            if (Repositories == null)
            {
                Repositories = new Hashtable();
            }

            // 檢查是否已經初始化過類別為 TEntity 的 Entity Repository
            var type = typeof(TEntity).Name;
            if (Repositories.ContainsKey(type)) return (IRepository<TEntity>)Repositories[type];

            // 將初始化的 Entity Repository 實體存放進 Repository 池
            var repositoryType = typeof(TableGenericRepository<>);
            var repositoryInstance =
                Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), GetCloudTable<TEntity>());
            Repositories.Add(type, repositoryInstance);

            return (IRepository<TEntity>)Repositories[type];
        }

        /// <summary>解構式</summary>
        ~TableManager()
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
                    // TODO: Dispose somethings
                }
            }
            Disposed = true;
        }
    }
}
