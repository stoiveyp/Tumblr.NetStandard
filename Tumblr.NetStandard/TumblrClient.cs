using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;
using Tumblr.NetStandard.OAuth;

namespace Tumblr.NetStandard
{
    public class TumblrClient : ITumblrClient
    {
        private TumblrClientDetail ClientDetail { get; }

        public Action<string> OnError { get; set; }

        public TumblrClient(TumblrClientCredentials client) : this(null, client)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials client) : this(handler, client,
            null)
        {

        }

        public TumblrClient(TumblrClientCredentials client, TumblrCredentials token) : this(null, client, token)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials client, TumblrCredentials token)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            ClientDetail = new TumblrClientDetail
            {
                ClientCreds = client
            };


            if (string.IsNullOrWhiteSpace(token?.Key) || string.IsNullOrWhiteSpace(token?.Secret))
            {
                ClientDetail.UseApiKey = true;
            }
            else
            {
                ClientDetail.AccessToken = new AccessToken(token.Key, token.Secret);
            }

            var oAuthMessageHandler = handler == null
                ? new OAuthMessageHandler(client, ClientDetail.AccessToken)
                : new OAuthMessageHandler(handler, client, ClientDetail.AccessToken);
            ClientDetail.Client = new HttpClient(oAuthMessageHandler);
            ClientDetail.OnError = HandleError;
        }

        private ITumblrUserMethods _user;
        public ITumblrUserMethods User => _user ?? (_user = new TumblrUserMethods(ClientDetail));

        public ITumblrBlogMethods ForBlog(string blogName)
        {
            return new TumblrBlogMethods(blogName, ClientDetail);
        }

        public ITumblrPostMethods ForPost(ulong id, string reblogKey)
        {
            return new TumblrPostMethods(id, reblogKey, ClientDetail);
        }

        public ITumblrPostMethods ForPost(Post post)
        {
            return ForPost(post.Id, post.ReblogKey);
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
