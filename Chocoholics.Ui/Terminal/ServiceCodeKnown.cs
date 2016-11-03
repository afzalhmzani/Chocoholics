using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Ui.Presenters;
using Chocoholics.Ui.Views;

namespace Chocoholics.Ui.Terminal
{
    class ServiceCodeKnown : ProviderTerminalState
    {
        TerminalPresenter _presenter;
        public ServiceCodeKnown(TerminalPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void ProcessInput(string input, ITerminalView view)
        {
            // to get out of this state, you need to enter Y or N based on if the 
            // service code entered was the service code you intended to enter.

            char answer;
            if (char.TryParse(input, out answer))
            {
                switch (answer)
                {
                    case ('Y'):
                        _presenter.TerminalState = _presenter.CommentsKnown;
                        view.Instructions = "Enter any comments (100 characters max).";
                        view.SelectAllTerminalText();
                        break;
                    case ('N'):
                        _presenter.TerminalState = _presenter.ServiceDateKnown;
                        view.Instructions = "Enter the service code for the service provided.";
                        view.SelectAllTerminalText();
                        break;
                    default:
                        view.Instructions = "Invalid answer, only Y or N are acceptable. Please try again.";
                        view.SelectAllTerminalText();
                        break;
                }
            }
            else
            {
                view.Instructions = "Invalid answer, only Y or N are acceptable. Please try again.";
                view.SelectAllTerminalText();
            }
        }

    }
}
