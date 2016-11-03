using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chocoholics.Business
{
    /// <summary>
    /// A single piece of electronic funds transfer data.
    /// </summary>
    public class EFT
    {
        public EFT() : this(string.Empty, 0, 0.00M)
        {
        }

        public EFT(string providerName, int providerNumber, decimal transferAmount)
        {
            ProviderName = providerName;
            ProviderNumber = providerNumber;
            TransferAmount = transferAmount;
        }

        // fields
        private string _providerName;
        private int _providerNumber;
        private decimal _transferAmount;

        /// <summary>
        /// The amount of money that needs to be transfered into 
        /// the bank account of the provider.
        /// </summary>
        public decimal TransferAmount
        {
            get { return _transferAmount; }
            private set { _transferAmount = value; }
        }

        /// <summary>
        /// The identification number for the provider that needs to get paid.
        /// </summary>
        public int ProviderNumber
        {
            get { return _providerNumber; }
            private set { _providerNumber = value; }
        }

        /// <summary>
        /// The name of the provider that needs to get paid.
        /// </summary>
        public string ProviderName
        {
            get { return _providerName; }
            private set { _providerName = value; }
        }
    }
}