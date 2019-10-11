using System;
using System.Collections.Generic;
namespace birdwatch
{
    public class Account
    {
        static void Main(string[] args)
        {
            var configuration = Configuration.Parse(@"conf\birdwatch.json");//設定ファイルを取得 
            var twitterApi = new TwitterApi(configuration);//ツイッターAPI生成
            var followers = twitterApi.GetFollowers("@nectarim");
            foreach(var name in followers)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Followlist");
            var followlist = twitterApi.GetFollowList("@nectarim");
            foreach(var name in followlist)
            {
                Console.WriteLine(name);
            }
        }
    } 


}
