﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YogaFrameWebAdapter.MovesJsonTypes;

namespace YogaFrameWebAdapter.MovesJsonTypes
{

    public class TblMove
    {

        [JsonProperty("idtbl_Moves")]
        public string IdtblMoves { get; set; }

        [JsonProperty("colName")]
        public string ColName { get; set; }

        [JsonProperty("idtblDapplers")]
        public string IdtblDapplers { get; set; }
    }

}

namespace YogaFrameWebAdapter
{

    public class Moves
    {

        [JsonProperty("tbl_Moves")]
        public TblMove[] TblMoves { get; set; }
    }

}