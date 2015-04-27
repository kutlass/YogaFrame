using System;
using System.Collections.Generic;
using System.Diagnostics;
using YogaFrameWebAdapter.MembersJsonTypes;
using YogaFrameWebAdapter.SessionsJsonTypes;
using YogaFrameWebAdapter.JSessionJsonTypes;
using UnityEngine;

public class YogaFrameUnityAdapter : MonoBehaviour
{
    public YogaFrameWebAdapter.Session.Session YogaCreateInstance()
    {
        return YogaFrameWebAdapter.Session.Session.Instance;
    }

    public string GetInstance()
    {
        YogaFrameWebAdapter.Session.Session session = YogaFrameWebAdapter.Session.Session.Instance;

        return session.ConstructorMessage;
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
    public sealed class Session
    {
        static readonly Session m_instance = new Session();

        //
        // Constructor
        //
        private Session()
        {
            m_cache = new Cache();
            m_strConstructorMessage = "private Session() constructor successfully initialized.";
        }
        private string m_strConstructorMessage;

        public static Session Instance
        {
            get
            {
                return m_instance;
            }
        }

        public string ConstructorMessage
        {
            get
            {
                return m_strConstructorMessage;
            }
        }

        private JSession jSession;  // JSession = The uber pipe we'll be using to communicate with Session.php
        private Cache m_cache;      // Cache that will persist data containers fetched from web service (Games, Characters, etc)

        //
        // public properties
        //
        public Cache Cache
        {
            get { return m_cache; }
        }

        //
        // public Instance methods
        //
        public bool Initialize()
        {
            bool fResult = false;
            fResult = this.MemberGetGames();
            if (true == fResult)
            {
                fResult = this.MemberGetCharacters();
                if (true == fResult)
                {
                    fResult = this.MemberGetMoves();
                }
            }
            
            return fResult;
        }

        public bool MemberPostGame(ref Games games)
        {
            if (null == games)
            {
                throw new ArgumentNullException();
            }

            bool fResult = false;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebSessionPostGame(ref games, ref m_cache);
            const string S_OK = "S_OK";
            if (S_OK == jSessionWebResponse.Dispatch.Message)
            {
                //
                // TODO: We may need/want to store record of the POST in
                //       client side cache.
                //
                //       Figure this out prior to YogaFrame app release.
                //
                fResult = true;
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }

        public bool MemberGetGames()
        {
            bool fResult = false;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetGames();
            const string S_OK = "S_OK";
            if (S_OK == jSessionWebResponse.Dispatch.Message)
            {
                //
                // Fill the Games cache with data fetched from web service
                //
                m_cache.Games = jSessionWebResponse.Games;

                fResult = true;
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }

        public bool MemberPostCharacter(ref Characters characters)
        {
            if (null == characters)
            {
                throw new ArgumentNullException();
            }

            bool fResult = false;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebSessionPostCharacter(ref characters, ref m_cache);
            const string S_OK = "S_OK";
            if (S_OK == jSessionWebResponse.Dispatch.Message)
            {
                fResult = true;
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }

        public bool MemberGetCharacters()
        {
            bool fResult = false;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetCharacters();
            const string S_OK = "S_OK";
            if (S_OK == jSessionWebResponse.Dispatch.Message)
            {
                //
                // Fill the Characters cache with data fetched from web service
                //
                m_cache.Characters = jSessionWebResponse.Characters;
                fResult = true;
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }

        public bool MemberPostMove(ref Moves move)
        {
            bool fResult = false;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebSessionPostMove(ref move, ref m_cache);
            const string S_OK = "S_OK";
            if (S_OK == jSessionWebResponse.Dispatch.Message)
            {
                fResult = true;
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }

        public bool MemberUpdateProfile(string strNameFirst, string strEmail, string strBio)
        {
            bool fResult = false;
            if (null == Session.Instance.Cache.Members || null == Session.Instance.Cache.Members.TblMembers)
            {
                fResult = false;
                throw new InvalidOperationException();
            }

            //
            // Prepare the to-be-updated data, also
            // aggregate required Member info from the Cache.
            // We're expecting a "Signed in" state at this
            // point in the code (see above param validation).
            //
            TblMember tblMember = new TblMember();
            tblMember.ColNameFirst = strNameFirst;
            tblMember.ColEmailAddress = strEmail;
            tblMember.ColBio = strBio;
            tblMember.IdtblMembers = Session.Instance.Cache.Members.TblMembers[0].IdtblMembers;

            Members members = new Members();
            members.TblMembers = new TblMember[1];
            members.TblMembers[0] = tblMember;

            //
            // Make the appropriate WEB UPDATE call
            //
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebUpdateMemberProfile(ref members);
            const string S_OK = "S_OK";
            if (S_OK == jSessionWebResponse.Dispatch.Message)
            {
                //
                // Synchronize cache:
                // ------------------
                // If web UPDATE succeeds, also add the data
                // that we submitted to local client cache:
                //
                Session.Instance.Cache.Members.TblMembers[0].ColNameFirst    = members.TblMembers[0].ColNameFirst;
                Session.Instance.Cache.Members.TblMembers[0].ColEmailAddress = members.TblMembers[0].ColEmailAddress;
                Session.Instance.Cache.Members.TblMembers[0].ColBio          = members.TblMembers[0].ColBio;

                fResult = true;
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }

        public bool MemberGetMoves()
        {
            bool fResult = false;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebGetMoves();
            const string S_OK = "S_OK";
            if (S_OK == jSessionWebResponse.Dispatch.Message)
            {
                //
                // Fill the Moves cache with data fetched from the web service
                //
                m_cache.Moves = jSessionWebResponse.Moves;
                fResult = true;
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }

        public bool MemberGetPulses()
        {
            // TODO: Implement MemberGetPulses API
            bool fResult = false;

            return fResult;
        }

        public JSession MemberSignIn(
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
                    m_cache.Members = jSessionWebResponseWebSessionMemberSignIn.Members;
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
                            m_cache.Sessions = jSessionWebResponseWebCreateSession.Sessions;
                            jSessionWebResponseAggregate.Sessions = jSessionWebResponseWebCreateSession.Sessions;
                        }
                    }
                }
            }

            return jSessionWebResponseAggregate;
        }

        public JSession MemberSignUp(
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
                // CACHE operation:
                //-----------------
                // Only cache the session if the
                // the Member Signup request succeeded. We give
                // our callers NULL on failure, not garbage objects.
                //
                if ("S_OK" == jSessionWebResponse.Dispatch.Message)
                {
                    m_cache.Sessions = jSessionWebResponse.Sessions;
                    m_cache.Members = jSessionWebResponse.Members;
                }
                else
                {
                    m_cache.Sessions = null;
                    m_cache.Members = null;
                }
            }
            else
            {
                m_cache.Sessions = null;
                m_cache.Members = null;
            }

            return jSessionWebResponse;
        }
    }
}
