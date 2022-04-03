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

        private ITumblrUserMethods _user;
        public ITumblrUserMethods User => _user ??= new TumblrUserMethods(ClientDetail);

        public TumblrClient(TumblrClientCredentials client) : this(null, client)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials client) : this(handler, client,
            null)
        {

        }

        public TumblrClient(TumblrClientCredentials client, TumblrBaseCredentials token) : this(null, client, token)
        {

        }

        public TumblrClient(HttpMessageHandler handler, TumblrClientCredentials client, TumblrBaseCredentials token)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            ClientDetail = new TumblrClientDetail
            {
                ClientCreds = client
            };

            if (token != null)
            {
                handler = token.Setup(ClientDetail, client, handler);
            }
            else
            {
                ClientDetail.UseApiKey = true;
            }

            ClientDetail.Client = handler == null ? new HttpClient() : new HttpClient(handler);
            ClientDetail.OnError = HandleError;
        }

        public ITumblrBlogMethods ForBlog(string blogName)
        {
            return new TumblrBlogMethods(blogName, ClientDetail);
        }

        public ITumblrPostMethods ForPost(Post post)
        {
            return new TumblrPostMethods(post, ClientDetail);
        }

        private void HandleError(string message)
        {
            OnError?.Invoke(message);
        }

        public Task<ApiResponse<Post[]>> Tagged(string tag)
        {
            var uri = ClientDetail.CreateUri("tagged", new Dictionary<string, string> { { "tag", tag } }.AddNpf(ClientDetail));
            return ClientDetail.MakeGetRequest<Post[]>(uri);
        }

        public bool ReturnNpfPostLists {
            get => ClientDetail.UseNpf;
            set => ClientDetail.UseNpf = value;
        }
    }
}
