using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class DeleteOperation
    {
        /* GENERIC SQL DELETE STATEMENT (more info ... http://www.w3schools.com/sql/sql_delete.asp)
         *  DELETE FROM table_name
         *  WHERE some_column=some_value;
         */

        /*
         *  DELETE FROM tableName
         *  WHERE columnName=valueToDelete;
         */
        public void deleteAttributeFromTableWithoutTransaction(string tableName, string columnName, string valueToDelete)
        {
            string deleteQuery = "DELETE FROM " + tableName;
            deleteQuery += " WHERE " + columnName + "=" + valueToDelete + ";";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, deleteQuery);
        }

        /*
         *  DELETE FROM tableName
         *  WHERE columnName=valueToDelete;
         */
        public void deleteAttributeFromTable(string tableName, string columnName, string valueToDelete)
        {
            string deleteQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'DeleteTransaction';" +
                " BEGIN TRANSACTION @TranName;" +
                " WITH MARK N'Deleting an attribute.';";

            deleteQuery += " DELETE FROM " + tableName;
            deleteQuery += " WHERE " + columnName + "=" + valueToDelete + ";";

            deleteQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, deleteQuery);
        }

        /*
         *  DELETE FROM tableName
         *  sqlWhereClause (where sqlWhereClause is a string something like "WHERE CustomerName='Alfreds Futterkiste' AND ContactName='Maria Anders';")
         *  for complex delete operations.
         */
        public void deleteAttributeFromTableComplex(string tableName, string columnName, string sqlWhereClause)
        {
            string deleteQuery = "DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'DeleteTransactionComplex';" +
                " BEGIN TRANSACTION @TranName;" +
                " WITH MARK N'Deleting an attribute.';";

            deleteQuery += " DELETE FROM " + tableName;
            deleteQuery += " " + sqlWhereClause;

            deleteQuery += " COMMIT TRANSACTION @TranName;" +
                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, deleteQuery);
        }

        /*
         *  DELETE FROM tableName
         *  sqlWhereClause (where sqlWhereClause is a string something like "WHERE CustomerName='Alfreds Futterkiste' AND ContactName='Maria Anders';")
         *  for complex delete operations.
         */
        public void deleteAttributeFromTableComplexWithRollback(string tableName, string columnName, string sqlWhereClause)
        {
            string deleteQuery = "BEGIN TRY " + 
                " DECLARE @TranName VARCHAR(20);" +
                " SELECT @TranName = 'DeleteTransactionComplex';" +
                " BEGIN TRANSACTION @TranName;" +
                " WITH MARK N'Deleting an attribute.';";

            deleteQuery += " DELETE FROM " + tableName;
            deleteQuery += " " + sqlWhereClause;

            deleteQuery += " COMMIT TRANSACTION @TranName;" +
                " GO" +
                " END TRY";

            deleteQuery += " BEGIN CATCH" +
                " IF @@TRANCOUNT > 0" +
                " ROLLBACK" +
                " END CATCH";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, deleteQuery);
        }
    }
}
