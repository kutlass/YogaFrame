using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Diagnostics;

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
    }
}
