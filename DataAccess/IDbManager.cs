using System;
using DataAccess.Repository;

namespace DataAccess
{
    /// <summary>資料庫管理者介面</summary>
    /// <remarks>REF: 採 Unit of Work 模式 ( https://ithelp.ithome.com.tw/articles/10157700 )</remarks>
    public interface IDbManager : IDisposable
    {
        /// <summary>檢查資料庫是否存在</summary>
        /// <returns>是否存在</returns>
        bool IsDatabasebExist();

        /// <summary>儲存所有異動</summary>
        void Save();

        /// <summary>取得某一個 Entity Repository。如果沒有取過會初始化一個，如果有就取得之前的</summary>
        /// <typeparam name="TEntity">此 DbContext 裡面的 Entity Type</typeparam>
        /// <returns>Entity Repository</returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
