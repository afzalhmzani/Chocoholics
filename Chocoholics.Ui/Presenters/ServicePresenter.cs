using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Chocoholics.Ui.Views;
using Chocoholics.Business;



namespace Chocoholics.Ui.Presenters
{
    public class ServicePresenter
    {
        IServiceView _view;
        Service _service;
        

        public ServicePresenter(IServiceView view)
        {
            _view = view;
            
            // subscribe to events.
            _view.AddService += _view_AddService;
            _view.UpdateService += _view_UpdateService;
            _view.DeleteService += _view_DeleteService;
            _view.SearchForService += _view_SearchForService;
            _view.SelectAllServices += _view_SelectAllServices;
            //DisplayData(); 
            //  _view.GradView += _view_GradView; 
        }

        private void _view_DeleteService(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                chocAnSystem.DeleteService(_view.ServiceCode); // Some How it is not working. It use to be but I do not know. 
                EmptyMyListData();
                DisplayData();
                // and I do not how to do it wil database
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex);
            }

        }

        private void _view_UpdateService(object sender, EventArgs e)
        {
            if ( !(string.IsNullOrEmpty(_view.ServiceName)) && !(string.IsNullOrEmpty(_view.ServiceDescription)) && (_view.ServiceFee != null) && (_view.ServiceCode != null) )
            {
                try
                {
                    ChocAnSystem chocAnSystem = new ChocAnSystem();
                    _service = new Service(_view.ServiceName, _view.ServiceCode, _view.ServiceFee, _view.ServiceDescription);
                    chocAnSystem.UpdateService(_service);
                    DisplayData();
                }
                catch (Exception ex)
                {
                    _view.DisplayException(ex);
                }
            }
            
        }

        private void _view_AddService(object sender, EventArgs e)
        {
            try
            {
                
               ChocAnSystem chocAnSystem = new ChocAnSystem();
               _service = new Service(_view.ServiceName, _view.ServiceCode, _view.ServiceFee, _view.ServiceDescription);
                chocAnSystem.AddService(_service);
                DisplayData();

            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
        }

        public void _view_SearchForService(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Service> myService = chocAnSystem.SearchServiceById(_view.SearchService);
                //_service = chocAnSystem.RetrieveService(_view.ServiceCode); 
                DisplayData(myService);

            }
            catch (Exception ex)
            {
                _view.DisplayException(ex); 
            }
        }
        
        public void _view_SelectAllServices(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Service> allMyService = chocAnSystem.RetrieveActiveServices();
                if(allMyService != null)
                {
                    _view.allService = allMyService; 
                }
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex);
            }
        }
        private void DisplayData(List<Service> list)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Service> allMyService = list; // chocAnSystem.RetrieveActiveServices();
                
                if( allMyService != null)
                {
                    _view.allService = allMyService;
                }
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex); 
            } 
        }
        private void DisplayData()
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Service> allServices = chocAnSystem.RetrieveActiveServices(); // chocAnSystem.RetrieveActiveServices();

                if (allServices != null)
                {
                    DisplayData(allServices);
                }
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
        }


        private void EmptyMyListData()
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Service> allMyService = null;
                _view.allService = allMyService; 
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex); 
            }
        }

       


    }
}
