using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class InnerJoinOperation
    {
        /* GENERIC SQL INNER JOIN STATEMENT (more info ... http://www.w3schools.com/sql/sql_join_inner.asp)
         *  SELECT column_name(s)
         *  FROM table1
         *  INNER JOIN table2
         *  ON table1.column_name=table2.column_name;
         */

        /*
         *  SELECT listOfSelectedColumns (where listOfSelectedColumns is something like "Customers.CustomerName, Orders.OrderID")
         *  FROM table1Name
         *  INNER JOIN table2Name
         *  ON table1Name.joinOnId=table2Name.joinOnId;
         */
        public System.Data.DataTable innerJoinTables(string listOfSelectedColumns, string joinOnId, string table1Name, string table2Name)
        {
            string joinQuery = "SELECT " + listOfSelectedColumns +
                " FROM " + table1Name +
                " INNER JOIN " + table2Name +
                " ON " + table1Name + "." + joinOnId + "=" + table2Name + "." + joinOnId + ";";

            SQLConnection sqlConnection = new SQLConnection();
            System.Data.DataTable table;

            table = sqlConnection.queryDatabase(table1Name, joinQuery);

            return table;
        }

        /*
         *  SELECT listOfSelectedColumns (where listOfSelectedColumns is something like "Customers.CustomerName, Orders.OrderID")
         *  FROM table1Name
         *  INNER JOIN table2Name
         *  ON table1Name.joinOnId=table2Name.joinOnId
         *  ORDER BY orderByClause (where orderByClause is something like "Customers.CustomerName")
         */
        public System.Data.DataTable innerJoinTables(string listOfSelectedColumns, string joinOnId, string table1Name, string table2Name, string orderByClause)
        {
            string joinQuery = "SELECT " + listOfSelectedColumns +
                " FROM " + table1Name +
                " INNER JOIN " + table2Name +
                " ON " + table1Name + "." + joinOnId + "=" + table2Name + "." + joinOnId +
                " ORDER BY " + orderByClause + ";";

            SQLConnection sqlConnection = new SQLConnection();
            System.Data.DataTable table;

            table = sqlConnection.queryDatabase(table1Name, joinQuery);

            return table;
        }
    }
}
