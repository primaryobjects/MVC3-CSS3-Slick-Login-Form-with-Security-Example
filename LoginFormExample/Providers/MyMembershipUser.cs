using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LoginFormExample.Providers
{
    public class MyMembershipUser : MembershipUser
    {
        public MyMembershipUser(long userId, string userName)
            : base(Membership.Provider.Name, userName, userId, null, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
        }
    }
}