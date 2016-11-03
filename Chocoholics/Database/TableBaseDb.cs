using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Chocoholics.Database
{
    internal class TableBaseDb
    {
        private const string CONN_STRING = "Database=Chocolate;Data Source=us-cdbr-azure-central-a.cloudapp.net;User Id=b11c304bf62741;Password=de7356bd";
        private static MySqlConnection _conn;

        /// <summary>
        /// Gets a connection to the Chocoholics database.
        /// </summary>
        /// <returns>An open database connection to the Chocoholics database.</returns>
        protected static MySqlConnection ChocAnConnection()
        {
            try
            {
                _conn = new MySqlConnection(CONN_STRING);
                _conn.Open();
                return _conn;
            }
            catch (MySqlException mySqlEx)
            {
                switch (mySqlEx.Number)
                {
                    case 0:
                        Debug.WriteLine(
                            "Cannot connect to server (Error Code: 0)\n\tMessage: {0}", 
                            new object[] { mySqlEx.Message });
                        break;
                    case 1045:
                        Debug.WriteLine(
                            "Invalid username/password, check connection string. (Error Code: 1045)");
                        break;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ChocAnConnection\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
        }

        /// <summary>
        /// Creates a MySqlCommand object that is able to perform whatever action 
        /// the storedProcedure has been programmed to accomplish.
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        protected static MySqlCommand ChocAnCommand(string storedProcedure, MySqlConnection conn)
        {
            try
            {
                if (storedProcedure == null || conn == null)
                {
                    throw new Exception("The stored procedure and database connection must not be null.");
                }

                MySqlCommand cmd = new MySqlCommand(storedProcedure, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                return cmd;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ChocAnCommand\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
        }

        /// <summary>
        /// Closes an open connection to the Chocoholics database.
        /// </summary>
        /// <param name="conn">
        /// An open connection to the database. If this value is null 
        /// this method does nothing.
        /// </param>
        protected static void CloseConnection(MySqlConnection conn)
        {
            if (conn == null)
            {
                return;
            }

            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }


        protected static MySqlParameter CreateParameter(string name, object value, MySqlDbType type)
        {
            MySqlParameter parameter = new MySqlParameter()
            {
                ParameterName = name,
                MySqlDbType = type,
                Value = (value == null) ? DBNull.Value : value
            };

            return parameter;
        }

        protected static MySqlParameter CreateInOutParameter(string name, object value, MySqlDbType type)
        {
            MySqlParameter parameter = CreateParameter(name, value, type);
            parameter.Direction = System.Data.ParameterDirection.InputOutput;
                        
            return parameter;
        }
    }
}