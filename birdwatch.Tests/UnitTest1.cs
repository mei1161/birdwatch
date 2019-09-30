using birdwatch;
using NUnit.Framework;
using System.Linq;
namespace birdwatch.Tests
{
    public class Tests
    {
        [Test]
        public void iequal0()
        {
         var i=Program.GetNum();
         Assert.That(i==0);
        }
    }
}