using birdwatch;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
namespace birdwatch.Tests
{
    public class twitterApi
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
            var twiterapi = new twitterApi();
            var followers =twiterapi.GetFollowers();
            Assert.That(followers, Is.SupersetOf(new[] { "@mei" }));
        }
    }
}