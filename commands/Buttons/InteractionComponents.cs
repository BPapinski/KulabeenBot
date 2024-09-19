using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChwesiukBotV2.commands.Buttons
{
    class InteractionComponents : BaseCommandModule
    {
        [Command("help")]
        public async Task HelpCommand(CommandContext ctx)
        {
            var basicsButton = new DiscordButtonComponent(ButtonStyle.Primary, "basicsButton", "Basics");
            var calculatorButton = new DiscordButtonComponent(ButtonStyle.Success, "calculatorButton", "Calculator");

            var message = new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithTitle("Help section")
                        .WithColor(DiscordColor.Black)
                        .WithDescription("Please press a button to view its commands")
                )
                .AddComponents(basicsButton, calculatorButton);

            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
