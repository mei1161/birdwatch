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
        public IEnumerable<string> GetFollowList(string username)
        {
            yield return "@mei";
        }
        public IEnumerable<string> GetFavorite(string username)
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
            var followers = twiterapi.GetFollowers(username);
            Assert.That(followers, Is.SupersetOf(new[] { "@mei" }));
        }

        [Test, Explicit]
        public void 実際のAPIでmeiのアカウントを指定してフォロワーを取得するとayaが取得できる()
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json");
            var twitterApi = new TwitterApi(configuration);
            var followers = twitterApi.GetFollowers("@mei_9961");
            Assert.That(followers, Is.SupersetOf(new[] { "@nectarim" }));
        }

        [Test, Explicit]
        public void 実際のAPIでayaのアカウントを指定してフォロワーを取得するとmeiが取得できる()
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json");
            var twitterApi = new TwitterApi(configuration);
            var followers = twitterApi.GetFollowers("@nectarim");
            Assert.That(followers, Is.SupersetOf(new[] { "@mei_9961" }));
        }
        [Test]
        public void 指定したアカウントからフォローリストを取得できる()
        {
            var username = "@mei_1161";
            var twiterapi = new MockTwitterApi();
            var followlist = twiterapi.GetFollowList(username);
            Assert.That(followlist, Is.SupersetOf(new[] { "@mei" }));
        }
        [Test, Explicit]
        public void 実際のAPIでayaのアカウントを指定してフォローリストを取得するとmeiが取得できる()
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json");
            var twitterApi = new TwitterApi(configuration);
            var followlist = twitterApi.GetFollowList("@nectarim");
            Assert.That(followlist, Is.SupersetOf(new[] { "@mei_9961" }));
        }
        [Test] 
        public void 指定したアカウントのお気に入りしたツイートを取得()
        {
            var username = "@mei_9961";
            var twitterApi = new MockTwitterApi();
            var favorite = twitterApi.GetFavorite(username);
            Assert.That(favorite, Is.SupersetOf(new[] { "@mei" }));

        }

        [Test,Explicit]
        public void 実際のAPIを使って指定したアカウントのお気に入り下ツイート5件を取得()
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json");
            var tokens = configuration.CreateTokens();
            var FavoriteList = tokens.Favorites.List(screen_name: "@mei_9961", count: 5);
            Assert.That(FavoriteList.ToList(), Has.Count.EqualTo(5));
        }


    }
}
