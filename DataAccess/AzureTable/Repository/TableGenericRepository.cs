using DataAccess.Common;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.AzureTable.Repository
{
    /// <summary>實作存取 Azure Table Service 的 Generic Repository</summary>
    /// <remarks>
    /// REF: 搭配 Repository Pattern ( https://ithelp.ithome.com.tw/articles/10157484 )
    /// </remarks>
    /// <typeparam name="TEntity">Azure Table Service 裡面的 Table Entity Type</typeparam>
    // ReSharper disable once InconsistentNaming
    public class TableGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : TableEntity, new()
    {
        private CloudTable CloudTable { get; }

        /// <summary>建構式</summary>
        /// <param name="cloudTable">Entity 所在的 Azure Table</param>
        public TableGenericRepository(CloudTable cloudTable)
        {
            CloudTable = cloudTable;
        }

        /// <summary>新增一筆資料</summary>
        /// <param name="entity">要新增的 Entity</param>
        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                InsertOrMerge(entity);
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            var query = new TableQuery<TEntity>();
            return CloudTable.ExecuteQuery(query).AsQueryable().Where(predicate).FirstOrDefault();
        }

        public IQueryable<TEntity> Read()
        {
            var query = new TableQuery<TEntity>();
            return CloudTable.ExecuteQuery(query).AsQueryable();
        }

        public void Update(TEntity entity)
        {
            var retrieveOperation = TableOperation.Retrieve<TEntity>(entity.PartitionKey, entity.RowKey.ToString());
            var retrievedResult = CloudTable.ExecuteAsync(retrieveOperation).GetAwaiter().GetResult();
            var data = retrievedResult.Result as TEntity;
            var hasData = data != null;

            if (hasData)
            {
                InsertOrMerge(entity);
            }
        }

        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("deleteEntity");
                }

                var deleteOperation = TableOperation.Delete(entity);
                var result = CloudTable.ExecuteAsync(deleteOperation).GetAwaiter().GetResult();

                // Get the request units consumed by the current operation. RequestCharge of a TableResult is only applied to Azure CosmoS DB 
                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of Delete Operation: " + result.RequestCharge);
                }

            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        private void InsertOrMerge(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                var insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
                var result = CloudTable.ExecuteAsync(insertOrMergeOperation).GetAwaiter().GetResult();
                var insertedCustomer = result.Result as TEntity;

                // Get the request units consumed by the current operation. RequestCharge of a TableResult is only applied to Azure Cosmos DB
                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }
            }
            catch (StorageException e)
            {
                throw;
            }
        }
    }
}
