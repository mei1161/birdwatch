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
        //Given: ����
        //When: �t�H�����[�ꗗ���擾
        //Then: mei���擾�ł���
        //GWTStyle

        [Test]
        public void �����̃A�J�E���g����t�H�����[�擾�ł���()
        {
            var twiterapi = new twitterApi();
            var followers =twiterapi.GetFollowers();
            Assert.That(followers, Is.SupersetOf(new[] { "@mei" }));
        }
    }
}