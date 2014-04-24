using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class UpdateOperation
    {
        /* GENERIC SQL UPDATE STATEMENT (more info ... http://www.w3schools.com/sql/sql_update.asp)
         *  UPDATE table_name
         *  SET column1=value1,column2=value2,...
         *  WHERE some_column=some_value;
         */

        /*
         *  UPDATE tableName
         *  SET sqlSetStatement (Where sqlSetStatement is a string that equals "column1=value1,column2=value2" or something similar) 
         *  WHERE columnName=rowId;
         */
        public void updateAttributeInTableWithoutTransaction(string tableName, string columnName, string rowId, string sqlSetStatement)
        {
            string updateQuery = "UPDATE " + tableName;
            updateQuery +=      " SET " + sqlSetStatement;
            updateQuery +=      " WHERE " + columnName + "=" + rowId + ";";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, updateQuery);
        }

        /*
         *  UPDATE tableName
         *  SET columnName=newColumnValue
         *  WHERE columnName=rowId;
         *
        public void updateAttributeInTable(string tableName, string columnName, string rowId, string newColumnValue)
        {
            string updateQuery = "DECLARE @TranName VARCHAR(20);" +
                                " SELECT @TranName = 'UpdateTransaction';" +
                                " BEGIN TRANSACTION @TranName;";
            updateQuery +=      " UPDATE " + tableName;
            updateQuery +=      " SET " + columnName + "=" + newColumnValue;
            updateQuery +=      " WHERE " + columnName + "=" + rowId + ";";
            updateQuery +=      " COMMIT TRANSACTION @TranName;" +
                                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, updateQuery);
        }
        */

        /*
         *  UPDATE tableName
         *  SET sqlSetStatement (Where sqlSetStatement is a string that equals "column1=value1,column2=value2" or something similar) 
         *  WHERE columnName=rowId;
         */
        public void updateAttributeInTableComplex(string tableName, string columnName, string rowId, string sqlSetStatement)
        {
            string updateQuery = "DECLARE @TranName VARCHAR(20);" +
                                " SELECT @TranName = 'UpdateTransaction';" +
                                " BEGIN TRANSACTION @TranName;" +
                                " WITH MARK N'Updating an attribute.';";
            updateQuery +=      " UPDATE " + tableName;
            updateQuery +=      " SET " + sqlSetStatement;
            updateQuery +=      " WHERE " + columnName + "=" + rowId + ";";
            updateQuery +=      " COMMIT TRANSACTION @TranName;" +
                                " GO";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, updateQuery);
        }

        /*
         *  UPDATE tableName
         *  SET sqlSetStatement (Where sqlSetStatement is a string that equals "column1=value1,column2=value2" or something similar) 
         *  WHERE columnName=rowId;
         */
        public void updateAttributeInTableComplexWithRollback(string tableName, string columnName, string rowId, string sqlSetStatement)
        {
            string updateQuery = "BEGIN TRY " + 
                                " DECLARE @TranName VARCHAR(20);" +
                                " SELECT @TranName = 'UpdateTransaction';" +
                                " BEGIN TRANSACTION @TranName;" +
                                " WITH MARK N'Updating an attribute.';";
            updateQuery +=      " UPDATE " + tableName;
            updateQuery +=      " SET " + sqlSetStatement;
            updateQuery +=      " WHERE " + columnName + "=" + rowId + ";";
            updateQuery +=      " COMMIT TRANSACTION @TranName;" +
                                " GO" +
                                " END TRY";
            updateQuery +=      " BEGIN CATCH" +
                                " IF @@TRANCOUNT > 0" +
                                " ROLLBACK" +
                                " END CATCH";

            SQLConnection sqlConnection = new SQLConnection();

            sqlConnection.queryDatabase(tableName, updateQuery);
        }
    }
}
