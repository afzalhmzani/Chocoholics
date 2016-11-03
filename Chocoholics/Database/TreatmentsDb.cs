using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chocoholics.Business;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Chocoholics.Database
{
    internal class TreatmentsDb : TableBaseDb
    {
        /// <summary>
        /// Inserts a new treatment record in the ChocAn database.
        /// </summary>
        /// <param name="treatment">The treatment to be inserted.</param>
        /// <returns>The id of the treatment that was just entered into the database.</returns>
        internal static int Insert(Treatment treatment)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "addTreatment";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("memid", treatment.MemberNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("provid", treatment.ProviderNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("treatmtdate", treatment.ServiceDate, MySqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("fee", DBNull.Value, MySqlDbType.Decimal));
                cmd.Parameters.Add(CreateParameter("comm", treatment.Comments, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("servcode", treatment.ServiceCode, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateInOutParameter("treatmentid", DBNull.Value, MySqlDbType.Int32));

                recordsAffected = cmd.ExecuteNonQuery();

                //// until I can get an inout parameter from Shannon
                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "select max(id) id from treatments";
                int nextId = 0;

                if (cmd.Parameters["treatmentid"].Value != DBNull.Value)
                {
                    nextId = (int)cmd.Parameters["treatmentid"].Value;
                }

                return nextId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: Treatment.Insert\n\tMessage: {0}",
                    new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Updates an existing record in the ChocAn database.
        /// </summary>
        /// <param name="treatment">The treatment that needs to be updated.</param>
        /// <returns>The number of records affected.</returns>
        internal static int Update(Treatment treatment)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "updateTreatment";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);

                cmd.Parameters.Add(CreateParameter("treatmentid", treatment.Id, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("memid", treatment.MemberNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("provid", treatment.ProviderNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("treatmtdate", treatment.ServiceDate, MySqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("fee", treatment.ServiceFee, MySqlDbType.Decimal));
                cmd.Parameters.Add(CreateParameter("comm", treatment.Comments, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("servcode", treatment.ServiceCode, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("daterep", treatment.DateEntered, MySqlDbType.DateTime));

                recordsAffected = cmd.ExecuteNonQuery();

                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: Treatment.Update\n\tMessage: {0}",
                    new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Deletes an existing record in the ChocAn database.
        /// </summary>
        /// <param name="treatment">The treatment that needs to be deleted.</param>
        /// <returns>The number of records affected.</returns>
        internal static int Delete(int treatmentId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "deleteTreatment";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("treatmentId", treatmentId, MySqlDbType.Int32));

                recordsAffected = cmd.ExecuteNonQuery();

                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: Treatment.Delete\n\tMessage: {0}",
                    new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        private static void AddParameters(MySqlCommand cmd, Treatment treatment)
        {
            try
            {
                cmd.Parameters.Add(CreateParameter("memid", treatment.MemberNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("provid", treatment.ProviderNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("treatmtdate", treatment.ServiceDate, MySqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("fee", treatment.ServiceFee, MySqlDbType.Decimal));
                cmd.Parameters.Add(CreateParameter("comm", treatment.Comments, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("servcode", treatment.ServiceCode, MySqlDbType.Int32));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a single treatment by the unique identifiers.
        /// </summary>
        /// <param name="memberId">The unique ID number for a ChocAn member.</param>
        /// <param name="providerId">The unique ID number for a ChocAn provider.</param>
        /// <param name="treatmentDate">The date the treatment was performed by a ChocAn provider on a ChocAn member.</param>
        /// <param name="serviceCode">The identification number for the service performed.</param>
        /// <returns>
        /// A treament with values loaded from the database.  If the treatment 
        /// is not found, returns null.
        /// </returns>
        internal static Treatment GetSpecificTreatment(int treatmentId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listTreatmentByID";
            Treatment treatment = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("treatmentid", treatmentId, MySqlDbType.Int32));

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        treatment = new Treatment()
                        {
                            MemberNumber = (int)dr["member_id"],
                            ProviderNumber = (int)dr["provider_id"],
                            ServiceDate = (DateTime)dr["treatmentdate"],
                            ServiceCode = (int)dr["servicecode"],
                            DateEntered = dr["datereported"] as DateTime?,
                            ServiceFee = (decimal)dr["servicefee"],
                            Comments = dr["comments"] as string,
                            Id = treatmentId
                            // what to do with billeddate??
                        };

                        // just need first one, ignore any others.
                        break;
                    }
                }

                cmd.Dispose();
                return treatment;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: Treatment.GetTreatmentById\n\tMessage: {0}",
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