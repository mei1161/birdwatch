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
        public IEnumerable<string> GetFollowers()
        {
            yield return "@mei";
        }
    }

    public class Tests
    {
        //Given: 自分
        //When: フォロワー一覧を取得
        //Then: meiを取得できる
        //GWTStyle

        [Test]
        public void 自分のアカウントからフォロワー取得できる()
        {
            var twiterapi = new MockTwitterApi();
            var followers =twiterapi.GetFollowers();
            Assert.That(followers, Is.SupersetOf(new[] { "@mei" }));
        }

        [Test]
        public void 実際のAPIでmeiのアカウントを指定してフォロワーを取得するとayaが取得できる()
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json"); 
            var twitterApi = new TwitterApi(configuration);
            var followers = twitterApi.GetFollowers();
            Assert.That(followers, Is.SupersetOf(new[] { "@nectarim" }));
        }

    }
}
