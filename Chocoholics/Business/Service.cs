using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chocoholics.Business
{
    /// <summary>
    /// A service, treatment, consultation or other
    /// benefit performed by a Provider for a Member.
    /// </summary>
    public class Service
    {
        // constructors
        public Service() : this(string.Empty, 0, 0.00M, string.Empty)
        {
        }
        
        public Service(string name, int code, decimal fee, string description) 
        {
            Name = name;
            Code = code;
            Fee = fee;
            Description = description;
        }
        public Service(string name, int code, decimal fee)
        {
            Name = name;
            Code = code;
            Fee = fee;
            
        }

        // fields
        private string _name;
        private int _code;
        private decimal _fee;
        private string _description;

        /// <summary>
        /// A descriptive name of the service.
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        /// <summary>
        /// A 6-digit code uniquely identifying the service.
        /// </summary>
        public int Code
        {
            get { return _code; }
            private set { _code = value; }
        }

        /// <summary>
        /// The fee to be paid by ChocAn for this service.
        /// </summary>
        public decimal Fee
        {
            get { return _fee; }
            private set { _fee = value; }
        }

        /// <summary>
        /// A more description of the particular service.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime? _inactiveDate;
        /// <summary>
        /// The date that the service became inactive.  A value 
        /// of null indicates that the service is still active.
        /// </summary>
        public DateTime? InactiveDate
        {
            get { return _inactiveDate; }
            set { _inactiveDate = value; }
        }

       
        // methods
    }
}