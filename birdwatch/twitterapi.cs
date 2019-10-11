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
        public IEnumerable<string> GetFollowers(string username);
        public IEnumerable<string> GetFollowList(string username);
    }
    // GoF Adapter pattern
    public class TwitterApi : ITwitterApi
    {
        private readonly Configuration configuration;
        public TwitterApi(Configuration configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<string> GetFollowers(string username)
        {
            var tokens = configuration.CreateTokens();
            var users = tokens.Followers;
            var followers = new List<User>();
            var nextCursor = -1L;
            while (true)
            {
                var list = users.List(username.Replace("@", ""), cursor: nextCursor, count: 200);
                followers.AddRange(list);
                if (list.Count == 0) break;
                nextCursor = list.NextCursor;
            }
            return followers.Select(u => "@" + u.ScreenName);
        }
        public IEnumerable<string> GetFollowList(string username)
        {
            var tokens = configuration.CreateTokens();
            var users = tokens.Friends;
            var followlist = new List<User>();
            var nextCursor = -1L;
            while (true)
            {
                var list = users.List(username.Replace("@", ""), cursor: nextCursor, count: 200);
                followlist.AddRange(list);
                if (list.Count == 0) break;
                nextCursor = list.NextCursor;
            }
            return followlist.Select(u => "@" + u.ScreenName);
        }
        public IEnumerable<Status> GetFavorite(string username)
        {
            var tokens = configuration.CreateTokens();
            var users = tokens.Users;
            var FavoriteList = new List<Status>();
            var nextCursor = -1L;
            while (true)
            {
            }
            return FavoriteList;
        }
    }
}
