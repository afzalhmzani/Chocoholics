using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Business;


namespace Chocoholics.Ui.Views
{
    public interface IServiceView
    {
        string ServiceName { get; set; }
        int ServiceCode { get; set; }
        decimal ServiceFee { get; set; }
        string ServiceDescription { get; set;  }
        List<Service> allService { get; set;  }
        int SearchService { get; set; }

        event EventHandler AddService;
        event EventHandler UpdateService;
        event EventHandler DeleteService;
        event EventHandler SearchForService;
        event EventHandler SelectAllServices;

        void DisplayException(Exception ex);

    }
}
