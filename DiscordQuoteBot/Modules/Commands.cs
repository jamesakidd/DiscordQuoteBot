﻿using System.Threading.Tasks;
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
    }
}