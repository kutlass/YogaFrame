﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YogaFrameWebAdapter.JSessionJsonTypes;

namespace YogaFrameWebAdapter.JSessionJsonTypes
{
    public class JSession
    {
        [JsonProperty("Dispatch")]
        public Dispatch Dispatch { get; set; }

        [JsonProperty("Dapplers")]
        public Dapplers Dapplers { get; set; }

        [JsonProperty("Characters")]
        public Characters Characters { get; set; }

        [JsonProperty("Games")]
        public Games Games { get; set; }

        [JsonProperty("InputSequences")]
        public InputSequences InputSequences { get; set; }

        [JsonProperty("Members")]
        public Members Members { get; set; }

        [JsonProperty("Moves")]
        public Moves Moves { get; set; }

        [JsonProperty("Sessions")]
        public Sessions Sessions { get; set; }
    }
}
