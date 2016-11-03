using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Ui.Presenters;
using Chocoholics.Ui.Views;
using Chocoholics.Business;

namespace Chocoholics.Ui.Terminal
{
    class ServiceDateKnown : ProviderTerminalState
    {
        TerminalPresenter _presenter;
        public ServiceDateKnown(TerminalPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void ProcessInput(string input, ITerminalView view)
        {
            // to get through the state, you need to enter a valid service code.
            int serviceCode;
            if (int.TryParse(input, out serviceCode))
            {
                // it's a number, so try to get the service.
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                string msg = chocAnSystem.VerifyServiceCodeRules(serviceCode);
                if (msg != null)
                {
                    view.Instructions = msg;
                    view.SelectAllTerminalText();
                }
                else
                {
                    Service service = chocAnSystem.RetrieveService(serviceCode);
                    if (service == null)
                    {
                        view.Instructions = "Service code not found. Please enter number again.";
                        view.SelectAllTerminalText();
                    }
                    else
                    {
                        // enter new information
                        _presenter.ProviderTreatment.ServiceCode = serviceCode;

                        // update the state
                        _presenter.TerminalState = _presenter.ServiceCodeKnown;
                        view.Instructions = string.Format("Is {0} the service you performed? (enter Y or N)", service.Name);
                        view.SelectAllTerminalText();
                    }
                }                
            }
            else
            {
                view.Instructions = "Service code must be a number. Please try again.";
                view.SelectAllTerminalText();
            }
        }

    }
}
