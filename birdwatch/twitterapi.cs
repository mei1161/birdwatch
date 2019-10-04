using System;
using System.Collections.Generic;
using System.Text;

namespace birdwatch
{
    public interface ITwitterApi
    {
        public IEnumerable<string> GetFollowers();
    }
}
