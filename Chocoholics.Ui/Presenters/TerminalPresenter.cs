using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Chocoholics.Ui.Views;
using Chocoholics.Business;
using Chocoholics.Ui.Terminal;
using Chocoholics.Reports;

namespace Chocoholics.Ui.Presenters
{
    public class TerminalPresenter
    {
        public TerminalPresenter(ITerminalView view)
        {
            _view = view;

            ProviderUnknown = new ProviderUnknown(this);
            ProviderKnown = new ProviderKnown(this);
            MemberKnown = new MemberKnown(this);
            ServiceDateKnown = new ServiceDateKnown(this);
            ServiceCodeKnown = new ServiceCodeKnown(this);
            CommentsKnown = new CommentsKnown(this);
            ServiceSaved = new ServiceSaved(this);

            TerminalState = ProviderUnknown;
            // start with power turned off
            TerminalState.TurnPowerOff(_view);

            // subscribe to events
            _view.AllServicesRequested += _view_AllServicesRequested;
            _view.RequestSubmitted += _view_RequestSubmitted;
            _view.PowerStateChanged += _view_PowerStateChanged;
            _view.ServicesDirectoryRequested += _view_ServicesDirectoryRequested;
            _view.ProviderReportRequested += _view_ProviderReportRequested;
            _view.ReportStatusMessage = "Select a report";
        }

        ITerminalView _view;

        // current state
        public ProviderTerminalState TerminalState { get; set; }

        // available terminal states.
        public ProviderTerminalState ProviderUnknown { get; private set; }
        public ProviderTerminalState ProviderKnown { get; private set; }
        public ProviderTerminalState MemberKnown { get; private set; }
        public ProviderTerminalState ServiceDateKnown { get; private set; }
        public ProviderTerminalState ServiceCodeKnown { get; private set; }
        public ProviderTerminalState CommentsKnown { get; private set; }
        public ProviderTerminalState ServiceSaved { get; private set; }

        public Treatment ProviderTreatment { get; set; }

        private void _view_PowerStateChanged(object sender, EventArgs e)
        {
            if (_view.IsOn)
            {
                TerminalState.TurnPowerOn(_view);

                // The actual treatment the terminal is trying to save.
                ProviderTreatment = new Treatment();
            }
            else
            {
                TerminalState.TurnPowerOff(_view);
            }
        }

        private void _view_AllServicesRequested(object sender, EventArgs e)
        {
            _view.ShowBusy(true);
            try
            {
                // get a preset member number and send to terminal window.
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Service> allServices = chocAnSystem.RetrieveActiveServices();

                if (allServices != null)
                {
                    _view.AvailableServices = allServices;
                }
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
            finally
            {
                _view.ShowBusy(false);
            }
        }

        private void _view_RequestSubmitted(object sender, EventArgs e)
        {
            _view.ShowBusy(true);
            _view.SubmitEnabled = false;

            try
            {
                TerminalState.ProcessInput(_view.TerminalText, _view);
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
            finally
            {
                _view.ShowBusy(false);
                _view.SubmitEnabled = true;
            }
        }
        
        private void _view_ProviderReportRequested(object sender, EventArgs e)
        {
            if (_view.ProviderReportRequestable)
            {
                _view.ReportStatusMessage = "Running report...";
                _view.ShowBusy(true);
                ActiveProviderReport rpt = new ActiveProviderReport();

                try
                {
                    _view.ReportStatusMessage = rpt.RunReport(ProviderTreatment.ProviderNumber);
                }
                catch (Exception ex)
                {
                    _view.DisplayException(ex);
                    _view.ReportStatusMessage = "Select a report";
                }
                finally
                {
                    _view.ShowBusy(false);
                }
            }
            else
            {
                _view.ReportStatusMessage = "Provider unknown, cannot run";
            }
        }

        private void _view_ServicesDirectoryRequested(object sender, EventArgs e)
        {
            _view.ReportStatusMessage = "Running report...";
            _view.ShowBusy(true);
            ServicesDirectoryReport rpt = new ServicesDirectoryReport();

            try
            {
                _view.ReportStatusMessage = rpt.RunReport();
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
                _view.ReportStatusMessage = "Select a report";
            }
            finally
            {
                _view.ShowBusy(false);
            }
        }
    }
}
