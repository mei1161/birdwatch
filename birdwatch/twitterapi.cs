using System;
using CoreTweet;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace birdwatch
{
    public interface ITwitterApi
    {
        public IEnumerable<string> GetFollowers();
    }
    public class TwitterApi : ITwitterApi
    {
        public IEnumerable<string> GetFollowers()
        {
            var tokens = Tokens.Create("", "", "", "");

            var users = tokens.Followers;

            var followers = new List<User>();

            var nextCursor = -1L;

            while(true)
            {

            }

            
        }
    }
}
