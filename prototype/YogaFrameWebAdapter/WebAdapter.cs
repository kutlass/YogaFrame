using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using YogaFrameWebAdapter.Session;

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
            WebGetInputSequence();
        }
        public static Games WebGetGames()
        {
            const string uriGetGames = "https://www.yogaframe.net/YogaFrame/GetGames.php";

            //
            // Method returns null on failure, or a valid Games object on success
            //
            string serializedGetGames = string.Empty;
            Games games = null;
            serializedGetGames = WebAdapter.CallPhpScriptSingle(uriGetGames);
            if (string.Empty != serializedGetGames)
            {
                games = HelperJson.JsonDeserialize2(serializedGetGames);
            }

            return games;
        }
        public static Characters WebGetCharacters()
        {
            const string uriGetCharacters = "https://www.yogaframe.net/YogaFrame/GetCharacters.php";

            //
            // Method returns null on failure, or a valid Characters object on success
            //
            string serializedGetCharacters = string.Empty;
            Characters characters = null;
            serializedGetCharacters = WebAdapter.CallPhpScriptSingle(uriGetCharacters);
            if (string.Empty != serializedGetCharacters)
            {
                characters = HelperJson.JsonDeserialize1(serializedGetCharacters);
            }

            return characters;
        }
        public static Dapplers WebGetDapplers()
        {
            const string strUriGetDapplers = "https://www.yogaframe.net/YogaFrame/GetDapplers.php";

            //
            // Method returns null on failure, or a valid Dapplers object on success
            //
            string strSerializedGetDapplers = string.Empty;
            Dapplers dapplers = null;
            strSerializedGetDapplers = WebAdapter.CallPhpScriptSingle(strUriGetDapplers);
            if (string.Empty != strSerializedGetDapplers)
            {
                dapplers = HelperJson.JsonDeserialize3(strSerializedGetDapplers);
            }

            return dapplers;
        }
        public static Members WebGetMembers()
        {
            // TODO: Implement WebGetMembers API
            return null;
        }
        public static Move WebGetMoves()
        {
            return new Move(null, null); // TODO: Add real params
        }
        public static InputSchema WebGetInputSchema()
        {            
            return null;
        }
        public static InputSequence WebGetInputSequence()
        {
            return null;
        }

        public static QuorumCriteria WebGetQuorumCriteria()
        {
            return null;
        }

        //
        // POST methods - database WRITE related operations
        //
        public static string WebPostGame(ref Games games)
        {
            //
            // - Serialize the Games object into a JSON-encoded string
            // - Pass said string as postData to our _SendPost() HTTP POST helper
            // - Return server response to the caller
            //
            string strSerializedJsonFromObject = string.Empty;
            string strJsonWebResponse = string.Empty;
            try
            {
                strSerializedJsonFromObject = HelperJson.JsonSerialize(games);
                if (string.Empty != strSerializedJsonFromObject)
                {
                    const string uriPostGame = "https://www.yogaframe.net/YogaFrame/PostGame.php";
                    strJsonWebResponse = WebAdapter._SendPost(uriPostGame, strSerializedJsonFromObject);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("WebPostGame: Exception occurred Exception.Message = " + ex.Message);
            }

            return strJsonWebResponse;
        }
        public static string WebPostCharacter(ref Characters characters)
        {
            //
            // - Serialize the Characters object into a JSON-encoded string
            // - Pass said string as postData to our _SendPost() HTTP POST helper
            // - Return server response to the caller
            //
            string strSerializedJsonFromObject = string.Empty;
            string strJsonWebResponse = string.Empty;
            try
            {
                strSerializedJsonFromObject = HelperJson.JsonSerialize(characters);
                if (string.Empty != strSerializedJsonFromObject)
                {
                    const string uriPostCharacter = "https://www.yogaframe.net/YogaFrame/PostCharacter.php";
                    strJsonWebResponse = WebAdapter._SendPost(uriPostCharacter, strSerializedJsonFromObject);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("WebPostCharacter: Exception occurred Exception.Message = " + ex.Message);
            }

            return strJsonWebResponse;
        }
        public static string WebPostDappler(ref Dapplers dapplers)
        {
            if (null == dapplers)
            {
                throw new ArgumentNullException();
            }
            //
            // - Serialize the Dapplers object into a JSON-encoded string
            // - Pass said string as postData to our _SendPost() HTTP POST helper
            // - Return server response to the caller
            //
            string strSerializedJsonFromObject = string.Empty;
            string strJsonWebResponse = string.Empty;                    
            strSerializedJsonFromObject = HelperJson.JsonSerialize(dapplers);
            if (string.Empty != strSerializedJsonFromObject)
            {
                const string strUriPostDappler = "https://www.yogaframe.net/YogaFrame/PostDappler.php";
                strJsonWebResponse = WebAdapter._SendPost(strUriPostDappler, strSerializedJsonFromObject);
            }
            
            return strJsonWebResponse;
        }
        public static string WebPostMember(ref Members members)
        {
            return string.Empty;
        }
        public static Move WebPostMoves()
        {
            return null;
        }
        public static InputSchema WebPostInputSchema()
        {
            return null;
        }
        public static InputSequence WebPostInputSequence()
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
