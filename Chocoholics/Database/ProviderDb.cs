using System;
using System.Collections.Generic;
using Chocoholics.Business;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Chocoholics.Database
{
    internal class ProviderDb : TableBaseDb
    {
        /// <summary>
        /// Loads a Provider from the database with a specific providerId.
        /// </summary>
        /// <param name="providerId">A number that uniquely identifies a particular provider.</param>
        /// <returns>
        /// A an instance of a specific Provider, determined by the providerId.  If no 
        /// Provider is found, it returns null.
        /// </returns>
        internal static Provider GetProviderById(int providerId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listProviderByID";
            Provider provider = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.AddWithValue("providerid", providerId);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        provider = new Provider()
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
                            ProviderNumber = providerId
                        };
                    }
                }

                cmd.Dispose();
                return provider;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.GetProviderById\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        //======================
        /// <summary>
        /// Get a provider by Id and store it a List
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        internal static List<Provider> GetProviderByIdList(int providerId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listProviderByID";
            Provider provider = null;
            List<Provider> providers = new List<Provider>();

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.AddWithValue("providerid", providerId);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {


                        int id = (int)dr["id"];
                        string name = dr["name"] as string;
                        string streetAddress = dr["streetaddress"] as string;
                        string city = dr["city"] as string;
                        string state = dr["state"] as string;
                        string zipCode = dr["zipcode"] as string;
                        string country = dr["country"] as string;
                        string phoneNumber = dr["phonenumber"] as string;
                        string emailAddress = dr["emailaddress"] as string;
                        int providerNumber = providerId;
                        
                        provider = new Provider(name, providerNumber, streetAddress, city, state, country, zipCode, phoneNumber, emailAddress);
                        providers.Add(provider); 
                    }
                }

                cmd.Dispose();
                return providers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.GetProviderById\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        // ==================================
        /// <summary>
        /// Get Active providr list 
        /// </summary>
        /// <returns></returns>
        internal static List<Provider>GetActiveProvidersList()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listProviders";
            Provider provider = null;
            List<Provider> providers = new List<Provider>();

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = (int)dr["id"];
                        string name = dr["name"] as string;
                        string streetAddress = dr["streetaddress"] as string;
                        string city = dr["city"] as string;
                        string state = dr["state"] as string;
                        string zipCode = dr["zipcode"] as string;
                        string country = dr["country"] as string;
                        string phoneNumber = dr["phonenumber"] as string;
                        string emailAddress = dr["emailaddress"] as string;
                        int providerNumber = (int)dr["provider_id"];

                        provider = new Provider(name, providerNumber, streetAddress, city, state, country, zipCode, phoneNumber, emailAddress);
                        providers.Add(provider);
                    }
                }

                cmd.Dispose();
                return providers; 
            }
            catch(Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.GetActiveProvidersList\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }


        /// <summary>
        /// Retrieves all current providers with an active status from the ChocAn system.
        /// </summary>
        /// <returns>A list containing active providers.</Provider></returns>
        internal static List<Provider> GetActiveProviders()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listProviders";
            Provider provider = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                List<Provider> providers = new List<Provider>();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        provider = new Provider()
                        {
                            Id = (int)dr["id"],
                            Name = dr["name"] as string,
                            StreetAddress = dr["streetaddress"] as string,
                            City = dr["city"] as string,
                            State = dr["state"] as string,
                            ZipCode = dr["zipcode"] as string,
                            Country = dr["country"] as string,
                            PhoneNumber = dr["phonenumber"] as string,
                            EmailAddress = dr["emailaddres"] as string,
                            ProviderNumber = (int)dr["provider_id"]
                        };

                        providers.Add(provider);
                    }
                }

                cmd.Dispose();
                return providers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.GetActiveProviders\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        ///<summary>
        /// Retrive all the current providers who provided at least 1 service last week. 
        /// </summary>
        /// <return> A list of active providers who provided at least 1 service last week<Member></return>
        /// 
        internal static List<Provider> GetProvidersWhoProvidedServiceLastWeek()  //Added by KW for report usage
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = " rpt_providercharges_providerlist";
            Provider provider = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                List<Provider> providers = new List<Provider>();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        provider = new Provider()
                        {
                            Name = dr["name"] as string,
                            ProviderNumber = (int)dr["provider_id"]
                        };
                        providers.Add(provider);
                    }
                }
                cmd.Dispose();
                return providers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.GetProvidersWhoProvidedServiceLastWeek\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Insert a provider into the ChocAn database.
        /// </summary>
        /// <param name="provider">A ChocAn provider to be inserted.</param>
        /// <returns>
        /// The number of records affected in the database.  
        /// </returns>
        internal static int Insert(Provider provider)
        {
            //int providerId = NextProviderNumber();

            MySqlConnection conn = ChocAnConnection();
            string sp = "addProvider";
            int recordsAffected = 0;
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);

                cmd.Parameters.Add(CreateParameter("cname", provider.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("caddr", provider.StreetAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ccity", provider.City, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cstate", provider.State, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("czipcode", provider.ZipCode, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cctry", provider.Country, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cphone", provider.PhoneNumber, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ceml", provider.EmailAddress, MySqlDbType.VarChar));

                // treat this differently, it's the return value for inserted id.
                cmd.Parameters.Add(new MySqlParameter()
                {
                    ParameterName = "pprovidernum",
                    Value = DBNull.Value,
                    Direction = System.Data.ParameterDirection.InputOutput,
                    DbType = System.Data.DbType.Int32
                });

                recordsAffected += cmd.ExecuteNonQuery();

                int nextId = 0;
            
                if (cmd.Parameters["pprovidernum"].Value != DBNull.Value)
                {
                    nextId = (int)cmd.Parameters["pprovidernum"].Value;
                }

                cmd.Dispose();
                return nextId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.Insert\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Update an existing provider in the ChocAn database.
        /// </summary>
        /// <param name="provider">A ChocAn provider to be updated.</param>
        /// <returns>The number of records affected in the database.</returns>
        internal static int Update(Provider provider)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "updateProvider";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);

                cmd.Parameters.Add(CreateParameter("providernum", provider.ProviderNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("cname", provider.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("caddr", provider.StreetAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ccity", provider.City, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cstate", provider.State, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("czipcode", provider.ZipCode, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cctry", provider.Country, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cphone", provider.PhoneNumber, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ceml", provider.EmailAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cinactive", provider.InactiveDate, MySqlDbType.DateTime));

                recordsAffected += cmd.ExecuteNonQuery();

                cmd.Dispose();
                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.Update\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Removes an existing provider from the ChocAn database.
        /// </summary>
        /// <param name="provider">The provider to remove from the ChocAn database.</param>
        /// <returns>The number of records affected in the database.</returns>
        internal static int Delete(int providerNumber)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "deleteProvider";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("providernum", providerNumber, MySqlDbType.Int32));

                recordsAffected += cmd.ExecuteNonQuery();

                cmd.Dispose();
                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.Delete\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Gets the next provider number available in the database.
        /// </summary>
        /// <returns>The next available number, or zero if an exception is caught.</returns>
        private static int NextProviderNumber()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "nextProviderNumber";
            int nextNumber = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);

                // need to know how Shannon is implemeting the sp.

                cmd.Dispose();
                return nextNumber;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ProviderDb.GetActiveProviders\n\tMessage: {0}",
                    new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }
    }
}