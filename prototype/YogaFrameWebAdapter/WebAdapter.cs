using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.DapplersJsonTypes;
using YogaFrameWebAdapter.TemplateEmailsJsonTypes;

namespace YogaFrameWebAdapter
{
    public static class WebAdapter
    {
        //
        // Methods prefixed with "_WebGet" signify any over-the-wire transaction
        //
        private static List<Dapple> _WebGetDapples()
        {
            // TODO: Return List<Dapple>() from TestData.cs
            return new List<Dapple>();
        }

        //
        // A series of pseudo methods for now:
        //
        public static void Initialize()
        {
            WebGetGames();
            WebGetCharacters();
            WebGetMoves();
            WebGetInputSchema();
            WebGetInputSequences();
        }
        public static JSession WebGetGames()
        {
            JSession jSessionWebResponse = null;
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_GAME_GETGAMES";
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebGetCharacters()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_CHARACTER_GETCHARACTERS";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebGetDapplers()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_DAPPLER_GETDAPPLERS";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebGetMembers()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_MEMBER_GETMEMBERS";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebGetMoves()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_MOVE_GETMOVES";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static InputSchema WebGetInputSchema()
        {
            // TODO: Implement WebGetInputSchema API
            return null;
        }
        public static JSession WebGetPulses()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_PULSE_GETPULSES";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebGetTemplateEmails()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_EMAIL_GETTEMPLATEEMAILS";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebGetInputSequences()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_INPUTSEQUENCE_GETINPUTSEQUENCES";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebGetSessions()
        {
            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            jSessionWebRequest.Dispatch.Message = "GETREQUEST_SESSION_GETSESSIONS";
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static QuorumCriteria WebGetQuorumCriteria()
        {
            return null;
        }

        //
        // POST methods - database WRITE related operations
        //
        public static JSession WebPostGame(ref Games games)
        {
            JSession jSessionWebResponse = null;
            if (null == games || null == games.TblGames)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_GAME_POSTGAME_RAW_PASSTHROUGH = "POSTREQUEST_GAME_POSTGAME_RAW_PASSTHROUGH";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_GAME_POSTGAME_RAW_PASSTHROUGH;
            jSessionWebRequest.Games = games;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebPostCharacter(ref Characters characters)
        {
            JSession jSessionWebResponse = null;
            if (null == characters || null == characters.TblCharacters)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_CHARACTER_POSTCHARACTER_RAW_PASSTHROUGH = "POSTREQUEST_CHARACTER_POSTCHARACTER_RAW_PASSTHROUGH";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_CHARACTER_POSTCHARACTER_RAW_PASSTHROUGH;
            jSessionWebRequest.Characters = characters;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebPostDappler(ref Dapplers dapplers)
        {
            JSession jSessionWebResponse = null;
            if (null == dapplers || null == dapplers.TblDapplers)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_DAPPLER_POSTDAPPLER_RAW_PASSTHROUGH = "POSTREQUEST_DAPPLER_POSTDAPPLER_RAW_PASSTHROUGH";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_DAPPLER_POSTDAPPLER_RAW_PASSTHROUGH;
            jSessionWebRequest.Dapplers = dapplers;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebPostInputSequence(ref InputSequences inputSequences)
        {
            JSession jSessionWebResponse = null;
            if (null == inputSequences || null == inputSequences.TblInputSequences)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_INPUTSEQUENCE_POSTINPUTSEQUENCE_RAW_PASSTHROUGH = "POSTREQUEST_INPUTSEQUENCE_POSTINPUTSEQUENCE_RAW_PASSTHROUGH";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_INPUTSEQUENCE_POSTINPUTSEQUENCE_RAW_PASSTHROUGH;
            jSessionWebRequest.InputSequences = inputSequences;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebPostMove(ref Moves moves)
        {
            JSession jSessionWebResponse = null;
            if (null == moves || null == moves.TblMoves)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_MOVE_POSTMOVE_RAW_PASSTHROUGH = "POSTREQUEST_MOVE_POSTMOVE_RAW_PASSTHROUGH";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_MOVE_POSTMOVE_RAW_PASSTHROUGH;
            jSessionWebRequest.Moves = moves;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebPostPulse(ref Pulses pulses)
        {
            JSession jSessionWebResponse = null;
            if (null == pulses || null == pulses.TblPulses)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_MOVE_POSTPULSE_RAW_PASSTHROUGH = "POSTREQUEST_PULSE_POSTPULSE_RAW_PASSTHROUGH";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_MOVE_POSTPULSE_RAW_PASSTHROUGH;
            jSessionWebRequest.Pulses = pulses;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession UpdateMemberAccountVerificationStatus(ref Members members)
        {
            JSession jSessionWebResponse = null;
            if (null == members || null == members.TblMembers)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string UPDATEREQUEST_MEMBER_UPDATEMEMBERACCOUNTVERIFICATIONSTATUS = "UPDATEREQUEST_MEMBER_UPDATEMEMBERACCOUNTVERIFICATIONSTATUS";
            jSessionWebRequest.Dispatch.Message = UPDATEREQUEST_MEMBER_UPDATEMEMBERACCOUNTVERIFICATIONSTATUS;
            jSessionWebRequest.Members = members;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebPostTemplateEmail(ref TemplateEmails templateEmails)
        {
            JSession jSessionWebResponse = null;
            if (null == templateEmails || null == templateEmails.TblTemplateEmails)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_EMAIL_POSTTEMPLATEEMAIL_RAW_PASSTHROUGH = "POSTREQUEST_EMAIL_POSTTEMPLATEEMAIL_RAW_PASSTHROUGH";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_EMAIL_POSTTEMPLATEEMAIL_RAW_PASSTHROUGH;
            jSessionWebRequest.TemplateEmails = templateEmails;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebSendEmailVerification(ref Members members)
        {
            JSession jSessionWebResponse = null;
            if (null == members || null == members.TblMembers)
            {
                jSessionWebResponse = null;
                throw new ArgumentException();
            }

            //
            // Fetch the "Verify your email address" email template from
            // the web service. We'll use this data as the template for
            // constructing the format and content of the member verification email.
            //
            JSession jSessionWebResponseWebGetTemplateEmails = null;
            jSessionWebResponseWebGetTemplateEmails = WebAdapter.WebGetTemplateEmails();
            if (null != jSessionWebResponseWebGetTemplateEmails)
            {
                if ("S_OK" == jSessionWebResponseWebGetTemplateEmails.Dispatch.Message)
                {
                    //
                    // Construct user-specific hyperlink for account activation
                    //
                    string strGuid = Guid.NewGuid().ToString();
                    string strUriAccountActivation =
                        "https://www.yogaframe.net/YogaFrame/ActivateAccount.php" + 
                        "?memberId="                                              + // param1 name
                        members.TblMembers[0].IdtblMembers                        + // param1 value
                        "&guid="                                                  + // param2 name
                        strGuid;                                                    // param2 value

                    //
                    // Call API: UpdateMemberAccountVerificationStatus 
                    // This API requires us to provide business logic for the following member fields:
                    //  - ColEmailVerificationGuid
                    //  - ColEmailVerificationGuidCreationDate
                    //  - ColIsEmailVerified
                    //
                    members.TblMembers[0].ColEmailVerificationGuid = strGuid;
                    members.TblMembers[0].ColEmailVerificationGuidCreationDate = DateTime.UtcNow.ToString();
                    members.TblMembers[0].ColIsEmailVerified = false.ToString();
                    JSession jSessionWebResponseUpdateMemberAccountVerificationStatus = null;
                    jSessionWebResponseUpdateMemberAccountVerificationStatus = WebAdapter.UpdateMemberAccountVerificationStatus(ref members);
                    if ("S_OK" == jSessionWebResponseUpdateMemberAccountVerificationStatus.Dispatch.Message)
                    {
                        //
                        // Parse (ie post-process) the template email document into user-specific
                        // values. Example: <UserName>, <HyperlinkForActivation>, etc
                        //
                        TblTemplateEmail preProcessed = jSessionWebResponseWebGetTemplateEmails.TemplateEmails.TblTemplateEmails[0];
                        TblTemplateEmail postProcessed = new TblTemplateEmail();
                        postProcessed.ColHeaders = preProcessed.ColHeaders; // ColHeaders remains unchanged
                        postProcessed.ColSubject = preProcessed.ColSubject; // ColSubject remains unchanged
                        postProcessed.ColMessage = preProcessed.ColMessage.Replace("<username>", members.TblMembers[0].ColNameAlias);
                        postProcessed.ColMessage = postProcessed.ColMessage.Replace("<HyperLinkForActivation>", strUriAccountActivation);
                        jSessionWebResponseWebGetTemplateEmails.TemplateEmails.TblTemplateEmails[0] = postProcessed;

                        //
                        // Finally, our template email is formatted and catored to
                        // the user at hand. We now send the packet to the server:
                        //
                        JSession jSessionWebRequest = new JSession();
                        jSessionWebRequest.Dispatch = new Dispatch();
                        const string UPDATEREQUEST_MEMBER_SEND_EMAIL_VERIFICATION = "UPDATEREQUEST_MEMBER_SEND_EMAIL_VERIFICATION";
                        jSessionWebRequest.Dispatch.Message = UPDATEREQUEST_MEMBER_SEND_EMAIL_VERIFICATION;
                        jSessionWebRequest.Members = members;
                        jSessionWebRequest.TemplateEmails = jSessionWebResponseWebGetTemplateEmails.TemplateEmails;

                        jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);
                    }
                }
            }

            return jSessionWebResponse;
        }
        public static JSession WebUpdateMemberProfile(ref Members members)
        {
            JSession jSessionWebResponse = null;
            if (null == members || null == members.TblMembers)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string UPDATEREQUEST_MEMBER_UPDATEPROFILE = "UPDATEREQUEST_MEMBER_UPDATEPROFILE";
            jSessionWebRequest.Dispatch.Message = UPDATEREQUEST_MEMBER_UPDATEPROFILE;
            jSessionWebRequest.Members = members;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebSessionMemberSignIn(ref Members members)
        {
            JSession jSessionWebResponse = null;
            if (null == members || null == members.TblMembers)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_MEMBER_SIGN_IN = "POSTREQUEST_MEMBER_SIGN_IN";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_MEMBER_SIGN_IN;
            jSessionWebRequest.Members = members;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebSessionCreateSession(ref Sessions sessions)
        {
            JSession jSessionWebResponse = null;
            if (null == sessions || null == sessions.TblSessions)
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_SESSION_CREATESESSION = "POSTREQUEST_SESSION_CREATESESSION";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_SESSION_CREATESESSION;
            jSessionWebRequest.Sessions = sessions;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebSessionPostCharacter(ref Characters characters, ref Cache cache)
        {
            JSession jSessionWebResponse = null;

            if (null == characters ||
                null == characters.TblCharacters ||
                null == cache ||
                null == cache.Sessions ||
                null == cache.Sessions.TblSessions
                )
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            //
            // Fill in the Dappler data for the character being posted
            //
            TblDappler tblDappler = new TblDappler();
            tblDappler.ColDapplerState = "SEEDED";
            tblDappler.ColtblParentTableName = "tbl_Characters";
            tblDappler.IdtblMembers = cache.Sessions.TblSessions[0].IdtblMembers;
            Dapplers dapplers = new Dapplers();
            dapplers.TblDapplers = new TblDappler[1];
            dapplers.TblDapplers[0] = tblDappler;

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_SESSION_POSTCHARACTER = "POSTREQUEST_SESSION_POSTCHARACTER";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_SESSION_POSTCHARACTER;
            jSessionWebRequest.Sessions = cache.Sessions;
            jSessionWebRequest.Characters = characters;
            jSessionWebRequest.Dapplers = dapplers;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebSessionPostGame(ref Games games, ref Cache cache)
        {
            JSession jSessionWebResponse = null;

            if (null == games ||
                null == games.TblGames ||
                null == cache ||
                null == cache.Sessions ||
                null == cache.Sessions.TblSessions
                )
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            //
            // Fill in the Dappler data for the game being posted
            //
            TblDappler tblDappler = new TblDappler();
            tblDappler.ColDapplerState = "SEEDED";
            tblDappler.ColtblParentTableName = "tbl_Games";
            tblDappler.IdtblMembers = cache.Sessions.TblSessions[0].IdtblMembers;
            Dapplers dapplers = new Dapplers();
            dapplers.TblDapplers = new TblDappler[1];
            dapplers.TblDapplers[0] = tblDappler;

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_SESSION_POSTGAME = "POSTREQUEST_SESSION_POSTGAME";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_SESSION_POSTGAME;
            jSessionWebRequest.Sessions = cache.Sessions;
            jSessionWebRequest.Games = games;
            jSessionWebRequest.Dapplers = dapplers;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);
     
            return jSessionWebResponse;
        }
        public static JSession WebSessionPostMove(ref Moves moves, ref Cache cache)
        {
            JSession jSessionWebResponse = null;
            if (null == moves ||
                null == moves.TblMoves ||
                null == cache ||
                null == cache.Sessions ||
                null == cache.Sessions.TblSessions
                )
            {
                jSessionWebResponse = null;
                throw new ArgumentNullException();
            }

            //
            // Fill in the Dappler data for the move being posted
            //
            TblDappler tblDappler = new TblDappler();
            tblDappler.ColDapplerState = "SEEDED";
            tblDappler.ColtblParentTableName = "tbl_Moves";
            tblDappler.IdtblMembers = cache.Sessions.TblSessions[0].IdtblMembers;
            Dapplers dapplers = new Dapplers();
            dapplers.TblDapplers = new TblDappler[1];
            dapplers.TblDapplers[0] = tblDappler;

            JSession jSessionWebRequest = new JSession();
            jSessionWebRequest.Dispatch = new Dispatch();
            const string POSTREQUEST_SESSION_POSTMOVE = "POSTREQUEST_SESSION_POSTMOVE";
            jSessionWebRequest.Dispatch.Message = POSTREQUEST_SESSION_POSTMOVE;
            jSessionWebRequest.Sessions = cache.Sessions;
            jSessionWebRequest.Moves = moves;
            jSessionWebRequest.Dapplers = dapplers;

            jSessionWebResponse = WebAdapter.WebPostJSession(ref jSessionWebRequest);

            return jSessionWebResponse;
        }
        public static JSession WebPostJSession(ref JSession jSession)
        {
            if (null == jSession)
            {
                throw new ArgumentNullException();
            }

            //
            // - Serialize the JSession object into a JSON-encoded string
            // - Pass said string as postData to our _SendPost() HTTP POST helper
            // - Return server response to the caller
            //
            JSession jSessionWebResponse = null;
            string strSerializedJsonFromObject = string.Empty;
            string strJsonWebResponse = string.Empty;
            strSerializedJsonFromObject = HelperJson.JsonSerialize(jSession);
            if (string.Empty != strSerializedJsonFromObject)
            {
                const string strUriJSession = "https://www.yogaframe.net/YogaFrame/Session.php";
                strJsonWebResponse = WebAdapter._SendPost(strUriJSession, strSerializedJsonFromObject);
                if (string.Empty != strJsonWebResponse)
                {
                    try
                    {
                        jSessionWebResponse = HelperJson.JsonDeserialize(strJsonWebResponse);
                        if (null == jSessionWebResponse || null == jSessionWebResponse.Dispatch)
                        {
                            Dispatch dispatch = new Dispatch();
                            dispatch.Message = "LOCAL: WebPostJSession: JsonDeserialize() failed. Server returned malformed JSON payload.";
                            jSessionWebResponse = new JSession();
                            jSessionWebResponse.Dispatch = dispatch;
                        }
                    }
                    catch (Newtonsoft.Json.JsonReaderException)
                    {
                        string strMalformedJsonResponse = strJsonWebResponse;
                        Dispatch dispatch = new Dispatch();
                        dispatch.Message = "LOCAL: WebPostJSession: Malformed JSON recieved. Raw string: " + strMalformedJsonResponse;
                        jSessionWebResponse = new JSession();
                        jSessionWebResponse.Dispatch = dispatch;
                    }
                }
                else
                {
                    Dispatch dispatch = new Dispatch();
                    dispatch.Message = "LOCAL: WebPostJSession: _SendPost() returned an empty web response. Likely a PHP marshalling bug.";
                    jSessionWebResponse = new JSession();
                    jSessionWebResponse.Dispatch = dispatch;
                }
            }
            else
            {
                Dispatch dispatch = new Dispatch();
                dispatch.Message = "LOCAL: WebPostJSession: HelperJson.JsonSerialize(jSession) returned at empty string.";
                jSessionWebResponse = new JSession();
                jSessionWebResponse.Dispatch = dispatch;
            }

            return jSessionWebResponse;
        }
        public static InputSchema WebPostInputSchema()
        {
            return null;
        }
        public static QuorumCriteria WebPostQuorumCriteria()
        {
            return null;
        }
        //
        // Test - Calling PHP script from .NET client WebRequest
        //
        public static string CallPhpScriptSingle(string URI)
        {
            Trace.WriteLine("CallPhpScriptSingle: Attempting WebRequest to " + URI);
            WebRequest webRequest = WebRequest.Create(URI);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = "GET";
            string strJsonResponse = string.Empty;
            try
            {
                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                strJsonResponse = streamReader.ReadToEnd();
                Trace.WriteLine("CallPhpScriptSingle: OUTPUT from streamReader.ReadToEnd(): " + strJsonResponse);

                streamReader.Close();
                webResponse.Close();
            }
            catch (WebException webException)
            {
                Trace.WriteLine("CallPhpScriptSingle.WebException.Message: " + webException.Message);
                Trace.WriteLine("CallPhpScriptSingle.WebException.Response: " + webException.Response);
            }

            return strJsonResponse;
        }
        private static string _SendPost(string strUri, string strPostData)
        {
            if (string.IsNullOrEmpty(strUri) || string.IsNullOrEmpty(strPostData))
            {
                throw new ArgumentNullException();
            }

            string strHttpWebRequestResponse = string.Empty;
            string strPostDataHttpEncoded = "json=" + HttpUtility.UrlEncode(strPostData);
            try
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(strPostDataHttpEncoded);

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strUri);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";                
                httpWebRequest.ContentLength = byteArray.Length;

                using (Stream webpageStream = httpWebRequest.GetRequestStream())
                {
                    webpageStream.Write(byteArray, 0, byteArray.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        strHttpWebRequestResponse = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException webException)
            {
                // throw or return an appropriate response/exception
                Trace.WriteLine("SendPost: WebException: " + webException.Message);
            }

            return strHttpWebRequestResponse;
        }
    }
}
