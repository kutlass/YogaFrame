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

        [JsonProperty("IdtblCharacters")]
        public string IdtblCharacters { get; set; }

        [JsonProperty("ColName")]
        public string ColName { get; set; }

        [JsonProperty("ColDescription")]
        public string ColDescription { get; set; }

        [JsonProperty("IdtblGames")]
        public string IdtblGames { get; set; }

        [JsonProperty("IdtblDapplers")]
        public string IdtblDapplers { get; set; }
    }

}

namespace YogaFrameWebAdapter
{

    public class Characters
    {

        [JsonProperty("TblCharacters")]
        public TblCharacter[] TblCharacters { get; set; }
    }

}
