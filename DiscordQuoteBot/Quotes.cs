using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiscordQuoteBot
{
    public class Quotes
    {
        public List<string> QuoteList { get; set; }


        public Quotes(string filePath)
        {
            QuoteList = File.ReadAllLines(filePath).ToList();
        }
    }
}