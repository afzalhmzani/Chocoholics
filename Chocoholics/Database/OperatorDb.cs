using System;
using System.Collections.Generic;
using Chocoholics.Business;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Chocoholics.Database
{
    internal class OperatorDb : TableBaseDb
    {
        /// <summary>
        /// Loads a Operator from the database with a specific memberId.
        /// </summary>
        /// <param name="operatorId">A number that uniquely identifies a particular operator.</param>
        /// <returns>
        /// A an instance of a specific operator, determined by the operatorId.  If no 
        /// Operator is found, it returns null.
        /// </returns>
        /// 
        internal static Operator GetOperatorById(int operatorId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listOperatorByID";
            Operator operatorr = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.AddWithValue("operatorId", operatorId);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        operatorr = new Operator()
                        {
                            Id = (int)dr["id"],
                            Name = dr["name"] as string,
                            StreetAddress = dr["streetaddress"] as string,
                            City = dr["city"] as string,
                            State = dr["state"] as string,
                            ZipCode = dr["zipcode"] as string,
                            Country = dr["country"] as string,
                            PhoneNumber = dr["phonenumber"] as string,
                            EmailAddress = dr["emailaddress"] as string,
                            OperatorNumber = operatorId
                        };
                        
                        
                    }
                    
                }
                cmd.Dispose();
                return operatorr;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: GetOperatorById\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;

            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Gets a list of all Operators in the database that are currently
        /// active.
        /// </summary>
        /// <returns>A list of active operators.</returns>
        internal static List<Operator> GetActiveOperators()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listOperators";
            Operator operatorr = null; 
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                List<Operator> operators = new List<Operator>();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        operatorr = new Operator()
                        {
                            Id = (int)dr["id"],
                            Name = dr["name"] as string,
                            StreetAddress = dr["streetaddress"] as string,
                            City = dr["city"] as string,
                            State = dr["state"] as string,
                            ZipCode = dr["zipcode"] as string,
                            Country = dr["country"] as string,
                            PhoneNumber = dr["phonenumber"] as string,
                            EmailAddress = dr["emailaddress"] as string,
                            OperatorStatus = dr["operatorstatus"] as string,
                            OperatorNumber = (int)dr["operator_id"],
                            UserName = dr["username"] as string
                            
                        };
                        operators.Add(operatorr);
                    }
                }
                cmd.Dispose();
                return operators;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: OperatorDb.GetActiveOperator\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        ///<summary>
        /// Insert operator to the database. 
        /// </summary>
        /// <param name ="operatorr"> A chocAn operator inserted</param>
        /// <returns>
        /// The number of records affected in the database.  Returns 0 if no 
        /// records are affected, or if an exeption is caught.
        /// </returns>
        /// 
        internal static int Insert(Operator operatorr)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "addOperator"; 
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("cname", operatorr.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("caddr", operatorr.StreetAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ccity", operatorr.City, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cstate", operatorr.State, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("czipcode", operatorr.ZipCode, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cctry", operatorr.Country, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cphone", operatorr.PhoneNumber, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ceml", operatorr.EmailAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("username", operatorr.UserName, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("upwd", operatorr.PassWord, MySqlDbType.VarChar));

                cmd.Parameters.Add(CreateInOutParameter("operatornum", DBNull.Value, MySqlDbType.Int32));

                recordsAffected += cmd.ExecuteNonQuery();

                int nextId = 0;
                if (cmd.Parameters["operatornum"].Value != DBNull.Value)
                {
                    nextId = (int)cmd.Parameters["operatornum"].Value;
                }

                cmd.Dispose();
                return nextId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("** Exception **\n\tLocation: OperatorDb.Insert\n\tMessage: {0}",
                    new object[] { ex.Message });
                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }

        }

        /// <summary>
        /// Update an existing operator in the ChocAn database.
        /// </summary>
        /// <param name="operatorr">A ChocAn operatorr to be updated.</param>
        /// <returns>The number of records affected in the database.</returns>
        internal static int Update(Operator operatorr)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "updateOperator";
            int recordsAffected = 0;
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);

                cmd.Parameters.Add(CreateParameter("oprid", operatorr.OperatorNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("cname", operatorr.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("caddr", operatorr.StreetAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ccity", operatorr.City, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cstate", operatorr.State, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("czipcode", operatorr.ZipCode, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cctry", operatorr.Country, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cphone", operatorr.PhoneNumber, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ceml", operatorr.EmailAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cinactive", operatorr.InactiveDate, MySqlDbType.DateTime));

                recordsAffected += cmd.ExecuteNonQuery();
                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: OperatorDb.Update\n\tMessage: {0}",
                    new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Removes an existing operator from the ChocAn database.
        /// </summary>
        /// <param name="operatorId">The operator to remove from the ChocAn database.</param>
        /// <returns>The number of records affected in the database.</returns>
        internal static int Delete(int operatorNumber)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "deleteOperator";
            int recordsAffected = 0;
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("operatornum", operatorNumber, MySqlDbType.Int32));

                recordsAffected += cmd.ExecuteNonQuery();
                cmd.Dispose();
                return recordsAffected; 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: OperatorDb.Delete\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

    }
}