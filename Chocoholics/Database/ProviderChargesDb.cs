using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chocoholics.Business;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Chocoholics.Database
{
    internal class ProviderChargesDb : TableBaseDb
    {
        /// <summary>
        /// Sums the total weekly charges for all providers.
        /// </summary>
        /// <returns>The number of records affected.</returns>
        internal static int SumTotalWeeklyCharges()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "totalWeeklyCharges";
            int recordsAffected = 0;
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                recordsAffected += cmd.ExecuteNonQuery();
                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                   "** Exception **\n\tLocation: ProviderChargesDb.SumTotalWeeklyCharges\n\tMessage: {0}",
                   new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        internal static List<EFT> ExtractEftData()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "rpt_simulateEFTextract";

            try
            {
                List<EFT> fundsTransferData = new List<EFT>();
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string name = dr["name"] as string;
                        int providerId = (int)dr["provider_id"];
                        decimal serviceTotal = (decimal)dr["service_total"];

                        fundsTransferData.Add(
                            new EFT(name, providerId, serviceTotal));
                    }
                }

                cmd.Dispose();
                return fundsTransferData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                   "** Exception **\n\tLocation: ProviderChargesDb.ExtractEftData\n\tMessage: {0}",
                   new object[] { ex.Message });

                return null;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

    }
}