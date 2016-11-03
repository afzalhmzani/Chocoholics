using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chocoholics.Business
{
    /// <summary>
    /// A service provider used by Chocoholics Anonymous.
    /// </summary>
    public class Provider : Contact
    {
        public Provider()
        {
        }

        public Provider(string name, int providrId, string addr, string city, string state, string country, string zipCode, string phoneNum, string email)
        {
            this.Name = name;
            ProviderNumber = providrId;
            this.StreetAddress = addr;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipCode;
            this.PhoneNumber = phoneNum;
            this.EmailAddress = email; 
        }

        // fields
        private int? _providerNumber;

        /// <summary>
        /// A 9-digit number assigned to a Provider. It's nullable 
        /// because a null value passed to the database on an insert will 
        /// assign a number automatically.
        /// </summary>
        public int? ProviderNumber
        {
            get { return _providerNumber; }
            set { _providerNumber = value; }
        }        
    }
}