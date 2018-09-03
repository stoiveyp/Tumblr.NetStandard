﻿using System;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models.PostRead
{
    public class VideoData
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("html5_enabled")]
        public bool IsHtml5 { get; set; }

        [JsonProperty("video_url")]
        public Uri VideoUrl { get; set; }

        [JsonProperty("permalink_url")]
        public Uri Permalink { get; set; }

        [JsonProperty("source_url")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("thumbnail_url")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnail_width")]
        public int ThumbnailWidth { get; set; }

        [JsonProperty("thumbnail_height")]
        public int ThumbnailHeight { get; set; }
    }
}