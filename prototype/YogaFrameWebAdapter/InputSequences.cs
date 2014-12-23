﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YogaFrameWebAdapter.InputSequencesJsonTypes;

namespace YogaFrameWebAdapter.InputSequencesJsonTypes
{

    public class TblSequence
    {

        [JsonProperty("idtbl_InputSequences")]
        public string IdtblInputSequences { get; set; }

        [JsonProperty("idtblMoves")]
        public string IdtblMoves { get; set; }

        [JsonProperty("idtblDapplers")]
        public string IdtblDapplers { get; set; }
    }

}

namespace YogaFrameWebAdapter
{

    public class InputSequences
    {

        [JsonProperty("tbl_Sequences")]
        public TblSequence[] TblSequences { get; set; }
    }

}
