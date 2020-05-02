using System.Collections.Generic;

namespace Tumblr.NetStandard
{
    public static class NpfExtensions
    {
        public static Dictionary<string, string> AddNpf(this Dictionary<string, string> query, TumblrClientDetail detail)
        {
            if (detail.UseNpf)
            {
                query.Add("npf",true.ToString().ToLower());
            }
            return query;
        }
    }
}