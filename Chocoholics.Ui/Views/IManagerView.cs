using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocoholics.Ui.Views
{
    public interface IManagerView
    {
        string OutputText { get; set; }
        int ActiveButton { get; set; }

        event EventHandler ActiveMemberInstructionsRequested;
        event EventHandler ActiveProviderInstructionsRequested;
        event EventHandler FetchRequestedReport;

    }
}
