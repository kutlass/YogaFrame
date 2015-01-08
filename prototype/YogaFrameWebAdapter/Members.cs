﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YogaFrameWebAdapter.MembersJsonTypes;

namespace YogaFrameWebAdapter.MembersJsonTypes
{

    public class TblMember
    {

        [JsonProperty("IdtblMembers")]
        public string IdtblMembers { get; set; }

        [JsonProperty("ColNameAlias")]
        public string ColNameAlias { get; set; }

        [JsonProperty("ColNameFirst")]
        public string ColNameFirst { get; set; }

        [JsonProperty("ColNameLast")]
        public string ColNameLast { get; set; }

        [JsonProperty("ColEmailAddress")]
        public string ColEmailAddress { get; set; }

        [JsonProperty("ColIsEmailVerified")]
        public string ColIsEmailVerified { get; set; }

        [JsonProperty("ColPasswordSaltHash")]
        public string ColPasswordSaltHash { get; set; }

        [JsonProperty("ColBio")]
        public string ColBio { get; set; }

        [JsonProperty("ColDtMemberSince")]
        public string ColDtMemberSince { get; set; }
    }

}

namespace YogaFrameWebAdapter
{

    public class Members
    {
        [JsonProperty("TblMembers")]
        public TblMember[] TblMembers { get; set; }
    }

}
