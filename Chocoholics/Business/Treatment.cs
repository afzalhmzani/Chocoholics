using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Globalization;

namespace Chocoholics.Business
{
    /// <summary>
    /// A specific instance of a service provided by a provider 
    /// to a ChocAn member on a specific date.
    /// </summary>
    public class Treatment
    {
        public Treatment()
        {
        }

        // fields
        private DateTime? _dateEntered;
        private DateTime _serviceDate;
        private int _providerNumber;
        private int _memberNumber;
        private int _serviceCode;
        private string _comments;
        private decimal _serviceFee;
        private int _id;
        private DateTime? _billedDate;

        /// <summary>
        /// A unique identifier for a particular treatment.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        /// <summary>
        /// The date that the provider recorded the particular service.  
        /// This date can  be on or after the actual date the service 
        /// was provided.
        /// </summary>
        public DateTime? DateEntered
        {
            get { return _dateEntered; }
            set { _dateEntered = value; }
        }

        /// <summary>
        /// The date that the particular service was performed.
        /// </summary>
        public DateTime ServiceDate
        {
            
            get { return _serviceDate; }
            set {
                    _serviceDate = value; 
                }
        }

        /// <summary>
        /// The identificatio number of the provider that provided 
        /// a partiular service to a member.
        /// </summary>
        public int ProviderNumber
        {
            get { return _providerNumber; }
            set { _providerNumber = value; }
        }

        /// <summary>
        /// The identification number of the member that received 
        /// a particular service from the provider.
        /// </summary>
        public int MemberNumber
        {
            get { return _memberNumber; }
            set { _memberNumber = value; }
        }

        /// <summary>
        /// The code that identifies the specific service provided.
        /// </summary>
        public int ServiceCode
        {
            get { return _serviceCode; }
            set { _serviceCode = value; }
        }

        /// <summary>
        /// The cost for a particular service.
        /// </summary>
        public decimal ServiceFee
        {
            get { return _serviceFee; }
            set
            {
                _serviceFee = value;
            }
        }

        /// <summary>
        /// Comments that can be entered by the provider for whatever 
        /// reason.
        /// </summary>
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        /// <summary>
        /// The date ChocAn system was billed by the provider for a service 
        /// they provided to a member.
        /// </summary>
        public DateTime? BilledDate
        {
            get { return _billedDate; }
            set { _billedDate = value; }
        }

        /// <summary>
        /// The current fee to be paid for the service performed with this treatment
        /// </summary>
        /// <returns></returns>
        internal decimal LookupCurrentFee()
        {
            try
            {
                ProviderDirectory currentDirectory = new ProviderDirectory();
                currentDirectory.Load();
                decimal fee = currentDirectory.PriceForService(ServiceCode);

                return fee;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

    }
}