using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Business;

namespace Chocoholics.Ui.Views
{
    public interface ITerminalView
    {
        string PowerStatus { get; set; }
        bool IsOn { get; set; }
        string TerminalText { get; set; }
        string Instructions { get; set; }
        string ReportStatusMessage { get; set; }
        bool EntryEnabled { get; set; }
        bool SubmitEnabled { get; set; }
        bool ProviderReportRequestable { get; set; }

        List<Service> AvailableServices { get; set; }

        event EventHandler RequestSubmitted;
        event EventHandler AllServicesRequested;
        event EventHandler PowerStateChanged;
        event EventHandler ServicesDirectoryRequested;
        event EventHandler ProviderReportRequested;

        void DisplayException(Exception ex);
        void ShowBusy(bool isBusy);
        void SelectAllTerminalText();
    }
}
