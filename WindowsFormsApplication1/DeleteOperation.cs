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
    }
}
