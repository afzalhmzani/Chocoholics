using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Chocoholics.Business
{
    /// <summary>
    /// A base class to provide information common to 
    /// different types of items that have contact information.
    /// </summary>
    public class Contact
    {
        
        public Contact()
        {
            

        }
        
        public Contact(string name, string addr, string city, string state, string country, string zipcode, string phone, string em)
        {
            Name = name;
            StreetAddress = addr;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
            PhoneNumber = phone;
            EmailAddress = em;            
        }
        
        // fields
        private int _id;
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _name;
        private string _country;
        private string _phoneNumber;
        private DateTime? _dateCreated;
        private DateTime? _inactiveDate;
        private string _emailAddress;

        /// <summary>
        /// A unique identifier
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// The street address for the Contact
        /// </summary>
        public string StreetAddress
        {
            get { return _streetAddress; }
            set {
                if (value.Length < 5){
                    throw new Exception("Address length must be longer than 5 characters.");
                }
                else{_streetAddress = value;}
            }
        }
        
        /// <summary>
        /// City the Contact resides in
        /// </summary>
        public string City
        {
            get { return _city; }
            set {
                if (value.Length < 3){
                    throw new Exception("City length must be longer than 2 characters.");
                }
                else { _city = value; }
             }
        }

        /// <summary>
        /// 2-character state code the Contact resides in
        /// </summary>
        public string State
        {
            get { return _state; }
            set 
            {
                if (value.Length != 2){
                    throw new Exception("State code must be exactly two characters.");
                }
                else {_state = value; }
            }
        }

        /// <summary>
        /// The postal code relating to the address of the Contact
        /// </summary>
        public string ZipCode
        {
            get { return _zipCode; }
            set {
                if (value.Length < 5){
                    throw new Exception("Zip code length must be longer than 4 characters.");
                }
                else
                {_zipCode = value;}
               }
        }

        /// <summary>
        /// The common name that identifies the Contact.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                int number;
                var regexItem = new Regex("^[a-zA-Z0-9' -]*$");

                if (value.Length < 3){
                    throw new Exception("Name length must be longer than 2 characters.");
                }
                else if (Int32.TryParse(value, out  number))
                {
                    throw new Exception("Name must not be all numeric.");
                }
                else if (!regexItem.IsMatch(value))
                {
                    throw new Exception("Name must not contain special characters.");
                }
                else { _name = value; }
            }
        }

        /// <summary>
        /// The name of the country the Contact is located in.
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>        
        /// A phone number that the Contact can be reached at.
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        /// <summary>
        /// The DateTime the Contact was entered into the ChocAn system.
        /// </summary>
        public DateTime? DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        /// <summary>
        /// True indicates this Contact is considered an active member in the ChocAn system.
        /// </summary>
        public DateTime? InactiveDate
        {
            get { return _inactiveDate; }
            set { _inactiveDate = value; }
        }

        /// <summary>
        /// A valid email address for this Contact.
        /// </summary>
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public void Deactivate()
        {
            InactiveDate = DateTime.Now;
        }
       
    }
}