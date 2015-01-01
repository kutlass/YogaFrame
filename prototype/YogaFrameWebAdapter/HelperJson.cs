using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Diagnostics;
using YogaFrameWebAdapter.JSessionJsonTypes;

namespace YogaFrameWebAdapter
{
    public class HelperJson
    {
        public static string JsonSerialize(Characters characters)
        {
            if (null == characters)
            {
                throw new ArgumentNullException();
            }
            string strSerializedCharacters = String.Empty;
            strSerializedCharacters = JsonConvert.SerializeObject(characters);
            
            return strSerializedCharacters;
        }
        public static string JsonSerialize(Games games)
        {
            if (null == games)
            {
                throw new ArgumentNullException();
            }
            string strSerializedGames = String.Empty;
            strSerializedGames = JsonConvert.SerializeObject(games);

            return strSerializedGames;
        }
        public static string JsonSerialize(Dapplers dapplers)
        {
            if (null == dapplers)
            {
                throw new ArgumentNullException();
            }
            string strSerializedDapplers = String.Empty;
            strSerializedDapplers = JsonConvert.SerializeObject(dapplers);

            return strSerializedDapplers;
        }
        public static string JsonSerialize(InputSequences inputSequences)
        {
            if (null == inputSequences)
            {
                throw new ArgumentNullException();
            }
            string strSerializednpIutSequences = String.Empty;
            strSerializednpIutSequences = JsonConvert.SerializeObject(inputSequences);

            return strSerializednpIutSequences;
        }
        public static string JsonSerialize(Members members)
        {
            if (null == members)
            {
                throw new ArgumentNullException();
            }
            string strSerializedMembers = String.Empty;
            strSerializedMembers = JsonConvert.SerializeObject(members);

            return strSerializedMembers;
        }
        public static string JsonSerialize(Moves moves)
        {
            if (null == moves)
            {
                throw new ArgumentNullException();
            }
            string strSerializedMembers = String.Empty;
            strSerializedMembers = JsonConvert.SerializeObject(moves);

            return strSerializedMembers;
        }
        public static string JsonSerialize(Sessions sessions)
        {
            if (null == sessions)
            {
                throw new ArgumentNullException();
            }
            string strSerializedSessions = String.Empty;
            strSerializedSessions = JsonConvert.SerializeObject(sessions);

            return strSerializedSessions;
        }
        public static string JsonSerialize(JSession jSession)
        {
            if (null == jSession)
            {
                throw new ArgumentNullException();
            }
            string strSerializedJSession = String.Empty;
            strSerializedJSession = JsonConvert.SerializeObject(jSession);

            return strSerializedJSession;
        }
        public static Characters JsonDeserialize1(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            Characters characters = JsonConvert.DeserializeObject<Characters>(strJson);

            return characters;
        }
        public static Games JsonDeserialize2(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            Games games = JsonConvert.DeserializeObject<Games>(strJson);

            return games;
        }
        public static Dapplers JsonDeserialize3(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            Dapplers dapplers = JsonConvert.DeserializeObject<Dapplers>(strJson);

            return dapplers;
        }
        public static Members JsonDeserialize4(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            Members members = JsonConvert.DeserializeObject<Members>(strJson);

            return members;
        }
        public static Moves JsonDeserialize5(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            Moves moves = JsonConvert.DeserializeObject<Moves>(strJson);

            return moves;
        }
        public static InputSequences JsonDeserialize6(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            InputSequences inputSequences = JsonConvert.DeserializeObject<InputSequences>(strJson);

            return inputSequences;
        }
        public static Sessions JsonDeserialize7(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            Sessions sessions = JsonConvert.DeserializeObject<Sessions>(strJson);

            return sessions;
        }
        public static Dispatch JsonDeserialize8(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            Dispatch dispatch = JsonConvert.DeserializeObject<Dispatch>(strJson);

            return dispatch;
        }
        public static JSession JsonDeserialize9(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("HelperJson::JsonDeserialize9: Calling JsonConvert.DeserializeObject<JSession>...");
            JSession jSession = JsonConvert.DeserializeObject<JSession>(strJson);

            return jSession;
        }
    }
}
