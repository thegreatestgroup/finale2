using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class DeleteOperation
    {
        public void deleteAttributeFromTableWithoutTransaction(string tableName, string columnName, string valueToDelete)
        {
            string deleteQuery = "DELETE FROM " + tableName;
            deleteQuery += " WHERE " + columnName + "=" + valueToDelete + ";";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, deleteQuery);
        }

        public void deleteAttributeFromTable(string tableName, string columnName, string valueToDelete)
        {
            string deleteQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'DeleteTransaction';" +
                " BEGIN TRANSACTION @TranName;";

            deleteQuery += " DELETE FROM " + tableName;
            deleteQuery += " WHERE " + columnName + "=" + valueToDelete + ";";

            deleteQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, deleteQuery);
        }

        public void deleteAttributeFromTableComplex(string tableName, string columnName, string sqlWhereClause)
        {
            string deleteQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'DeleteTransactionComplex';" +
                " BEGIN TRANSACTION @TranName;";

            deleteQuery += " DELETE FROM " + tableName;
            deleteQuery += " " + sqlWhereClause;

            deleteQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, deleteQuery);
        }
    }
}
