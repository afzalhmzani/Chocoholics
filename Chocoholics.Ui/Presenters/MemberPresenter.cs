using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Business;
using System.ComponentModel;
using Chocoholics.Ui.Views;


namespace Chocoholics.Ui.Presenters
{
    public class MemberPresenter
    {
        IMemberView _view;
        Member _member;
        
        public MemberPresenter(IMemberView view)
        {
            _view = view;

            _view.AddMember += _view_AddMember;
            _view.UpdateMember += _view_UpdateMember;
            _view.DeleteMember += _view_DeleteMember;
            _view.SearchMember += _view_SearchMember;
            _view.SelectAllMembers += _view_SelectAllMembers;



        }

        private void _view_DeleteMember(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                _member = new Member(_view.MemberName, _view.MemberNumber, _view.NickName, _view.MemberAddress, _view.MemberCity, _view.MemberState, _view.Country, _view.MemberZipCode, _view.PaidInFull, _view.Phone, _view.Eamil);
                chocAnSystem.DeleteMember(_member);
                EmptyMyListData(); 

            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
        }

        private void _view_UpdateMember(object sender, EventArgs e)
        {
            
                try
                {
                    ChocAnSystem chocAnSystem = new ChocAnSystem();
                _member = new Member(_view.MemberName, _view.MemberNumber, _view.NickName, _view.MemberAddress, _view.MemberCity, _view.MemberState, _view.Country, _view.MemberZipCode, _view.PaidInFull, _view.Phone, _view.Eamil);
                    chocAnSystem.UpdateMember(_member);
                }
                catch (Exception ex)
                {
                    _view.DisplayException(ex);
                }


            


        }

        private void _view_AddMember(object sender, EventArgs e)
        {
           try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                 _member = new Member( _view.MemberName, _view.MemberNumber, _view.NickName, _view.MemberAddress, _view.MemberCity, _view.MemberState, _view.Country,_view.MemberZipCode, _view.PaidInFull, _view.Phone,_view.Eamil);
                chocAnSystem.AddMember(_member);
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
           
        }

        private void _view_SearchMember(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Member> myMember = chocAnSystem.SearchMemberById(_view.SearchMemberNum);
                DisplayData(myMember);
            }
            catch(Exception ex)
            {
                _view.DisplayException(ex);
            }
        }
        private void DisplayData(List<Member> myMember)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Member> allMyMember = myMember;

                if (allMyMember != null)
                {
                    _view.allMember = allMyMember;
                }
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }


        }


        private void _view_SelectAllMembers(object sender, EventArgs e)
        {
            try
            {
                ChocAnSystem chocAnSystem = new ChocAnSystem();
                List<Member> allMyMember = chocAnSystem.GetActiveMembers();

                if (allMyMember != null)
                {
                    _view.allMember = allMyMember;
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
                List<Member> allMyMember = null;
                _view.allMember = allMyMember;
            }
            catch (Exception ex)
            {
                _view.DisplayException(ex);
            }
        }

    }

    }
