using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Ui.Views; 

namespace Chocoholics.Ui.Terminal
{
    /// <summary>
    /// The finite state machine that represents the behavior 
    /// of the provider terminal.
    /// </summary>
    public abstract class ProviderTerminalState
    {
        public virtual void TurnPowerOn(ITerminalView view)
        {
            // common logic for turning the power on.
            view.PowerStatus = "Power On";
            view.Instructions = "Enter a valid provider number.";
            view.EntryEnabled = true;
            view.SubmitEnabled = true;
            view.SelectAllTerminalText();
        }

        public virtual void TurnPowerOff(ITerminalView view)
        {
            // common logic for turning the power off.
            view.PowerStatus = "Power Off";
            view.TerminalText = "";
            view.Instructions = "Must turn on to begin";
            view.EntryEnabled = false;
            view.SubmitEnabled = false;
            view.ProviderReportRequestable = false;
        }

        public abstract void ProcessInput(string input, ITerminalView view);

    }
}
