using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace OefeningTwitter
{
    public class Twitter
    {
        const string twitterbestand = @"C:Data\Twitter.obj";
        public List<Tweet> AlleTweets()
        {
            if (File.Exists(twitterbestand))
            {
                var tweets = LeesTweets();
                return tweets.AlleTweets().OrderByDescending(t => t.Tijdstip).ToList();
            }
            else
            {
                throw new Exception("Het bestand " + twitterbestand + "is niet gevonden");
            }
        }

        public List<Tweet> TweetsVan(string naam)
        {
            return AlleTweets().Where(t => t.Naam.ToUpper() == naam.ToUpper()).ToList();

        }

        public void SchrijfTweet (Tweet tweet)
        {
            Tweets tweets;
            if (File.Exists(twitterbestand))
            { tweets = LeesTweets();
            }

            else
            {
                tweets = new Tweets();

            }

            tweets.Addtweet(tweet);
            SchrijfTweets(tweets);

        }

        private Tweets LeesTweets()
        {
            try
            {
                using (var bestand = File.Open(twitterbestand,FileMode.Open, FileAccess.Read))
                {
                    var lezer = new BinaryFormatter();
                    return ((Tweets)lezer.Deserialize(bestand));

                }
            }
            catch (IOException)
            {
                throw new Exception("Fout bij het openen van het bestand");
            }
            catch(SerializationException)
            {
                throw new Exception("Fout bij het deserialiseren, het twitterbestand kan niet meer geopend worden");

            }
            catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
          }


        private void SchrijfTweets (Tweets tweets)
        {
            try
            {
                using (var bestand = File.Open(twitterbestand, FileMode.OpenOrCreate))
                { 
                var schrijver = new BinaryFormatter();
                schrijver.Serialize(bestand, tweets);
                }

             }
            catch (IOException)
            { throw new Exception("Fout bij het openen van het bestand");
            }
            catch (SerializationException)
            { throw new Exception("Fout bij het serialiseren"); 
            }
            catch (Exception ex)
            { throw new Exception(ex.Message);
            }
        }

    }
}
