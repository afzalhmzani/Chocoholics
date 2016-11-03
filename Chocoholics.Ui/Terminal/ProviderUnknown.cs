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
    class ProviderUnknown : ProviderTerminalState
    {
        TerminalPresenter _presenter;
        public ProviderUnknown(TerminalPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void ProcessInput(string input, ITerminalView view)
        {
            // this state needs to verify the provider number
            // in order to move to the next state.

            int providerNumber;
            if (int.TryParse(input, out providerNumber))
            {
                // it's a number, so validate the form
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                string msg = chocAnSystem.VerifyProvider(providerNumber);

                if (msg != "Verified")
                {
                    // display the message on the terminal.
                    if (!msg.EndsWith("."))
                    {
                        msg += ".";
                    }
                    view.Instructions = msg + " Please try again.";
                    view.SelectAllTerminalText();
                }
                else
                {
                    // add the piece of new information.
                    _presenter.ProviderTreatment.ProviderNumber = providerNumber;

                    // time to change the state.
                    _presenter.TerminalState = _presenter.ProviderKnown;
                    view.ProviderReportRequestable = true; 
                    view.Instructions = "Enter a valid member number.";
                    view.SelectAllTerminalText();
                }
            }
            else
            {
                view.Instructions = "Provider number must be a number. Please try again.";
                view.SelectAllTerminalText();
            }
        }

    }
}
