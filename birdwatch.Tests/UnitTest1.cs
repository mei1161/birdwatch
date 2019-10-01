using birdwatch;
using NUnit.Framework;
using System.Linq;
namespace birdwatch.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string i = Program.GetWhen();
            Assert.That(i.Equals("Twitter"));
        }
    }
}