﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YogaFrameWebAdapter.CharactersJsonTypes;

namespace YogaFrameWebAdapter.CharactersJsonTypes
{

    public class TblCharacter
    {

        [JsonProperty("idtbl_Characters")]
        public string IdtblCharacters { get; set; }

        [JsonProperty("colName")]
        public string ColName { get; set; }

        [JsonProperty("colDescription")]
        public string ColDescription { get; set; }

        [JsonProperty("idtblGames")]
        public string IdtblGames { get; set; }
    }

}

namespace YogaFrameWebAdapter
{

    public class Characters
    {

        [JsonProperty("tbl_Characters")]
        public TblCharacter[] TblCharacters { get; set; }
    }

}
