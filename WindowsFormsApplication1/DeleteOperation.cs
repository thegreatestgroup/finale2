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
            string insertQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'DeleteTransaction';" +
                " BEGIN TRANSACTION @TranName;";

            string deleteQuery = "DELETE FROM " + tableName;
            deleteQuery += " WHERE " + columnName + "=" + valueToDelete + ";";

            insertQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, insertQuery);
        }
    }
}
