using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumblr.NetStandard.Api;
using Xunit;

namespace Tumblr.NetStandard.Tests
{
    public class PostTests
    {
        [Fact]
        public void Response()
        {
            var example = "BlogPostResponse.json";
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

                var count = actualArray.Cast<JObject>().Zip(expectedArray.Cast<JObject>(), CheckObjectArray).Count(b => b);
                Assert.Equal(20, count);
            }
        }

        [Fact]
        public void ResponseLegacy()
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

                var count = actualArray.Cast<JObject>().Zip(expectedArray.Cast<JObject>(), CheckObjectArray).Count(b => b);
                Assert.Equal(20, count);
            }
        }

        private bool CheckObjectArray(JObject aj, JObject ej)
        {
            if (aj.ContainsKey("date"))
            {
                aj.Remove("date");
            }

            if (ej.ContainsKey("date"))
            {
                ej.Remove("date");
            }

            if (JToken.DeepEquals(aj, ej))
            {
                return true;
            }

            if (aj.Properties().Count() != ej.Properties().Count())
            {
                var ajWins = aj.Properties().Count() > ej.Properties().Count();
                var max = ajWins ? aj : ej;
                var min = ajWins ? ej : aj;
                var leftovers = max.Properties().Select(p => p.Name).Except(min.Properties().Select(p => p.Name)).ToArray();
                throw new InvalidOperationException($"Bad Properties: {string.Join(",",leftovers)}");
            }

            if (aj.ContainsKey("notes"))
            {
                    var _ = aj.Value<JArray>("notes").Cast<JObject>().ToArray().Zip(
                    ej.Value<JArray>("notes").Cast<JObject>().ToArray(),CheckObjectArray).ToArray();
            }

            if (aj.ContainsKey("trail"))
            {
                var _ = aj.Value<JArray>("trail").Cast<JObject>().ToArray().Zip(
                    ej.Value<JArray>("trail").Cast<JObject>().ToArray(), CheckObjectArray).ToArray();
            }

            foreach (var pair in aj.Properties().OrderBy(p => p.Name).ToArray().Zip(ej.Properties().OrderBy(p=> p.Name).ToArray(), (ac, ex) => (ac, ex)))
            {
                if (JToken.DeepEquals(pair.ac, pair.ex))
                {
                    pair.ac.Remove();
                    pair.ex.Remove();
                }
                else
                {
                    Console.WriteLine(pair.ac.Name);
                    Console.WriteLine(pair.ac.Value);
                }
            }

            return !aj.Properties().Any();
        }
    }
}
