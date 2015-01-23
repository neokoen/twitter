using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningTwitter
{
    [Serializable]
    public class Tweets
    {
        private List<Tweet> alleTweetsValue;
        public ReadOnlyCollection <Tweet> AlleTweets()
        {

            return new ReadOnlyCollection <Tweet>(alleTweetsValue);

        }
        public void Addtweet (Tweet tweet)
        {
            if (alleTweetsValue == null)
                alleTweetsValue = new List<Tweet>();
            alleTweetsValue.Add(tweet);

        }
    }
}
