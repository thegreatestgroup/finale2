using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class AddOperation
    {
        public void addAttributeToTableWithoutTransaction(string tableName, string listOfValues)
        {
            string insertQuery = "INSERT INTO " + tableName;
            insertQuery += " VALUES (" + listOfValues + ");";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, insertQuery);
        }

        public void addAttributeToTable(string tableName, string listOfValues)
        {
            string insertQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'InsertTransaction';" +
                " BEGIN TRANSACTION @TranName;";
            
            insertQuery += " INSERT INTO " + tableName;
            insertQuery += " VALUES (" + listOfValues + ");";

            insertQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, insertQuery);
        }
    }
}
