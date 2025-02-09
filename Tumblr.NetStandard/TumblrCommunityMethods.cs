using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    public class TumblrCommunityMethods: ITumblrCommunityMethods
    {
        //https://www.tumblr.com/docs/en/api/v2#put-v2communitiescommunity-handleinvitations---invite-someone-to-the-community
        public const string CommunityPathPrefix = "communities";

        private string Handle { get; }
        private TumblrClientDetail ClientDetail { get; }

        public TumblrCommunityMethods(string handle, TumblrClientDetail clientDetail)
        {
            Handle = handle;
            ClientDetail = clientDetail;
        }

        public Task<ApiResponse<Community[]>> Joined()
        {
            var uri = ClientDetail.CreateUri(CommunityPathPrefix);
            return ClientDetail.MakeGetRequest<Community[]>(uri);
        }
    }
}
