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
            var favoritelist = twitterApi.GetFavorite("@mei_9961");
            if (args[0].Equals("birdwatch"))
            {
                foreach (var name in followers)
                {
                    Console.WriteLine(name);
                }
            }
            else
            {
                Console.WriteLine("Followlist");
                var followlist = twitterApi.GetFollowList("@nectarim");
                foreach (var name in followlist)
                {
                    Console.WriteLine(name);
                }
            }
            //取得したツイートの内容表示
            foreach(var value in favoritelist)
            {
                var count = value.FavoriteCount;
                var text = value.Text;
                Console.WriteLine(count);
                Console.WriteLine(text);

            }

        }
    } 


}
