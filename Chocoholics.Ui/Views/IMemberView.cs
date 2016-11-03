using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocoholics.Business;


namespace Chocoholics.Ui.Views
{
    public interface IMemberView
    {
        string MemberName { get; set;  }
        int MemberNumber { get; set;  }
        string MemberAddress { get; set;  }
        string MemberCity { get; set;  }
        string MemberState { get; set;  }
        string MemberZipCode { get; set;  }
        string NickName { get; set; }
        char PaidInFull { get; set; }
        string Country { get; set;  }
        string Phone { get; set; }
        string Eamil { get; set; }
        List<Member> allMember { get; set;  }
        int SearchMemberNum { get; set;  }


        event EventHandler AddMember;
        event EventHandler UpdateMember;
        event EventHandler DeleteMember;
        event EventHandler SearchMember;
        event EventHandler SelectAllMembers; 

        void DisplayException(Exception ex);

    }
}
