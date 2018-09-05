using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public class TumblrClient : ITumblrClient
    {
        private TumblrClientDetail ClientDetail { get; }

        public Action<string> OnError { get; set; }

        public TumblrClient(TumblrClientCredentials consumer) : this(null, consumer)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials consumer) : this(handler, consumer,
            null)
        {

        }

        public TumblrClient(TumblrClientCredentials consumer, TumblrCredentials token) : this(null, consumer, token)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials consumer, TumblrCredentials token)
        {
            AccessToken accessToken = null;
            ClientDetail = new TumblrClientDetail
            {
                ConsumerKey = consumer.Id,
            };


            if (string.IsNullOrWhiteSpace(token.Key) || string.IsNullOrWhiteSpace(token.Secret))
            {
                ClientDetail.UseApiKey = true;
            }
            else
            {
                ClientDetail.AccessToken = new AccessToken(token.Key, token.Secret);
            }

            var oAuthMessageHandler = handler == null
                ? new OAuthMessageHandler(consumer.Id, consumer.Secret, accessToken)
                : new OAuthMessageHandler(handler, consumer.Id, consumer.Secret, accessToken);
            ClientDetail.Client = new HttpClient(oAuthMessageHandler);
            ClientDetail.OnError = HandleError;
        }

        private ITumblrUserMethods _user;
        public ITumblrUserMethods User => _user ?? (_user = new TumblrUserMethods(ClientDetail));

        public ITumblrBlogMethods ForBlog(string blogName)
        {
            return new TumblrBlogMethods(blogName, ClientDetail);
        }

        public ITumblrPostMethods ForPost(long id, string reblogKey)
        {
            return new TumblrPostMethods(id, reblogKey, ClientDetail);
        }

        public ITumblrPostMethods ForPost(Post post)
        {
            return ForPost(post.Common.Id, post.Common.ReblogKey);
        }

        private void HandleError(string message)
        {
            OnError?.Invoke(message);
        }

        public Task<ApiResponse<Post[]>> Tagged(string tag)
        {
            var uri = ClientDetail.CreateUri("tagged", new Dictionary<string, string> { { "tag", tag } });
            return ClientDetail.MakeGetRequest<Post[]>(uri);
        }
    }
}
