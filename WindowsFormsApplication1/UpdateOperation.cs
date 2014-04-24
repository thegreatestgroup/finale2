using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class UpdateOperation
    {
        public void updateAttributeInTableWithoutTransaction(string tableName, string columnName, string updateAttributeKey, string sqlSetStatement)
        {
            string updateQuery = "UPDATE " + tableName;
            updateQuery += " SET " + sqlSetStatement;
            updateQuery += " WHERE " + columnName + "=" + updateAttributeKey + ";";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, updateQuery);
        }

        public void updateAttributeInTable(string tableName, string columnName, string updateAttributeKey, string updateAttributeValue)
        {
            string updateQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'UpdateTransaction';" +
                " BEGIN TRANSACTION @TranName;";

            updateQuery += " UPDATE " + tableName;
            updateQuery += " SET " + columnName + "=" + updateAttributeValue;
            updateQuery += " WHERE " + columnName + "=" + updateAttributeKey + ";";

            updateQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, updateQuery);
        }

        public void updateAttributeInTableComplex(string tableName, string columnName, string updateAttributeKey, string sqlSetStatement)
        {
            string updateQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'UpdateTransaction';" +
                " BEGIN TRANSACTION @TranName;";

            updateQuery += " UPDATE " + tableName;
            updateQuery += " SET " + sqlSetStatement;
            updateQuery += " WHERE " + columnName + "=" + updateAttributeKey + ";";

            updateQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, updateQuery);
        }
    }
}
