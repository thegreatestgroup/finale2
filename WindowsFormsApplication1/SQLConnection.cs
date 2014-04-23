using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class SQLConnection
    {
        private const string DEFAULT_USER_ID = "GreatestGroup";
        private const string DEFAULT_PASSWORD = "password";
        private const string DEFAULT_SERVER = "champlainmssql.cabect4hsdzs.us-east-1.rds.amazonaws.com,7788";
        private const string DEFAULT_DATABASE_NAME = "Greatest";
        private const string DEFAULT_TIMEOUT = "connection timeout=30";

        private string mUserId;
        private string mPassword;
        private string mServer;
        private string mDatabaseName;

        public SQLConnection()
        {
            mUserId = DEFAULT_USER_ID;
            mPassword = DEFAULT_PASSWORD;
            mServer = DEFAULT_SERVER;
            mDatabaseName = DEFAULT_DATABASE_NAME;
        }

        public SQLConnection(string userId, string password, string server, string databaseName)
        {
            mUserId = userId;
            mPassword = password;
            mServer = server;
            mDatabaseName = databaseName;
        }

        public void setUserId(string userId)
        {
            mUserId = userId;
        }

        public void setPassword(string password)
        {
            mPassword = password;
        }

        public void setServer(string server)
        {
            mServer = server;
        }

        public void setDatabaseName(string databaseName)
        {
            mDatabaseName = databaseName;
        }

        public string getId()
        {
            return mUserId;
        }

        public string getPassword()
        {
            return mPassword;
        }

        public string getServer()
        {
            return mServer;
        }

        public string getDatabaseName()
        {
            return mDatabaseName;
        }

        public System.Data.DataTable queryDatabase(string tableName, string queryStatement)
        {
            System.Data.DataTable table;

            using (System.Data.SqlClient.SqlConnection _con = new System.Data.SqlClient.SqlConnection(
                  "user id=" + mUserId + ";"
                + "password=" + mPassword + ";"
                + "server=" + mServer + ";"
                + "database=" + mDatabaseName + ";"
                + DEFAULT_TIMEOUT))
            {
                using (System.Data.SqlClient.SqlCommand _cmd = new System.Data.SqlClient.SqlCommand(queryStatement, _con))
                {
                    table = new System.Data.DataTable(tableName);

                    System.Data.SqlClient.SqlDataAdapter _dap = new System.Data.SqlClient.SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(table);
                    _con.Close();
                }
            }

            return table;
        }
    }
}