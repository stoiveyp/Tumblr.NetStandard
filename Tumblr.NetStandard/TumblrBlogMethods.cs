using System;
using System.Threading.Tasks;
using Tumblr.NetStandard.Api;

namespace Tumblr.NetStandard
{
    internal class TumblrBlogMethods : ITumblrBlogMethods
    {
        private string BlogName { get; }
        private TumblrClientDetail ClientDetail { get; }

        public TumblrBlogMethods(string blogName, TumblrClientDetail clientDetail)
        {
            BlogName = blogName;
            ClientDetail = clientDetail;
        }

        public Task<ApiResponse<BlogPostResult>> Posts()
        {
            var uri = ClientDetail.CreateUri(ApiPath(BlogName, BlogApiPart.Posts), ClientDetail.StandardPostDictionary);
            return ClientDetail.MakeGetRequest<BlogPostResult>(uri);
        }

        public Task<ApiResponse<BlogPostResult>> Posts(int offset, int pageSize)
        {
            var posts = ClientDetail.StandardPostDictionary;

            posts.Add(nameof(offset), offset.ToString());
            posts.Add("limit", pageSize.ToString());

            var uri = ClientDetail.CreateUri(ApiPath(BlogName, BlogApiPart.Posts), posts);
            return ClientDetail.MakeGetRequest<BlogPostResult>(uri);
        }

        private string ApiPath(string candidate, BlogApiPart blogPart)
        {
            return $"blog/{candidate}{(!candidate.Contains(".") ? ".tumblr.com" : string.Empty)}/{TranslatePart(blogPart)}";
        }

        private string TranslatePart(BlogApiPart part)
        {
            return part switch
            {
                BlogApiPart.Posts => "posts",
                BlogApiPart.Avatar => "avatar",
                _ => "info"
            };
        }
    }
}
