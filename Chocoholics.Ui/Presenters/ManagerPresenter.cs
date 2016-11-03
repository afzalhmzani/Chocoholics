using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Ui.Views;
using Chocoholics.Business;
using Chocoholics.Reports;

namespace Chocoholics.Ui.Presenters
{
    public class ManagerPresenter
    {
        IManagerView _view;

        public ManagerPresenter(IManagerView view)
        {
            _view = view;

            // subscribe to events from view.
            _view.ActiveMemberInstructionsRequested += _view_ActiveMemberInstructionsRequested;
            _view.ActiveProviderInstructionsRequested += _view_ActiveProviderInstructionsRequested;
            _view.FetchRequestedReport += _view_FetchRequestedReport;
        }

    
        private async void _view_FetchRequestedReport(object sender, EventArgs e)
        {
            int inputInteger;
            switch (_view.ActiveButton)
            {
                case 0:
                    _view.OutputText = "Please select a report using buttons below";
                    await Task.Delay(3000);
                    _view.ActiveButton = 0;
                    _view.OutputText = "Choose Report...";
                    break;
                case 1:
                    string amrInput = _view.OutputText.ToString().Trim();
                    if (amrInput == "Enter Member ID or leave blank for all")  //In case user doesn't clear out original text before hitting enter
                        amrInput = "";
                    ActiveMemberReport amr = new ActiveMemberReport();
                    _view.OutputText = "Running Report(s)...";
                    
                    if(int.TryParse(amrInput, out inputInteger))
                        _view.OutputText = amr.RunReport(inputInteger);
                    else
                        _view.OutputText = amr.RunReport(amrInput);
                    await Task.Delay(3000);
                    _view.ActiveButton = 0;
                    _view.OutputText = "Choose Report...";
                    break;
                case 2:
                    string aprInput = _view.OutputText.ToString().Trim();
                    if (aprInput == "Enter Provider ID or leave blank for all") //In case user doesn't clear out original text before hitting enter
                        aprInput = "";
                    ActiveProviderReport apr = new ActiveProviderReport();
                    _view.OutputText = "Running Report(s)...";
                    if (int.TryParse(aprInput, out inputInteger))
                        _view.OutputText = apr.RunReport(inputInteger);
                    else
                        _view.OutputText = apr.RunReport(aprInput);
                    await Task.Delay(3000);
                    _view.ActiveButton = 0;
                    _view.OutputText = "Choose Report...";
                    break;
            }
        }

        private void _view_ActiveProviderInstructionsRequested(object sender, EventArgs e)
        {
            _view.ActiveButton = 2;
            _view.OutputText = "Enter Provider ID or leave blank for all";
        }

        private void _view_ActiveMemberInstructionsRequested(object sender, EventArgs e)
        {
            _view.ActiveButton = 1;
            _view.OutputText = "Enter Member ID or leave blank for all";
        }
    }
}
