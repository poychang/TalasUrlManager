using DataAccess.Common;
using Microsoft.Azure.Cosmos.Table;
using System;

namespace DataAccess.AzureTable
{
    public interface ITableManager : IDisposable
    {
        /// <summary>初始化 Azure Table</summary>
        /// <param name="tableName">資料表名稱</param>
        void InitTable(string tableName);

        /// <summary>檢查資料表是否存在</summary>
        /// <param name="tableName">資料表名稱</param>
        /// <returns>是否存在</returns>
        bool IsTableExist(string tableName);

        /// <summary>取得某一個 Entity Repository。如果沒有取過會初始化一個，如果有就取得之前的</summary>
        /// <typeparam name="TEntity">此 DbContext 裡面的 Entity Type</typeparam>
        /// <returns>Entity Repository</returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : TableEntity, new();
    }
}
