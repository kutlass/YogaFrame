using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YogaFrameWebAdapter.Session
{
    //
    // Quick notes:
    //  - Make Session.cs instanced, where we hold state fetched
    //    by above classes.
    //  - Make Session.cs a singleton.
    //
    public class Session
    {
        private Guid guidSession;
        public static Session MemberSignIn(
            string strUserName,
            string strPassword
            )
        {
            // TODO: Implement MemberSignIn API
            return null;
        }

        public static Session MemberSignUp(
            string strUserNameAlias,
            string strUserNameFirst,
            string strUserNameLast,
            string strEmailAddress,
            string strPasswordMatchEntry1,
            string strPasswordMatchEntry2
            )
        {
            // TODO: Implememnt MemberSignUp API
            return null;
        }
    }
}
