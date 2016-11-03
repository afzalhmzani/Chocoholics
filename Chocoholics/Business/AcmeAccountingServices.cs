using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chocoholics.Business
{
    /// <summary>
    /// Represents a third party service responsible for financial procedures
    /// such as recording payments of membership fees, suspending members whose 
    /// fees are overdue, and reinstating suspended members who have now paid what 
    /// is owing.  This is just a mock class used for testing.
    /// </summary>
    public class AcmeAccountingServices
    {
        /// <summary>
        /// Returns a mock list of ChocAn members that have just paid their membership fees.
        /// </summary>
        /// <returns>A list of ChocAn members that have paid their membership fees</returns>
        public List<Member> MembersWhoJustPaid()
        {
            try
            {
                // make all members unpaid, so it can pass that list to the caller.  
                Database.MemberDb.MarkAllMembersUnpaid();

                // pretend all members just paid, currently they are shown 
                // as unpaid in the chocAn system.
                List<Member> membersWhoPaid = Database.MemberDb.GetUnpaidMembers();

                return membersWhoPaid;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                   "** Exception **\n\tLocation: AcmeAccountingServices.MembersWhoJustPaid\n\tMessage: {0}",
                   new object[] { ex.Message });

                return null;
            }
        }

    }
}
