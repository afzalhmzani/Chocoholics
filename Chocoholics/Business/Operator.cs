using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chocoholics.Business
{
    /// <summary>
    /// current or formor of Chocoholics Operator. 
    /// </summary>
    public class Operator : Contact
    {
        public Operator()
        {

        }
        private int _operatorNumber;
        private string _username;
        private string _password;
        private string _operatorstatus;


        public int OperatorNumber
        {
            get { return _operatorNumber; }
            set { _operatorNumber = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }
        public string OperatorStatus
        {
            get { return _operatorstatus;  }
            set { _operatorstatus = value;  }
        }
    }
}
