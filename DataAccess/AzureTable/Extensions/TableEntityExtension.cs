using Microsoft.Azure.Cosmos.Table;
using System;

namespace DataAccess.AzureTable.Extensions
{
    public static class TableEntityExtension
    {
        public static void InitPartitionKeyAndRowKey(this TableEntity tableEntity)
        {
            var guid = Guid.NewGuid().ToString();
            tableEntity.PartitionKey = guid.Substring(0, 2);
            tableEntity.RowKey = guid;
        }
    }
}
