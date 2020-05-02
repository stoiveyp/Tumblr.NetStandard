﻿using Newtonsoft.Json;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard.Posts
{
    public class AnswerPost:Post
    {
        public const string PostType = "answer";
        [JsonProperty("type")] public override string Type => PostType;

        [JsonProperty("asking_name")]
        public string AskingName { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}
