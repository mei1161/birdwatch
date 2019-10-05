using System;
using System.Collections.Generic;
namespace birdwatch
{
    public class Account
    {
        static void Main(string[] args)
        {

            var configuration = Configuration.Parse(@"conf\birdwatch.json"); 
            var twitterApi = new TwitterApi(configuration);
            var followers = twitterApi.GetFollowers("@nectarim");
            foreach(var i in followers)
            {
                Console.WriteLine(i);
            }
        }
    } 


}
