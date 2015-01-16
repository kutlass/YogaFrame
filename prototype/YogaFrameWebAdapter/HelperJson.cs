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
        public static JSession JsonDeserialize(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
            {
                throw new ArgumentNullException();
            }
            Trace.WriteLine("HelperJson::JsonDeserialize: Calling JsonConvert.DeserializeObject<JSession>...");
            JSession jSession = JsonConvert.DeserializeObject<JSession>(strJson);

            return jSession;
        }
    }
}
