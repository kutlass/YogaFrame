﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

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
            return null;
        }
        public static Characters WebGetCharacters()
        {
            const string uriGetCharacters = "https://www.yogaframe.net/YogaFrame/GetCharacters.php";

            string serializedGetCharacters = WebAdapter.CallPhpScriptSingle(uriGetCharacters);

            Characters characters = HelperJson.JsonDeserialize1(serializedGetCharacters);

            return characters;
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
        public static Game WebPostGames()
        {
            return null;
        }
        public static Character WebPostCharacters()
        {
            List<Move> listMoves = new List<Move>();
            return new Character(null, listMoves);
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
    }
}
