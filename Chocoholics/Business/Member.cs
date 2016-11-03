using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chocoholics.Business
{
    /// <summary>
    /// A current or former member of Chocoholics Anonymous.
    /// </summary>
    public class Member : Contact
    {
        
         public Member() :base()
         {

         }

        
        
       
        public Member(string name, int memberNum, string nickName, string addr, string city, string state, string country, string zip, char paid, string phone, string email) 
        {
            this.Name = name;
            this.MemberNumber = memberNum;
            this.NickName = nickName;
            this.StreetAddress = addr;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zip;
            this.PaidInFull = paid;
            this.PhoneNumber = phone;
            this.EmailAddress = email;
           
            
        }
        
        // fields
        private int _memberNumber;
        private int _contactNumber;
        private string _nickName;
        private char _paidInFull;
        private string _memberstatus;

        /// <summary>
        /// A 9-digit number assigned to a ChocAn Member.
        /// </summary>
        public int MemberNumber
        {
            get { return _memberNumber; }
            set { _memberNumber = value; }
        }  

        ///<summary>
        /// Contact number. 
        /// </summary>
        public int ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        ///<summary>
        /// A 12 charactor nickname assigned to a ChocAn Member
        /// </summary>
        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }

        ///<summary>
        /// Here is paid in full 
        /// </summary>
         public char PaidInFull
        {
            get { return _paidInFull; }
            set { _paidInFull = value; }
        }

        ///<summary>
        /// Here is the member staus if Active or not. 
        /// </summary>
        /// 
        public string MemberStatus
        {
            get { return _memberstatus; }
            set { _memberstatus = value;  }
        }
    }
}