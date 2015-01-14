﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.JSessionJsonTypes;

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
            return null;
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
                        jSessionWebResponse = HelperJson.JsonDeserialize9(strJsonWebResponse);
                        if (null == jSessionWebResponse || null == jSessionWebResponse.Dispatch)
                        {
                            Dispatch dispatch = new Dispatch();
                            dispatch.Message = "LOCAL: WebPostJSession: JsonDeserialize9() failed. Server returned malformed JSON payload.";
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

        public static void CallPhpScriptMulti()
        {
            const string uriGetCharacters = "https://www.yogaframe.net/YogaFrame/GetCharacters.php";
            const string uriGetGames = "https://www.yogaframe.net/YogaFrame/GetGames.php";

            string serializedGetCharacters = WebAdapter.CallPhpScriptSingle(uriGetCharacters);
            string serializedGetGames = WebAdapter.CallPhpScriptSingle(uriGetGames);

            YogaFrameWebAdapter.Characters characters = HelperJson.JsonDeserialize1(serializedGetCharacters);
            YogaFrameWebAdapter.Games games = HelperJson.JsonDeserialize2(serializedGetGames);
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
