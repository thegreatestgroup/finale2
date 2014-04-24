using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class AddOperation
    {
        /* GENERIC SQL INSERT STATEMENT (more info ... http://www.w3schools.com/sql/sql_insert.asp)
         *  INSERT INTO table_name
         *  VALUES (value1,value2,value3,...);
         */

        /* 
         *  INSERT INTO tableName
         *  VALUES (listOfValues); (where listOfValues is a string something like "value1,value2,value3,...")
         */
        public void addAttributeToTableWithoutTransaction(string tableName, string listOfValues)
        {
            string insertQuery = "INSERT INTO " + tableName;
            insertQuery += " VALUES (" + listOfValues + ");";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, insertQuery);
        }

        /* 
         *  INSERT INTO tableName
         *  VALUES (listOfValues); (where listOfValues is a string something like "value1,value2,value3,...")
         */
        public void addAttributeToTable(string tableName, string listOfValues)
        {
            string insertQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'InsertTransaction';" +
                " BEGIN TRANSACTION @TranName;" +
                " WITH MARK N'Adding a new attribute.';";
            
            insertQuery += " INSERT INTO " + tableName;
            insertQuery += " VALUES (" + listOfValues + ");";

            insertQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, insertQuery);
        }

        /* 
         *  INSERT INTO tableName
         *  VALUES (listOfValues); (where listOfValues is a string something like "value1,value2,value3,...")
         */
        public void addAttributeToTableWithRollback(string tableName, string listOfValues)
        {
            string insertQuery = "BEGIN TRY " +
                " DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'InsertTransaction';" +
                " BEGIN TRANSACTION @TranName;" +
                " WITH MARK N'Adding a new attribute.';";

            insertQuery += " INSERT INTO " + tableName;
            insertQuery += " VALUES (" + listOfValues + ");";

            insertQuery += " COMMIT TRANSACTION @TranName;" +
                " GO" +
                " END TRY";

            insertQuery = "BEGIN CATCH" +
                " IF @@TRANCOUNT > 0" +
                " ROLLBACK" +
                " END CATCH";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, insertQuery);
        }
    }
}
