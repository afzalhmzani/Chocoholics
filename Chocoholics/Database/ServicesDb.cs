using System;
using System.Collections.Generic;
using System.Diagnostics;
using Chocoholics.Business;
using MySql.Data.MySqlClient;

namespace Chocoholics.Database
{
    internal class ServicesDb : TableBaseDb
    {
        /// <summary>
        /// Loads a Service from the database with a specific serviceCode.
        /// </summary>
        /// <param name="serviceCode">A number that uniquely identifies a particular service.</param>
        /// <returns>
        /// A an instance of a specific Service, determined by the serviceCode.  Returns null if no 
        /// Service is found.
        /// </returns>
        internal static Service GetServiceByCode(int serviceCode)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listServiceByID";
            Service service = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("service_code", serviceCode, MySqlDbType.Int32));

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int code = (int)dr["servicecode"];
                        string name = dr["nameofservice"] as string;
                        decimal fee = (decimal)dr["price"];

                        service = new Service(name, code, fee);
                        service.Description = dr["description"] as string;
                        service.InactiveDate = dr["inactive"] as DateTime?;
                    }
                }

                cmd.Dispose();
                return service;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ServicesDb.GetServiceByCode\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }


        // ====
        /// <summary>
        /// Get a service by Id and sort it in a List
        /// </summary>
        /// <param name="serviceCode"></param>
        /// <returns></returns>
        internal static List<Service> GetServiceByCodeList(int serviceCode)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listServiceByID";
            List<Service> services = new List<Service>();
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("service_code", serviceCode, MySqlDbType.Int32));

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int code = (int)dr["servicecode"];
                        string name = dr["nameofservice"] as string;
                        decimal fee = (decimal)dr["price"];

                        Service service = new Service(name, code, fee);
                        service.Description = dr["description"] as string;

                        services.Add(service);
                    }
                }

                cmd.Dispose();
                return services;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ServicesDb.GetServiceByCodeList\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }

        }

        

        /// <summary>
        /// Retrieves all services from the ChocAn system.
        /// </summary>
        /// <returns>
        /// An alphabetically ordered list of service names and corresponding 
        /// service codes and fees.
        /// </returns>
        internal static List<Service> GetAllServices()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listServices";
            List<Service> services = new List<Service>();

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int code = (int)dr["servicecode"];
                        string name = dr["nameofservice"] as string;
                        decimal fee = (decimal)dr["price"];

                        Service service = new Service(name, code, fee);
                        service.Description = dr["description"] as string;

                        services.Add(service);
                    }
                }

                cmd.Dispose();
                return services;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ServicesDb.GetAllServices\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Adds a new service into the ChocAn database.
        /// </summary>
        /// <param name="service">A service that a provider can be reimbursed for.</param>
        /// <returns>The number of records affected in the database.</returns>
        internal static int Add(Service service)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "addService";

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("service_code", service.Code, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("servicename", service.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("servicedescription", service.Description, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("serviceprice", service.Fee, MySqlDbType.Decimal));

                int rowsAffected = cmd.ExecuteNonQuery();
                
                cmd.Dispose();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ServicesDb.Add\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing service record in the database.
        /// </summary>
        /// <param name="service">The data used to update the record.</param>
        /// <returns>The number of records updated.</returns>
        internal static int Update(Service service)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "updateService";

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("service_code", service.Code, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("servicename", service.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("servicedescription", service.Description, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("serviceprice", service.Fee, MySqlDbType.Decimal));

                int rowsAffected = cmd.ExecuteNonQuery();

                cmd.Dispose();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ServicesDb.Update\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Removes an existing service from the database.
        /// </summary>
        /// <param name="code">The unique identifier of the service to remove.</param>
        /// <returns>The number of records deleted.</returns>
        internal static int Delete(int code)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "deleteService";

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("service_code", code, MySqlDbType.Int32));
                
                int rowsAffected = cmd.ExecuteNonQuery();

                cmd.Dispose();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ServicesDb.Delete\n\tMessage: {0}",
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