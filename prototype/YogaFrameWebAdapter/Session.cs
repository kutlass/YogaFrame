using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using YogaFrameWebAdapter.MembersJsonTypes;
using YogaFrameWebAdapter.SessionsJsonTypes;
using YogaFrameWebAdapter.JSessionJsonTypes;
using UnityEngine;

public class YogaFrameUnityAdapter : MonoBehaviour
{
    public string GetInstance()
    {
        YogaFrameWebAdapter.Session.Session session = new YogaFrameWebAdapter.Session.Session();

        return session.strConstructorMessage;
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
        //
        // Constructor
        //
        public Session()
        {
            this.strConstructorMessage = "Successfully created class instance: Session()";
        }
        public string strConstructorMessage;

        private JSession jSession; // JSession = The uber pipe we'll be using to communicate with Session.php

        private string guidSession;     // TODO: Make this a real GUID type along with service
        private string dtLastHeartBeat; // TODO: Make this a real DateTime type along with service

        public static JSession MemberSignIn(
            string strUserName,
            string strPassword
            )
        {
            JSession jSessionWebResponseAggregate = null;

            //
            // This MemberSignIn API makes a double call
            // to the web service. We sequentially fill
            // the jSessionWebResponseAggregate struct 
            // along the way and return the aggregate at
            // the method's end.
            //
            List<TblMember> tblMembers = new List<TblMember>()
            {
                new TblMember()
                {
                    ColNameAlias = strUserName, ColPasswordSaltHash = strPassword
                }
            };
            Members members = new Members();
            members.TblMembers = tblMembers.ToArray();
            JSession jSessionWebResponseWebSessionMemberSignIn = null;
            jSessionWebResponseWebSessionMemberSignIn = WebAdapter.WebSessionMemberSignIn(ref members);        
            if (null != jSessionWebResponseWebSessionMemberSignIn)
            {
                jSessionWebResponseAggregate = jSessionWebResponseWebSessionMemberSignIn;
                const string S_OK = "S_OK";
                if (S_OK == jSessionWebResponseWebSessionMemberSignIn.Dispatch.Message)
                {
                    string strServerGeneratedMemberId = jSessionWebResponseWebSessionMemberSignIn.Members.TblMembers[0].IdtblMembers;
                    List<TblSession> tblSessions = new List<TblSession>()
                    {
                        new TblSession()
                        {
                            IdtblMembers = strServerGeneratedMemberId
                        }
                    };
                    Sessions sessions = new Sessions();
                    sessions.TblSessions = tblSessions.ToArray();
                    JSession jSessionWebResponseWebCreateSession = null;
                    jSessionWebResponseWebCreateSession = WebAdapter.WebSessionCreateSession(ref sessions);
                    if (null != jSessionWebResponseWebCreateSession)
                    {
                        jSessionWebResponseAggregate.Dispatch.Message = jSessionWebResponseWebCreateSession.Dispatch.Message;
                        if (S_OK == jSessionWebResponseWebCreateSession.Dispatch.Message)
                        {
                            jSessionWebResponseAggregate.Sessions = jSessionWebResponseWebCreateSession.Sessions;
                        }
                    }
                }
            }

            return jSessionWebResponseAggregate;
        }

        public static JSession MemberSignUp(
            out Session sessionOut,
            string strUserNameAlias,
            string strUserNameFirst,
            string strUserNameLast,
            string strEmailAddress,
            string strPasswordMatchEntry1,
            string strPasswordMatchEntry2
            )
        {
            JSession jSessionWebResponse = null;

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
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }        
            
            //
            // CHECK 2: Ensure the user's double-entry password proposal
            // is identical. This concludes our client side param checks.
            // The rest will be handled server side for extensibilty.
            //
            if (strPasswordMatchEntry1 != strPasswordMatchEntry2)
            {
                sessionOut = null;
                jSessionWebResponse = null;
                Trace.WriteLine("Session::MemberSignUp: The two password fields do not match.");

                return jSessionWebResponse;
            }
            string strPassword = strPasswordMatchEntry1;

            //
            // Fill the Members object fields via user-submited form data
            //
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
            Dispatch dsptchWebRequest = new Dispatch();
            dsptchWebRequest.Message = "POSTREQUEST_MEMBER_SIGN_UP";
            JSession jSession = new JSession();
            jSession.Dispatch = dsptchWebRequest;
            jSession.Members = members;

            //
            // POST the above data with WebPostJSession() API
            //
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSession);
            if (null != jSessionWebResponse)
            {
                //
                // OUT param: Only return a non-null sessionOut if the
                //            the Member Signup request succeeded. We give
                //            our callers NULL on failure, not garbage objects.
                //
                if ("S_OK" == jSessionWebResponse.Dispatch.Message)
                {
                    sessionOut = new Session();
                    sessionOut.jSession = new JSession();
                    sessionOut.jSession.Sessions = jSessionWebResponse.Sessions;
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

            return jSessionWebResponse;
        }
    }
}
