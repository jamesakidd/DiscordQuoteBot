using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordQuoteBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong");
        }

        [Command("quote")]
        public async Task Quote([Remainder] string keywords = null)
        {

            var quotes = new Quotes(Path.Combine(Directory.GetCurrentDirectory(), "quotes.txt")).QuoteList;
            var quote = keywords != null ? GetKeywordQuote(quotes, keywords) : GetRandomQuote(quotes);
            await ReplyAsync(quote);
        }

        private static string GetRandomQuote(List<string> quotes)
        {
            return quotes[new Random().Next(quotes.Count)];
        }

        private static string GetKeywordQuote(List<string> quotes, string keywords)
        {
            var matched = quotes.Where(keyword =>
                Regex.IsMatch(keywords, Regex.Escape(keyword), RegexOptions.IgnoreCase)).ToList();

            return matched[new Random().Next(quotes.Count)];
        }
    }
}