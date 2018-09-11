﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tumblr.NetStandard.Models;

namespace Tumblr.NetStandard
{
    public class TumblrPostMethods:ITumblrPostMethods
    {
        private long PostId { get; }
        private string ReblogKey { get; }
        private TumblrClientDetail ClientDetail { get; }

        public TumblrPostMethods(long postId, string reblogKey, TumblrClientDetail clientDetail)
        {
            PostId = postId;
            ReblogKey = reblogKey;
            ClientDetail = clientDetail;
        }

        public Task<ApiResponse<bool>> Like()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "id", PostId.ToString() }, { "reblog_key", ReblogKey } };

            var uri = ClientDetail.CreateUri(ApiPath(UserApiPart.Like));
            return ClientDetail.MakeStatusPost(uri, dictionary, HttpStatusCode.OK);
        }

        public Task<ApiResponse<bool>> Unlike()
        {
            if (ClientDetail.UseApiKey)
            {
                return Task.FromResult(ClientDetail.HandleNotLoggedIn<bool>());
            }

            var dictionary = new Dictionary<string, string> { { "id", PostId.ToString() }, { "reblog_key", ReblogKey } };

            var uri = ClientDetail.CreateUri(ApiPath(UserApiPart.Unlike));
            return ClientDetail.MakeStatusPost(uri, dictionary, HttpStatusCode.OK);
        }

        private string ApiPath(UserApiPart blogPart)
        {
            return $"user/{TranslatePart(blogPart)}";
        }

        private string TranslatePart(UserApiPart part)
        {
            switch (part)
            {
                case UserApiPart.Dashboard:
                    return "dashboard";
                case UserApiPart.Likes:
                    return "likes";
                case UserApiPart.Following:
                    return "following";
                case UserApiPart.Like:
                    return "like";
                case UserApiPart.Unlike:
                    return "unlike";
                default:
                    return "info";
            }
        }
    }
}
