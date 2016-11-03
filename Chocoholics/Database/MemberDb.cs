using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chocoholics.Business;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Chocoholics.Database
{
    internal class MemberDb : TableBaseDb
    {
        /// <summary>
        /// Loads a Member from the database with a specific memberId.
        /// </summary>
        /// <param name="memberId">A number that uniquely identifies a particular member.</param>
        /// <returns>
        /// A an instance of a specific Member, determined by the memberId.  If no 
        /// Member is found, it returns null.
        /// </returns>
        internal static Member GetMemberById(int memberId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listMemberByID";
            Member member = null; 
                   

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.AddWithValue("memberId", memberId);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        member = new Member()
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
                            MemberNumber = memberId,
                            PaidInFull = dr.GetChar("paidinfull")
                        };
                    }
                }
                cmd.Dispose();
                return member;
            }
            catch (Exception ex)
            {
                Debug.WriteLine (
                    "** Exception **\n\tLocation: GetMemberById\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
            finally
            {
                CloseConnection(conn);
            }            
        }

        

        //=============
        /// <summary>
        /// Get a member by Id
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>

        internal static List<Member> GetMemberByIdList(int memberId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listMemberByID";
            List<Member> members = new List<Member>();
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.AddWithValue("memberId", memberId);
               // cmd.Parameters.Add(CreateParameter("memberId", memberId, MySqlDbType.Int32));
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    { 
                        int Id = (int)dr["id"];
                        string name = dr["name"] as string;
                        string streetAddress = dr["streetaddress"] as string;
                        string city = dr["city"] as string;
                        string state = dr["state"] as string;
                        string zipCode = dr["zipcode"] as string;
                        string country = dr["country"] as string;
                        string phoneNumber = dr["phonenumber"] as string;
                        string emailAddress = dr["emailaddress"] as string;
                        string memberStatus = "Active";// dr["memberstatus"] as string;
                        string nickName =  dr["nickname"] as string;
                        char paidInFull = dr.GetChar("paidinfull");
                        int memberNumber = memberId;// (int)dr["member_id"];

     Member member = new Member(name, memberNumber, nickName, streetAddress, city, state, country, zipCode, paidInFull, phoneNumber, emailAddress);
                       
                        members.Add(member);
                    }
                }
                cmd.Dispose();
                return members;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.GetMemberById\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        //==========================
        ///<summary>
        /// Retrive all the current members. 
        /// </summary>
        /// <return> A list of active members <Member></return>
        ///
        internal static List<Member> GetActiveMembers()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "listMembers";
            Member member = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                List<Member> members = new List<Member>();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        member = new Member()
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
                            MemberStatus = dr["memberstatus"] as string,
                            NickName = dr["nickname"] as string,
                            PaidInFull = dr.GetChar("paidinfull"),
                            MemberNumber = (int)dr["member_id"]
                        };
                        members.Add(member);
                    }
                }
                cmd.Dispose();
                return members;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.GetActiveMembers\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Gets a list of all active members that are not up to date with their payments.
        /// </summary>
        /// <returns>Unpaid active members.</returns>
        internal static List<Member> GetUnpaidMembers()
        {
            List<Member> activeMembers = GetActiveMembers();
            // Filters all members
            List<Member> unpaidMembers = activeMembers.Where(m => m.PaidInFull == 'N').ToList();
            return unpaidMembers;
        }

        ///<summary>
        /// Retrive all the current members treated last week. 
        /// </summary>
        /// <return> A list of active members treated last week<Member></return>
        /// 
        internal static List<Member> GetMembersTreatedLastWeek()  //Added by KW for report usage
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = " rpt_servicesprovided_memberlist";
            Member member = null;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                List<Member> members = new List<Member>();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        member = new Member()
                        {
                            Name = dr["name"] as string, 
                            MemberNumber = (int)dr["member_id"]
                        };
                        members.Add(member);
                    }
                }
                cmd.Dispose();
                return members;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.GetMembersTreatedLastWeek\n\tMessage: {0}",
                    new object[] { ex.Message });

                return null;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        ///<summary>
        /// Insert members into ChocAn database
        /// </summary>
        /// <param name="member">A ChocAn member to be inserted.</param>
        /// /// <returns>
        /// The number of records affected in the database.  Returns 0 if no 
        /// records are affected, or if an exeption is caught.
        /// </returns>
        /// 
        internal static int Insert(Member member)
        {
            int memberId = NextMemberNumber();
            MySqlConnection conn = ChocAnConnection();
            string sp = "addMember";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                
                cmd.Parameters.Add(CreateParameter("cname", member.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("caddr", member.StreetAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ccity", member.City, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cstate", member.State, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("czipcode", member.ZipCode, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cctry", member.Country, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cphone", member.PhoneNumber, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ceml", member.EmailAddress, MySqlDbType.VarChar));

                cmd.Parameters.Add(new MySqlParameter()
                {
                    ParameterName = "mmembernum",
                    Value = DBNull.Value,
                    Direction = System.Data.ParameterDirection.InputOutput,
                    DbType = System.Data.DbType.Int32

                });

                cmd.Parameters.Add(CreateParameter("mnickname", member.NickName, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("mpaid", member.PaidInFull, MySqlDbType.VarChar));

                recordsAffected += cmd.ExecuteNonQuery();

                int nextId = 0; 
                 if (cmd.Parameters["mmembernum"].Value != DBNull.Value)
                {
                    nextId = (int)cmd.Parameters["mmembernum"].Value;
                }
                cmd.Dispose();
                return nextId;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemebrDb.Insert\n\tMessage: {0}",
                    new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Update an existing member in the ChocAn database.
        /// </summary>
        /// <param name="member">A ChocAn member to be updated.</param>
        /// <returns>The number of records affected in the database.</returns>
        internal static int Update(Member member)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "updateMember";
            int recordsAffected = 0;
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
               
                cmd.Parameters.Add(CreateParameter("mmembernum", member.MemberNumber, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("cname", member.Name, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("caddr", member.StreetAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ccity", member.City, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cstate", member.State, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("czipcode", member.ZipCode, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cctry", member.Country, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cphone", member.PhoneNumber, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ceml", member.EmailAddress, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("cinactive", member.InactiveDate, MySqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("mnickname", member.NickName, MySqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("mpaid", member.PaidInFull, MySqlDbType.VarChar));

                recordsAffected += cmd.ExecuteNonQuery();
                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.Update\n\tMessage: {0}",
                    new object[] { ex.Message });

                return 0;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Removes an existing member from the ChocAn database.
        /// </summary>
        /// <param name="member">The member to remove from the ChocAn database.</param>
        /// <returns>The number of records affected in the database.</returns>
        internal static int Delete(int memberNumber)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "deleteMember";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("mmembernum", memberNumber, MySqlDbType.Int32));

                recordsAffected += cmd.ExecuteNonQuery();

                cmd.Dispose();
                return recordsAffected;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.Delete\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Sets all members paid in full status to 'N', meaning they owe money.
        /// </summary>
        /// <returns>The number of records affected.</returns>
        internal static int MarkAllMembersUnpaid()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "markAllMembersasUnpaid";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                recordsAffected += cmd.ExecuteNonQuery();
                cmd.Dispose();

                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.MarkAllMembersUnpaid\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// Sets a specific member's paid in full status to 'Y', meaning they do not owe money.
        /// </summary>
        /// <param name="memberId">A unique identification number for a member.</param>
        /// <returns>The number of records affected.</returns>
        internal static int MarkMemberAsPaid(int memberId)
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "markMemberasPaid";
            int recordsAffected = 0;

            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);
                cmd.Parameters.Add(CreateParameter("memid", memberId, MySqlDbType.Int32));

                recordsAffected += cmd.ExecuteNonQuery();
                cmd.Dispose();

                return recordsAffected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.MarkMemberAsPaid\n\tMessage: {0}",
                    new object[] { ex.Message });

                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        /// <summary>
        /// I copied Jeff code I do not have an access to the database. 
        /// Gets the next member number available in the database.
        /// </summary>
        /// <returns>The next available number, or zero if an exception is caught.</returns>
        /// 
        private static int NextMemberNumber()
        {
            MySqlConnection conn = ChocAnConnection();
            string sp = "nextMemberNumber";
            int nextNumber = 0;
            try
            {
                MySqlCommand cmd = ChocAnCommand(sp, conn);

             

                cmd.Dispose();
                return nextNumber;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: MemberDb.GetActiveMembers\n\tMessage: {0}",
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