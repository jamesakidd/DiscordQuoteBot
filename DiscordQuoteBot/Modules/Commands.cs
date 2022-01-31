using System;
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
        public async Task Quote()
        {
            var quotes = new Quotes(Path.Combine(Directory.GetCurrentDirectory(), "quotes.txt")).QuoteList;
            string message = Context.Message.ToString().Remove(0, 6);
            var matched = quotes.Where(keyword =>
                Regex.IsMatch(message, Regex.Escape(keyword), RegexOptions.IgnoreCase)).ToList();

            int index = new Random().Next(quotes.Count);
            await ReplyAsync(quotes[index]);
        }

    }
}