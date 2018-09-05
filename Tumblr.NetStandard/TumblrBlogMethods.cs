using System.Threading.Tasks;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.CallResult;

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

        private string ApiPath(string candidate, BlogApiPart blogPart)
        {
            return $"blog/{candidate}{(!candidate.Contains(".") ? ".tumblr.com" : string.Empty)}/{TranslatePart(blogPart)}";
        }

        private string TranslatePart(BlogApiPart part)
        {
            switch (part)
            {
                case BlogApiPart.Posts:
                    return "posts";
                default:
                    return "info";
            }
        }
    }
}
