using System;
using CoreTweet;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace birdwatch
{
    public class Configuration
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSercret { get; set; }
        public string AccsessToken { get; set; }
        public string AccsessSercret { get; set; }

        public Configuration(string consumerKey, string consumerSercret, string accsessToken, string accsessSercret)
        {
            this.ConsumerKey = consumerKey;
            this.ConsumerSercret = consumerSercret;
            this.AccsessToken = accsessToken;
            this.AccsessSercret = accsessSercret;
        }
        public Tokens CreateTokens()
        {
            return Tokens.Create(ConsumerKey, ConsumerSercret, AccsessToken, AccsessSercret);
        }

        public Configuration()
        {
        }

        public static Configuration Parse(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Configuration>(json);
        }
    }

    public interface ITwitterApi
    {
        public IEnumerable<string> GetFollowers();
    }
    // GoF Adapter pattern
    public class TwitterApi : ITwitterApi
    {
        private readonly Configuration configuration; 
        public TwitterApi(Configuration configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<string> GetFollowers()
        {
            var tokens = configuration.CreateTokens(); 
            var users = tokens.Followers;
            var followers = new List<User>();
            var nextCursor = -1L;
            while (true)
            {
                var list = users.List("mei_9961", cursor: nextCursor, count: 200);
                followers.AddRange(list);
                if (list.Count == 0) break;
                nextCursor = list.NextCursor;
            }
            return followers.Select(u => "@" + u.ScreenName);
        }
    }
}
