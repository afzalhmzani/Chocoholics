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
    class MemberKnown : ProviderTerminalState
    {
        TerminalPresenter _presenter;
        public MemberKnown(TerminalPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void ProcessInput(string input, ITerminalView view)
        {
            // to get through the state, you need to get a valid date in the
            // form of MM-DD-YYYY
            DateTime serviceDate;
            if (DateTime.TryParseExact(
                input, 
                "MM-dd-yyyy", 
                new System.Globalization.CultureInfo("en-US"), 
                System.Globalization.DateTimeStyles.AssumeLocal, 
                out serviceDate
                ))
            {
                // add the new piece of information.
                _presenter.ProviderTreatment.ServiceDate = serviceDate;
                
                // time to change the state.
                _presenter.TerminalState = _presenter.ServiceDateKnown;
                view.Instructions = "Enter the service code for the service provided.";
                view.SelectAllTerminalText();
            }
            else
            {
                view.Instructions = "Invalid date format, must be MM-DD-YYYY";
                view.SelectAllTerminalText();
            }
        }

    }
}
