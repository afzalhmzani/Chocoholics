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
    public class ProviderPresenter
    {
        IProviderView _view;
        Provider _provider;

        public ProviderPresenter(IProviderView view)
        {
            _view = view;

            _view.AddProvider += _view_AddProvider;
            _view.UpdateProvider += _view_UpdateProvider;
            _view.DeleteProvider += _view_DeleteProvider;
            _view.SearchProvider += _view_SearchProvider;
            _view.SelectAllProviders += _view_SelectAllProviders; 
        }

        
        private void _view_DeleteProvider(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                chocAnSystem.DeleteProvider(_view.ProviderNumber);
                EmptyMyListData(); 
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex); 
            }
        }

        private void _view_UpdateProvider(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                _provider = new Provider(_view.ProviderName, _view.ProviderNumber, _view.ProviderStreetAddress, _view.ProviderCity, _view.ProviderState, _view.ProviderCountry, _view.ProviderZipCode, _view.ProviderPhoneNumber, _view.ProviderEmailAddress);
                chocAnSystem.UpdateProvider(_provider);
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex);
            }
        }

        private void _view_AddProvider(object sender, EventArgs e)
        {
           try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                _provider = new Provider(_view.ProviderName, _view.ProviderNumber, _view.ProviderStreetAddress, _view.ProviderCity, _view.ProviderState, _view.ProviderCountry, _view.ProviderZipCode, _view.ProviderPhoneNumber, _view.ProviderEmailAddress);
                chocAnSystem.AddProvider(_provider);
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex);
            }
        }

        private void _view_SearchProvider(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Provider> myProvider = chocAnSystem.SearchProviderByIdList(_view.SearchProviderGet);
                DisplayData(myProvider);
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex);
            }
        }

        private void _view_SelectAllProviders(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Provider> allMyProvider = chocAnSystem.GetActiveProvider();
                if(allMyProvider != null)
                {
                    _view.allProvider = allMyProvider; 
                }
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex); 
            }


        }

        private void DisplayData(List<Provider> myProvider)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();

                List<Provider> allMyProvider = myProvider;

                if (allMyProvider != null)
                {
                    _view.allProvider = allMyProvider;
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
                List<Provider> allMyProvider = null;
                _view.allProvider = allMyProvider; 
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
        }

    }
}
