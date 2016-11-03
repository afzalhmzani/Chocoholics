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
    class ProviderKnown : ProviderTerminalState
    {
        TerminalPresenter _presenter;
        public ProviderKnown(TerminalPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void ProcessInput(string input, ITerminalView view)
        {
            // to get through the state, you need to get a valid member number.
            int memberNumber;
            if (int.TryParse(input, out memberNumber))
            {
                // it's a number, so validate the form
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                string msg = chocAnSystem.VerifyMember(memberNumber);

                if (msg != "Validated")
                {
                    // display the message on the terminal.
                    if (!msg.EndsWith("."))
                    {
                        msg += ".";
                    }
                    view.Instructions = msg + " Please try again.";
                }
                else
                {
                    // add the new piece of information
                    _presenter.ProviderTreatment.MemberNumber = memberNumber;

                    // time to change the state.
                    _presenter.TerminalState = _presenter.MemberKnown;
                    view.Instructions = "Enter the date the service was provided.";
                    view.SelectAllTerminalText();
                }
            }
            else
            {
                view.Instructions = "Member number must be a number. Please try again.";
                view.SelectAllTerminalText();
            }
        }
    }
}
