using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using YogaFrameWebAdapter.SessionsJsonTypes;
using YogaFrameWebAdapter.MembersJsonTypes;

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
        private string guidSession;     // TODO: Make this a real GUID type along with service
        private string dtLastHeartBeat; // TODO: Make this a real DateTime type along with service
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
            Session session = null;

            //
            // CHECK 1: Allow 0 parameters to be null
            //
            if (
                null == strUserNameAlias       ||
                null == strUserNameFirst       ||
                null == strUserNameLast        ||
                null == strEmailAddress        ||
                null == strPasswordMatchEntry1 ||
                null == strPasswordMatchEntry2 )
            {
                session = null;
                throw new ArgumentNullException();
            }        
            
            //
            // CHECK 2: Ensure the user's double-entry password proposal
            // is identical. This concludes our client side param checks.
            // The rest will be handled server side for extensibilty.
            //
            if (strPasswordMatchEntry1 != strPasswordMatchEntry2)
            {
                session = null;
                Trace.WriteLine("Session::MemberSignUp: The two password fields do not match.");

                return session;
            }
            string strPassword = strPasswordMatchEntry1;

            const string POSTREQUEST_MEMBER_SIGN_UP = "POSTREQUEST_MEMBER_SIGN_UP";
            Dispatch dispatch = new Dispatch();
            dispatch.Message = POSTREQUEST_MEMBER_SIGN_UP;
            List<TblMember> tblMembers = new List<TblMember>()
            {
                new TblMember()
                {
                    ColNameAlias        = strUserNameAlias,
                    ColNameFirst        = strUserNameFirst,
                    ColNameLast         = strUserNameLast,
                    ColEmailAddress     = strEmailAddress,
                    ColPasswordSaltHash = strPassword
                }
            };
            Members members = new Members();
            members.Dispatch = dispatch;
            members.TblMembers = tblMembers.ToArray();

            string strJsonWebResponse = string.Empty;
            strJsonWebResponse = WebAdapter.WebPostMember(ref members);
            if (string.Empty != strJsonWebResponse)
            {
                //
                // Fill the Sessions object fields via user-submited form data
                //
                List<TblSession> TblSessions = new List<TblSession>
            {
                new TblSession(){GuidSession = "{62b4eb67-80f0-4c70-bfc4-bcfa09a10073}", IdtblMembers = "41", DtLastHeartBeat = "01/12/2015"}
            };
                Sessions sessionsPost = new Sessions();
                sessionsPost.TblSessions = TblSessions.ToArray();

                //
                // POST the above data with WebPostSession() API
                //
                strJsonWebResponse = string.Empty;
                strJsonWebResponse = WebAdapter.WebPostSession(ref sessionsPost);
                if (string.Empty != strJsonWebResponse)
                {
                    //
                    // FETCH results with WebGetSessions API
                    //
                    Sessions sessionsGet = null;
                    sessionsGet = WebAdapter.WebGetSessions();
                    if (null != sessionsGet)
                    {
                        session = new Session();
                        session.guidSession = sessionsGet.TblSessions[0].GuidSession;
                        session.dtLastHeartBeat = sessionsGet.TblSessions[0].DtLastHeartBeat;
                    }
                    else
                    {
                        session = null;
                    }
                }
                else
                {
                    session = null;
                }

            }
            else
            {
                session = null;
            }

            return session;
        }
    }
}
