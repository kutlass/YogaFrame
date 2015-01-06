﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YogaFrameWebAdapter.SessionsJsonTypes;

namespace YogaFrameWebAdapter.SessionsJsonTypes
{

    public class TblSession
    {

        [JsonProperty("idtbl_Sessions")]
        public string IdtblSessions { get; set; }

        [JsonProperty("guidSession")]
        public string GuidSession { get; set; }

        [JsonProperty("idtblMembers")]
        public string IdtblMembers { get; set; }

        [JsonProperty("dtLastHeartBeat")]
        public string DtLastHeartBeat { get; set; }
    }

}

namespace YogaFrameWebAdapter
{

    public class Sessions
    {
        [JsonProperty("tbl_Sessions")]
        public TblSession[] TblSessions { get; set; }
    }

}
