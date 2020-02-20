using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.Models;
using Tumblr.NetStandard.Models.CallResult;
using Xunit;

namespace Tumblr.NetStandard.Tests
{
    public class PostTests
    {
        [Fact]
        public void BlogPostsResponse()
        {
            var response = Utility.ExampleFileContent<ApiResponse<BlogPostResult>>("BlogPostResponse.json");
            Assert.True(Utility.CompareJson(response, "BlogPostResponse.json"));
        }

        [Fact]
        public void ResponseLink()
        {
            var example = "BlogPostResponse_Legacy.json";
            var response = Utility.ExampleFileContent<ApiResponse<BlogPostResult>>(example);
            Assert.True(Utility.CompareJson(response, example, j => j["metadata"]));
            Assert.True(Utility.CompareJson(response, example, j => j["response"]["blog"]));
            Assert.True(Utility.CompareJson(response, example, j => j["response"]["total_posts"]));
            Assert.True(Utility.CompareJson(response, example, j => j["response"]["_links"]));
            var postsWork = Utility.CompareJson(response, example, j => j["response"]["posts"]);

            if (!postsWork)
            {
                var actualArray = JObject.Parse(JsonConvert.SerializeObject(response.Response)).Value<JArray>("posts");
                var expectedArray = JObject.Parse(Utility.ExampleFileContent(example))["response"].Value<JArray>("posts");

                if (actualArray.Count != expectedArray.Count)
                {
                    throw new InvalidOperationException("Bad counts");
                }

                var count = actualArray.Zip(expectedArray,(a,e) =>
                {
                    var result = JToken.DeepEquals(a,e);
                    if (!result)
                    {
                        Console.WriteLine(a.Value<string>("type"));
                    }

                    return result;
                }).Count(b => !b);
                Assert.Equal(0,count);
            }
        }
    }
}
