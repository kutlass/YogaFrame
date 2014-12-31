using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using YogaFrameWebAdapter.SessionsJsonTypes;
using YogaFrameWebAdapter.MembersJsonTypes;
using YogaFrameWebAdapter.JSessionJsonTypes;

namespace YogaFrameWebAdapter.JSessionJsonTypes
{
    public class JSession
    {
        [JsonProperty("dispatch")]
        public Dispatch Dispatch { get; set; }

        [JsonProperty("members")]
        public Members Members { get; set; }

        [JsonProperty("sessions")]
        public Sessions Sessions { get; set; }
    }
}

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
        private JSession jSession; // JSession = The uber pipe we'll be using to communicate with Session.php

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

        public static Dispatch MemberSignUp(
            out Session sessionOut,
            string strUserNameAlias,
            string strUserNameFirst,
            string strUserNameLast,
            string strEmailAddress,
            string strPasswordMatchEntry1,
            string strPasswordMatchEntry2
            )
        {
            Dispatch dsptchWebResponse = null;
            sessionOut = null;

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
                dsptchWebResponse = null;
                throw new ArgumentNullException();
            }        
            
            //
            // CHECK 2: Ensure the user's double-entry password proposal
            // is identical. This concludes our client side param checks.
            // The rest will be handled server side for extensibilty.
            //
            if (strPasswordMatchEntry1 != strPasswordMatchEntry2)
            {
                dsptchWebResponse = null;
                Trace.WriteLine("Session::MemberSignUp: The two password fields do not match.");

                return dsptchWebResponse;
            }
            string strPassword = strPasswordMatchEntry1;

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
            members.TblMembers = tblMembers.ToArray();
            
            //
            // Fill the Sessions object fields via user-submited form data
            //
            List<TblSession> TblSessions = new List<TblSession>
            {
                new TblSession(){GuidSession = "{62b4eb67-80f0-4c70-bfc4-bcfa09a10073}", IdtblMembers = "41", DtLastHeartBeat = "01/12/2015"}
            };
            Sessions sessionsPost = new Sessions();
            sessionsPost.TblSessions = TblSessions.ToArray();

            JSession jSession = new JSession();
            jSession.Dispatch.Message = "POSTREQUEST_MEMBER_SIGN_UP";
            jSession.Members = members;
            jSession.Sessions = sessionsPost;

            //
            // POST the above data with WebPostJSession() API
            //
            dsptchWebResponse.Message = string.Empty;
            dsptchWebResponse = WebAdapter.WebPostJSession(ref sessionsPost);
            if (null != dsptchWebResponse)
            {
                //
                // FETCH results with WebGetSessions API
                //
                Sessions sessionsGet = null;
                sessionsGet = WebAdapter.WebGetSessions();
                if (null != sessionsGet)
                {
                    sessionOut = new Session();
                    sessionOut.guidSession = sessionsGet.TblSessions[0].GuidSession;
                    sessionOut.dtLastHeartBeat = sessionsGet.TblSessions[0].DtLastHeartBeat;
                }
                else
                {
                    sessionOut = null;
                }
            }
            else
            {
                sessionOut = null;
            }
            
            return dsptchWebResponse;
        }
    }
}
