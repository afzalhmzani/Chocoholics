using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Ui.Presenters;
using Chocoholics.Ui.Views;

namespace Chocoholics.Ui.Terminal
{
    class ServiceSaved : ProviderTerminalState
    {
        TerminalPresenter _presenter;
        public ServiceSaved(TerminalPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void ProcessInput(string input, ITerminalView view)
        {
            throw new NotImplementedException();
        }

    }
}
