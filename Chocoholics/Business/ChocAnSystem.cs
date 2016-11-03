using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Chocoholics.Business
{
    public class ChocAnSystem
    {
        /// <summary>
        /// Inserts the member into the ChocAn database.
        /// </summary>
        /// <param name="member">
        /// A new member that will be added to the ChocAn database.
        /// </param>
        /// <returns>
        /// The number of rows affected in the ChocAn database.
        /// </returns>
        public string AddMember(Member member)
        {
            try
            {
                Validate(member);

                int newMemberId = Database.MemberDb.Insert(member);
                member.MemberNumber = newMemberId;

                if (member.MemberNumber > 0)
                {
                    return ("Member was added successfully");
                }
                else
                {
                    return ("Member could not be added to the ChocAn System");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Validate(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.Name) ||
                    string.IsNullOrWhiteSpace(member.StreetAddress) ||
                    string.IsNullOrWhiteSpace(member.City) ||
                    string.IsNullOrWhiteSpace(member.State) ||
                    string.IsNullOrWhiteSpace(member.ZipCode))
            {
                throw new Exception("Required fields are missing");
            }
        }

        /// <summary>
        /// Updates the member in the ChocAn database.
        /// </summary>
        /// <param name="member">
        /// A current member that has information that 
        /// needs to be updated in the ChocAn database.
        /// </param>
        /// <returns>
        /// The number of records affected in the ChocAn database.
        /// </returns>
        public string UpdateMember(Member member)
        {
            try
            {
                int recordsUpdated = Database.MemberDb.Update(member);
                if (recordsUpdated == 1)
                {
                    return "Update Successful";
                }
                else
                {
                    return "Update Failed";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Removes the member from the ChocAn database.
        /// </summary>
        /// <param name="member">
        ///  A current member that is about to be removed.
        /// </param>
        /// <returns>
        /// The number of records affected in the ChocAn database.
        /// </returns>
        public int DeleteMember(Member member)
        {
            try
            {
                int recordsDeleted = Database.MemberDb.Delete(member.MemberNumber);
                return recordsDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifies that the member is valid and represents a 
        /// current ChocAn member in good standing.
        /// </summary>
        /// <param name="memberNumber">
        /// The 9-digit member number for a possible ChocAn member who is 
        /// attempting to get verified by the ChocAn system.</param>
        /// <returns>
        /// 'Validated' if a member is found matching the member 
        /// number, and that member is found to be in good standing.  If the number 
        /// is found but the member has not paid their membership fees for at 
        /// least a month, 'Member suspended'. If the member number is invalid, 
        /// 'Invalid number' is returned.
        /// </returns>
        public string VerifyMember(int memberNumber)
        {
            // make sure the number itself is in a valid form.
            string msg = VerifyMemberNumberRules(memberNumber);
            if (msg != null)
            {
                return msg;
            }

            Member member = Database.MemberDb.GetMemberById(memberNumber);
            if (member != null)
            {
                if (member.PaidInFull == 'Y')
                {
                    return "Validated";
                }
                else
                {
                    return "Member Suspended";
                }
            }
            
            // member not found
            return "Invalid Number";
        }

        public string VerifyMemberNumberRules(int memberNumber)
        {
            string mbrNumber = memberNumber.ToString();
            if (mbrNumber.Length != 9)
            {
                return ("Member number must be exactly 9 digits long.");
            }

            return null;
        }

        /// <summary>
        /// Verifies that the provider is valid. 
        /// </summary>
        /// <returns>
        /// 'Verified' if a provider is found matching the provider 
        /// number. 
        /// </returns>
        public string VerifyProvider(int providerNumber)
        {
            // make sure the number itself is in a valid form.
            string msg = VerifyProviderNumberRules(providerNumber);
            if (msg != null)
            {
                return msg;
            }

            Provider provider = Database.ProviderDb.GetProviderById(providerNumber);
            if (provider != null)
            {
                // need to recreate this test to focus on provider only
                return "Verified";
            }
            return "Invalid Number";
        }

        /// <summary>
        /// Verifies a provider id number is of a valid form.
        /// </summary>
        /// <param name="providerNumber">The provider id number</param>
        /// <returns>
        /// A message indicating that the validation failed, 
        /// or null, indicating the validation passed.
        /// </returns>
        public string VerifyProviderNumberRules(int providerNumber)
        {
            string prvdrNumber = providerNumber.ToString();
            if (prvdrNumber.Length != 9)
            {
                return ("Provider number must be exactly 9 digits long.");
            }

            return null;
        }

        /// <summary>
        /// Inserts the provider into the ChocAn database.
        /// </summary>
        /// <param name="provider">
        /// A new provider that will be added to the ChocAn database.
        /// </param>
        /// <returns>
        /// The provider identification number.
        /// </returns>
        public int AddProvider(Provider provider)
        {
            try
            {
                int newId = Database.ProviderDb.Insert(provider);
                return newId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Provider RetrieveProvider(int providerId)
        {
            try
            {
                Provider p = Database.ProviderDb.GetProviderById(providerId);

                if (p == null)
                {
                    throw new Exception(string.Format("Provider number {0} does not exist", providerId));
                }

                return p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the provider in the ChocAn database.
        /// </summary>
        /// <param name="provider">
        /// A current provider that has information that 
        /// needs to be updated in the ChocAn database.
        /// </param>
        /// <returns>
        /// The number of records affected in the ChocAn database.
        /// </returns>
        public string UpdateProvider(Provider provider)
        {
            try
            {
                int recordsAffected = Database.ProviderDb.Update(provider);
                if (recordsAffected == 1)
                {
                    return "Update Successful";
                }
                else
                {
                    return "Update Failed";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Removes the provider from the ChocAn database.
        /// </summary>
        /// <param name="provider">
        ///  A current provider that is about to be removed.
        /// </param>
        /// <returns>
        /// The number of records affected in the ChocAn database.
        /// </returns>
        public int DeleteProvider(int providerId)
        {
            try
            {
                int recordsAffected = Database.ProviderDb.Delete(providerId);
                return recordsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //===========================
        /// <summary>
        /// to get all my active provider 
        /// </summary>
        /// <returns></returns>
        public List<Provider> GetActiveProvider()
        {
            try
            {
                List<Provider> allProvider = Database.ProviderDb.GetActiveProvidersList(); 
                return allProvider; 
            }
            catch (Exception)
            {
                throw; 
            }
        }

        /// <summary>
        /// Adds a new Treatment to the ChocAn system.
        /// </summary>
        /// <param name="treatment">The treatment to save.</param>
        /// <returns>The id number of the record just added to the database.</returns>
        public int AddTreatment(Treatment treatment)
        {
            try
            {
                int nextId = Database.TreatmentsDb.Insert(treatment);
                return nextId;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Retrieves a treatment, which is a service that was performed 
        /// by a provider on a member at some date in history.
        /// </summary>
        /// <param name="memberId">The unique ID number for a ChocAn member.</param>
        /// <param name="providerId">The unique ID number for a ChocAn provider.</param>
        /// <param name="treatmentDate">The date the service was performed.</param>
        /// <param name="serviceCode">The unique ID number identifying the service provided.</param>
        /// <returns>
        /// A treatment object with values populated from the database.  
        /// If the treatment is not found in the database, returns null.
        /// </returns>
        public Treatment RetrieveTreatment(int treatmentId)
        {
            try
            {
                Treatment t = Database.TreatmentsDb.GetSpecificTreatment(treatmentId);
                return t;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates an existing treatment in the ChocAn system.
        /// </summary>
        /// <param name="treatment">The treatment to update.</param>
        /// <returns>The number of records affected in the database.</returns>
        public int UpdateTreatment(Treatment treatment)
        {
            try
            {
                int recordsAffected = Database.TreatmentsDb.Update(treatment);
                return recordsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete an existing treatment from the ChocAn system.
        /// </summary>
        /// <param name="treatment">The treatment to delete.</param>
        /// <returns>The number of records affected in the database.</returns>
        public int DeleteTreatment(int treatmentId)
        {
            try
            {
                int recordsAffected = Database.TreatmentsDb.Delete(treatmentId);
                return recordsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Retrieves a single service from the ChocAn database.
        /// </summary>
        /// <param name="serviceCode">An number that uniquely identifeis t.</param>
        /// <returns>
        /// A single service if one is found that matches the 
        /// serviceCode. If none are found, returns null
        /// </returns>
        public Service RetrieveService(int serviceCode)
        {
            try
            {
                Service s = Database.ServicesDb.GetServiceByCode(serviceCode);
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string VerifyServiceCodeRules(int serviceCode)
        {
            string svcCode = serviceCode.ToString();
            if (svcCode.Length != 6)
            {
                return ("Service code must be exactly 6 digits long.");
            }
            return null;
        }

        /// <summary>
        /// Retrieves a list of all the active services from the ChocAn database.
        /// </summary>
        /// <returns>
        /// A list of all active service, if none are found, returns an empty list.
        /// </returns>
        public List<Service> RetrieveActiveServices()
        {
            try
            {
                List<Service> all = Database.ServicesDb.GetAllServices();
                return all;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //================
        // My Code Service 
        public List<Service> SearchServiceById(int serviceCode)
        {
            try
            {
                List<Service> all = Database.ServicesDb.GetServiceByCodeList(serviceCode);
                return all;
            }
            catch (Exception)
            {
                throw; 
            }
        }

        //=====================

        // ======================
        // My Code Memeber
        public List<Member> SearchMemberById(int memberId)
        {
            try
            {
                List<Member> all = Database.MemberDb.GetMemberByIdList(memberId);
                return all;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //====================

        //=======================
        public List<Provider> SearchProviderByIdList(int providerId)
        {
            try
            {
                List<Provider> all = Database.ProviderDb.GetProviderByIdList(providerId);
                return all; 
            }
            catch(Exception)
            {
                throw; 
            }
        }

        //=============

        /// <summary>
        /// Adds a new service to the ChocAn system.
        /// </summary>
        /// <param name="service">The service instance to add the system.</param>
        /// <returns>The number of services added during the call to this method.</returns>
        public int AddService(Service service)
        {
            try
            {
                int servicesAdded = Database.ServicesDb.Add(service);
                return servicesAdded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates an existing service in the ChocAn system
        /// </summary>
        /// <param name="service">The updated service information.</param>
        /// <returns>The number of records affected.</returns>
        public int UpdateService(Service service)
        {
            try
            {
                int recordsAffected = Database.ServicesDb.Update(service);
                return recordsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing service in the ChocAn system.
        /// </summary>
        /// <param name="code">The service code used to identify the service to delete.</param>
        /// <returns>The number of services deleted from the ChocAn system.</returns>
        public int DeleteService(int code)
        {
            try
            {
                int recordsAffected = Database.ServicesDb.Delete(code);
                return recordsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a specific provider by their identification number.
        /// </summary>
        /// <param name="providerId">The provider identification number.</param>
        /// <returns>A single provider if one is found, otherwise null.</returns>
        public Provider GetProviderById(int providerId)
        {
            try
            {
                Provider provider = Database.ProviderDb.GetProviderById(providerId);
                return provider;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a single operator by their identification number.
        /// </summary>
        /// <param name="operatorId">The identification number for the operator.</param>
        /// <returns>An operator that has the operatorId.  If none is found, returns null.</returns>
        public Operator GetOperatorById(int operatorId)
        {
            try
            {
                Operator operatorr = Database.OperatorDb.GetOperatorById(operatorId);
                return operatorr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all active operators in the ChocAn system.
        /// </summary>
        /// <returns>A list of active operators.</returns>
        public List<Operator> GetAllActiveOperators()
        {
            try
            {
                List<Operator> operators = Database.OperatorDb.GetActiveOperators();
                return operators;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a specific member by their identification number.
        /// </summary>
        /// <param name="memberId">The member identification number.</param>
        /// <returns>A member with the identification number.</returns>
        public Member GetMemberById(int memberId)
        {
            try
            {
                Member member = Database.MemberDb.GetMemberById(memberId);
                return member;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all the active members in the ChocAn system.
        /// </summary>
        /// <returns>A list of active ChocAn members.</returns>
        public List<Member> GetActiveMembers()
        {
            try
            {
                List<Member> all = Database.MemberDb.GetActiveMembers();
                return all;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all providers in the ChocAn system with activities in the last week.
        /// </summary>
        /// <returns>A count of those providers.</returns>
        public int GetLastWeekProvidersCount()
        {
            try
            {
                List<Provider> providers = Database.ProviderDb.GetProvidersWhoProvidedServiceLastWeek();
                return providers.Count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all members in the ChocAn system with activities in the last week.
        /// </summary>
        /// <returns>A count of those members.</returns>
        public int GetLastWeekMembersCount()
        {
            try
            {
                List<Member> members = Database.MemberDb.GetMembersTreatedLastWeek();
                return members.Count;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                     "** Exception **\n\tLocation: Reports.ActiveProviderReport.RunReport\n\tMessage: {0}",
                     new object[] { ex.Message });
                throw ex;
            }
        }

        /// <summary>
        /// Records the payment of a ChocAn member, called (normally) by Acme Accounting Services.
        /// </summary>
        /// <param name="memberId">The unique identification number for a member.</param>
        /// <returns></returns>
        public int RecordMemberPayment(int memberId)
        {
            try
            {
                int membersUpdated = Database.MemberDb.MarkMemberAsPaid(memberId);
                return membersUpdated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Suspends a ChocAn member, called (normally) by Acme Accounting Services.
        /// </summary>
        /// <param name="memberId">The unique identification number for a member.</param>
        /// <returns></returns>
        public string SuspendMember(int memberId)
        {
            try
            {
                Member member = GetMemberById(memberId);
                member.PaidInFull = 'N';
                Database.MemberDb.Update(member);
                return "Member Suspended";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reinstates a ChocAn member, called (normally) by Acme Accounting Services.
        /// </summary>
        /// <param name="memberId">The unique identification number for a member.</param>
        /// <returns></returns>
        public string ReinstateMember(int memberId)
        {
            try
            {
                Member member = GetMemberById(memberId);
                member.PaidInFull = 'Y';
                Database.MemberDb.Update(member);
                return "Member Reinstated";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sums all the charges
        /// </summary>
        public void SumWeeklyCharges()
        {
            try
            {
                int recordsAffected = Database.ProviderChargesDb.SumTotalWeeklyCharges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of provider charges for the week.
        /// </summary>
        /// <returns></returns>
        public List<EFT> ProviderChargesForWeek()
        {
            try
            {
                // get the charges for the week (provider charges to ChocAn)
                List<EFT> charges = Database.ProviderChargesDb.ExtractEftData();
                return charges;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of provider charges for the week.
        /// </summary>
        /// <returns>A list of provider charges.</returns>
        public void SaveProviderChargesForWeek(List<EFT> charges, string path)
        {
            try
            {             
                FileInfo file = new FileInfo(path);
                if (!Directory.Exists(file.DirectoryName))
                {
                    Directory.CreateDirectory(file.DirectoryName);
                }

                using (StreamWriter sr = new StreamWriter(path, false))
                {
                    sr.WriteLine("ProviderName, ProviderId, ServiceTotal");
                    foreach (EFT charge in charges)
                    {
                        if (charge.TransferAmount <= 0)
                        {
                            Utilities.ErrorLogger.WriteError(
                                string.Format("Error... Provider: {0} wants to transfer = {1}", 
                                charge.ProviderName, charge.TransferAmount));

                            continue;
                        }

                        sr.WriteLine(
                            "{0},{1},{2:n2}", 
                            charge.ProviderName, 
                            charge.ProviderNumber, 
                            charge.TransferAmount);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void WriteToErrorLog(EFT charge)
        {
            using (StreamWriter sr = new StreamWriter(@"C:\temp\errorlog.txt", true))
            {
                sr.WriteLine("Invalid charge for {0}", charge.ProviderName);
            }
        }
    }
}