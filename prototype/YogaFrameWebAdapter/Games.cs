﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YogaFrameWebAdapter.GamesJsonTypes;

namespace YogaFrameWebAdapter.GamesJsonTypes
{

    public class TblGame
    {

        [JsonProperty("idtbl_Games")]
        public string IdtblGames { get; set; }

        [JsonProperty("colName")]
        public string ColName { get; set; }

        [JsonProperty("colDeveloper")]
        public string ColDeveloper { get; set; }

        [JsonProperty("colDeveloperURL")]
        public string ColDeveloperURL { get; set; }

        [JsonProperty("colPublisher")]
        public string ColPublisher { get; set; }

        [JsonProperty("colPublisherURL")]
        public string ColPublisherURL { get; set; }

        [JsonProperty("colDescription")]
        public string ColDescription { get; set; }
    }

}

namespace YogaFrameWebAdapter
{

    public class Games
    {

        [JsonProperty("tbl_Games")]
        public TblGame[] TblGames { get; set; }
    }

}
