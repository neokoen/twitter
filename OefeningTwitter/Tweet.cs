using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningTwitter
{
    [Serializable]
    public class Tweet
    {
        public Tweet()
        {
            this.Tijdstip = DateTime.Now;
        }
        public string Naam
        {get;set;}

        private string BerichtValue;
        public string Bericht
        {
            get
            {
                return BerichtValue;
            }
           
          set
            {
                if (value.Length > 140)
                    throw new Exception("Het bericht is te lang");
              BerichtValue = value;
          }
             
        
        }
        public DateTime Tijdstip
        {get;set;}

        public override string ToString()
           
        {
            StringBuilder tweet = new StringBuilder(this.Naam + ": " + this.Bericht + " :");
            TimeSpan verschil = DateTime.Now - this.Tijdstip;
            if (verschil.Days > 1)
                tweet.Append(this.Tijdstip.ToShortDateString());
            else if (verschil.Hours > 0)
                tweet.Append(verschil.Hours + " uur geleden");
            else if (verschil.Minutes > 0)
                tweet.Append(verschil.Minutes + " minuten geleden");
            else
            {
                tweet.Append(this.Tijdstip.ToShortTimeString());
            }
            return tweet.ToString();

        }


    }
}
