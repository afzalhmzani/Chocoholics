using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Business;

namespace Chocoholics.Ui.Views
{
    public interface IProviderView
    {
        string ProviderName { get; set; }
        int ProviderNumber { get; set; }
        string ProviderStreetAddress { get; set; }
        string ProviderCity { get; set; }
        string ProviderState { get; set; }
        string ProviderCountry { get; set; }
        string ProviderZipCode { get; set; }
        string ProviderPhoneNumber { get; set; }
        string ProviderEmailAddress { get; set; }
        List<Provider> allProvider { get; set; }
        int SearchProviderGet { get; set;  }

        event EventHandler AddProvider;
        event EventHandler UpdateProvider;
        event EventHandler DeleteProvider;
        event EventHandler SearchProvider;
        event EventHandler SelectAllProviders;


        void DisplayException(Exception ex);
    }
}
