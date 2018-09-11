
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tumblr.NetStandard.Models
{
    public abstract class Post: IAvatar
    {
        protected Post()
        {
            Common = new CommonPostData();
            Reblog = new ReblogPostData();
            Notes = new List<Note>();
        }

        public ReblogPostData Reblog { get; }

        public CommonPostData Common { get; }

        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        [JsonIgnore]
        public string BlogName => Common.BlogName;
    }

    public abstract class Post<T>:Post where T:new()
    {
        protected Post()
        {
            Data = new T();
        }

        public T Data { get; set; }
    }
}
