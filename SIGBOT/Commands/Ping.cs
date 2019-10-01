﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace SIGBOT.Commands
{
    class Ping : Command
    {
        public override async Task Execute(DiscordUser user, DiscordMessage message, string[] args)
        {
            await message.RespondAsync("Pong");
        }
    }
}
