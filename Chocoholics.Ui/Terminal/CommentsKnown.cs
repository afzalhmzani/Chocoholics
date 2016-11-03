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
    class CommentsKnown : ProviderTerminalState
    {
        TerminalPresenter _presenter;
        public CommentsKnown(TerminalPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void ProcessInput(string input, ITerminalView view)
        {
            // add the last of the information to the Treatment
            _presenter.ProviderTreatment.Comments = input;
            _presenter.ProviderTreatment.DateEntered = DateTime.Now;

            // save the treatment
            ChocAnSystem chocAnSystem = new ChocAnSystem();

            try
            {
                chocAnSystem.AddTreatment(_presenter.ProviderTreatment);

                // return back to the state where a member number must be provided.
                _presenter.TerminalState = _presenter.ProviderKnown;

                // display the fee to be paid and other information.
                Service serviceWithPrice = chocAnSystem.RetrieveService(_presenter.ProviderTreatment.ServiceCode);
                view.Instructions = string.Format("Treatment was saved successfully. Fee to be paid = {0:C}. Enter member number.", serviceWithPrice.Fee);
                view.SelectAllTerminalText();
            }
            catch (Exception ex)
            {
                view.DisplayException(ex);
            }
        }

    }
}
