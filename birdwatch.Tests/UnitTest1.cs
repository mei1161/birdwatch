using birdwatch;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace birdwatch.Tests
{
    public class MockTwitterApi :ITwitterApi
    {
        public IEnumerable<string> GetFollowers(string username)
        {
            yield return "@mei";
        }
    }

    public class Tests
    {
        [Test]
        public void 指定したアカウントからフォロワー取得できる()
        {
            var username = "@mei_1161";
            var twiterapi = new MockTwitterApi();
            var followers =twiterapi.GetFollowers(username);
            Assert.That(followers, Is.SupersetOf(new[] { "@mei" }));
        }

        [Test]
        public void 実際のAPIでmeiのアカウントを指定してフォロワーを取得するとayaが取得できる()
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json"); 
            var twitterApi = new TwitterApi(configuration);
            var followers = twitterApi.GetFollowers("@mei_9961");
            Assert.That(followers, Is.SupersetOf(new[] { "@nectarim" }));
        }

        [Test]
        public void 実際のAPIでayaのアカウントを指定してフォロワーを取得するとmeiが取得できる()
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json"); 
            var twitterApi = new TwitterApi(configuration);
            var followers = twitterApi.GetFollowers("@nectarim");
            Assert.That(followers, Is.SupersetOf(new[] { "@mei_9961" }));
        }

    }
}
